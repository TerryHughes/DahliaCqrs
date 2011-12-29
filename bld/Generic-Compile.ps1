function Generic-Compile
{
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = 1)] [string]$outFile,
        [Parameter(Mandatory = 1)] [string[]]$sourceFiles,
        [Parameter(Mandatory = 0)] [string[]]$referenceAssemblies = @(),
        [Parameter(Mandatory = 0)] [string]$target = "library",
        [Parameter(Mandatory = 0)] [string]$options = $null
    )

    $references = $referenceAssemblies | % { "/r:" + $_ }

    if ($configuration -eq "Release")
    {
        $emitDebugInformation = "/debug-"
        $debugType = "pdbonly"
        $optimize = "/o+"
        $defineConstants = "TRACE;"
    }
    else
    {
        $emitDebugInformation = "/debug+"
        $debugType = "full"
        $optimize = "/o-"
        $defineConstants = "DEBUG;TRACE;"
    }

    Exec { csc /out:$outFile /t:$target $options $references $emitDebugInformation /debug:$debugType $optimize /d:$defineConstants /nologo $sourceFiles }
}
