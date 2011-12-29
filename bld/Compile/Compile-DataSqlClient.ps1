Include bld\CompileSource.ps1
Include bld\Generic-Compile.ps1

function Compile-DataSqlClient
{
    $sourceFiles = "Data.SqlClient" | Get-FilesToCompile

    $referenceAssemblies = @() + `
        $compositionFile + `
        $dataCommonFile + `
        $frameworkFile

    Generic-Compile $dataSqlClientFile $sourceFiles $referenceAssemblies
}
