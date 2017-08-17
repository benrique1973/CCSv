using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.Views.Compartidas;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace SGPTWpf.SGPtWpf.Views.Principales.Documentos.Consulta
{
    /// <summary>
    /// Lógica de interacción para DetalleIndiceConsultaView.xaml
    /// </summary>
    public partial class DetalleIndiceConsultaView : UserControl
    {
        public delegate Point GetPosition(IInputElement element);
        int rowIndex = -1;
        public ObservableCollection<IndiceModelo> listaDetallePlantillaIndice;
        public IndiceModelo changedIndiceModelo;
        public DialogCoordinator dlg;

        #region tokenRecepcionVista

        private string _tokenRecepcionVista;
        private string tokenRecepcionVista
        {
            get { return _tokenRecepcionVista; }
            set { _tokenRecepcionVista = value; }
        }

        #endregion

        #region tokenActualizacionLista

        private string _tokenActualizacionLista;
        private string tokenActualizacionLista
        {
            get { return _tokenActualizacionLista; }
            set { _tokenActualizacionLista = value; }
        }

        #endregion
        public DetalleIndiceConsultaView()
        {
            InitializeComponent();
            _tokenActualizacionLista = "EncargoPlanIndiceCambioOrden";
            _tokenRecepcionVista = "EncargoPlanIndiceDetalleDatosVista";//Identifica la fuente de un mensaje generico

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
            dataGrid.MaxWidth = datosConsulta.MinWidth - 1;
            dataGrid.MinWidth = datosConsulta.MaxWidth - 1;

            dataGrid.Height = datosConsulta.Height - 1;
            dataGrid.MaxHeight = datosConsulta.MaxHeight - 1;
            dataGrid.MinHeight = datosConsulta.MinHeight - 1;

            //Ordenamiento
            dlg = new DialogCoordinator();
            changedIndiceModelo = null;
            dataGrid.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(dataGrid_PreviewMouseLeftButtonDown);
            dataGrid.Drop += new DragEventHandler(dataGrid_Drop);
            Messenger.Default.Register<ObservableCollection<IndiceModelo>>(this, tokenRecepcionVista, (listaDetalle) => ControllistaDetalle(listaDetalle));
        }

        private void ControllistaDetalle(ObservableCollection<IndiceModelo> listaMensaje)
        {
            listaDetallePlantillaIndice = listaMensaje;
        }


        void dataGrid_Drop(object sender, DragEventArgs e)
        {
            decimal factor = 0;
            decimal? contador = 1;
            //decimal? contadorHijos = 1;
            //int cantidadRegistros = 0;


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
            changedIndiceModelo = listaDetallePlantillaIndice[rowIndex];
            listaDetallePlantillaIndice.RemoveAt(rowIndex);
            listaDetallePlantillaIndice.Insert(index, changedIndiceModelo);
            listaDetallePlantillaIndice[index].guardadoBase = false;
            //Reordenar los principales
            //Reordenamiento
            #region listas

            ObservableCollection<IndiceModelo> listaHijos = new ObservableCollection<IndiceModelo>();
            ObservableCollection<IndiceModelo> listaPadres = new ObservableCollection<IndiceModelo>();
            ObservableCollection<IndiceModelo> listaDetalle = new ObservableCollection<IndiceModelo>();

            #endregion


            #region reordenamiento
            try
            {
                contador = 10;
                //decimal factor = 0;//Para cambiar el orden
                foreach (IndiceModelo itemDetalle in listaDetallePlantillaIndice)
                {
                    if (itemDetalle.indidindice == null)
                    {
                        if (itemDetalle.ordenindice != contador)
                        {
                            itemDetalle.guardadoBase = false;
                        }

                        //Se asigna el orden a los principales
                        itemDetalle.ordenindice = (decimal)contador;
                        //itemDetalle.ordendpPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordenindice);
                        itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordenindice);
                        itemDetalle.descripcionPresentacion = itemDetalle.descripcionindice;
                        /*if (guardar)
                        {
                            IndiceModelo.UpdateModeloReodenar(itemDetalle);
                            //Se modifica el orden para mantener una estandarizacion
                        }*/
                        listaDetalle.Add(itemDetalle);
                        if (listaDetallePlantillaIndice.Where(x => x.indidindice == itemDetalle.idindice).Count() > 0)
                        {
                            listaPadres.Add(itemDetalle);
                        }
                        contador = contador + 10;
                    }
                }
                //Corrigiendo los sub-procedimientos
                bool salir = false;
                factor = (decimal)0.1;
                string desplazar = "  ";
                int ciclos = listaPadres.Count();

                do
                {
                    if (listaPadres.Count > 0)
                    {
                        if (ciclos == 0)
                        {
                            factor = factor / 10;
                            desplazar = desplazar + desplazar;
                            ciclos = listaPadres.Count();
                        }
                        salir = true;//No sale volvera a recorrerla
                                     //Recorrer todos los  que tienen hijos
                        listaHijos = new ObservableCollection<IndiceModelo>(listaDetallePlantillaIndice.Where(x => x.indidindice == listaPadres[0].idindice));
                        if (listaHijos.Count > 0)
                        {
                            //Hay hijos
                            contador = (decimal)listaPadres[0].ordenindice;
                            //factor = MetodosModelo.factorPadreIndice(item.descripciontei);
                            int j = 1;
                            foreach (IndiceModelo hijo in listaHijos)
                            {
                                //Es un hijo
                                if (hijo.ordenindice != Decimal.Add((decimal)contador, factor * j))
                                {
                                    hijo.guardadoBase = false;
                                }
                                hijo.ordenindicePadre = (decimal)contador;
                                hijo.ordenindice = Decimal.Add((decimal)contador, factor * j);
                                hijo.ordenDhPresentacion = MetodosModelo.ordenConversion(hijo.ordenindice);
                                hijo.descripcionPresentacion = desplazar + hijo.descripcionindice;

                                hijo.indiceModeloPadre = listaPadres[0]; ;
                                hijo.descripcionPresentacionPadre = hijo.indiceModeloPadre.descripcionindice;

                                j++;
                                /*if (guardar)
                                {
                                    IndiceModelo.UpdateModeloReodenar(hijo);
                                    //Se modifica el orden para mantener una estandarizacion
                                }**/
                                //Agregar a la lista
                                listaDetalle.Add(hijo);
                                //Verificar que no tenga hijos
                                if (listaDetallePlantillaIndice.Where(x => x.indidindice == hijo.idindice).Count() > 0)
                                {
                                    listaPadres.Add(hijo);
                                }
                            }
                        }
                        listaPadres.Remove(listaPadres[0]);
                        ciclos--;
                    }
                    else
                    {
                        salir = false;//Termino el proceso, salir
                    }

                } while (salir);

            }
            catch (Exception)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception generar el orden \n");
                listaDetallePlantillaIndice.OrderBy(x => x.ordenindice).ToList();
                //throw;
            }

            #endregion fin reordenamiento

            //Reordenar la lista
            ObservableCollection<IndiceModelo> ListaOrdenada = new ObservableCollection<IndiceModelo>(listaDetalle.OrderBy(x => x.ordenindice));
            for (int i = 0; i < listaDetallePlantillaIndice.Count(); i++)
            {
                changedIndiceModelo = ListaOrdenada[i];
                listaDetallePlantillaIndice.RemoveAt(i);
                listaDetallePlantillaIndice.Insert(i, changedIndiceModelo);
                //listaDetallePlantillaIndice[i].guardadoBase = true;
            }
            foreach (IndiceModelo item in listaDetallePlantillaIndice)
            {
                item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordenindice);
            }
            notificarCambio(); //Para darle agilidad se  elimina
        }
        private void notificarCambio()
        {
            //Para sub-ventana
            //Se crea el mensaje
            Messenger.Default.Send<bool>(true, tokenActualizacionLista);
        }
        void dataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            rowIndex = GetCurrentRowIndex(e.GetPosition);
            if (rowIndex < 0)
                return;
            dataGrid.SelectedIndex = rowIndex;
            IndiceModelo selectedDetalleHerramientas = dataGrid.Items[rowIndex] as IndiceModelo;
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
