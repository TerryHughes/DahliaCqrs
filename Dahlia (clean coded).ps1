$framework = "4.0"

Properties {
    $applicationName = "Dahlia"

    $configuration = "Debug"
}

Include bld\Clean.ps1
Include bld\Compile.ps1
Include bld\Assemble.ps1

Task default -depends Clean, Compile, Assemble

#Verify
#Exec { lib\Machine.Specifications\tools\mspec-clr4.exe $specsFile -s --html "bin\mspec.htm" }