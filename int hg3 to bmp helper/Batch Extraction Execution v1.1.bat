:: processing of graphical encrypted obfuscation computer generated visualization extraction
:: put this file with execution file of choice on the same folder with files to convert
@echo off

setlocal enableextensions enabledelayedexpansion

set count=0
set pattern=*.hg3

REM use dir /b %pattern% ^| find /c /v ""
for /f %%i in ('dir /b /a-d %pattern% ^| find /c /v ""') do @call set count=%%i

echo preparing %count% mach of thermonuclear semiconductor bionic conversion...
TIMEOUT /T 3

set /a iteration = 0
:: replace hg3 with format of choice
:: replace hgx2bmp.exe with exe of choice
for %%f in (*.hg3) do (
    set /a iteration += 1
	echo|set /P ="!iteration!/%count% converting %%f...    "
	start /B /wait hgx2bmp.exe %%f
	echo OK
)

echo conversion completed
echo closing in 3 seconds...
TIMEOUT /T 3
EXIT /B