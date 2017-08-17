using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace SGPTWpf.Support.Conversores
{ 
public sealed class  BinaryImageConverter : IValueConverter
{
       object IValueConverter.Convert(object value,
            Type targetType,
            object parameter,
            System.Globalization.CultureInfo cultureInfo)
        {
            if (value != null && value is byte[])
            {
                byte[] bytes = value as byte[];

                MemoryStream stream = new MemoryStream(bytes);

                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = stream;
                image.EndInit();

                return image;
            }

            return null;
        }

        object IValueConverter.ConvertBack(object value,
            Type targetType,
            object parameter,
            System.Globalization.CultureInfo cultureInfo)
        {
            throw new Exception("The method or operation is not implemented.");
        }

    }
    //Fuente: 
    [ValueConversion(typeof(byte[]), typeof(BitmapImage))]
    public class ConvertByteArrayToBitmapImage : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo cultureInfo)
        {
            try
            {
                byte[] res;
                res = value as byte[];
                BitmapImage b = new BitmapImage();

                MemoryStream ms = new MemoryStream(res);

                b.BeginInit();
                b.CacheOption = BitmapCacheOption.OnLoad;
                b.StreamSource = ms;
                b.EndInit();
                return b;
            }
            catch
            {
                return value;
            }
        }
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo cultureInfo)
        {
            try
            {
                byte[] res;
                string path = (value as BitmapImage).UriSource.OriginalString;
                FileStream sr = new FileStream(path, FileMode.Open, FileAccess.Read);
                res = new byte[sr.Length];
                sr.Read(res, 0, res.Length);
                return res;
            }
            catch
            {
                return value;
            }
        }
    }

}