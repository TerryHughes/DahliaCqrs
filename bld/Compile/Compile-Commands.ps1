Include bld\CompileSource.ps1
Include bld\Generic-Compile.ps1

function Compile-Commands
{
    $sourceFiles = "Commands" | Get-FilesToCompile

    $referenceAssemblies = @() + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        $frameworkFile

    Generic-Compile $commandsFile $sourceFiles $referenceAssemblies
}
