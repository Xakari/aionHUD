using aionHUD.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace aionHUD
{
    public partial class aionHUD : Form
    {
        private bool mouseDown;
        private Point lastLocation;

        private const int PROCESS_WM_READ = 0x0010;

        private FormHoverWindow formHoverInfo;

        public int GlobalLoopSpeed = 200;

        private Process[] processes;
        private Thread MemReadThread;

        public Stopwatch ExpTimer = new Stopwatch();
        public Stopwatch APTimer = new Stopwatch();

        public Stopwatch ConsoleTimer = new Stopwatch();

        public long StartingEXP = 0;
        public long StartingAP = 0;
        public long RefreshedEXP = 0;
        public long RefreshedAP = 0;

        public long currentAP = 0;
        public long currentEXP = 0;

        public long MaximumEXPToLevel = 0;
        public long EXPToLevel = 0;
        private double EXPperSecond = 0;
        public double APperSecond = 0;
        public long EXPGained = 0;
        public long APGained = 0;
        public long EXPOverall = 0;
        public long APOverall = 0;

        public float CurrentScale = 1;

        private string[] ConsoleData = new string[] { };
        private int currentLine = 0;

        private int[] APBrackets = new int[] {
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

        private string[] APBracketsNames = new string[] {
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

        private object[] labelsToScale = new object[]
            { };

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(IntPtr hProcess,
        IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

        [DllImport("user32.dll")]
        internal static extern int GetScrollPos(IntPtr hWnd, int nBar);

        [DllImport("user32.dll")]
        internal static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

        [DllImport("user32.dll")]
        internal static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        public enum ScrollbarDirection
        {
            Horizontal = 0,
            Vertical = 1,
        }

        private enum Messages
        {
            WM_HSCROLL = 0x0114,
            WM_VSCROLL = 0x0115
        }

        public aionHUD()
        {
            InitializeComponent();
            labelsToScale = new object[]{
                label,
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
                label1,
            };

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(AppDomain_UnhandledException);

            // Unhandled exceptions for the executing UI thread
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
        }

        public static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString());
        }

        /// <summary>
        /// Application domain exception handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        public static void AppDomain_UnhandledException(object sender, System.UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.ExceptionObject.ToString());
        }

        private void aionHUD_Load(object sender, EventArgs e)
        {
            formHoverInfo = new FormHoverWindow();
            formHoverInfo.Show();

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
                if (Settings.Default.BackgroundColor == Color.White)
                {
                    MakeHUDWhite();
                }
                else if (Settings.Default.BackgroundColor == Color.Black)
                {
                    MakeHUDBlack();
                }
                else
                {
                    MakeHUDTransparent();
                }
            }
            if (Settings.Default.BrokerChecked)
            {
                yesToolStripMenuItem.Checked = true;
                noToolStripMenuItem.Checked = false;
            }
            else
            {
                yesToolStripMenuItem.Checked = false;
                noToolStripMenuItem.Checked = true;
            }

            processes = Process.GetProcessesByName("Aion.bin");
            if (processes.Length == 0)
            {
                MessageBox.Show("Game client not found. Start game first then HUD.");
                Application.Exit();
            }
            else if (processes.Length == 1)
            {
                MemReadThread = new Thread(new ParameterizedThreadStart(MemReadThreadFunction));
                MemReadThread.Start();
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
            long itemID = 0;

            long tempItemID = 0;

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

                WriteLabelFromThread(labelEXPOverall, EXPOverall.ToString("#,0", nfi));

                if (currentEXP != RefreshedEXP)
                {
                    WriteLabelFromThread(labelEXPpH, Convert.ToInt32(EXPperSecond * 60 * 60).ToString("#,0", nfi));
                    if (EXPperSecond > 0)
                    {
                        TimeSpan t = TimeSpan.FromSeconds((MaximumEXPToLevel - RefreshedEXP) / EXPperSecond);

                        string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                                        t.Hours,
                                        t.Minutes,
                                        t.Seconds);
                        WriteLabelFromThread(labelTimeToLevel, answer);
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
                    WriteLabelFromThread(labelAPnH, Convert.ToInt32(APperSecond * 60 * 60).ToString("#,0", nfi));
                    WriteLabelFromThread(labelAPOverall, APOverall.ToString("#,0", nfi));
                    WriteLabelFromThread(labelCurrentRank, GetCurrentRankName(RefreshedAP));
                    long APToRankUp = GetNextRankAP(RefreshedAP);
                    if (APperSecond > 0 && APToRankUp >= 0)
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

                if (ConsoleTimer.ElapsedMilliseconds > 10000)
                {
                    ConsoleTimer.Stop();
                    WriteConsoleThreadMoveToEnd();
                }

                //ItemHover
                itemID = ReadItemIDFromMem(processHandle, gamedllAddress);

                if (itemID > 100000000 && itemID <= 200000000 && yesToolStripMenuItem.Checked)
                {
                    if (tempItemID != itemID)
                    {
                        DataTable dTable = ReadItemFromDB(itemID);
                        if (dTable.Rows.Count != 0)
                        {
                            WriteLabelFromThread(formHoverInfo.labelLastUpdate, dTable.Rows[0]["update_time"].ToString());
                            WriteLabelFromThread(formHoverInfo.labelNPCSellPrice, ((int)dTable.Rows[0]["price"] / 20).ToString("#,0", nfi));

                            foreach (DataRow dr in dTable.Rows)
                            {
                                if ((int)dr["market_price"] != 0)
                                {
                                    if (dTable.Rows.IndexOf(dr) != 0)
                                    {
                                        WriteLabelFromThread(formHoverInfo.labelMarketPrice, "not posted, last known: " + Convert.ToInt32(dr["market_price"]).ToString("#,0", nfi));
                                    }
                                    else
                                    {
                                        WriteLabelFromThread(formHoverInfo.labelMarketPrice, Convert.ToInt32(dr["market_price"]).ToString("#,0", nfi));
                                    }
                                    break;
                                }
                            }

                            UpdateHoverLocationFromThread(Cursor.Position);

                            UpdateHoverVisibilityFromThread(true);
                            tempItemID = itemID;
                        }
                        else
                        {
                            tempItemID = itemID;
                            UpdateHoverVisibilityFromThread(false);
                            WriteLabelFromThread(formHoverInfo.labelLastUpdate, "no data");
                            WriteLabelFromThread(formHoverInfo.labelNPCSellPrice, "no data");
                            WriteLabelFromThread(formHoverInfo.labelMarketPrice, "no data");
                        }
                    }
                }
                else
                {
                    UpdateHoverVisibilityFromThread(false);
                    tempItemID = 0;
                }

                Thread.Sleep(GlobalLoopSpeed);
            }
        }

        private int GetNextRankAP(long currentAP)
        {
            for (int i = 1; i < APBrackets.Length; i++)
            {
                if (APBrackets[i] <= currentAP)
                {
                    return APBrackets[i - 1];
                }
            }
            return -1;
        }

        private string GetCurrentRankName(long currentAP)
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

        private IntPtr FindModuleByName(Process process, string name)
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

        private void WriteLabelFromThread(Label label, string text)
        {
            MethodInvoker invoker = new MethodInvoker(delegate { label.Text = text; });
            if (InvokeRequired)
                label.Invoke(invoker);
        }

        private void UpdateHoverLocationFromThread(Point location)
        {
            MethodInvoker invoker = new MethodInvoker(delegate
            {
                formHoverInfo.Location = location;
                formHoverInfo.Update();
            });
            if (InvokeRequired)
                formHoverInfo.Invoke(invoker);
        }

        private void UpdateHoverVisibilityFromThread(bool visible)
        {
            MethodInvoker invoker = new MethodInvoker(delegate
            {
                formHoverInfo.Visible = visible;
            });
            if (InvokeRequired)
                formHoverInfo.Invoke(invoker);
        }

        private void WriteConsoleThread(string text)
        {
            MethodInvoker invoker = new MethodInvoker(delegate { textBoxHUDConsole.Lines = ConsoleData; textBoxHUDConsole.AppendText(Environment.NewLine + DateTime.Now.ToString("HH:mm:ss") + ": " + text); ConsoleData = textBoxHUDConsole.Lines; currentLine = ConsoleData.Length; });
            if (InvokeRequired)
                textBoxHUDConsole.Invoke(invoker);
        }

        private void WriteConsoleThreadMoveToEnd()
        {
            MethodInvoker invoker = new MethodInvoker(delegate
            {
                textBoxHUDConsole.Lines = ConsoleData;
                currentLine = ConsoleData.Length;
                textBoxHUDConsole.SelectionStart = textBoxHUDConsole.Text.Length;
                textBoxHUDConsole.ScrollToCaret();
            });
            if (InvokeRequired)
                textBoxHUDConsole.Invoke(invoker);
        }

        private void WriteConsole(string text)
        {
            textBoxHUDConsole.Lines = ConsoleData;
            textBoxHUDConsole.AppendText(Environment.NewLine + DateTime.Now.ToString("HH:mm:ss") + ": " + text);
            ConsoleData = textBoxHUDConsole.Lines;
            currentLine = ConsoleData.Length;
        }

        private long ReadCurrentExpFromMem(IntPtr processHandle, IntPtr gamedllAddress)
        {
            long value = 0;
            IntPtr bytesRead;
            byte[] buffer = new byte[4];

            //Read HP
            ReadProcessMemory(processHandle, gamedllAddress + 0xC8DA10 + 16, buffer, buffer.Length, out bytesRead);
            value = BitConverter.ToInt32(buffer, 0);
            return value;
        }

        private long ReadMaxExpFromMem(IntPtr processHandle, IntPtr gamedllAddress)
        {
            long value = 0;
            IntPtr bytesRead;
            byte[] buffer = new byte[4];

            //Read HP
            ReadProcessMemory(processHandle, gamedllAddress + 0xC8DA10, buffer, buffer.Length, out bytesRead);
            value = BitConverter.ToInt32(buffer, 0);
            return value;
        }

        private long ReadAPFromMem(IntPtr processHandle, IntPtr gamedllAddress)
        {
            long value = 0;
            IntPtr bytesRead;
            byte[] buffer = new byte[4];

            //Read MP
            ReadProcessMemory(processHandle, gamedllAddress + 0xC8B240, buffer, buffer.Length, out bytesRead);
            value = BitConverter.ToInt32(buffer, 0);
            return value;
        }

        private long ReadItemIDFromMem(IntPtr processHandle, IntPtr gamedllAddress)
        {
            long value = 0;
            IntPtr bytesRead;
            byte[] buffer = new byte[4];

            //Read MP
            ReadProcessMemory(processHandle, gamedllAddress + 0x8730C8, buffer, buffer.Length, out bytesRead);
            value = BitConverter.ToInt32(buffer, 0);
            return value;
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

        public static int GetScrollPosition(IntPtr hWnd, ScrollbarDirection direction)
        {
            return GetScrollPos(hWnd, (int)direction);
        }

        public static void GetScrollPosition(IntPtr hWnd, out int horizontalPosition, out int verticalPosition)
        {
            horizontalPosition = GetScrollPos(hWnd, (int)ScrollbarDirection.Horizontal);
            verticalPosition = GetScrollPos(hWnd, (int)ScrollbarDirection.Vertical);
        }

        public static void SetScrollPosition(IntPtr hwnd, int hozizontalPosition, int verticalPosition)
        {
            SetScrollPosition(hwnd, ScrollbarDirection.Horizontal, hozizontalPosition);
            SetScrollPosition(hwnd, ScrollbarDirection.Vertical, verticalPosition);
        }

        public static void SetScrollPosition(IntPtr hwnd, ScrollbarDirection direction, int position)
        {
            //move the scroll bar
            SetScrollPos(hwnd, (int)direction, position, true);

            //convert the position to the windows message equivalent
            IntPtr msgPosition = new IntPtr((position << 16) + 4);
            Messages msg = (direction == ScrollbarDirection.Horizontal) ? Messages.WM_HSCROLL : Messages.WM_VSCROLL;
            SendMessage(hwnd, (int)msg, msgPosition, IntPtr.Zero);
        }

        private void ScaleUI(int percent)
        {
            if (percent == 75) toolStripMenuItemResize75.Checked = true; else toolStripMenuItemResize75.Checked = false;
            if (percent == 100) toolStripMenuItemResize100.Checked = true; else toolStripMenuItemResize100.Checked = false;
            if (percent == 110) toolStripMenuItemResize110.Checked = true; else toolStripMenuItemResize110.Checked = false;
            if (percent == 125) toolStripMenuItemResize125.Checked = true; else toolStripMenuItemResize125.Checked = false;
            if (percent == 150) toolStripMenuItemResize150.Checked = true; else toolStripMenuItemResize150.Checked = false;
            if (percent == 175) toolStripMenuItemResize175.Checked = true; else toolStripMenuItemResize175.Checked = false;
            if (percent == 200) toolStripMenuItemResize200.Checked = true; else toolStripMenuItemResize200.Checked = false;

            float scaleValue = percent / 100.0f;

            SizeF scaleFactor = new SizeF(scaleValue / CurrentScale, scaleValue / CurrentScale);
            Scale(scaleFactor);

            foreach (Label _label in labelsToScale)
            {
                _label.Font = new Font("Arial", (percent / 10) - 1, FontStyle.Regular);
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
            MakeHUDTransparent();
        }

        private void MakeHUDTransparent()
        {
            BlackToolStripMenuItem.Checked = false;
            TranspToolStripMenuItem.Checked = true;
            whiteToolStripMenuItem.Checked = false;
            panelBG.BackColor = Color.DarkGray;
            textBoxHUDConsole.BackColor = Color.DarkGray;
            Settings.Default.BackgroundColor = Color.DarkGray;
            Settings.Default.Save();
            foreach (Label _label in labelsToScale)
            {
                _label.ForeColor = Color.White;
            }
            textBoxHUDConsole.ForeColor = Color.White;

            buttonClose.BackColor = Color.DarkGray;
            buttonConsoleDown.BackColor = Color.DarkGray;
            buttonConsoleUP.BackColor = Color.DarkGray;
            buttonMove.BackColor = Color.DarkGray;
            buttonResetAP.BackColor = Color.DarkGray;
            buttonResetExpCounter.BackColor = Color.DarkGray;

            buttonClose.ForeColor = Color.White;
            buttonConsoleDown.ForeColor = Color.White;
            buttonConsoleUP.ForeColor = Color.White;
            buttonMove.ForeColor = Color.White;
            buttonResetAP.ForeColor = Color.White;
            buttonResetExpCounter.ForeColor = Color.White;
        }

        private void noToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeHUDBlack();
        }

        private void MakeHUDWhite()
        {
            BlackToolStripMenuItem.Checked = false;
            TranspToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = true;

            panelBG.BackColor = Color.White;
            textBoxHUDConsole.BackColor = Color.White;
            Settings.Default.BackgroundColor = Color.White;
            Settings.Default.Save();
            foreach (Label _label in labelsToScale)
            {
                _label.ForeColor = Color.Black;
            }
            textBoxHUDConsole.ForeColor = Color.Black;

            buttonClose.BackColor = Color.White;
            buttonConsoleDown.BackColor = Color.White;
            buttonConsoleUP.BackColor = Color.White;
            buttonMove.BackColor = Color.White;
            buttonResetAP.BackColor = Color.White;
            buttonResetExpCounter.BackColor = Color.White;

            buttonClose.ForeColor = Color.Black;
            buttonConsoleDown.ForeColor = Color.Black;
            buttonConsoleUP.ForeColor = Color.Black;
            buttonMove.ForeColor = Color.Black;
            buttonResetAP.ForeColor = Color.Black;
            buttonResetExpCounter.ForeColor = Color.Black;
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeHUDWhite();
        }

        private void MakeHUDBlack()
        {
            BlackToolStripMenuItem.Checked = true;
            TranspToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = false;

            panelBG.BackColor = Color.Black;
            textBoxHUDConsole.BackColor = Color.Black;
            Settings.Default.BackgroundColor = Color.Black;
            Settings.Default.Save();
            foreach (Label _label in labelsToScale)
            {
                _label.ForeColor = Color.White;
            }
            textBoxHUDConsole.ForeColor = Color.White;

            buttonClose.BackColor = Color.Black;
            buttonConsoleDown.BackColor = Color.Black;
            buttonConsoleUP.BackColor = Color.Black;
            buttonMove.BackColor = Color.Black;
            buttonResetAP.BackColor = Color.Black;
            buttonResetExpCounter.BackColor = Color.Black;

            buttonClose.ForeColor = Color.White;
            buttonConsoleDown.ForeColor = Color.White;
            buttonConsoleUP.ForeColor = Color.White;
            buttonMove.ForeColor = Color.White;
            buttonResetAP.ForeColor = Color.White;
            buttonResetExpCounter.ForeColor = Color.White;
        }

        private void buttonMove_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void buttonMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void buttonMove_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            Settings.Default.HUD_position = Location;
            Settings.Default.Save();
        }

        private void buttonConsoleUP_Click(object sender, EventArgs e)
        {
            ConsoleTimer.Restart();
            currentLine -= 1;
            if (currentLine < 10)
            {
                currentLine = 10;
            }

            textBoxHUDConsole.Lines = ConsoleData.Take(currentLine).ToArray();
            textBoxHUDConsole.SelectionStart = textBoxHUDConsole.Text.Length;
            textBoxHUDConsole.ScrollToCaret();
        }

        private void buttonConsoleDown_Click(object sender, EventArgs e)
        {
            ConsoleTimer.Restart();
            currentLine += 1;
            if (currentLine > ConsoleData.Length)
            {
                currentLine = ConsoleData.Length;
            }

            textBoxHUDConsole.Lines = ConsoleData.Take(currentLine).ToArray();
            textBoxHUDConsole.SelectionStart = textBoxHUDConsole.Text.Length;
            textBoxHUDConsole.ScrollToCaret();
        }

        private void textBoxHUDConsole_TextChanged(object sender, EventArgs e)
        {
            if (textBoxHUDConsole.Lines.Length > 10)
                buttonConsoleUP.Enabled = true;
            else
                buttonConsoleUP.Enabled = false;

            if (textBoxHUDConsole.Lines.Length >= ConsoleData.Length)
            {
                buttonConsoleDown.Enabled = false;
            }
            else
            {
                buttonConsoleDown.Enabled = true;
            }
        }

        private DataTable ReadItemFromDB(long id)
        {
            DataTable dTable = new DataTable();
            try
            {
                string MyConnection2 = "datasource=aionhud.com;port=3306;username=daiumqyiat_aionhudAPP;password=Nn2Z-bE_Y7swzxK-;SSL Mode=None";
                //Display query
                string Query = "SELECT * FROM daiumqyiat_aionitems.client_items WHERE id=" + id.ToString() + " ORDER BY `client_items`.`primary_key` DESC;";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                //  MyConn2.Open();
                //For offline connection we weill use  MySqlDataAdapter class.
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                MyAdapter.Fill(dTable);
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void panelBG_Paint(object sender, PaintEventArgs e)
        {
        }

        private void yesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            yesToolStripMenuItem.Checked = true;
            noToolStripMenuItem.Checked = false;
            Settings.Default.BrokerChecked = true;
            Settings.Default.Save();
        }

        private void noToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            yesToolStripMenuItem.Checked = false;
            noToolStripMenuItem.Checked = true;
            Settings.Default.BrokerChecked = false;
            Settings.Default.Save();
        }
    }
}