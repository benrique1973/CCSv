using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using SGPTWpf.Views.Compartidas;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion
{
    /// <summary>
    /// Lógica de interacción para CatalogoCuentasView.xaml
    /// </summary>
    public partial class CatalogoCuentasView : UserControl
    {
        public delegate Point GetPosition(IInputElement element);
        int rowIndex = -1;
        public ObservableCollection<CatalogoCuentasModelo> listaDetalleHerramienta;
        public CatalogoCuentasModelo changedDetalleHerramientas;
        public DialogCoordinator dlg;

        #region tokenRecepcionVista

        private string _tokenRecepcionVista;
        private string tokenRecepcionVista
        {
            get { return _tokenRecepcionVista; }
            set { _tokenRecepcionVista = value; }
        }
        #endregion

        #region ViewModel Properties : SelectedItems

        public const string SelectedItemsPropertyName = "SelectedItems";

        private ObservableCollection<CatalogoCuentasModelo> _SelectedItems;

        public ObservableCollection<CatalogoCuentasModelo> SelectedItems
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

        public CatalogoCuentasView()
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

            datosConsulta.Width = Width - 5;
            datosConsulta.MinWidth = Width * 0.5;
            datosConsulta.MaxWidth = Width - 5;

            datosConsulta.Height = Height - 57;
            datosConsulta.MaxHeight = Height - 57;
            datosConsulta.MinHeight = Height * 0.5;

            dataGrid.Width = datosConsulta.Width - 5;
            dataGrid.MaxWidth = datosConsulta.MinWidth - 5;
            dataGrid.MinWidth = datosConsulta.MaxWidth - 5;

            dataGrid.Height = datosConsulta.Height - 1;
            dataGrid.MaxHeight = datosConsulta.MaxHeight - 1;
            dataGrid.MinHeight = datosConsulta.MinHeight - 1;

            _tokenRecepcionVista = "datosEDCatalogoCuentas";//Datos de controllador CatalogoCuentasViewModel
            _tokenEnvioPadre = "datosControllerCatalogoCuentas";//Datos de controllador CatalogoCuentasViewModel

            dlg = new DialogCoordinator();
            changedDetalleHerramientas = null;
            dataGrid.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(dataGrid_PreviewMouseLeftButtonDown);
            dataGrid.Drop += new DragEventHandler(dataGrid_Drop);
            Messenger.Default.Register<EncargoDCCDetalleCuentasListaMsj>(this, tokenRecepcionVista, (herramientasDetalleListaMensaje) => ControlHerramientasDetalleListaMensaje(herramientasDetalleListaMensaje));


        }
        private void ControlHerramientasDetalleListaMensaje(EncargoDCCDetalleCuentasListaMsj herramientasDetalleListaMensaje)
        {
            listaDetalleHerramienta = herramientasDetalleListaMensaje.listaElementos;

        }

        void dataGrid_Drop(object sender, DragEventArgs e)
        {
            //Permite gestionar los registros con dependencias
            CatalogoCuentasModelo padre = new CatalogoCuentasModelo();
            bool masHijos = false;//Bandera para salir del ciclo
            decimal contador = 1;
            decimal contadorPadre = 1;
            int escalarCuenta = 100000;
            decimal factor = 0;//Para cambiar el orden
            int cuenta = 1;
            if (rowIndex < 0)
                return;
            int index = this.GetCurrentRowIndex(e.GetPosition);
            if (index < 0)
                return;
            if (index == rowIndex)
                return;
            if (index == dataGrid.Items.Count - 1)
            {
                //dlg.ShowMessageAsync(this, "El registro no puede ser eliminado ","");
                return;
            }
            changedDetalleHerramientas = listaDetalleHerramienta[rowIndex];
            listaDetalleHerramienta.RemoveAt(rowIndex);
            listaDetalleHerramienta.Insert(index, changedDetalleHerramientas);
            //Se utiliza para repetir el ciclo
            ObservableCollection<CatalogoCuentasModelo> listaPadres = new ObservableCollection<CatalogoCuentasModelo>();

            if (!(listaDetalleHerramienta[index].catidcc == null || listaDetalleHerramienta[index].catidcc == 0))
            {
                //Es un subprocedimiento
                do
                {
                    cuenta = 1;
                    if (!masHijos)
                    {
                        //Se recoge al padre y sus datos
                        padre = listaDetalleHerramienta.Where(x => x.idcc == listaDetalleHerramienta[index].catidcc).SingleOrDefault();
                        listaPadres.Add(padre);//Se identifica al padre
                    }
                    else
                    {
                        padre = listaPadres[0];//Siempre procesa el primer registro
                    }
                    contador = (decimal)padre.ordencc;
                    //Se identifico el orden en que esta presentado y se guarda en contador
                    foreach (CatalogoCuentasModelo itemDetalle in listaDetalleHerramienta)
                    {
                        if (itemDetalle.catidcc == padre.idcc)
                        {
                            //Es un hijo
                            factor = MetodosModelo.factorHijoCatalogo(itemDetalle.nombreClaseCuenta);
                            itemDetalle.ordencc = Decimal.Add((decimal)contador, factor * cuenta);
                            itemDetalle.ordenccPadre = contador;
                            cuenta++;
                            itemDetalle.guardadoBase = false;
                            itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordencc);
                            //Verificar si tiene hijos
                            if (listaDetalleHerramienta.Where(x => x.catidcc == itemDetalle.idcc).Count() > 0)
                            {
                                //Tiene dependientes es agregado a la lista para procesarlos
                                listaPadres.Add(itemDetalle);
                            }
                        }

                    }
                    listaPadres.Remove(padre);//Padre fue procesado
                    if (listaPadres.Count == 0)
                    {
                        masHijos = false;
                        //Termina el ciclo
                    }
                    else
                    {
                        masHijos = true;
                    }
                }
                while (masHijos);
            }
            else
            {
                //Es un procedimiento principal debe reordenarse 
                foreach (CatalogoCuentasModelo item in listaDetalleHerramienta)
                {
                    if (item.catidcc == null || item.catidcc == 0)
                    {
                        item.ordencc = contador*escalarCuenta;
                        item.guardadoBase = false;
                        //Se cambian los ordenes de los hijos
                        if(listaDetalleHerramienta.Where(x => x.catidcc == item.idcc).Count() > 0)
                        { 
                        //El registro tiene hijos
                        masHijos = false;
                        do
                        {
                            cuenta = 1;
                            if (!masHijos)
                            {
                                //Se recoge al padre y sus datos
                                padre = item;
                                listaPadres.Add(padre);//Se identifica al padre
                            }
                            else
                            {
                                padre = listaPadres[0];//Siempre procesa el primer registro
                            }
                            contadorPadre = (decimal)padre.ordencc;
                            //Se identifico el orden en que esta presentado y se guarda en contador
                            foreach (CatalogoCuentasModelo itemDetalle in listaDetalleHerramienta)
                            {
                                if (itemDetalle.catidcc == padre.idcc)
                                {
                                    //Es un hijo
                                    factor = MetodosModelo.factorHijoCatalogo(itemDetalle.nombreClaseCuenta);
                                    itemDetalle.ordencc = Decimal.Add((decimal)contadorPadre, factor * cuenta);
                                    itemDetalle.ordenccPadre = contadorPadre;
                                    cuenta++;
                                    itemDetalle.guardadoBase = false;
                                    itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordencc);
                                    //Verificar si tiene hijos
                                    if (listaDetalleHerramienta.Where(x => x.catidcc == itemDetalle.idcc).Count() > 0)
                                    {
                                        //Tiene dependientes es agregado a la lista para procesarlos
                                        listaPadres.Add(itemDetalle);
                                    }
                                }

                            }
                            listaPadres.Remove(padre);//Padre fue procesado
                            if (listaPadres.Count == 0)
                            {
                                masHijos = false;
                                //Termina el ciclo
                            }
                            else
                            {
                                masHijos = true;
                            }
                        }
                        while (masHijos);

                        }
                        //Aumenta el contador
                        contador++;
                    }
                }
            }
            //Reordenar la lista
            var ListaOrdenada = listaDetalleHerramienta.OrderBy(p => p.ordencc).ToList();
            //var ListaOrdenada = CatalogoCuentasModelo.RegeneraOrdenSubRegistros(listaDetalleHerramienta, false);
                //ListaOrdenada.OrderBy(p=>p.ordencc);
            for (int i = 0; i < listaDetalleHerramienta.Count(); i++)
            {
                changedDetalleHerramientas = ListaOrdenada[i];
                listaDetalleHerramienta.RemoveAt(i);
                listaDetalleHerramienta.Insert(i, changedDetalleHerramientas);
            }
            //listaDetalleHerramienta.OrderBy(x => x.ordencc);
            notificarCambio();// Para guardar los cambios
        }

        private void notificarCambio()
        {
           //Para sub-ventana
            //Se crea el mensaje
            Messenger.Default.Send<bool>(true, tokenEnvioPadre);
        }

        void dataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            rowIndex = GetCurrentRowIndex(e.GetPosition);
            if (rowIndex < 0)
                return;
            dataGrid.SelectedIndex = rowIndex;
            CatalogoCuentasModelo selectedDetalleHerramientas = dataGrid.Items[rowIndex] as CatalogoCuentasModelo;
            if (selectedDetalleHerramientas == null)
                return;
            DragDropEffects dragdropeffects = DragDropEffects.Move;
            if (DragDrop.DoDragDrop(dataGrid, selectedDetalleHerramientas, dragdropeffects)
            != DragDropEffects.None)
            {
                dataGrid.SelectedItem = selectedDetalleHerramientas;
            }
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
        private DataGridRow GetRowItem(int index)
        {
            if (dataGrid.ItemContainerGenerator.Status
                    != GeneratorStatus.ContainersGenerated)
                return null;
            return dataGrid.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
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
    }
}
