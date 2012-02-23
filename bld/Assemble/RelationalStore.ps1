Include bld\Utilities\Make-Directory.ps1

function Assemble-RelationalStore {
    Make-Directory "app\rel"

    cpi "lib\nservicebus\lib\net40\log4net.dll" "app\rel"
    cpi "lib\nservicebus\lib\net40\NServiceBus.dll" "app\rel"
    cpi "lib\nservicebus\lib\net40\NServiceBus.Core.dll" "app\rel"
    cpi "lib\nservicebus\lib\net40\NServiceBus.Host.exe" "app\rel"
    cpi "bin\Dahlia.Framework.*" "app\rel"
    cpi "bin\Dahlia.Events.*" "app\rel"
    cpi "bin\Dahlia.Data.Common.*" "app\rel"
    cpi "bin\Dahlia.Data.SqlClient.*" "app\rel"
    cpi "bin\$bitness\*.Data.SQLite.*" "app\rel" -ex "*Specs*"
    cpi "bin\Dahlia.RelationalStore.*" "app\rel"
    cpi "src\RelationalStore\App.config" "app\rel\Dahlia.RelationalStore.dll.config"
}
