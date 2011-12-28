Task Verify {
# no quotes around the pathing
    cpi "lib\nservicebus\lib\net40\NServiceBus.dll" "bin"
    cpi "lib\Machine.Specifications\lib\Machine.Specifications.dll" "bin"

    Exec { lib\Machine.Specifications\tools\mspec-clr4.exe bin\Dahlia.Specs.dll -s --html bin\mspec.htm }
}
