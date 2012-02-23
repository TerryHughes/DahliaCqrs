Include bld\Utilities\Get-FilesToCompile.ps1
Include bld\Utilities\Generic-Compile.ps1

function Compile-RelationalStore
{
    $sourceFiles = "RelationalStore" | Get-FilesToCompile

    $referenceAssemblies = @() + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Core.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Host.exe" + `
        $frameworkFile + `
        $dataCommonFile + `
        $eventsFile

    Generic-Compile $RelationalStoreFile $sourceFiles $referenceAssemblies
}
