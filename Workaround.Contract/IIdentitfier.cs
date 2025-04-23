using System.ComponentModel.Composition;
using Workaround.Shared;

namespace Workaround.Contract;

[InheritedExport]
public interface IIdentifier
{
    public UtilInfo GetInfo();
}
