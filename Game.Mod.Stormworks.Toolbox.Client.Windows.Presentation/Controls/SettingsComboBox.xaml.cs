using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Game.Mod.Stormworks.Toolbox.Client.Windows.Presentation.Controls;
public partial class SettingsComboBox : UserControl
{
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(SettingsComboBox), new PropertyMetadata(defaultValue: null));
    public static readonly DependencyProperty ValuesProperty = DependencyProperty.Register(nameof(Values), typeof(ObservableCollection<string>), typeof(SettingsComboBox), new PropertyMetadata(defaultValue: new ObservableCollection<string>()));
    public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.Register(nameof(SelectedValue), typeof(string), typeof(SettingsComboBox), new PropertyMetadata(defaultValue: null));
    public static readonly DependencyProperty SelectedValueChangedCommandProperty = DependencyProperty.Register(nameof(SelectedValueChangedCommand), typeof(ICommand), typeof(SettingsComboBox), new PropertyMetadata(defaultValue: null));

    public SettingsComboBox() => InitializeComponent();

    public ICommand? SelectedValueChangedCommand
    {
        get => (ICommand?)GetValue(SelectedValueChangedCommandProperty);
        set => SetValue(SelectedValueChangedCommandProperty, value);
    }

    public string? Title
    {
        get => (string?)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public ObservableCollection<string> Values
    {
        get => (ObservableCollection<string>)GetValue(ValuesProperty);
        set
        {
            SetValue(ValuesProperty, value);

            ArgumentNullException.ThrowIfNull(Values);
        }
    }

    public string? SelectedValue
    {
        get => (string?)GetValue(SelectedValueProperty);
        set => SetValue(SelectedValueProperty, value);
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        SelectedValueChangedCommand?.Execute(e);
    }
}
