Include bld\Utilities\Make-Directory.ps1

function Assemble-CommandProcessor {
    Make-Directory "app\cmd"

    cpi "lib\nservicebus\lib\net40\log4net.dll" "app\cmd"
    cpi "lib\nservicebus\lib\net40\NServiceBus.dll" "app\cmd"
    cpi "lib\nservicebus\lib\net40\NServiceBus.Core.dll" "app\cmd"
    cpi "lib\nservicebus\lib\net40\NServiceBus.Host.exe" "app\cmd"
    cpi "bin\Dahlia.Framework.*" "app\cmd"
    cpi "bin\Dahlia.Events.*" "app\cmd"
    cpi "bin\Dahlia.Commands.*" "app\cmd"
    cpi "bin\Dahlia.CommandProcessor.*" "app\cmd"
    cpi "src\CommandProcessor\App.config" "app\cmd\Dahlia.CommandProcessor.dll.config"
}
