

using System;
using System.Globalization;
using System.Linq;
using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;
using FluentIcons.Common;

namespace EvoComTest.Views.Converters;

public class IconConverter :  MarkupExtension ,IValueConverter
{
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string iconKey)
        {
            return Enum.GetValues<Symbol>()
                .FirstOrDefault(s => s.ToString() == iconKey);
        }

        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}