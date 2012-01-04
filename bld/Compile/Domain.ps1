Include bld\Utilities\Get-FilesToCompile.ps1
Include bld\Utilities\Generic-Compile.ps1

function Compile-Domain
{
    $sourceFiles = "Domain" | Get-FilesToCompile

    $referenceAssemblies = @() + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        $frameworkFile + `
        $eventsFile

    Generic-Compile $domainFile $sourceFiles $referenceAssemblies
}
