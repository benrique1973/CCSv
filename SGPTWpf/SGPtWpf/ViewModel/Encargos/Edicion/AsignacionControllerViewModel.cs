using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Model;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;
using CapaDatos;
using System.Linq;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.Messages.Encargos;
using System;

namespace SGPTWpf.ViewModel.Encargos.Gestion
{
    public sealed class AsignacionControllerViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        private string tokenRecepcion = "asignacionCrud";
        private string tokenEnvioCierre = "CrudAsignacionCerrada";
        private DialogCoordinator dlg;
        private bool salida = false;
        private int comando = 0;

        #endregion

        #region ViewModel Properties publicas

        #region lista asignacion

        public const string listaPropertyName = "lista";


        private ObservableCollection<AsignacionModelo> _lista;

        public ObservableCollection<AsignacionModelo> lista
        {
            get
            {
                return _lista;
            }

            set
            {
                if (_lista == value) return;

                _lista = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaPropertyName);
            }
        }

        #endregion

        #region listaEmpleados
        public const string listaEmpleadosPropertyName = "listaEmpleados";


        private ObservableCollection<UsuarioModelo> _listaEmpleados;

        public ObservableCollection<UsuarioModelo> listaEmpleados
        {
            get
            {
                return _listaEmpleados;
            }

            set
            {
                if (_listaEmpleados == value) return;

                _listaEmpleados = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaEmpleadosPropertyName);
            }
        }

        #endregion

        public static int Errors { get; set; }

        /*       #region  Errores

               public const string erroresPropertyName = "errores";

               public static int _errores;

               public int errores
               {
                   get
                   {
                       return _errores;
                   }

                   set
                   {
                       if (_errores == value)
                       {
                           return;
                       }

                       _errores = value;
                       RaisePropertyChanged(erroresPropertyName);
                   }
               }

               #endregion */

        #region  Primary key idasignacion

        public const string idasignacionPropertyName = "idasignacion";

        private int _idasignacion = 0;

        public int idasignacion
        {
            get
            {
                return _idasignacion;
            }

            set
            {
                if (_idasignacion == value)
                {
                    return;
                }

                _idasignacion = value;
                RaisePropertyChanged(idasignacionPropertyName);
            }
        }

        #endregion

        #region  Primary key idusuario

        public const string idusuarioPropertyName = "idusuario";

        private int _idusuario = 0;

        /// <summary>
        /// Sets and gets the nombretablamc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int idusuario
        {
            get
            {
                return _idusuario;
            }

            set
            {
                if (_idusuario == value)
                {
                    return;
                }

                _idusuario = value;
                RaisePropertyChanged(idusuarioPropertyName);
            }
        }

        #endregion

        #region  Primary key idencargo

        public const string idencargoPropertyName = "idencargo";

        private int _idencargo = 0;

        public int idencargo
        {
            get
            {
                return _idencargo;
            }

            set
            {
                if (_idencargo == value)
                {
                    return;
                }

                _idencargo = value;
                RaisePropertyChanged(idencargoPropertyName);
            }
        }

        #endregion

        #region nombre de plantilla

        public const string fechacreaasignacionPropertyName = "fechacreaasignacion";

        private string _fechacreaasignacion = string.Empty;

        public string fechacreaasignacion
        {
            get
            {
                return _fechacreaasignacion;
            }

            set
            {
                if (_fechacreaasignacion == value)
                {
                    return;
                }

                _fechacreaasignacion = value;
                RaisePropertyChanged(fechacreaasignacionPropertyName);
            }
        }


        #endregion

        #region horasplanasignacion

        public const string horasplanasignacionPropertyName = "horasplanasignacion";

        private decimal _horasplanasignacion = 0;

        public decimal horasplanasignacion
        {
            get
            {
                return _horasplanasignacion;
            }

            set
            {
                if (_horasplanasignacion == value)
                {
                    return;
                }

                _horasplanasignacion = value;
                RaisePropertyChanged(horasplanasignacionPropertyName);
            }
        }

        #endregion

        #region horasejecucionasignacion

        public const string horasejecucionasignacionPropertyName = "horasejecucionasignacion";

        private decimal _horasejecucionasignacion = 0;

        public decimal horasejecucionasignacion
        {
            get
            {
                return _horasejecucionasignacion;
            }

            set
            {
                if (_horasejecucionasignacion == value)
                {
                    return;
                }

                _horasejecucionasignacion = value;
                RaisePropertyChanged(horasejecucionasignacionPropertyName);
            }
        }

        #endregion

        #region preciohoraasignacion

        public const string preciohoraasignacionPropertyName = "preciohoraasignacion";

        private decimal _preciohoraasignacion;

        public decimal preciohoraasignacion
        {
            get
            {
                return _preciohoraasignacion;
            }

            set
            {
                if (_preciohoraasignacion == value)
                {
                    return;
                }

                _preciohoraasignacion = value;
                RaisePropertyChanged(preciohoraasignacionPropertyName);
            }
        }

        #endregion

        # region estadoasignacion

        public const string estadoasignacionPropertyName = "estadoasignacion";

        private string _estadoasignacion = string.Empty;

        public string estadoasignacion
        {
            get
            {
                return _estadoasignacion;
            }

            set
            {
                if (_estadoasignacion == value)
                {
                    return;
                }

                _estadoasignacion = value;
                RaisePropertyChanged(estadoasignacionPropertyName);
            }
        }

        #endregion

        #region rolUsuarioAsignacion

        public const string rolUsuarioAsignacionPropertyName = "rolUsuarioAsignacion";

        private string _rolUsuarioAsignacion = string.Empty;

        public string rolUsuarioAsignacion
        {
            get
            {
                return _rolUsuarioAsignacion;
            }

            set
            {
                if (_rolUsuarioAsignacion == value)
                {
                    return;
                }

                _rolUsuarioAsignacion = value;
                RaisePropertyChanged(rolUsuarioAsignacionPropertyName);
            }
        }
        #endregion

        #region usuarioModeloAsignacion

        public const string usuarioModeloAsignacionPropertyName = "usuarioModeloAsignacion";

        private UsuarioModelo _usuarioModeloAsignacion = null;

        public UsuarioModelo usuarioModeloAsignacion
        {
            get
            {
                return _usuarioModeloAsignacion;
            }

            set
            {
                if (_usuarioModeloAsignacion == value)
                {
                    return;
                }

                _usuarioModeloAsignacion = value;
                RaisePropertyChanged(usuarioModeloAsignacionPropertyName);
            }
        }


        #endregion

        #region nombreUsuario

        public const string nombreUsuarioPropertyName = "nombreUsuario";

        private string _nombreUsuario = string.Empty;

        public string nombreUsuario
        {
            get
            {
                return _nombreUsuario;
            }

            set
            {
                if (_nombreUsuario == value)
                {
                    return;
                }

                _nombreUsuario = value;
                RaisePropertyChanged(nombreUsuarioPropertyName);
            }
        }

        #endregion

        #region Entidad en uso

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private AsignacionModelo _currentEntidad;

        public AsignacionModelo currentEntidad
        {
            get
            {
                return _currentEntidad;
            }

            set
            {
                if (_currentEntidad == value) return;

                _currentEntidad = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentUsuario usuario

        public const string currentUsuarioPropertyName = "currentUsuario";

        private usuario _currentUsuario;

        public usuario currentUsuario
        {
            get
            {
                return _currentUsuario;
            }

            set
            {
                if (_currentUsuario == value) return;

                _currentUsuario = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentUsuarioPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentUsuarioModelo usuario

        public const string currentUsuarioModeloPropertyName = "currentUsuarioModelo";

        private UsuarioModelo _currentUsuarioModelo;

        public UsuarioModelo currentUsuarioModelo
        {
            get
            {
                return _currentUsuarioModelo;
            }

            set
            {
                if (_currentUsuarioModelo == value) return;

                _currentUsuarioModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentUsuarioModeloPropertyName);
            }
        }

        #endregion


        #endregion

        #endregion


        #region Propiedades Ventana


        #region ViewModel Properties : accesibilidadWindow

        public const string accesibilidadWindowPropertyName = "accesibilidadWindow";

        private bool _accesibilidadWindow = true;

        public bool accesibilidadWindow
        {
            get
            {
                return _accesibilidadWindow;
            }

            set
            {
                if (_accesibilidadWindow == value)
                {
                    return;
                }

                _accesibilidadWindow = value;
                RaisePropertyChanged(accesibilidadWindowPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : activarCarga

        public const string activarCargaPropertyName = "activarCarga";

        private bool _activarCarga = true;

        public bool activarCarga
        {
            get
            {
                return _activarCarga;
            }

            set
            {
                if (_activarCarga == value)
                {
                    return;
                }

                _activarCarga = value;
                RaisePropertyChanged(activarCargaPropertyName);
            }
        }

        #endregion


        #region visibilidadCrear

        public const string visibilidadCrearPropertyName = "visibilidadCrear";

        private Visibility _visibilidadCrear = Visibility.Collapsed;

        public Visibility visibilidadCrear
        {
            get
            {
                return _visibilidadCrear;
            }

            set
            {
                if (_visibilidadCrear == value)
                {
                    return;
                }

                _visibilidadCrear = value;
                RaisePropertyChanged(visibilidadCrearPropertyName);
            }
        }

        #endregion

        #region visibilidadConsultar

        public const string visibilidadConsultarPropertyName = "visibilidadConsultar";

        private Visibility _visibilidadConsultar = Visibility.Collapsed;

        public Visibility visibilidadConsultar
        {
            get
            {
                return _visibilidadConsultar;
            }

            set
            {
                if (_visibilidadConsultar == value)
                {
                    return;
                }

                _visibilidadConsultar = value;
                RaisePropertyChanged(visibilidadConsultarPropertyName);
            }
        }

        #endregion

        #region visibilidadEditar

        public const string visibilidadEditarPropertyName = "visibilidadEditar";

        private Visibility _visibilidadEditar = Visibility.Collapsed;

        public Visibility visibilidadEditar
        {
            get
            {
                return _visibilidadEditar;
            }

            set
            {
                if (_visibilidadEditar == value)
                {
                    return;
                }

                _visibilidadEditar = value;
                RaisePropertyChanged(visibilidadEditarPropertyName);
            }
        }

        #endregion

        #region visibilidadCopiar

        public const string visibilidadCopiarPropertyName = "visibilidadCopiar";

        private Visibility _visibilidadCopiar = Visibility.Collapsed;

        public Visibility visibilidadCopiar
        {
            get
            {
                return _visibilidadCopiar;
            }

            set
            {
                if (_visibilidadCopiar == value)
                {
                    return;
                }

                _visibilidadCopiar = value;
                RaisePropertyChanged(visibilidadCopiarPropertyName);
            }
        }

        #endregion

        #region encabezadoPantalla

        public const string encabezadoPantallaPropertyName = "encabezadoPantalla";

        private string _encabezadoPantalla = string.Empty;

        public string encabezadoPantalla
        {
            get
            {
                return _encabezadoPantalla;
            }

            set
            {
                if (_encabezadoPantalla == value)
                {
                    return;
                }

                _encabezadoPantalla = value;
                RaisePropertyChanged(encabezadoPantallaPropertyName);
            }
        }

        #endregion

        #endregion

        #region ViewModel Commands

        public RelayCommand EditarCommand { get; set; }
        public RelayCommand GuardarCommand { get; set; }
        public RelayCommand CancelarCommand { get; set; }
        public RelayCommand OkCommand { get; set; }
        public RelayCommand SalirCommand { get; set; }
        public RelayCommand<UsuarioModelo> SelectionChangedCommand { get; set; }
        #endregion

        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public AsignacionControllerViewModel()
        {
            //Suscribiendo el mensaje
            _preciohoraasignacion = 0;
            Errors = 0;
           listaEmpleados = new ObservableCollection<UsuarioModelo>(UsuarioModelo.GetAll());
            Messenger.Default.Register<AsignacionDatosMensaje>(this, tokenRecepcion, (asignacionDatosMensaje) => ControlAsignacionDatosMensaje(asignacionDatosMensaje));
            encabezadoPantalla = "";
            RegisterCommands();
            dlg = new DialogCoordinator();
            salida = false;
            activarCarga = false;
            accesibilidadWindow = true;
        }


        private void ControlAsignacionDatosMensaje(AsignacionDatosMensaje asignacionDatosMensaje)
        {
            currentEntidad = asignacionDatosMensaje.asignacionModelo;
            lista = asignacionDatosMensaje.listaAsignacionModelo;
            comando=asignacionDatosMensaje.comandoCrud;
            if (lista.Count > 0 && comando==1)
            {
                var itemsToRemove = new ObservableCollection<UsuarioModelo>();
                foreach (AsignacionModelo asignacion in lista)
                { 
                for (int i = 0; i < listaEmpleados.Count; i++)
                {
                   if (listaEmpleados[i].idUsuario ==asignacion.idusuario )
                    {
                        itemsToRemove.Add(listaEmpleados[i]);
                            i = listaEmpleados.Count;
                    }

                }
                }
                foreach (var item in itemsToRemove)
                {
                    listaEmpleados.Remove(item);
                }
            }
            currentUsuarioModelo = asignacionDatosMensaje.usuarioModelo;
            if (currentEntidad.usuarioModeloAsignacion != null)
            {
                usuarioModeloAsignacion = listaEmpleados.Single(i => i.idUsuario == currentEntidad.idusuario);
                horasplanasignacion = (decimal) currentEntidad.horasplanasignacion;
                preciohoraasignacion = (decimal)currentEntidad.preciohoraasignacion;
            }
            if (asignacionDatosMensaje.comandoCrud == 1)
            {
                encabezadoPantalla = "Seleccione al usuario a asignar";
                accesibilidadWindow = true;
                visibilidadCrear = Visibility.Visible;
                visibilidadEditar = Visibility.Collapsed;
                visibilidadConsultar = Visibility.Collapsed;
                visibilidadCopiar = Visibility.Collapsed;
            }
            else
            {
                if (asignacionDatosMensaje.comandoCrud == 2)
                {
                    encabezadoPantalla = "Modifique al usuario asignado";
                    accesibilidadWindow = false;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Visible;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCopiar = Visibility.Collapsed;
                }
                else
                {
                    if (asignacionDatosMensaje.comandoCrud == 5)
                    {
                        encabezadoPantalla = "Modifique el nombre de asignacion";
                        accesibilidadWindow = false;
                        visibilidadCrear = Visibility.Collapsed;
                        visibilidadEditar = Visibility.Collapsed;
                        visibilidadConsultar = Visibility.Collapsed;
                        visibilidadCopiar = Visibility.Visible; ;
                    }
                    else
                    {
                        encabezadoPantalla = "Consulta de asignacion";
                        accesibilidadWindow = false;
                        visibilidadCrear = Visibility.Collapsed;
                        visibilidadEditar = Visibility.Collapsed;
                        visibilidadConsultar = Visibility.Visible;
                        visibilidadCopiar = Visibility.Collapsed;
                    }
                }
            }

            Messenger.Default.Unregister<AsignacionDatosMensaje>(this, tokenRecepcion);
        }

        #endregion

        private async void Cancelar()
        {
            // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
            //Debe cerrar el sistema
            salida = true;
            await dlg.ShowMessageAsync(this, "Operación cancelada", "");
            CloseWindow();
        }

        private void Ok()
        {
            salida = true;
            CloseWindow();
        }


        private void Salir()
        {

            if (!salida)
            {
                CloseWindow();
            }
            else
            {
                //Ya procesado
            }
            enviarMensaje();
        }


        public async void Guardar()
        {

                //currentEntidad.id = AsignacionModelo.IdAsignar();
                if (currentEntidad.idencargo == 0)
                {
                    currentEntidad.numeroCorrelativo = lista.Count + 1;
                    currentEntidad.usuarioModeloAsignacion = usuarioModeloAsignacion;
                    currentEntidad.nombreUsuario = usuarioModeloAsignacion.nombreUsuario;
                    currentEntidad.rolUsuarioAsignacion = usuarioModeloAsignacion.rolModeloUsuario.descripcion;
                    currentEntidad.idusuario = usuarioModeloAsignacion.idUsuario;
                    currentEntidad.totalCosto= Math.Round(Decimal.Multiply((decimal)currentEntidad.horasplanasignacion, (decimal)currentEntidad.preciohoraasignacion), 2);
                //currentEntidad.preciohoraasignacion = preciohoraasignacion;
                //currentEntidad.horasejecucionasignacion = horasejecucionasignacion;
                currentEntidad.guardadoBase = false;
                    lista.Add(currentEntidad);
                    salida = true;
                    CloseWindow();
                }
                else
                {
                    if (AsignacionModelo.Insert(currentEntidad, true))
                    {
                        await dlg.ShowMessageAsync(this, "Registro insertado con éxito", "");
                        currentEntidad.guardadoBase = true;
                        salida = true;
                        CloseWindow();
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                    }
                }
        }


       public async void Modificar()
        {
                if (currentEntidad.idencargo == 0)
                {
                    //Ya esta incorporada
                    await dlg.ShowMessageAsync(this, "Registro actualizado con éxito", "");
                    salida = true;
                    currentEntidad.guardadoBase = false;
                    CloseWindow();
                }
                else
                {
                    if (AsignacionModelo.UpdateModelo(currentEntidad))
                    {
                        await dlg.ShowMessageAsync(this, "Registro actualizado con éxito", "");
                        salida = true;
                        currentEntidad.guardadoBase = true;
                        CloseWindow();
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "No ha sido posible actualizar el registro", "");
                    }
                }
        }


        #endregion

        #region Mensajes

        //Procesando el mensaje recibido

        public void enviarMensaje()
        {
            //Creando el mensaje de cierre
            bool cerrado = true;
            Messenger.Default.Send(cerrado, tokenEnvioCierre);
        }

        #endregion

        #region Metodos de apoyo

        public bool CanSave()
        {
            bool evaluar = false;

            if (currentEntidad == null || usuarioModeloAsignacion == null)
            {
                return evaluar;
            }
            else
            {
                return (Errors == 0);
                //return  (Errors == 0) && (preciohoraasignacion == 0 || preciohoraasignacion > 1) &&
                //        (horasejecucionasignacion == 0 || horasplanasignacion > 0);
            }
        }

        #endregion

        #endregion
        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            EditarCommand = new RelayCommand(Modificar, CanSave);
            GuardarCommand = new RelayCommand(Guardar, CanSave);
            CancelarCommand = new RelayCommand(Cancelar);
            OkCommand = new RelayCommand(Ok);
            SalirCommand = new RelayCommand(Salir);
            SelectionChangedCommand = new RelayCommand<UsuarioModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad.usuarioModeloAsignacion = entidad;
                //Buscar el valor de precio por hora
                if (currentEntidad.preciohoraasignacion==0)
                { 
                currentEntidad.preciohoraasignacion = AsignacionModelo.GetValorHoraEmpleado(entidad.idUsuario);
                preciohoraasignacion =(decimal) currentEntidad.preciohoraasignacion;
                }
            });
        }

        #endregion

        #region Verifica unicidad
        //Cada marca debe ser única
        /*public int contenidoUnico(UsuarioModelo usuarioModeloAsignacion, ObservableCollection<AsignacionModelo> listaBusqueda)
        {
            int numeroRegistros;
            UsuarioModelo marcame = usuarioModeloAsignacion;
            numeroRegistros = listaBusqueda.Where(j => j.idusuario == marcame.idUsuario).Count();
            if (numeroRegistros == 1)
            {
                return 1;
            }
            else
            {
                return numeroRegistros;
            }
        }*/
        #endregion


    }
}

