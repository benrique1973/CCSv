﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace ExtendedGrid.Converter
{
    internal class GroupByPathConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
}
