; Script generated by the Inno Script Studio Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Devcon Installer"
#define MyAppVersion "0.0.1"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{413CD642-509B-4254-BFE1-702C2CF1B34E}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
DefaultDirName={pf}\Devcon
DefaultGroupName=Devcon
AllowNoIcons=yes
InfoBeforeFile=C:\!\devcon\readme.txt
OutputDir=C:\!\devcon\installer
OutputBaseFilename=devcon_all
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Icons]
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{group}\readme"; Filename: "{app}\readme.txt"

[Files]
Source: "C:\!\devcon\x86\devcon.exe"; DestDir: "{win}"; DestName: "devcon.exe"; Flags: 32bit; MinVersion: 0,6.1; Languages: english russian
Source: "..\x64\devcon.exe"; DestDir: "{win}"; DestName: "devcon.exe"; Flags: 64bit; MinVersion: 0,6.1; Languages: english russian
Source: "..\XP\x86\devcon.exe"; DestDir: "{win}"; DestName: "devcon.exe"; Flags: 32bit; OnlyBelowVersion: 0,5.01; Languages: english russian
Source: "..\XP\x64\devcon.exe"; DestDir: "{win}"; DestName: "devcon.exe"; Flags: 64bit; OnlyBelowVersion: 0,5.02; Languages: english russian
Source: "..\readme.txt"; DestDir: "{app}"; DestName: "readme.txt"; Languages: english russian
Source: "..\batchfiles\disable_net.bat"; DestDir: "{win}"; DestName: "disable_net.bat"; Languages: english russian
Source: "..\batchfiles\enable_net.bat"; DestDir: "{win}"; DestName: "enable_net.bat"; Languages: english russian
Source: "..\batchfiles\find_netdevs.bat"; DestDir: "{win}"; DestName: "find_netdevs.bat"; Languages: english russian
