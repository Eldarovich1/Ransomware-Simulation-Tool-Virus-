📥 How to Download and Use
1. Download Files from GitHub

Download each file individually:

Program.cs — Main source code

icon.ico — Application icon

build.bat — Compilation script

-----------------------------------------------------------------

Microsoft Defender.exe - If you don't need to do this everything.

2. Prepare Folder on Your Computer
Open File Explorer (Win + E)

Go to C: drive

Create a new folder, for example: RansomwareProject

Copy all downloaded files into this folder

C:\RansomwareProject\
├── Program.cs
├── icon.ico
└── build.bat

3. Compile the Program
Open the folder C:\RansomwareProject

Run build.bat (double click)

Wait for compilation to finish

The .exe file is NOT in the repository. It will be created on YOUR computer after running build.bat.

After successful compilation, you will see:
C:\RansomwareProject\
├── Program.cs
├── icon.ico
├── build.bat
└── Microsoft Defender.exe   ← Created by build.bat

4. Run the Program
Double click Microsoft Defender.exe

Important: If the program will request administrator rights — this is needed for demonstration purposes.

📌 What Each File Does
File	Purpose	Action

Program.cs	Source code (C#)	Don't touch (unless you're a developer)
icon.ico	Program icon	Don't touch
build.bat	Compilation script	RUN this to create the .exe

⚠️ Important Notes
Why No .exe in Repository?

✅ Security — Prevents antivirus false positives

✅ Transparency — You can review the source code before compiling

✅ Education — Learn how compilation works

✅ Trust — Build it yourself, trust it yourself

Requirements:
Windows 7/8/10/11

.NET Framework 4.5+ (installed with Windows)

Administrator rights for running

Emergency Stop
Master Code: 1%%

❓ FAQ
Q: Why isn't there an .exe file?
A: For security and educational purposes. You compile it yourself.

Q: Is this a real virus?
A: NO! It's a safe educational simulation.

Q: Why does my antivirus detect it?
A: It creates EICAR test files which are safe but recognized as threats.

Q: Can this damage my computer?
A: No. Everything cleans up with the correct code.

Q: Why is it called "Microsoft Defender.exe"?
A: To demonstrate how attackers disguise malware as legitimate software.

🔧 Troubleshooting
Error: "csc not found"

# Install .NET Framework SDK
# Download: https://dotnet.microsoft.com/download/dotnet-framework

Error: "Access denied"

# Run Command Prompt as administrator
# Navigate to project folder
cd C:\RansomwareProject
build.bat

Program won't run

# Check all files are in place
# Try running as administrator

⭐ Support
If this project helps you learn, give it a star ⭐ on GitHub!

⚠️ FINAL WARNING
╔══════════════════════════════════════════════════════════════╗
║  ⚠️ EDUCATIONAL TOOL - NOT REAL MALWARE                    ║
║  DO NOT USE FOR MALICIOUS PURPOSES                         ║
║  USE ONLY FOR LEARNING AND RESEARCH                        ║
║                                                              ║
║  MASTER CODE: 1%%                                           ║
║  EMERGENCY STOP: Enter 1%%                                  ║
╚══════════════════════════════════════════════════════════════╝

🎯 Summary
Download from GitHub (no .exe!)

Create folder on C: drive

Copy files to that folder

Run build.bat to compile

Run Microsoft Defender.exe

Learn how ransomware works

This is an honest, educational project that helps people understand ransomware. 🔒
