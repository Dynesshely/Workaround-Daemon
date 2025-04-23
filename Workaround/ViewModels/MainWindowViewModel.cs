using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.Linq;
using ReactiveUI;
using Workaround.Contract;
using Workaround.Shared;

namespace Workaround.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        var path = $"{System.AppContext.BaseDirectory}/Utils";

        var catalog = new DirectoryCatalog(path, "*.dll");

        var container = new CompositionContainer(catalog);

        var sub = container.GetExportedValues<IIdentifier>();

        if (sub is not null)
            foreach (var item in sub)
            {
                var info = item.GetInfo();

                Debug.WriteLine($"Got info: {info.Name}");

                ActionsProviders.Add(info);
            }

        SelectedUtil = ActionsProviders.FirstOrDefault();
    }

    private int _selectedIndex;

    public int SelectedIndex
    {
        get => _selectedIndex;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedIndex, value);

            SelectedUtil = ActionsProviders[value];
        }
    }

    public UtilInfo? _selectedUtilInfo;

    public UtilInfo? SelectedUtil
    {
        get => _selectedUtilInfo;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedUtilInfo, value);

            this.RaisePropertyChanged(nameof(Authors));
        }
    }

    public ObservableCollection<UtilInfo> ActionsProviders { get; set; } = [];

    public IEnumerable<string> Authors => SelectedUtil?.Authors?.Split(',')?.Prepend("Authors: ") ?? [];
}
