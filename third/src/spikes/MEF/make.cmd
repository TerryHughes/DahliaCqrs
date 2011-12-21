@ECHO Off

IF NOT EXIST "bin" MKDIR "bin"

COPY "..\..\bin\Dahlia.Framework.dll" "bin" >> NUL
COPY "..\..\bin\Dahlia.Data.dll" "bin" >> NUL
COPY "..\..\bin\Dahlia.Data.Common.dll" "bin" >> NUL
COPY "..\..\bin\Dahlia.Data.SqlClient.dll" "bin" >> NUL
COPY "..\..\bin\x64\Dahlia.Data.SQLite.dll" "bin" >> NUL
COPY "..\..\bin\x64\System.Data.SQLite.dll" "bin" >> NUL

"%windir%\Microsoft.NET\Framework64\v4.0.30319\csc.exe" /out:"bin\mef.exe" /t:exe /r:"%windir%\Microsoft.NET\Framework64\v4.0.30319\System.ComponentModel.Composition.dll" /r:"bin\Dahlia.Data.Common.dll" /debug+ /debug:"full" /o- /d:"DEBUG;TRACE" /nologo "*.cs"

@ECHO ON
