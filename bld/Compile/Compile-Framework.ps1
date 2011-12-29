Include bld\CompileSource.ps1
Include bld\GenericCompile.ps1

function Compile-Framework
{
    $sourceFiles = "Framework" | Get-FilesToCompile

    GenericCompile $frameworkFile $sourceFiles
}
