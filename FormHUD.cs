using aionHUD.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aionHUD
{
    public partial class aionHUD : Form
    {

        private bool mouseDown;
        private Point lastLocation;

        const int PROCESS_WM_READ = 0x0010;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_OPERATION = 0x0008;
        const int PROCESS_WM_ALL = 0x001F0FFF;

        public int GlobalLoopSpeed = 200;


        Process[] processes;
        Thread MemReadThread;


        public Stopwatch ExpTimer = new Stopwatch();
        public Stopwatch APTimer = new Stopwatch();

        public long StartingEXP = 0;
        public long StartingAP = 0;
        public long RefreshedEXP = 0;
        public long RefreshedAP = 0;

        public long currentAP = 0;
        public long currentEXP = 0;

        public long MaximumEXPToLevel = 0;
        public long EXPToLevel = 0;
        double EXPperSecond = 0;
        public double APperSecond = 0;
        public long EXPGained = 0;
        public long APGained = 0;
        public long EXPOverall = 0;
        public long APOverall = 0;

        public float CurrentScale = 1;

        int[] APBrackets = new int[] {
            800700, 
            721600, 
            643200, 
            565400, 
            488200,
            411700,
            344500,
            278700,
            214100,
            150800,
            105600,
            69700,
            42780,
            23500,
            10990,
            4220,
            1200,
            0,

        };
        string[] APBracketsNames = new string[] {
            "Governor",
            "Commander",
            "Great General",
            "General",
            "5-Star Officer",
            "4-Star Officer",
            "3-Star Officer",
            "2-Star Officer",
            "1-Star Officer",
            "Soldier, Rank 1",
            "Soldier, Rank 2",
            "Soldier, Rank 3",
            "Soldier, Rank 4",
            "Soldier, Rank 5",
            "Soldier, Rank 6",
            "Soldier, Rank 7",
            "Soldier, Rank 8",
            "Soldier, Rank 9",

        };
        object[] labelsToScale = new object[]
            { };

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        static extern bool ReadProcessMemory(IntPtr hProcess,
        IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

        public aionHUD()
        {
            InitializeComponent();
            labelsToScale = new object[]{ 
                label,
                label1,
                label10,
                label11,
                label12,
                label13,
                label14,
                label15,
                label19,
                label2,
                label21,
                label23,
                label3,
                label4,
                labelAPgained,
                labelAPnH,
                labelAPOverall,
                labelCurrentAP,
                labelCurrentRank,
                labelEXP,
                labelEXPGained,
                labelEXPOverall,
                labelEXPpH,
                labelTimeToLevel,
                labelTTRU,
                label5,
            };

        }

        private void aionHUD_Load(object sender, EventArgs e)
        {

            if (Settings.Default.HUD_position != null)
            {
                this.Location = Settings.Default.HUD_position;
                this.Update();
            }
            if (Settings.Default.ScalePercent != 0)
            {
                ScaleUI(Settings.Default.ScalePercent);
            }
            if (Settings.Default.BackgroundColor != null)
            {
                panelBG.BackColor = Settings.Default.BackgroundColor;
                textBoxHUDConsole.BackColor = Settings.Default.BackgroundColor;
                if(Settings.Default.BackgroundColor == Color.White)
                {
                    foreach (Label _label in labelsToScale)
                    {
                        _label.ForeColor = Color.Black;

                    }
                    textBoxHUDConsole.ForeColor = Color.Black;
                }
                else
                {
                    foreach (Label _label in labelsToScale)
                    {
                        _label.ForeColor = Color.White;

                    }
                    textBoxHUDConsole.ForeColor = Color.White;
                }
            }

            processes = Process.GetProcessesByName("Aion.bin");
            if(processes.Length==0)
            {
                MessageBox.Show("Game client not found. Start game first then HUD.");
                Application.Exit();
            }else if(processes.Length == 1)
            {
                
                MemReadThread = new Thread(new ParameterizedThreadStart(MemReadThreadFunction));
                MemReadThread.Start();
            }else
            {
               
            }



        }

        private void MemReadThreadFunction(object args)
        {
            Process gameProcess = processes[0];
            IntPtr gamedllAddress = FindModuleByName(gameProcess, "Game.dll");
            IntPtr processHandle = OpenProcess(PROCESS_WM_READ, false, gameProcess.Id);

            StartingEXP = ReadCurrentExpFromMem(processHandle, gamedllAddress);
            RefreshedEXP = StartingEXP;
            ExpTimer.Restart();
            APTimer.Restart();

            StartingAP = ReadAPFromMem(processHandle, gamedllAddress);
            RefreshedAP = StartingAP;

            WriteLabelFromThread(labelCurrentRank, GetCurrentRankName(RefreshedAP));

            var nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = " ";
            TimeSpan tsEXP;

            while (true)
            {
                currentAP = ReadAPFromMem(processHandle, gamedllAddress);
                currentEXP = ReadCurrentExpFromMem(processHandle, gamedllAddress);
                MaximumEXPToLevel = ReadMaxExpFromMem(processHandle, gamedllAddress);
                WriteLabelFromThread(labelEXP, currentEXP.ToString("#,0", nfi) + " /" + MaximumEXPToLevel.ToString("#,0", nfi));
                WriteLabelFromThread(labelCurrentAP, currentAP.ToString("#,0", nfi));

                EXPOverall = currentEXP - StartingEXP;
                tsEXP = ExpTimer.Elapsed;
                EXPperSecond = EXPOverall / tsEXP.TotalSeconds;

                WriteLabelFromThread(labelEXPOverall,EXPOverall.ToString("#,0", nfi));

                if (currentEXP != RefreshedEXP)
                {
                    WriteLabelFromThread(labelEXPpH,Convert.ToInt32(EXPperSecond * 60 * 60).ToString("#,0", nfi));
                    if (EXPperSecond > 0)
                    {
                        TimeSpan t = TimeSpan.FromSeconds((MaximumEXPToLevel - RefreshedEXP) / EXPperSecond);

                        string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                                        t.Hours,
                                        t.Minutes,
                                        t.Seconds);
                        WriteLabelFromThread(labelTimeToLevel,answer);
                    }
                }
                if (currentEXP > RefreshedEXP)
                {
                    EXPGained = EXPGained + (currentEXP - RefreshedEXP);
                    WriteLabelFromThread(labelEXPGained, EXPGained.ToString("#,0", nfi));
                    WriteConsoleThread("EXP +" + (currentEXP - RefreshedEXP).ToString("#,0", nfi));
                    RefreshedEXP = currentEXP;
                }
                else if (currentEXP < RefreshedEXP)
                {
                    WriteConsoleThread("EXP -" + (RefreshedEXP - currentEXP).ToString("#,0", nfi));
                    RefreshedEXP = currentEXP;
                }

                APOverall = currentAP - StartingAP;
                TimeSpan tsAP = APTimer.Elapsed;
                APperSecond = APOverall / tsAP.TotalSeconds;
                if (currentAP != RefreshedAP)
                {
                    WriteLabelFromThread(labelAPnH,Convert.ToInt32(APperSecond * 60 * 60).ToString("#,0", nfi));
                    WriteLabelFromThread(labelAPOverall,APOverall.ToString("#,0", nfi));
                    WriteLabelFromThread(labelCurrentRank, GetCurrentRankName(RefreshedAP));
                    long APToRankUp = GetNextRankAP(RefreshedAP);
                    if (APperSecond > 0 && APToRankUp >=0)
                    {
                        TimeSpan t = TimeSpan.FromSeconds((APToRankUp - RefreshedAP) / APperSecond);

                        string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                                        t.Hours,
                                        t.Minutes,
                                        t.Seconds);
                        WriteLabelFromThread(labelTTRU, answer);
                    }
                }


                if (currentAP > RefreshedAP)
                {
                    APGained = APGained + (currentAP - RefreshedAP);
                    WriteLabelFromThread(labelAPgained, APGained.ToString("#,0", nfi));
                    WriteConsoleThread("AP +" + (currentAP - RefreshedAP).ToString("#,0", nfi));
                    RefreshedAP = currentAP;
                }
                else if (currentAP < RefreshedAP)
                {
                    WriteConsoleThread("AP -" + (RefreshedAP - currentAP).ToString("#,0", nfi));
                    RefreshedAP = currentAP;
                }

                Thread.Sleep(GlobalLoopSpeed);
            }
        }


        int GetNextRankAP(long currentAP)
        {
            for(int i=1; i<APBrackets.Length; i++)
            {
                if(APBrackets[i]<=currentAP)
                {
                    return APBrackets[i-1];
                }
            }
            return -1;
        }

        string GetCurrentRankName(long currentAP)
        {
            for (int i = 0; i < APBrackets.Length; i++)
            {
                if (APBrackets[i] <= currentAP)
                {
                    return APBracketsNames[i];
                }
            }
            return "";
        }

        IntPtr FindModuleByName(Process process, string name)
        {
            foreach (ProcessModule m in process.Modules)
            {
                if (m.ModuleName == name)
                {
                    return m.BaseAddress;
                }

            }
            return (IntPtr)0;
        }

        private void WriteLabelFromThread(Label label, String text)
        {

            MethodInvoker invoker = new MethodInvoker(delegate { label.Text = text; });
            if (InvokeRequired)
                label.Invoke(invoker);
        }
        private void WriteConsoleThread(String text)
        {

            MethodInvoker invoker = new MethodInvoker(delegate { textBoxHUDConsole.AppendText(DateTime.Now.ToString() + ": " + text + Environment.NewLine); });
            if (InvokeRequired)
                textBoxHUDConsole.Invoke(invoker);
        }
        private void WriteConsole(String text)
        {

            textBoxHUDConsole.AppendText(DateTime.Now.ToString() + ": " + text + Environment.NewLine);
            
        }

        long ReadCurrentExpFromMem(IntPtr processHandle, IntPtr gamedllAddress)
        {
            long value = 0;
            IntPtr bytesRead;
            byte[] buffer = new byte[4];

            //Read HP
            ReadProcessMemory(processHandle, gamedllAddress + 0xC8A700, buffer, buffer.Length, out bytesRead);
            value = BitConverter.ToInt32(buffer, 0);
            return value;
        }
        long ReadMaxExpFromMem(IntPtr processHandle, IntPtr gamedllAddress)
        {
            long value = 0;
            IntPtr bytesRead;
            byte[] buffer = new byte[4];

            //Read HP
            ReadProcessMemory(processHandle, gamedllAddress + 0xC8A6F0, buffer, buffer.Length, out bytesRead);
            value = BitConverter.ToInt32(buffer, 0);
            return value;
        }
        long ReadAPFromMem(IntPtr processHandle, IntPtr gamedllAddress)
        {
            long value = 0;
            IntPtr bytesRead;
            byte[] buffer = new byte[4];

            //Read MP
            ReadProcessMemory(processHandle, gamedllAddress + 0xC87F20, buffer, buffer.Length, out bytesRead);
            value = BitConverter.ToInt32(buffer, 0);
            return value;
        }

        private void panelMove_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMove_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panelMove_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            Settings.Default.HUD_position = Location;
            Settings.Default.Save();
        }

        private void panelMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (MemReadThread != null)
                MemReadThread.Abort();
            Application.Exit();
            
        }

        private void aionHUD_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MemReadThread != null)
                MemReadThread.Abort();
        }

        private void buttonResetExpCounter_Click(object sender, EventArgs e)
        {
            ExpTimer.Restart();
            StartingEXP = currentEXP;
            RefreshedEXP = currentEXP;
            EXPGained = 0;
            labelEXPOverall.Text = "0";
            labelEXPGained.Text = "0";
            labelEXPpH.Text = "0";
            labelTimeToLevel.Text = "0";

            WriteConsole("Experience points data reseted.");
        }

        private void buttonResetAP_Click(object sender, EventArgs e)
        {
            APTimer.Restart();
            StartingAP = currentAP;
            RefreshedAP = currentAP;
            APGained = 0;
            labelAPOverall.Text = "0";
            labelAPgained.Text = "0";
            labelAPnH.Text = "0";
            labelTTRU.Text = "0";

            WriteConsole("Abyss points data reseted.");
        }

        private void toolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            if (MemReadThread != null)
                MemReadThread.Abort();
            Application.Exit();
        }

        void ScaleUI(int percent)
        {

            
            float scaleValue = percent/100.0f;

            SizeF scaleFactor = new SizeF(scaleValue / CurrentScale, scaleValue / CurrentScale);
            Scale(scaleFactor);

            foreach (Label _label in labelsToScale)
            {
                _label.Font = new Font("Arial", (percent/10)-1, FontStyle.Regular);
                
            }
            textBoxHUDConsole.Font = new Font("Arial", (percent / 10) - 1, FontStyle.Regular);

            CurrentScale = scaleValue;
            Settings.Default.ScalePercent = percent;
            Settings.Default.Save();
            


        }


        private void toolStripMenuItemResize100_Click(object sender, EventArgs e)
        {

            ScaleUI(100);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ScaleUI(125);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ScaleUI(200);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ScaleUI(150);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ScaleUI(175);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            ScaleUI(75);
        }

        private void toolStripMenuItemresize110_Click(object sender, EventArgs e)
        {
            ScaleUI(110);
        }

        private void yesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelBG.BackColor = Color.DarkGray;
            textBoxHUDConsole.BackColor = Color.DarkGray;
            Settings.Default.BackgroundColor = Color.DarkGray;
            Settings.Default.Save();
            foreach (Label _label in labelsToScale)
            {
                _label.ForeColor = Color.White;

            }
            textBoxHUDConsole.ForeColor = Color.White;
        }

        private void noToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelBG.BackColor = Color.Black;
            textBoxHUDConsole.BackColor = Color.Black;
            Settings.Default.BackgroundColor = Color.Black;
            Settings.Default.Save();
            foreach (Label _label in labelsToScale)
            {
                _label.ForeColor = Color.White;

            }
            textBoxHUDConsole.ForeColor = Color.White;
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelBG.BackColor = Color.White;
            textBoxHUDConsole.BackColor = Color.White;
            Settings.Default.BackgroundColor = Color.White;
            Settings.Default.Save();
            foreach (Label _label in labelsToScale)
            {
                _label.ForeColor = Color.Black;

            }
            textBoxHUDConsole.ForeColor = Color.Black;



           
        }
    }
}
