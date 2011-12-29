Task Verify {
    cpi "lib\nservicebus\lib\net40\NServiceBus.dll" "bin"
    cpi "lib\Machine.Specifications\lib\Machine.Specifications.dll" "bin"

# TODO: no quotes around the pathing
    Exec { lib\Machine.Specifications\tools\mspec-clr4.exe bin\Dahlia.Specs.dll -s --html bin\mspec.htm }
}
