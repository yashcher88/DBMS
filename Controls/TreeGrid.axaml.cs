using Avalonia;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DBMS.Classes;
using System;
using System.Collections.ObjectModel;
using System.Globalization;

namespace DBMS;
public class Property
{
    public Property(string name, string value)
    {
        Name = name;
        Value = value;
    }
    public string Name { get; set; }
    public string Value { get; set; }
}

public class PropertyGroup : Avalonia.AvaloniaObject
{
    public PropertyGroup(string groupName)
    {
        GroupName = groupName;
    }
    public string GroupName { get; set; }
    public static readonly AvaloniaProperty<bool> IsExpandedProperty =
        AvaloniaProperty.Register<PropertyGroup, bool>(nameof(IsExpanded), true);
    public bool IsExpanded
    {
        get => (bool)GetValue(IsExpandedProperty);
        set => SetValue(IsExpandedProperty, value);
    }
    public ObservableCollection<Property> Items { get; set; } = new();
}

// Конвертер стрелочки (▼ / ▶)
public class BoolToArrowConverter : IValueConverter
{
    public static readonly BoolToArrowConverter Instance = new();
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (bool)value ? "▼" : "▶";
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}

public partial class TreeGrid : BaseUserControl
{
    public TreeGrid()
    {
        InitializeComponent(); 
        var groups = new ObservableCollection<PropertyGroup>
            {
                new PropertyGroup("Основные настройки")
                {
                    Items =
                    {
                        new Property("OID", "672550"),
                        new Property("Имя", "apt_db"),
                        new Property("Владелец", "postgres"),
                        new Property("Шаблон базы данных", "❌"),
                    }
                },
                new PropertyGroup("Сопоставление")
                {
                    Items =
                    {
                        new Property("Кодировка", "UTF8"),
                        new Property("Категория сортировки", "ru_RU.UTF-8"),
                        new Property("Категория типов символов", "ru_RU.UTF-8"),
                    }
                },
                new PropertyGroup("Дополнительно")
                {
                    Items =
                    {
                        new Property("Размер базы данных", "32 GB"),
                        new Property("Дата создания", "16.10.2024 00:13:31"),
                    }
                }
            };

        GroupsList.ItemsSource = groups;
    }
    private void OnGroupHeaderClick(object sender, PointerPressedEventArgs e)
    {
        if (sender is StackPanel panel && panel.DataContext is PropertyGroup group)
        {
            group.IsExpanded = !group.IsExpanded;
        }
    }
    public void SelectAll(object sender, RoutedEventArgs e)
    {

    }
    public void Copy(object sender, RoutedEventArgs e)
    {

    }
}