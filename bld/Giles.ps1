Include bld\Utilities\Make-Directory.ps1

Task Giles {
    Make-Directory "tst"

    cpi "lib\nservicebus\lib\net40\NServiceBus.dll" "tst"
    cpi "lib\Machine.Specifications\lib\Machine.Specifications.dll" "tst"

    cpi "bin\Dahlia.Framework.dll" "tst"
    cpi "bin\Dahlia.Events.dll" "tst"
    cpi "bin\Dahlia.Domain.dll" "tst"
    cpi "bin\Dahlia.Commands.dll" "tst"
    cpi "bin\Dahlia.CommandProcessor.dll" "tst"
    cpi "bin\Dahlia.Testing.dll" "tst"
    cpi "bin\Dahlia.Specs.dll" "tst"
}
