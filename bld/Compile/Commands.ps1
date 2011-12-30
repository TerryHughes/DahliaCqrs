Include bld\Utilities\Get-FilesToCompile.ps1
Include bld\Utilities\Generic-Compile.ps1

function Compile-Commands
{
    $sourceFiles = "Commands" | Get-FilesToCompile

    $referenceAssemblies = @() + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        $frameworkFile

    Generic-Compile $commandsFile $sourceFiles $referenceAssemblies
}
