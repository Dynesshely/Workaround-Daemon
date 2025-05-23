﻿namespace Workaround.Shared;

public class UtilAction
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool CanExecute { get; set; }

    public bool IsNeedToRestart { get; set; }

    public bool IsEnabled => CanExecute && !EnabledChecker();

    public Action Execution { get; set; } = () => { };

    public Action Reopener { get; set; } = () => { };

    public Func<bool> EnabledChecker { get; set; } = () => false;
};
