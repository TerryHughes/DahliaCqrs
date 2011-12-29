Include bld\Get-FilesToCompile.ps1
Include bld\Generic-Compile.ps1

function Compile-Framework
{
    $sourceFiles = "Framework" | Get-FilesToCompile

    Generic-Compile $frameworkFile $sourceFiles
}
