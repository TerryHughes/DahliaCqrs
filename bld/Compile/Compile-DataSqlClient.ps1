Include bld\CompileSource.ps1
Include bld\GenericCompile.ps1

function Compile-DataSqlClient
{
    $sourceFiles = "Data.SqlClient" | Get-FilesToCompile

    $referenceAssemblies = @() + `
        $compositionFile + `
        $dataCommonFile + `
        $frameworkFile

    GenericCompile $dataSqlClientFile $sourceFiles $referenceAssemblies
}
