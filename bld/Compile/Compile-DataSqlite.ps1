Include bld\CompileSource.ps1
Include bld\MakeDirectory.ps1

function Compile-DataSqlite
{
    Compile-DataSqliteBitness "x86"
    Compile-DataSqliteBitness "x64"
}

function Compile-DataSqliteBitness
{
    param(
        [Parameter(Mandatory = 1)] [string]$bitness
    )

    MakeDirectory "bin\$bitness"

    $sqliteBitnessFile = "lib\System.Data.SQLite.$bitness\lib\net40\System.Data.SQLite.dll"

    $sourceFiles = "Data.SQLite" | Get-FilesToCompile

    $sqliteBitnessReferenceAssemblies = @() + `
        $compositionFile + `
        $sqliteBitnessFile + `
        $frameworkFile + `
        $dataCommonFile

    $sqlite = @{}
    $sqlite.sourceFiles = $sourceFiles
    $sqlite.referenceAssemblies = $sqliteBitnessReferenceAssemblies
    $sqlite.outFile = "bin\$bitness\$dataSqliteFile"
    $sqlite.target = "library"

    $frameworkVersionBitness = $frameworkVersion + $bitness
    Invoke-psake "bld\BitnessCompile.ps1" "BitnessCompile" $frameworkVersionBitness -parameters $sqlite | Out-Null

    cpi $sqliteBitnessFile "bin\$bitness"
}
