; Script generated with the Venis Install Wizard

!include gvv.nsi
!include WinVer.nsh
!include x64.nsh

; Define your application name
!define APPNAME "Devcon"
!define APPNAMEANDVERSION "Devcon All OS"

; Main Install settings
Name "${APPNAMEANDVERSION}"
InstallDir "$WINDIR"
InstallDirRegKey HKLM "Software\${APPNAME}" ""
OutFile "Output\devcon_all.exe"

LicenseData "LICENSE"
LicenseText "If you accept the terms of the agreement, click I Agree to continue. You must accept the agreement to install ${APPNAMEANDVERSION}."

ComponentText "Choose which features of ${APPNAMEANDVERSION} you want to install."

DirText "Choose the folder in which to install ${APPNAMEANDVERSION}."

ShowInstDetails show
Var UNINSTDIR

Section "Devcon"

	; Set Section properties
	SectionIn RO
	SetOverwrite on
	
	DetailPrint "Unpacking DEVCON in temporary directory"

	; Set Section Files and Shortcuts
	SetOutPath "$TEMP\devcon\x64\"
	File "devcon\x64\devcon.exe"
	SetOutPath "$TEMP\devcon\x86\"
	File "devcon\x86\devcon.exe"
	SetOutPath "$TEMP\devcon\XP\x64\"
	File "devcon\XP\x64\devcon.exe"
	SetOutPath "$TEMP\devcon\XP\x86\"
	File "devcon\XP\x86\devcon.exe"
	
	${GetWindowsVersion} $R0
	DetailPrint "Windows Version: $R0"
	
	${If} ${IsWinXP} ;Win XP
		DetailPrint "Is Windows XP"
		${If} ${IsNativeAMD64}
     DetailPrint "System Architecture: x64"
		 CopyFiles "$TEMP\devcon\XP\x64\devcon.exe" "$INSTDIR\devcon.exe"
   ${ElseIf} ${IsNativeIA32}
     DetailPrint "System Architecture: x86"
		 CopyFiles "$TEMP\devcon\XP\x86\devcon.exe" "$INSTDIR\devcon.exe"
   ${Else}
     MessageBox MB_ICONEXCLAMATION|MB_OK "Unsupported CPU architecture!" /SD IDOK
		 Abort "Unsupported CPU architecture!"
   ${EndIf}
	${ElseIf} ${AtLeastWin7} ; Win 7 or higher
		DetailPrint "Is Windows 7 or higher"
		${If} ${IsNativeAMD64}
     DetailPrint "System Architecture: x64"
		 CopyFiles "$TEMP\devcon\x64\devcon.exe" "$INSTDIR\devcon.exe"
   ${ElseIf} ${IsNativeIA32}
     DetailPrint "System Architecture: x86"
		 CopyFiles "$TEMP\devcon\x86\devcon.exe" "$INSTDIR\devcon.exe"
   ${Else}
     MessageBox MB_ICONEXCLAMATION|MB_OK "Unsupported CPU architecture!"	/SD IDOK	 
		 Abort "Unsupported CPU architecture!"
   ${EndIf}
	${Else} ;fucking Vista
		${If} ${IsNativeIA32}
			MessageBox MB_ICONQUESTION|MB_YESNO "Windows Vista may be not supported! Continue install?" /SD IDYES IDNO NoInstall
			CopyFiles "$TEMP\devcon\XP\x86\devcon.exe" "$INSTDIR\devcon.exe"
			NoInstall:
		${Else}
			MessageBox MB_ICONEXCLAMATION|MB_OK "Windows Vista x64 is not supported" /SD IDOK
			Abort "Windows Vista x64 is not supported"
		${EndIf}
	${EndIf}
	
	RMDir /r "$TEMP\devcon"
	
	StrCpy $UNINSTDIR "$PROGRAMFILES\Devcon"
	CreateDirectory "$UNINSTDIR"
	CreateDirectory "$SMPROGRAMS\Devcon"
	CreateShortCut "$SMPROGRAMS\Devcon\Uninstall.lnk" "$UNINSTDIR\uninstall.exe"
	
	WriteINIStr "$UNINSTDIR\dirs.ini" "dirs" "I" "$INSTDIR"
	WriteINIStr "$UNINSTDIR\dirs.ini" "dirs" "U" "$UNINSTDIR"

SectionEnd

Section "Batchfiles"

	; Set Section properties
	SetOverwrite on

	; Set Section Files and Shortcuts
	SetOutPath "$INSTDIR\"
	File "batchfiles\disable_net.bat"
	File "batchfiles\enable_net.bat"
	File "batchfiles\find_netdevs.bat"
	CreateShortCut "$SMPROGRAMS\Devcon\List network devices.lnk" "$INSTDIR\find_netdevs.bat"
	CreateShortCut "$SMPROGRAMS\Devcon\Disable Network.lnk" "$INSTDIR\disable_net.bat"
	CreateShortCut "$SMPROGRAMS\Devcon\Enable Network.lnk" "$INSTDIR\enable_net.bat"

SectionEnd

Section -FinishSection

	WriteRegStr HKLM "Software\${APPNAME}" "" "$INSTDIR"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "DisplayName" "${APPNAME}"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "UninstallString" "$UNINSTDIR\uninstall.exe"
	WriteUninstaller "$UNINSTDIR\uninstall.exe"
	
SectionEnd

;Uninstall section
Section Uninstall
	
	SetDetailsView show
	
	ReadINIStr $0 "$INSTDIR\dirs.ini" "dirs" "I"
	IfErrors Dupa 0
	ReadINIStr $1 "$INSTDIR\dirs.ini" "dirs" "U"
	IfErrors Dupa 0
	StrCpy $INSTDIR $0
	StrCpy $UNINSTDIR $1
	
	;Remove from registry...
	DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}"
	DeleteRegKey HKLM "SOFTWARE\${APPNAME}"

	; Delete Shortcuts
	DetailPrint "Delete Shortcuts..."
	Delete "$SMPROGRAMS\Devcon\Uninstall.lnk"
	Delete "$SMPROGRAMS\Devcon\List network devices.lnk"
	Delete "$SMPROGRAMS\Devcon\Disable Network.lnk"
	Delete "$SMPROGRAMS\Devcon\Enable Network.lnk"

	; Clean up Devcon
	DetailPrint "Delete Devcon..."
	Delete "$INSTDIR\devcon.exe"	

	; Clean up Batchfiles
	DetailPrint "Delete BatchFiles..."
	Delete "$INSTDIR\disable_net.bat"
	Delete "$INSTDIR\enable_net.bat"
	Delete "$INSTDIR\find_netdevs.bat"
	
	; Delete self
	Delete "$UNINSTDIR\uninstall.exe"
	Delete "$UNINSTDIR\dirs.ini"
	RMDir "$UNINSTDIR"
	
	Goto OK
	Dupa:
		MessageBox MB_ICONSTOP|MB_OK "Error reading $INSTDIR\dirs.ini! Uninstall aborted!"
	
	OK:

SectionEnd

Function un.onInit

	MessageBox MB_YESNO|MB_DEFBUTTON2|MB_ICONQUESTION "Remove ${APPNAMEANDVERSION} and all of its components?" IDYES DoUninstall
		Abort
	DoUninstall:

FunctionEnd

BrandingText "Devcon Install"

; eof