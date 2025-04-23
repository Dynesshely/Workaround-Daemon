using Workaround.Contract;
using Workaround.Shared;

namespace Enhancer.Windows.InputMethod;

public class Program : IIdentifier
{
    public UtilInfo GetInfo() =>
        new()
        {
            Name = "Windows Input Method Enhancer",
            Description = "Enhance your windows input method experience.",
            Version = "0.0.1",
            Authors = "Dynesshely",
            UtilActions =
            [
                new UtilAction()
                {
                    Name = "Simplified Chinese Input Mode Guard",
                    Description = "To fix the issue that the input method can not stay on default input mode.",
                    CanExecute = true,
                    IsNeedToRestart = true,
                    Execution = () => { },
                    Reopener = () => { },
                    EnabledChecker = () => false,
                },
            ],
        };
}
