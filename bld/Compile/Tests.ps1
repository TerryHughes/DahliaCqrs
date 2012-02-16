Include bld\Utilities\Get-FilesToCompile.ps1
Include bld\Utilities\Generic-Compile.ps1

function Compile-Tests
{
    $sourceFiles = "Tests" | Get-FilesToCompile

    $referenceAssemblies = @() + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        "lib\NUnit\lib\nunit.framework.dll" + `
        $eventsFile + `
        $domainFile + `
        $testingFile

    Generic-Compile $testsFile $sourceFiles $referenceAssemblies
}
