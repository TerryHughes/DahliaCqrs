Include bld\CompileSource.ps1
Include bld\GenericCompile.ps1

function Compile-DataStore
{
    $sourceFiles = "DataStore" | Get-FilesToCompile

    $referenceAssemblies = @() + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Host.exe" + `
        $frameworkFile + `
        $dataCommonFile + `
        $eventsFile

    GenericCompile $dataStoreFile $sourceFiles $referenceAssemblies
}
