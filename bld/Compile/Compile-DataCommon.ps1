Include bld\Utilities\Get-FilesToCompile.ps1
Include bld\Utilities\Generic-Compile.ps1

function Compile-DataCommon
{
    $sourceFiles = "Data", "Data.Common" | Get-FilesToCompile

    $referenceAssemblies = @() + `
        $compositionFile + `
        $frameworkFile

    Generic-Compile $dataCommonFile $sourceFiles $referenceAssemblies 
}
