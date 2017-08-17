using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using SGPTWpf.Views.Compartidas;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Sumarias.Detalle
{

    public partial class DetalleCedulaView : UserControl
    {
        public delegate Point GetPosition(IInputElement element);
        public ObservableCollection<DetalleCedulaModelo> listaElementos;
        public DetalleCedulaModelo changedDetalleHerramientas;
        public DialogCoordinator dlg;

        #region tokenRecepcionVista

        private string _tokenRecepcionVista;
        private string tokenRecepcionVista
        {
            get { return _tokenRecepcionVista; }
            set { _tokenRecepcionVista = value; }
        }
        #endregion

        #region filaIndice

        private int _filaIndice;
        private int filaIndice
        {
            get { return _filaIndice; }
            set { _filaIndice = value; }
        }
        #endregion

        #region colIndice

        private int _colIndice;
        private int colIndice
        {
            get { return _colIndice; }
            set { _colIndice = value; }
        }
        #endregion

        #region ViewModel Properties : SelectedItems

        public const string SelectedItemsPropertyName = "SelectedItems";

        private ObservableCollection<DetalleCedulaModelo> _SelectedItems;

        public ObservableCollection<DetalleCedulaModelo> SelectedItems
        {
            get
            {
                return _SelectedItems;
            }
            set
            {
                if (_SelectedItems == value) return;

                _SelectedItems = value;
            }
        }

        #endregion

        #region tokenEnvioPadre

        private string _tokenEnvioPadre;
        private string tokenEnvioPadre
        {
            get { return _tokenEnvioPadre; }
            set { _tokenEnvioPadre = value; }
        }
        #endregion

        #region tokenEnvioPadreColumna

        private string _tokenEnvioPadreColumna;
        private string tokenEnvioPadreColumna
        {
            get { return _tokenEnvioPadreColumna; }
            set { _tokenEnvioPadreColumna = value; }
        }
        #endregion

        public DetalleCedulaView()
        {
            InitializeComponent();
            //Tamaño de pantalla
            double ancho = PrincipalAlterna.anchoFrame;
            double largo = PrincipalAlterna.MaxlargoFrame;

            this.Width = ancho - 205;
            this.Height = PrincipalAlterna.largoFrame - 42;

            MinWidth = Width * 0.6;
            MaxWidth = Width;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = Height * 0.5;
            MaxHeight = Height;

            datosConsulta.Width = Width - 7;
            datosConsulta.MinWidth = Width * 0.5;
            datosConsulta.MaxWidth = Width - 7;

            datosConsulta.Height = Height - 62;
            datosConsulta.MaxHeight = Height - 62;
            datosConsulta.MinHeight = Height * 0.5;

            dataGrid.Width = datosConsulta.Width - 1;
            dataGrid.MaxWidth = datosConsulta.MaxWidth - 1;
            dataGrid.MinWidth = datosConsulta.MaxWidth - 1;

            dataGrid.Height = datosConsulta.Height - 1;
            dataGrid.MaxHeight = datosConsulta.MaxHeight - 1;
            dataGrid.MinHeight = datosConsulta.MinHeight - 1;

            _tokenRecepcionVista = "datosControllerEncargoCedulasSumariasDetalleDatosVista";//Datos de controllador CatalogoCuentasViewModel
            _tokenEnvioPadre = "datosControllerEncargoCedulasSumariasDetallefila";//Datos de controllador CatalogoCuentasViewModel
            _tokenEnvioPadreColumna = "datosControllerEncargoCedulasSumariasDetalleColumna";

            colIndice = -1;
            filaIndice = -1;
            dataGrid.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(dataGrid_PreviewMouseLeftButtonDown);
        }

        void dataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int filaanterior = filaIndice;
            if (filaIndice != GetCurrentRowIndex(e.GetPosition))
            {
                filaIndice = GetCurrentRowIndex(e.GetPosition);
                //dataGrid.SelectedIndex = filaIndice;
                //MessageBox.Show("Fila " + filaIndice);
            }
            if (filaIndice != -1 && filaanterior != filaIndice)
            {
                //MessageBox.Show("fila " + filaIndice);
                Messenger.Default.Send<int>(filaIndice, tokenEnvioPadre);
            }            
        }
        private int GetCurrentRowIndex(GetPosition pos)
        {
            int curIndex = -1;
            for (int i = 0; i < dataGrid.Items.Count; i++)
            {
                DataGridRow itm = GetRowItem(i);
                if (GetMouseTargetRow(itm, pos))
                {
                    curIndex = i;
                    break;
                }
            }
            return curIndex;
        }
        private DataGridRow GetRowItem(int index)
        {
            if (dataGrid.ItemContainerGenerator.Status
                    != GeneratorStatus.ContainersGenerated)
                return null;
            return dataGrid.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
        }
        private bool GetMouseTargetRow(Visual theTarget, GetPosition position)
        {
            try
            {
                if (theTarget != null)
                {
                    Rect rect = VisualTreeHelper.GetDescendantBounds(theTarget);
                    Point point = position((IInputElement)theTarget);
                    return rect.Contains(point);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Error en  evento");
                return false;
            }

        }

        private void getColumn_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            int anterior = colIndice;
            if (colIndice != e.Column.DisplayIndex)
            {
                colIndice = e.Column.DisplayIndex;
                int valor = e.Column.DisplayIndex;
                //MessageBox.Show("Columna " + colIndice);
            }
            if (colIndice != -1 && anterior!=colIndice )
            {
                //MessageBox.Show("columna :" + colIndice);
                Messenger.Default.Send<int>(colIndice, tokenEnvioPadreColumna);
            }
        }

        //https://social.msdn.microsoft.com/Forums/en-US/d7aeab5f-f60e-4200-b990-fa056fdf475d/get-the-index-of-selected-cell-in-a-datagrid-mvvm?forum=wpf
        private void dataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGrid.CurrentCell != null)
            {
                int columnIndex = dataGrid.CurrentCell.Column.DisplayIndex;
                int rowIndex = dataGrid.Items.IndexOf(dataGrid.CurrentItem);
                MessageBox.Show("The Cell Row Is: " + rowIndex + "\n" + "The Cell Column Is: " + columnIndex);
                    int colAnterior = colIndice;
                    colIndice = dataGrid.CurrentCell.Column.DisplayIndex;
                    int filaAnterior = filaIndice;

                    filaIndice = dataGrid.Items.IndexOf(dataGrid.CurrentItem);

                    if ((filaIndice != -1 && filaAnterior != filaIndice) || (colIndice != -1 && colAnterior != colIndice))
                    {
                        enviarMensaje(columnIndex, rowIndex);
                    }
            }
        }

        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var dg = sender as DataGrid;
            if (dg != null && e.AddedCells != null && e.AddedCells.Count > 0)
            {
                var cell = e.AddedCells[0];
                if (!cell.IsValid)
                    return;
                var generator = dg.ItemContainerGenerator;
                int columnIndex = cell.Column.DisplayIndex; //OK as long user can't reorder
                                                            //int rowIndex = generator.IndexFromContainer(generator.ContainerFromItem(cell.Item));
                int rowIndex = dataGrid.Items.IndexOf(dataGrid.CurrentItem);
                //MessageBox.Show("The Cell Row Is: " + rowIndex + "\n" + "The Cell Column Is: " + columnIndex);
                enviarMensaje(columnIndex, rowIndex);
            }

        }
        //https://social.msdn.microsoft.com/Forums/en-US/d7aeab5f-f60e-4200-b990-fa056fdf475d/get-the-index-of-selected-cell-in-a-datagrid-mvvm?forum=wpf
        //https://social.technet.microsoft.com/wiki/contents/articles/21202.wpf-programmatically-selecting-and-focusing-a-row-or-cell-in-a-datagrid.aspx
        /* private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
         {
             var dg = sender as DataGrid;
             if (dg != null && e.AddedCells != null && e.AddedCells.Count > 0)
             {
                 var cell = e.AddedCells[0];
                 if (!cell.IsValid)
                     return;
                 var generator = dg.ItemContainerGenerator;
                 int columnIndex = cell.Column.DisplayIndex; //OK as long user can't reorder
                 int rowIndex = generator.IndexFromContainer(generator.ContainerFromItem(cell.Item));
                 MessageBox.Show("fila " + rowIndex + "\n" + "columna " + columnIndex);
                 enviarMensaje(columnIndex, rowIndex);
                 //TODO assign indexes to VM
             }
         }*/
        public void enviarMensaje(int columna, int fila)
        {
            celdaSeleccionadaMsj msj = new celdaSeleccionadaMsj();
            msj.fila = fila;
            msj.columna = columna;
            //msj.registro= dataGrid.CurrentItem as DetalleCedulaModelo;
            Messenger.Default.Send<celdaSeleccionadaMsj>(msj, tokenEnvioPadre);
        }

    }
}