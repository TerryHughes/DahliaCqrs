Task Verify {
# no quotes around the pathing
    Exec { lib\Machine.Specifications\tools\mspec-clr4.exe bin\Dahlia.Specs.dll -s --html bin\mspec.htm }
}
