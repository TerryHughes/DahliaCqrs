Include bld\Utilities\Get-FilesToCompile.ps1
Include bld\Utilities\Generic-Compile.ps1

function Compile-Testing
{
    $sourceFiles = "Testing" | Get-FilesToCompile

    $referenceAssemblies = @() + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        "lib\NUnit\lib\nunit.framework.dll" + `
        $frameworkFile + `
        $eventsFile + `
        $domainFile

    Generic-Compile $testingFile $sourceFiles $referenceAssemblies
}
