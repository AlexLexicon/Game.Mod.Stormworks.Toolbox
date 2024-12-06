using Lexicom.Validation;
using System.Windows;
using System.Windows.Controls;

namespace Game.Mod.Stormworks.Toolbox.Client.Windows.Presentation.Controls;
public partial class SettingsTextBox : UserControl
{
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(SettingsTextBox), new PropertyMetadata(defaultValue: null));
    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(SettingsTextBox), new PropertyMetadata(defaultValue: null));
    public static readonly DependencyProperty ValidatorProperty = DependencyProperty.Register(nameof(Validator), typeof(IRuleSetValidator<string?>), typeof(SettingsTextBox), new PropertyMetadata(defaultValue: null));

    public SettingsTextBox() => InitializeComponent();

    public string? Title
    {
        get => (string?)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string? Text
    {
        get => (string?)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public IRuleSetValidator<string?>? Validator
    {
        get => (IRuleSetValidator<string?>)GetValue(ValidatorProperty);
        set => SetValue(ValidatorProperty, value);
    }
}
