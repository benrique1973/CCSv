using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System;
using MahApps.Metro.Controls.Dialogs;
using System.Linq;
using SGPTWpf.Model.Modelo.Indice;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.Views.Compartidas;

namespace SGPTWpf.Views.Principales.Herramientas.Indice
{

    public partial class DetalleIndiceCrudView : UserControl
    {
        public delegate Point GetPosition(IInputElement element);
        int rowIndex = -1;
        public ObservableCollection<DetallePlantillaIndiceModelo> listaDetallePlantillaIndice;
        public DetallePlantillaIndiceModelo changedDetallePlantillaIndiceModelo;
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

        public DetalleIndiceCrudView()
        {
            InitializeComponent();
            _tokenActualizacionLista = "EncargoPlanificacionIndiceCambioOrden";
            _tokenRecepcionVista = "DetalleDatosElementoAVista";//Identifica la fuente de un mensaje generico

            double ancho = PrincipalAlterna.anchoFrame;
            double largo = PrincipalAlterna.MaxlargoFrame;

            this.MinWidth = PrincipalAlterna.MinanchoFrame * 0.5;
            this.Width = PrincipalAlterna.anchoFrame - 205;
            this.MaxWidth = PrincipalAlterna.MaxanchoFrame - 205;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            this.MinHeight = PrincipalAlterna.MinlargoFrame * 0.5;
            this.MaxHeight = PrincipalAlterna.MaxlargoFrame-103;
            this.Height = PrincipalAlterna.largoFrame - 103;

            datosConsulta.Width = Width-5;
            datosConsulta.MaxWidth = Width - 5;
            datosConsulta.Height = Height - 64;
            datosConsulta.MaxHeight = Height - 64;


            dgContenido.Width = datosConsulta.Width-1;
            dgContenido.MaxWidth = datosConsulta.Width - 1;
            dgContenido.Height = datosConsulta.Height-1;
            dgContenido.MaxHeight = datosConsulta.Height - 1;
            
            //Ordenamiento
            dlg = new DialogCoordinator();
            changedDetallePlantillaIndiceModelo = null;
            dgContenido.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(dgContenido_PreviewMouseLeftButtonDown);
            dgContenido.Drop += new DragEventHandler(dgContenido_Drop);
            Messenger.Default.Register<ObservableCollection<DetallePlantillaIndiceModelo>>(this, tokenRecepcionVista, (listaDetalle) => ControllistaDetalle(listaDetalle));
        }

        private void ControllistaDetalle(ObservableCollection<DetallePlantillaIndiceModelo> listaMensaje)
        {
            listaDetallePlantillaIndice = listaMensaje;
        }


        void dgContenido_Drop(object sender, DragEventArgs e)
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
            if (index == dgContenido.Items.Count - 1)
            {
                //dlg.ShowMessageAsync(this, "El registro no puede ser eliminado ","");
                return;
            }
            changedDetallePlantillaIndiceModelo = listaDetallePlantillaIndice[rowIndex];
            listaDetallePlantillaIndice.RemoveAt(rowIndex);
            listaDetallePlantillaIndice.Insert(index, changedDetallePlantillaIndiceModelo);
            listaDetallePlantillaIndice[index].guardadoBase = false;
            //Reordenar los principales
            //Reordenamiento
            #region listas

            ObservableCollection<DetallePlantillaIndiceModelo> listaHijos = new ObservableCollection<DetallePlantillaIndiceModelo>();
            ObservableCollection<DetallePlantillaIndiceModelo> listaPadres = new ObservableCollection<DetallePlantillaIndiceModelo>();
            ObservableCollection<DetallePlantillaIndiceModelo> listaDetalle = new ObservableCollection<DetallePlantillaIndiceModelo>();

            #endregion


            #region reordenamiento
            try
            {
                    contador = 10;
                    //decimal factor = 0;//Para cambiar el orden
                    foreach (DetallePlantillaIndiceModelo itemDetalle in listaDetallePlantillaIndice)
                    {
                        if (itemDetalle.detiddpi == null)
                        {
                            if (itemDetalle.ordendpi != contador)
                            {
                                itemDetalle.guardadoBase = false;
                            }

                            //Se asigna el orden a los principales
                            itemDetalle.ordendpi = contador;
                            //itemDetalle.ordendpPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordendpi);
                            itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordendpi);
                            itemDetalle.descripcionPresentacion = itemDetalle.descripciondpi;
                            /*if (guardar)
                            {
                                DetallePlantillaIndiceModelo.UpdateModeloReodenar(itemDetalle);
                                //Se modifica el orden para mantener una estandarizacion
                            }*/
                            listaDetalle.Add(itemDetalle);
                            if (listaDetallePlantillaIndice.Where(x => x.detiddpi == itemDetalle.iddpi).Count() > 0)
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
                            listaHijos = new ObservableCollection<DetallePlantillaIndiceModelo>(listaDetallePlantillaIndice.Where(x => x.detiddpi == listaPadres[0].iddpi));
                            if (listaHijos.Count > 0)
                            {
                                //Hay hijos
                                contador = (decimal)listaPadres[0].ordendpi;
                                //factor = MetodosModelo.factorPadreIndice(item.descripciontei);
                                int j = 1;
                                foreach (DetallePlantillaIndiceModelo hijo in listaHijos)
                                {
                                    //Es un hijo
                                    if (hijo.ordendpi != Decimal.Add((decimal)contador, factor * j))
                                    {
                                        hijo.guardadoBase=false;
                                    }
                                    hijo.ordendpiPadre = contador;
                                    hijo.ordendpi = Decimal.Add((decimal)contador, factor * j);
                                    hijo.ordenDhPresentacion = MetodosModelo.ordenConversion(hijo.ordendpi);
                                    hijo.descripcionPresentacion = desplazar + hijo.descripciondpi;

                                    hijo.detalleplantillaindicePadre = listaPadres[0]; ;
                                    hijo.descripcionDpiPadre = hijo.detalleplantillaindicePadre.descripciondpi;

                                    j++;
                                    /*if (guardar)
                                    {
                                        DetallePlantillaIndiceModelo.UpdateModeloReodenar(hijo);
                                        //Se modifica el orden para mantener una estandarizacion
                                    }**/
                                    //Agregar a la lista
                                    listaDetalle.Add(hijo);
                                    //Verificar que no tenga hijos
                                    if (listaDetallePlantillaIndice.Where(x => x.detiddpi == hijo.iddpi).Count() > 0)
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
                catch (Exception )
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception generar el orden \n" );
                    listaDetallePlantillaIndice.OrderBy(x => x.ordendpi).ToList();
                    //throw;
                }

            #endregion fin reordenamiento
            
            //Reordenar la lista
            ObservableCollection<DetallePlantillaIndiceModelo> ListaOrdenada =new ObservableCollection<DetallePlantillaIndiceModelo>(listaDetalle.OrderBy(x => x.ordendpi)); 
            for (int i = 0; i < listaDetallePlantillaIndice.Count(); i++)
            {
                changedDetallePlantillaIndiceModelo = ListaOrdenada[i];
                listaDetallePlantillaIndice.RemoveAt(i);
                listaDetallePlantillaIndice.Insert(i, changedDetallePlantillaIndiceModelo);
                //listaDetallePlantillaIndice[i].guardadoBase = true;
            }
            foreach (DetallePlantillaIndiceModelo item in listaDetallePlantillaIndice)
            {
                item.ordenDhPresentacion= MetodosModelo.ordenConversion(item.ordendpi);
            }
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
        DetallePlantillaIndiceModelo selectedDetalleHerramientas = dgContenido.Items[rowIndex] as DetallePlantillaIndiceModelo;
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
