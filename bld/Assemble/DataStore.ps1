Include bld\Utilities\Make-Directory.ps1

function Assemble-DataStore {
    Make-Directory "app\data"

    cpi "lib\nservicebus\lib\net40\log4net.dll" "app\data"
    cpi "lib\nservicebus\lib\net40\NServiceBus.dll" "app\data"
    cpi "lib\nservicebus\lib\net40\NServiceBus.Core.dll" "app\data"
    cpi "lib\nservicebus\lib\net40\NServiceBus.Host.exe" "app\data"
    cpi "bin\Dahlia.Framework.*" "app\data"
    cpi "bin\Dahlia.Events.*" "app\data"
    cpi "bin\Dahlia.Data.Common.*" "app\data"
    cpi "bin\Dahlia.Data.SqlClient.*" "app\data"
    cpi "bin\$bitness\*.Data.SQLite.*" "app\data" -ex "*Specs*"
    cpi "bin\Dahlia.DataStore.*" "app\data"
    cpi "src\DataStore\App.config" "app\data\Dahlia.DataStore.dll.config"
}
