Include bld\Utilities\Get-FilesToCompile.ps1
Include bld\Utilities\Generic-Compile.ps1

function Compile-DataStore
{
    $sourceFiles = "DataStore" | Get-FilesToCompile

    $referenceAssemblies = @() + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Host.exe" + `
        $frameworkFile + `
        $dataCommonFile + `
        $eventsFile

    Generic-Compile $dataStoreFile $sourceFiles $referenceAssemblies
}