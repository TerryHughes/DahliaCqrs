Include bld\CompileSource.ps1
Include bld\GenericCompile.ps1

function Compile-DataCommon
{
    $sourceFiles = "Data", "Data.Common" | Get-FilesToCompile

    $referenceAssemblies = @() + `
        $compositionFile + `
        $frameworkFile

    GenericCompile $dataCommonFile $sourceFiles $referenceAssemblies 
}
