@ECHO OFF

IF EXIST "src\tools\BinToXml\bin" RMDIR "src\tools\BinToXml\bin" /S /Q
MKDIR "src\tools\BinToXml\bin"
COPY "bin\Dahlia.Framework.*" "src\tools\BinToXml\bin"
COPY "bin\Dahlia.Events.*" "src\tools\BinToXml\bin"
COPY "bin\Dahlia.Data.Common.*" "src\tools\BinToXml\bin"
COPY "bin\Dahlia.Data.SqlClient.*" "src\tools\BinToXml\bin"
COPY "lib\nservicebus\lib\net40\NServiceBus.dll" "src\tools\BinToXml\bin"
COPY "lib\nservicebus\lib\net40\NServiceBus.pdb" "src\tools\BinToXml\bin"
COPY "lib\nservicebus\lib\net40\NServiceBus.xml" "src\tools\BinToXml\bin"
COPY "src\tools\BinToXml\App.config" "src\tools\BinToXml\bin\BinToXml.exe.config"

MKDIR src\tools\BinToXml\bin\bin"
COPY "bin\Dahlia.Data.SqlClient.*" "src\tools\BinToXml\bin\bin"

"%windir%\Microsoft.NET\Framework\v4.0.30319\csc.exe" /out:"src\tools\BinToXml\bin\BinToXml.exe" /t:winexe /reference:"src\tools\BinToXml\bin\Dahlia.Framework.dll" /reference:"src\tools\BinToXml\bin\Dahlia.Events.dll" /reference:"src\tools\BinToXml\bin\Dahlia.Data.Common.dll" /reference:"src\tools\BinToXml\bin\NServiceBus.dll" /debug+ /debug:"full" /o- /d:"DEBUG;TRACE;" /nologo "src\tools\BinToXml\*.cs"

@ECHO ON
