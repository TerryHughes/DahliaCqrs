$framework = "4.0"

Properties {
    $applicationName = "Dahlia"

    $configuration = "Debug"
}

Include bld\Clean.ps1
Include bld\Compile.ps1
Include bld\Verify.ps1
Include bld\Assemble.ps1

Task default -depends Clean, Compile, Verify, Assemble
