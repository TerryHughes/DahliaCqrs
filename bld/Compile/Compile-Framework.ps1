Include bld\Utilities\Get-FilesToCompile.ps1
Include bld\Utilities\Generic-Compile.ps1

function Compile-Framework
{
    $sourceFiles = "Framework" | Get-FilesToCompile

    Generic-Compile $frameworkFile $sourceFiles
}
