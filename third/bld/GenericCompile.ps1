# Debug configuration compiler options
$script:emitDebugInformation = "/debug+"
$script:debugType = "full"
$script:optimize = "/o-"
$script:defineConstants = "DEBUG;TRACE;"

function GenericCompile
{
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = 1)] [string]$outFile,
        [Parameter(Mandatory = 1)] [string[]]$sourceFiles,
        [Parameter(Mandatory = 0)] [string[]]$referenceAssemblies = @(),
        [Parameter(Mandatory = 0)] [string]$target = "library",
        [Parameter(Mandatory = 0)] [string]$options = $null
    )

    if ($configuration -eq "Release")
    {
        UpdateCompilerOptionsForReleaseConfiguration
    }

    $references = $referenceAssemblies | % { "/r:" + $_ }

    Exec { csc /out:$outFile /t:$target $options $references $emitDebugInformation /debug:$debugType $optimize /d:$defineConstants /nologo $sourceFiles }
}

function UpdateCompilerOptionsForReleaseConfiguration
{
    $script:emitDebugInformation = "/debug-"
    $script:debugType = "pdbonly"
    $script:optimize = "/o+"
    $script:defineConstants = "TRACE;"
}
