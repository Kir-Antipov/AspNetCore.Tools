using System;

namespace AspNetCore.Tools.ViewModels.Internal
{
    [Flags]
    internal enum ModelBuilderStrategy
    {
        None,
        CreateAndBuild          = Create | Build,
        TryBuild                = Try | Build,
        CreateAndTryBuild       = Create | TryBuild,
        BuildAsync              = Build | Async,
        CreateAndBuildAsync     = Create | BuildAsync,
        TryBuildAsync           = Try | BuildAsync,
        CreateAndTryBuildAsync  = Create | TryBuildAsync,

        Build   = 0b0001,
        Create  = 0b0010,
        Async   = 0b0100,
        Try     = 0b1000
    }
}
