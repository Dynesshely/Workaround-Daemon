using System.Collections.Generic;

namespace Workaround.Shared;

public class UtilInfo
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Version { get; set; }

    public string? Authors { get; set; }

    public List<UtilAction> UtilActions { get; set; } = [];
}
