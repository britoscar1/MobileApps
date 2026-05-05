using System.Globalization;

namespace Demo_FinalProject;

public sealed class BoolToSuccessColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value is true ? Color.FromArgb("#16A34A") : Color.FromArgb("#0F172A");

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
