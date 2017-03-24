:: processing of graphical encrypted obfuscation computer generated visualization extraction
:: put this file with execution file of choice on the same folder with files to convert
@echo off
echo preparing thermonuclear semiconductor bionic conversion...
TIMEOUT /T 3

:: replace hg3 with format of choice
:: replace hgx2bmp.exe with exe of choice
for %%f in (*.hg3) do (
	echo|set /P ="converting %%f...    "
	start /B /wait hgx2bmp.exe %%f
	echo OK
)

echo conversion completed
echo closing in 3 seconds...
TIMEOUT /T 3
EXIT /B