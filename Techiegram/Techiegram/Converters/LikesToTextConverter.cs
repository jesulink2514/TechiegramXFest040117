using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techiegram.Models;
using Xamarin.Forms;

namespace Techiegram.Converters
{
    public class LikesToTextConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ObservableCollection<User>)) return string.Empty;

            var likes = (ObservableCollection<User>)value;

            switch (likes.Count)
            {
                case 0:
                    return "Nobody likes this photo.";
                case 1:
                    var user = likes.First();
                    return $"{user.UserName} like this photo";
                default:
                    return $"{likes.Count} people like this photo";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
