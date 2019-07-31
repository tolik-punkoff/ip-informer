;Tolik-Punkoff (L) 2010-2019

; Define your application name
!define APPNAME "IPInformer"
!define APPNAMEANDVERSION "IPInformer 0.2.0"

!include "nsProcess.nsh"

; Main Install settings
Name "${APPNAMEANDVERSION}"
InstallDir "$PROGRAMFILES\IPInformer"
InstallDirRegKey HKLM "Software\${APPNAME}" ""
OutFile "Output\IPInformerInstall.exe"

LicenseData "addfiles\LICENSE.txt"
LicenseText "If you accept the terms of the agreement, click I Agree to continue. You must accept the agreement to install ${APPNAMEANDVERSION}."

ComponentText "Choose which features of ${APPNAMEANDVERSION} you want to install."

DirText "Choose the folder in which to install ${APPNAMEANDVERSION}."

ShowInstDetails show

Section "IPInformer"

	; Set Section properties
	SetOverwrite on
	SectionIn RO
	
	DetailPrint "Kill process IPInformer2.exe..."
	${nsProcess::KillProcess} "IPInformer2.exe" $R0
	${nsProcess::Unload}

	DetailPrint "Installing main files..."
	SetOutPath "$INSTDIR\"
	File "pf\IPAddressControlLib.dll"
	File "pf\IPInformer2.exe"
	
	DetailPrint "Installing help file..."
	CreateDirectory "$INSTDIR\help"
	SetOutPath "$INSTDIR\help"
	File "pf\help\help.chm"
	
	DetailPrint "Installing ISO.csv..."
	CreateDirectory "$LOCALAPPDATA\IPInformer2"
	SetOutPath "$LOCALAPPDATA\IPInformer2"
	File "data\iso.csv"
	
	DetailPrint "Installing SxGeo..."
	CreateDirectory "$LOCALAPPDATA\IPInformer2\SxGeo"
	SetOutPath "$LOCALAPPDATA\IPInformer2\SxGeo"
	File "data\SxGeo\readme.txt"
	File "data\SxGeo\SxGeo.dat"
	File "data\SxGeo\SxGeoCity.dat"
	
	MessageBox MB_YESNO|MB_ICONQUESTION "Add IP Informer to startup?" IDNO NoStartup
	SetOutPath "$INSTDIR\"
	CreateShortCut "$SMSTARTUP\IPInformer.lnk" "$INSTDIR\IPInformer2.exe" "/np" "$INSTDIR\IPInformer2.exe" "0"
	
	NoStartup:
	
	DetailPrint "Creating Shortcuts..."
	CreateDirectory "$SMPROGRAMS\IPInformer"
	SetOutPath "$INSTDIR\"
	CreateShortCut "$SMPROGRAMS\IPInformer\IPInformer.lnk" "$INSTDIR\IPInformer2.exe" "/np" "$INSTDIR\IPInformer2.exe" "0"
	CreateShortCut "$SMPROGRAMS\IPInformer\Help.lnk" "$INSTDIR\help\help.chm"
	CreateShortCut "$SMPROGRAMS\IPInformer\Uninstall.lnk" "$INSTDIR\uninstall.exe"

SectionEnd

Section "PHP Script"

	; Set Section properties
	SetOverwrite on

	DetailPrint "Installing PHP Script..."
	CreateDirectory "$INSTDIR\php"
	SetOutPath "$INSTDIR\php"
	File "php\iplist.php"
	
	CreateShortCut "$SMPROGRAMS\IPInformer\PHP Script.lnk" "$INSTDIR\php"

SectionEnd

Section /o "Devcon & Batch Files"

	; Set Section properties
	SetOverwrite on

	; Set Section Files and Shortcuts
	DetailPrint "Installing Devcon..."
	SetOutPath "$TEMP\"
	File "devcon\devcon_all.exe"
	ExecWait "$TEMP\devcon_all.exe /S"
	Delete "$TEMP\devcon_all.exe"
	
SectionEnd

Section -FinishSection

	WriteRegStr HKLM "Software\${APPNAME}" "" "$INSTDIR"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "DisplayName" "${APPNAME}"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "UninstallString" "$INSTDIR\uninstall.exe"
	WriteUninstaller "$INSTDIR\uninstall.exe"

	MessageBox MB_YESNO "Would you like to run ${APPNAMEANDVERSION}?" IDNO NoRun
		Exec "$INSTDIR\IPInformer2.exe /np"
	NoRun:

SectionEnd

;Uninstall section
Section Uninstall
	
	SetDetailsView show
	
	DetailPrint "Kill process IPInformer2.exe..."
	${nsProcess::KillProcess} "IPInformer2.exe" $R0
	${nsProcess::Unload}
	
	MessageBox MB_YESNO|MB_ICONQUESTION "Remove configuration files?" IDNO KeepConfigs
	Delete "$LOCALAPPDATA\IPInformer2\network.xml"
	Delete "$LOCALAPPDATA\IPInformer2\settings.xml"
	
	KeepConfigs:
	
	DetailPrint "Removing main files..."
	Delete "$INSTDIR\IPAddressControlLib.dll"
	Delete "$INSTDIR\IPInformer2.exe"
	
	DetailPrint "Removing help..."
	Delete "$INSTDIR\help\help.chm"
	RMDir "$INSTDIR\help"
	
	DetailPrint "Removing PHP Script..."
	Delete "$INSTDIR\php\iplist.php"
	RMDir "$INSTDIR\php"
	
	DetailPrint "Removing country codes..."
	Delete "$LOCALAPPDATA\IPInformer2\iso.csv"
	
	DetailPrint "Removing SxGeo..."
	Delete "$LOCALAPPDATA\IPInformer2\SxGeo\readme.txt"
	Delete "$LOCALAPPDATA\IPInformer2\SxGeo\SxGeo.dat"
	Delete "$LOCALAPPDATA\IPInformer2\SxGeo\SxGeoCity.dat"
	RMDir "$LOCALAPPDATA\IPInformer2\SxGeo"
	
	DetailPrint "Removing Data directory..."
	RMDir "$LOCALAPPDATA\IPInformer2\"
	
	DetailPrint "Removing Shortcuts..."
	Delete "$SMSTARTUP\IPInformer.lnk"
	Delete "$SMPROGRAMS\IPInformer\IPInformer.lnk"
	Delete "$SMPROGRAMS\IPInformer\Help.lnk"
	Delete "$SMPROGRAMS\IPInformer\PHP Script.lnk"
	Delete "$SMPROGRAMS\IPInformer\Uninstall.lnk"
	RMDir "$SMPROGRAMS\IPInformer"

	DetailPrint "Cleanup system..."
	;Remove from registry...
	DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}"
	DeleteRegKey HKLM "SOFTWARE\${APPNAME}"
	; Delete self
	Delete "$INSTDIR\uninstall.exe"
	; Remove remaining directories
	RMDir "$INSTDIR\"

SectionEnd

Function un.onInit

	MessageBox MB_YESNO|MB_DEFBUTTON2|MB_ICONQUESTION "Remove ${APPNAMEANDVERSION} and all of its components?" IDYES DoUninstall
		Abort
	DoUninstall:

FunctionEnd

; eof