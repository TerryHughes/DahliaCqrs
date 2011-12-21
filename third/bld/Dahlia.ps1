$framework = "4.0"

Properties {
    $applicationName = "Dahlia"

    $configuration = "Debug"
}

Include Clean.ps1
Include Compile.ps1
Include Assemble.ps1

Task default -depends Clean, Compile, Assemble
