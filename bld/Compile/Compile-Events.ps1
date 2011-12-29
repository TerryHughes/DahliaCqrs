Include bld\CompileSource.ps1
Include bld\GenericCompile.ps1

function Compile-Events
{
    $sourceFiles = "Events" | Get-FilesToCompile

    $referenceAssemblies = @() + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        $frameworkFile

    GenericCompile $eventsFile $sourceFiles $referenceAssemblies
}
