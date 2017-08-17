using System;

using System.Windows.Data;
using System.Windows.Forms;

namespace SGPTmvvm.CustomValidationAttributes
{
    public class ConvertirItemEnIndice : IValueConverter
    {
        #region IValueConverter Members
        //Convertir una fila en un indice en un datagrid
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                ////Obteniendo el DataRowView that is being passed to the Converter
                //System.Data.DataRowView drv = (System.Data.DataRowView)value;
                ////Get the CollectionView from the DataGrid that is using the converter
                //DataGrid dg = (DataGrid)Application.Current.MainWindow.FindName("DG1");
                //CollectionView cv = (CollectionView)dg.Items;
                ////Get the index of the DataRowView from the CollectionView
                int rowindex =  1;

                return rowindex.ToString();
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }
        //One way binding, so ConvertBack is not implemented
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
