using Domain;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace BuzzerGui.Utility.Converters
{
    public class MessageToHorizontalAlignmentConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Hivemember sender = values[0] as Hivemember;
            Hivemember currentUser = values[1] as Hivemember;
            if (sender != null && currentUser != null)
            {
                if (sender.Id == currentUser.Id)
                {
                    return HorizontalAlignment.Right;
                }
                else
                {
                    return HorizontalAlignment.Left;
                }
            }
            return HorizontalAlignment.Center;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
