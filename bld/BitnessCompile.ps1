# TODO: why is this not needed?
#Include bld\GenericCompile.ps1

Task BitnessCompile {
    pushd
    cd ".."

    if ($parameters.target -eq $null) {
        $parameters.target = "library"
    }

    $bitness = $framework.Substring(3)
    $parameters.options = "/platform:$bitness"

    GenericCompile $parameters.outFile $parameters.sourceFiles $parameters.referenceAssemblies $parameters.target $parameters.options

    popd
}
