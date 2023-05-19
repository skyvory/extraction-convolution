@echo off
set "Folder=D:\#\test\ÅIÅ@ÇªÇÃ"
if not exist "%Folder%" (
    md "%Folder%"
    goto EndBatch
)
for /L %%N in (1 1 30) do (
    if not exist "%Folder%%%N" (
        md "%Folder%%%N"
        goto EndBatch
    )
)
:EndBatch
set "Folder="