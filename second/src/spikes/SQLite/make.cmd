@ECHO Off

IF NOT EXIST "bin" MKDIR "bin"

COPY "..\..\lib\System.Data.SQLite.x64\lib\net40\System.Data.SQLite.dll" "bin" >> NUL

"%windir%\Microsoft.NET\Framework64\v4.0.30319\csc.exe" /out:"bin\Create.exe" /t:exe /platform:x64 /r:"bin\System.Data.SQLite.dll" /debug+ /debug:"full" /o- /d:"DEBUG;TRACE;CREATE" /nologo "*.cs"
"%windir%\Microsoft.NET\Framework64\v4.0.30319\csc.exe" /out:"bin\Update.exe" /t:exe /platform:x64 /r:"bin\System.Data.SQLite.dll" /debug+ /debug:"full" /o- /d:"DEBUG;TRACE;UPDATE" /nologo "*.cs"
"%windir%\Microsoft.NET\Framework64\v4.0.30319\csc.exe" /out:"bin\Read.exe" /t:exe /platform:x64 /r:"bin\System.Data.SQLite.dll" /debug+ /debug:"full" /o- /d:"DEBUG;TRACE;READ" /nologo "*.cs"
"%windir%\Microsoft.NET\Framework64\v4.0.30319\csc.exe" /out:"bin\Drop.exe" /t:exe /platform:x64 /r:"bin\System.Data.SQLite.dll" /debug+ /debug:"full" /o- /d:"DEBUG;TRACE;DROP" /nologo "*.cs"

@ECHO ON
