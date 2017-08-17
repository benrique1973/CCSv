using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Messages.Herramientas;
using SGPTWpf.SGPtWpf.Messages.Encargos;
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

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Cuestionario
{
    /// <summary>
    /// Lógica de interacción para DetalleCuestionarioEdicionView.xaml
    /// </summary>
    public partial class DetalleCuestionarioEdicionView : UserControl
    {
        public delegate Point GetPosition(IInputElement element);
        int rowIndex = -1;
        public ObservableCollection<DetalleCuestionarioModelo> listaDetalleHerramienta;
        public DetalleCuestionarioModelo changedDetalleHerramientas;
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

        public DetalleCuestionarioEdicionView()
        {
            InitializeComponent();
            _tokenRecepcionVista = "listaDetalleCuestionarioVista";
            _tokenActualizacionLista = "EncargoPlanificacionCuestionarioCambioOrden";
            dlg = new DialogCoordinator();
            changedDetalleHerramientas = null;
            dataGrid.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(dataGrid_PreviewMouseLeftButtonDown);
            dataGrid.Drop += new DragEventHandler(dataGrid_Drop);
            Messenger.Default.Register<EncargosPlanProgramasDetalleListaMsj>(this, tokenRecepcionVista, (herramientasDetalleListaMensaje) => ControlHerramientasDetalleListaMensaje(herramientasDetalleListaMensaje));
            //Tamaño de pantalla
            //double ancho = PrincipalAlterna.ancho;
            //double largo = PrincipalAlterna.largo;

            double ancho = CuestionarioCrudView.anchoFrame;
            double largo = CuestionarioCrudView.largoFrame;

            this.Width = ancho-1;
            this.Height = largo-1;

            MinWidth = Width * 0.6;
            MaxWidth = Width;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = Height * 0.5;
            MaxHeight = Height;

            datosConsulta.Width = Width - 7;
            datosConsulta.MinWidth = Width * 0.5;
            datosConsulta.MaxWidth = Width - 7;

            datosConsulta.Height = Height - 135;
            datosConsulta.MaxHeight = Height - 135;
            datosConsulta.MinHeight = Height * 0.5;

            dataGrid.Width = datosConsulta.Width - 1;
            dataGrid.MaxWidth = datosConsulta.MinWidth - 1;
            dataGrid.MinWidth = datosConsulta.MaxWidth - 1;

            dataGrid.Height = datosConsulta.Height - 1;
            dataGrid.MaxHeight = datosConsulta.MaxHeight - 1;
            dataGrid.MinHeight = datosConsulta.MinHeight - 1;
        }

        private void ControlHerramientasDetalleListaMensaje(EncargosPlanProgramasDetalleListaMsj herramientasDetalleListaMensaje)
        {
            listaDetalleHerramienta = herramientasDetalleListaMensaje.listaElementosCuestionario;

        }


        void dataGrid_Drop(object sender, DragEventArgs e)
        {
            decimal contador = 1;
            decimal factor = 0;//Para cambiar el orden
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

            #region listas

            ObservableCollection<DetalleCuestionarioModelo> listaHijos = new ObservableCollection<DetalleCuestionarioModelo>();
            ObservableCollection<DetalleCuestionarioModelo> listaPadres = new ObservableCollection<DetalleCuestionarioModelo>();
            ObservableCollection<DetalleCuestionarioModelo> listaDetalle = new ObservableCollection<DetalleCuestionarioModelo>();

            #endregion


            #region reordenamiento
            try
            {
                contador = 1;
                //decimal factor = 0;//Para cambiar el orden
                foreach (DetalleCuestionarioModelo itemDetalle in listaDetalleHerramienta)
                {
                    if (itemDetalle.idpadredp == null)
                    {
                        if (itemDetalle.ordendp != contador)
                        {
                            itemDetalle.guardadoBase = false;
                        }

                        //Se asigna el orden a los principales
                        itemDetalle.ordendp = contador;
                        //itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordendp);
                        itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordendp);
                        //itemDetalle.descripcionPresentacion = itemDetalle.descripciondpi;
                        /*if (guardar)
                        {
                            DetalleCuestionarioModelo.UpdateModeloReodenar(itemDetalle);
                            //Se modifica el orden para mantener una estandarizacion
                        }*/
                        listaDetalle.Add(itemDetalle);
                        if (listaDetalleHerramienta.Where(x => x.idpadredp == itemDetalle.iddp).Count() > 0)
                        {
                            listaPadres.Add(itemDetalle);
                        }
                        contador = contador + 1;
                    }
                }
                //Corrigiendo los sub-procedimientos
                bool salir = false;
                //factor = (decimal)0.1;
                string desplazar = "  ";
                int ciclos = listaPadres.Count();

                do
                {
                    if (listaPadres.Count > 0)
                    {
                        if (ciclos == 0)
                        {
                            //factor = factor / 10;
                            desplazar = desplazar + desplazar;
                            ciclos = listaPadres.Count();
                        }
                        salir = true;//No sale volvera a recorrerla
                                     //Recorrer todos los  que tienen hijos
                        listaHijos = new ObservableCollection<DetalleCuestionarioModelo>(listaDetalleHerramienta.Where(x => x.idpadredp == listaPadres[0].iddp));
                        if (listaHijos.Count > 0)
                        {
                            //Hay hijos
                            contador = (decimal)listaPadres[0].ordendp;
                            //factor = MetodosModelo.factorPadreIndice(item.descripciontei);
                            int j = 1;
                            foreach (DetalleCuestionarioModelo hijo in listaHijos)
                            {
                                //Es un hijo
                                if (hijo.ordendp != Decimal.Add((decimal)contador, factor * j))
                                {
                                    hijo.guardadoBase = false;
                                }
                                hijo.ordendpPadre = contador;
                                factor = MetodosModelo.factorHijo(hijo.nombreTipoProcedimiento);
                                hijo.ordendp = Decimal.Add((decimal)contador, factor * j);
                                hijo.ordenDhPresentacion = MetodosModelo.ordenConversion(hijo.ordendp);
                                //hijo.descripcionPresentacion = desplazar + hijo.descripciondpi;

                                hijo.DetalleCuestionarioModeloPadre = listaPadres[0]; ;
                                hijo.nombreDetallePadre = hijo.DetalleCuestionarioModeloPadre.descripciondp;

                                j++;
                                /*if (guardar)
                                {
                                    DetalleCuestionarioModelo.UpdateModeloReodenar(hijo);
                                    //Se modifica el orden para mantener una estandarizacion
                                }**/
                                //Agregar a la lista
                                listaDetalle.Add(hijo);
                                //Verificar que no tenga hijos
                                if (listaDetalleHerramienta.Where(x => x.idpadredp == hijo.iddp).Count() > 0)
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
                listaDetalleHerramienta.OrderBy(x => x.ordendp).ToList();
                //throw;
            }

            #endregion fin reordenamiento


            //Reordenar la lista
            //var ListaOrdenada = listaDetalleHerramienta.OrderBy(p => p.ordendp).ToList();
            ObservableCollection<DetalleCuestionarioModelo> ListaOrdenada = new ObservableCollection<DetalleCuestionarioModelo>(listaDetalle.OrderBy(x => x.ordendp));

            for (int i = 0; i < listaDetalleHerramienta.Count(); i++)
            {
                changedDetalleHerramientas = ListaOrdenada[i];
                listaDetalleHerramienta.RemoveAt(i);
                listaDetalleHerramienta.Insert(i, changedDetalleHerramientas);
            }
            //listaDetalleHerramienta.OrderBy(x => x.ordendp);
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
            DetalleCuestionarioModelo selectedDetalleHerramientas = dataGrid.Items[rowIndex] as DetalleCuestionarioModelo;
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
