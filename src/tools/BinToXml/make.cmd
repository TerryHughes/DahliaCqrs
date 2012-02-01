@ECHO OFF

IF NOT EXIST "src\tools\BinToXml\bin" MKDIR "src\tools\BinToXml\bin"

COPY "bin\Dahlia.Framework.*" "src\tools\BinToXml\bin" >> NUL
COPY "bin\Dahlia.Events.*" "src\tools\BinToXml\bin" >> NUL
COPY "bin\Dahlia.Data.Common.*" "src\tools\BinToXml\bin" >> NUL
COPY "bin\Dahlia.Data.SqlClient.*" "src\tools\BinToXml\bin" >> NUL
COPY "lib\nservicebus\lib\net40\NServiceBus.dll" "src\tools\BinToXml\bin" >> NUL
COPY "lib\nservicebus\lib\net40\NServiceBus.pdb" "src\tools\BinToXml\bin" >> NUL
COPY "lib\nservicebus\lib\net40\NServiceBus.xml" "src\tools\BinToXml\bin" >> NUL
COPY "src\tools\BinToXml\App.config" "src\tools\BinToXml\bin\BinToXml.exe.config" >> NUL

IF NOT EXIST "src\tools\BinToXml\bin\bin" MKDIR "src\tools\BinToXml\bin\bin"
COPY "bin\Dahlia.Data.SqlClient.*" "src\tools\BinToXml\bin\bin" >> NUL

"%windir%\Microsoft.NET\Framework\v4.0.30319\csc.exe" /out:"src\tools\BinToXml\bin\BinToXml.exe" /t:winexe /r:"src\tools\BinToXml\bin\Dahlia.Framework.dll" /r:"src\tools\BinToXml\bin\Dahlia.Events.dll" /r:"src\tools\BinToXml\bin\Dahlia.Data.Common.dll" /r:"src\tools\BinToXml\bin\NServiceBus.dll" /debug+ /debug:"full" /o- /d:"DEBUG;TRACE;" /nologo "src\tools\BinToXml\*.cs"

@ECHO ON
