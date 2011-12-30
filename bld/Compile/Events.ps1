Include bld\Utilities\Get-FilesToCompile.ps1
Include bld\Utilities\Generic-Compile.ps1

function Compile-Events
{
    $sourceFiles = "Events" | Get-FilesToCompile

    $referenceAssemblies = @() + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        $frameworkFile

    Generic-Compile $eventsFile $sourceFiles $referenceAssemblies
}