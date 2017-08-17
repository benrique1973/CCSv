using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Herramientas;
using SGPTWpf.Model.Modelo.detalleherramientas;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System;
using MahApps.Metro.Controls.Dialogs;
using System.Linq;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;

namespace SGPTWpf.Views.Principales.Herramientas.Cuestionarios
{

    public partial class HerramientaCuestionarioEdicionView : UserControl
    {
        #region tokenActualizacionLista

        private string _tokenActualizacionLista;
        private string tokenActualizacionLista
        {
            get { return _tokenActualizacionLista; }
            set { _tokenActualizacionLista = value; }
        }

        #endregion

        public delegate Point GetPosition(IInputElement element);
        int rowIndex = -1;
        public ObservableCollection<DetalleHerramientasModelo> listaDetalleHerramienta;
        public DetalleHerramientasModelo changedDetalleHerramientas;
        public DialogCoordinator dlg;
        private static int cuentaMensajeDetalleCuestionarioRecibidos=0;//Para control de listados recibidos
        public HerramientaCuestionarioEdicionView()
        {
            InitializeComponent();
            dlg = new DialogCoordinator();
            _tokenActualizacionLista = "HerramientaCuestionarioCambioOrden";
            changedDetalleHerramientas = null;
            dgContenido.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(dgContenido_PreviewMouseLeftButtonDown);
            dgContenido.Drop += new DragEventHandler(dgContenido_Drop);
            Messenger.Default.Register<HerramientasDetalleCuestionarioListaMensaje>(this, (herramientasDetallaCuestionarioListaMensaje) => ControlHerramientasDetallaCuestionarioListaMensaje(herramientasDetallaCuestionarioListaMensaje));

            double ancho = SystemParameters.PrimaryScreenWidth;

            double largo = SystemParameters.PrimaryScreenHeight;

            dgContenido.MaxHeight = largo * 0.70;
        }



        private void ControlHerramientasDetallaCuestionarioListaMensaje(HerramientasDetalleCuestionarioListaMensaje herramientasDetallaCuestionarioListaMensaje)
        {
                listaDetalleHerramienta = herramientasDetallaCuestionarioListaMensaje.listaElementos;
                cuentaMensajeDetalleCuestionarioRecibidos++;

        }


        void dgContenido_Drop(object sender, DragEventArgs e)
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
            if (index == dgContenido.Items.Count - 1)
            {
                //dlg.ShowMessageAsync(this, "El registro no puede ser eliminado ","");
                return;
            }
            changedDetalleHerramientas = listaDetalleHerramienta[rowIndex];
            listaDetalleHerramienta.RemoveAt(rowIndex);
            listaDetalleHerramienta.Insert(index, changedDetalleHerramientas);

            #region listas

            ObservableCollection<DetalleHerramientasModelo> listaHijos = new ObservableCollection<DetalleHerramientasModelo>();
            ObservableCollection<DetalleHerramientasModelo> listaPadres = new ObservableCollection<DetalleHerramientasModelo>();
            ObservableCollection<DetalleHerramientasModelo> listaDetalle = new ObservableCollection<DetalleHerramientasModelo>();

            #endregion


            #region reordenamiento
            try
            {
                contador = 1;
                //decimal factor = 0;//Para cambiar el orden
                foreach (DetalleHerramientasModelo itemDetalle in listaDetalleHerramienta)
                {
                    if (itemDetalle.idDhPrincipalDh == null)
                    {
                        if (itemDetalle.ordenDh != contador)
                        {
                            itemDetalle.guardadoBase = false;
                        }

                        //Se asigna el orden a los principales
                        itemDetalle.ordenDh = contador;
                        //itemDetalle.ordendpPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordenDh);
                        itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordenDh);
                        //itemDetalle.descripcionPresentacion = itemDetalle.descripciondpi;
                        /*if (guardar)
                        {
                            DetalleHerramientasModelo.UpdateModeloReodenar(itemDetalle);
                            //Se modifica el orden para mantener una estandarizacion
                        }*/
                        listaDetalle.Add(itemDetalle);
                        if (listaDetalleHerramienta.Where(x => x.idDhPrincipalDh == itemDetalle.idDh).Count() > 0)
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
                        listaHijos = new ObservableCollection<DetalleHerramientasModelo>(listaDetalleHerramienta.Where(x => x.idDhPrincipalDh == listaPadres[0].idDh));
                        if (listaHijos.Count > 0)
                        {
                            //Hay hijos
                            contador = (decimal)listaPadres[0].ordenDh;
                            //factor = MetodosModelo.factorPadreIndice(item.descripciontei);
                            int j = 1;
                            foreach (DetalleHerramientasModelo hijo in listaHijos)
                            {
                                //Es un hijo
                                if (hijo.ordenDh != Decimal.Add((decimal)contador, factor * j))
                                {
                                    hijo.guardadoBase = false;
                                }
                                hijo.ordenDhPadre = contador;
                                factor = MetodosModelo.factorHijo(hijo.nombreTipoProcedimiento);
                                hijo.ordenDh = Decimal.Add((decimal)contador, factor * j);
                                hijo.ordenDhPresentacion = MetodosModelo.ordenConversion(hijo.ordenDh);
                                //hijo.descripcionPresentacion = desplazar + hijo.descripciondpi;

                                hijo.detalleHerramientasModeloPadre = listaPadres[0]; ;
                                hijo.nombreDetallePadre = hijo.detalleHerramientasModeloPadre.descripcionDh;

                                j++;
                                /*if (guardar)
                                {
                                    DetalleHerramientasModelo.UpdateModeloReodenar(hijo);
                                    //Se modifica el orden para mantener una estandarizacion
                                }**/
                                //Agregar a la lista
                                listaDetalle.Add(hijo);
                                //Verificar que no tenga hijos
                                if (listaDetalleHerramienta.Where(x => x.idDhPrincipalDh == hijo.idDh).Count() > 0)
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
                listaDetalleHerramienta.OrderBy(x => x.ordenDh).ToList();
                //throw;
            }

            #endregion fin reordenamiento


            //Reordenar la lista
            //var ListaOrdenada = listaDetalleHerramienta.OrderBy(p => p.ordenDh).ToList();
            ObservableCollection<DetalleHerramientasModelo> ListaOrdenada = new ObservableCollection<DetalleHerramientasModelo>(listaDetalle.OrderBy(x => x.ordenDh));
            for (int i = 0; i < listaDetalleHerramienta.Count(); i++)
            {
                changedDetalleHerramientas = ListaOrdenada[i];
                listaDetalleHerramienta.RemoveAt(i);
                listaDetalleHerramienta.Insert(i, changedDetalleHerramientas);
            }
            //listaDetalleHerramienta.OrderBy(x => x.ordenDh);
            notificarCambio(); //Para darle agilidad se  elimina
        }

        private void notificarCambio()
        {
            //Para sub-ventana
            //Se crea el mensaje
            Messenger.Default.Send<bool>(true, tokenActualizacionLista);
        }

        void dgContenido_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            rowIndex = GetCurrentRowIndex(e.GetPosition);
            if (rowIndex < 0)
                return;
            dgContenido.SelectedIndex = rowIndex;
            DetalleHerramientasModelo selectedDetalleHerramientas = dgContenido.Items[rowIndex] as DetalleHerramientasModelo;
            if (selectedDetalleHerramientas == null)
                return;
            DragDropEffects dragdropeffects = DragDropEffects.Move;
            if (DragDrop.DoDragDrop(dgContenido, selectedDetalleHerramientas, dragdropeffects)
                                != DragDropEffects.None)
            {
                dgContenido.SelectedItem = selectedDetalleHerramientas;
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
            if (dgContenido.ItemContainerGenerator.Status
                    != GeneratorStatus.ContainersGenerated)
                return null;
            return dgContenido.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
        }
        private int GetCurrentRowIndex(GetPosition pos)
        {
            int curIndex = -1;
            for (int i = 0; i < dgContenido.Items.Count; i++)
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
