using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DBMS.Classes;
using DBMS.Classes.Base;
using Dock.Model.Core;
using Dock.Model.Mvvm.Core;
using Dock.Model.Avalonia.Controls;

namespace DBMS.WindowDocks;

public partial class ObjectExplorer : Tool
{
    public ObjectExplorer()
    {
        InitializeComponent();
    }
}