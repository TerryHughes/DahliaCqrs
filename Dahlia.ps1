$framework = "4.0"

Include bld\Assemble.ps1
Include bld\Clean.ps1
Include bld\Compile.ps1
Include bld\Verify.ps1

Properties {
    $applicationName = "Dahlia"

    $configuration = "Debug"
}

Task default -depends Clean, Compile, Verify, Assemble
