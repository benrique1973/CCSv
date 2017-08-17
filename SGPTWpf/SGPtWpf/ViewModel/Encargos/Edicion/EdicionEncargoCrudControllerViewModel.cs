using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Model;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;
using CapaDatos;
using System.Linq;

using System.Data;
using System;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.Messages.Encargos;
using System.Globalization;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;

namespace SGPTWpf.ViewModel.Encargos.Edicion
{
    public sealed class EdicionEncargoCrudControllerViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        #region ViewModel Properties : tokenRecepcionCrudEncargos

        private string _tokenRecepcionCrudEncargos;
        private string tokenRecepcionCrudEncargos
        {
            get { return _tokenRecepcionCrudEncargos; }
            set { _tokenRecepcionCrudEncargos = value; }
        }

        #endregion

        #region ViewModel Properties : tokenEnvioCrudEncargos

        private string _tokenEnvioCrudEncargos;
        private string tokenEnvioCrudEncargos
        {
            get { return _tokenEnvioCrudEncargos; }
            set { _tokenEnvioCrudEncargos = value; }
        }

        private bool _evaluarCondiciones;
        private bool evaluarCondiciones
        {
            get { return _evaluarCondiciones; }
            set { _evaluarCondiciones = value; }
        }
        #endregion

        private string tokenEnvioAsignacion = "asignacionCrud";

        private string tokenRecepcionCierre = "CrudAsignacionCerrada";
        private int comando = 0;
        //Rubros contables  debe tener menos dígitos que cuentas contables
        //Fecha de inicio debe ser menor que fecha fin
        //Si dice que la auditoria es recurrente debe verificarse que asi sea

        #region ViewModel Properties : controlEdicionElementoContable

        private bool _controlEdicionElementoContable;
        private bool controlEdicionElementoContable
        {
            get { return _controlEdicionElementoContable; }
            set { _controlEdicionElementoContable = value; }
        }

        #endregion


        private DialogCoordinator dlg;
        private bool salida = false;
        #endregion

        #region ViewModel Properties publicas

        public static int Errors { get; set; }//Para controllar los errores de edición

        #region lista entidades de encargos

        public const string listaEncargosPropertyName = "listaEncargos";

        private ObservableCollection<EncargoModelo> _listaEncargos;

        public ObservableCollection<EncargoModelo> listaEncargos
        {
            get
            {
                return _listaEncargos;
            }

            set
            {
                if (_listaEncargos == value) return;

                _listaEncargos = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaEncargosPropertyName);
            }
        }

        #endregion

        #region lista entidades de elementos contables

        public const string listaElementosPropertyName = "listaElementos";

        private ObservableCollection<ElementoModelo> _listaElementos;

        public ObservableCollection<ElementoModelo> listaElementos
        {
            get
            {
                return _listaElementos;
            }

            set
            {
                if (_listaElementos == value) return;

                _listaElementos = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaElementosPropertyName);
            }
        }

        #endregion

        #region lista entidades de elementos contables temporal

        public const string listaElementosTemporalPropertyName = "listaElementosTemporal";

        private ObservableCollection<ElementoModelo> _listaElementosTemporal;

        public ObservableCollection<ElementoModelo> listaElementosTemporal
        {
            get
            {
                return _listaElementosTemporal;
            }

            set
            {
                if (_listaElementosTemporal == value) return;

                _listaElementosTemporal = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaElementosTemporalPropertyName);
            }
        }

        #endregion

        #region lista digitos de Elementos

        public const string listaDigitosElementoModeloPropertyName = "listaDigitosElementoModelo";

        private ObservableCollection<DigitosModelo> _listaDigitosElementoModelo;

        public ObservableCollection<DigitosModelo> listaDigitosElementoModelo
        {
            get
            {
                return _listaDigitosElementoModelo;
            }

            set
            {
                if (_listaDigitosElementoModelo == value) return;

                _listaDigitosElementoModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaDigitosElementoModeloPropertyName);
            }
        }

        #endregion

        #region propiedades Elementos Contables
        #region  Primary key numeroCorrelativoElemento

        public const string numeroCorrelativoElementoPropertyName = "numeroCorrelativoElemento";

        private int _numeroCorrelativoElemento = 0;

        public int numeroCorrelativoElemento
        {
            get
            {
                return _numeroCorrelativoElemento;
            }

            set
            {
                if (_numeroCorrelativoElemento == value)
                {
                    return;
                }

                _numeroCorrelativoElemento = value;
                RaisePropertyChanged(numeroCorrelativoElementoPropertyName);
            }
        }

        #endregion

        #region descripcion Elemento contable

        public const string descripcionPropertyName = "descripcion";

        private string _descripcion = string.Empty;

        public string descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                if (_descripcion == value)
                {
                    return;
                }

                _descripcion = value;
                RaisePropertyChanged(descripcionPropertyName);
            }
        }


        #endregion

        #region digitosElementoModelo

        public const string digitosElementoModeloPropertyName = "digitosElementoModelo";

        private DigitosModelo _digitosElementoModelo;

        public DigitosModelo digitosElementoModelo
        {
            get
            {
                return _digitosElementoModelo;
            }

            set
            {
                if (_digitosElementoModelo == value)
                {
                    return;
                }

                _digitosElementoModelo = value;
                RaisePropertyChanged(digitosElementoModeloPropertyName);
            }
        }


        #endregion

        #region  codigoelemento

        public const string codigoelementoPropertyName = "codigoelemento";

        private int _codigoelemento = 0;

        public int codigoelemento
        {
            get
            {
                return _codigoelemento;
            }

            set
            {
                if (_codigoelemento == value)
                {
                    return;
                }

                _codigoelemento = value;
                RaisePropertyChanged(codigoelementoPropertyName);
            }
        }

        #endregion

        #endregion

        #region Propiedades asignacion

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


        #region fechacreaasignacion

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

            private decimal _preciohoraasignacion = 0;

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

        #endregion

        #region Lista asignaciones

        public const string listaAsignacionesPropertyName = "listaAsignaciones";

        private ObservableCollection<AsignacionModelo> _listaAsignaciones;

        public ObservableCollection<AsignacionModelo> listaAsignaciones
        {
            get
            {
                return _listaAsignaciones;
            }

            set
            {
                if (_listaAsignaciones == value) return;

                _listaAsignaciones = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaAsignacionesPropertyName);
            }
        }

        #endregion

        #region lista Sistema Contable

        public const string listaSistemaContablePropertyName = "listaSistemaContable";

        private ObservableCollection<SistemaContableModelo> _listaSistemaContable;

        public ObservableCollection<SistemaContableModelo> listaSistemaContable
        {
            get
            {
                return _listaSistemaContable;
            }

            set
            {
                if (_listaSistemaContable == value) return;

                _listaSistemaContable = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaSistemaContablePropertyName);
            }
        }

        #endregion

        #region Propiedades de  entidad encargo

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


        #region  Primary key idDigitosModelo

        public const string idDigitosModeloPropertyName = "idDigitosModelo";

        private int _idDigitosModelo = 0;

        public int idDigitosModelo
        {
            get
            {
                return _idDigitosModelo;
            }

            set
            {
                if (_idDigitosModelo == value)
                {
                    return;
                }

                _idDigitosModelo = value;
                RaisePropertyChanged(idDigitosModeloPropertyName);
            }
        }

        #endregion

        #region  Primary key Cliente idnitcliente

        public const string idnitclientePropertyName = "idnitcliente";

        private string _idnitcliente = string.Empty;

        /// <summary>
        /// Sets and gets the nombretablamc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string idnitcliente
        {
            get
            {
                return _idnitcliente;
            }

            set
            {
                if (_idnitcliente == value)
                {
                    return;
                }

                _idnitcliente = value;
                RaisePropertyChanged(idnitclientePropertyName);
            }
        }

        #endregion

        #region  Primary key tipo de auditoria idta

        public const string idtaPropertyName = "idta";

        private int _idta = 0;

        public int idta
        {
            get
            {
                return _idta;
            }

            set
            {
                if (_idta == value)
                {
                    return;
                }

                _idta = value;
                RaisePropertyChanged(idtaPropertyName);
            }
        }

        #endregion

        /*#region primary Key Idsc

        public const string idscPropertyName = "idsc";

        private int _idsc = 0;

        public int idsc
        {
            get
            {
                return _idsc;
            }

            set
            {
                if (_idsc == value)
                {
                    return;
                }

                _idsc = value;
                RaisePropertyChanged(idscPropertyName);
            }
        }


        #endregion*/

        #region idindice

        public const string idindicePropertyName = "idindice";

        private int _idindice = 0;

        public int idindice
        {
            get
            {
                return _idindice;
            }

            set
            {
                if (_idindice == value)
                {
                    return;
                }

                _idindice = value;
                RaisePropertyChanged(idindicePropertyName);
            }
        }

        #endregion

        #region fechacreadoencargo

        public const string fechacreadoencargoPropertyName = "fechacreadoencargo";

        private string _fechacreadoencargo = string.Empty;

        public string fechacreadoencargo
        {
            get
            {
                return _fechacreadoencargo;
            }

            set
            {
                if (_fechacreadoencargo == value)
                {
                    return;
                }

                _fechacreadoencargo = value;
                RaisePropertyChanged(fechacreadoencargoPropertyName);
            }
        }

        #endregion

        #region fecha de modificacion de plantilla

        public const string fechacreadoplantillaPropertyName = "fechacreadoplantilla";

        private string _fechacreadoplantilla = string.Empty;

        public string fechacreadoplantilla
        {
            get
            {
                return _fechacreadoplantilla;
            }

            set
            {
                if (_fechacreadoplantilla == value)
                {
                    return;
                }

                _fechacreadoplantilla = value;
                RaisePropertyChanged(fechacreadoplantillaPropertyName);
            }
        }

        #endregion

        #region tipoclienteencargo
        //Permite determinar si es un encargo recurrente (segunda o mas veces) que se hace el encargo del cliente.
        //True=El encargo es recurrente, False= Primera vez que se hace la auditoria. 
        //En el caso de las auditorias recurrentes permite utilizar archivos del encargo inmediato anterior.
        public const string tipoclienteencargoPropertyName = "tipoclienteencargo";

        private bool _tipoclienteencargo = false;

        public bool tipoclienteencargo
        {
            get
            {
                return _tipoclienteencargo;
            }

            set
            {
                if (_tipoclienteencargo == value)
                {
                    return;
                }

                _tipoclienteencargo = value;
                RaisePropertyChanged(tipoclienteencargoPropertyName);
            }
        }

        #endregion

        #region etapaencargo
        //Permite gestionar las diferentes etapas de los archivos que componen las auditorias. 
        //Se distinguen las siguientes etapas; I=inicial, P=En proceso, R=Revisado, C=Cerrado. 
        //Un encargo con estado = "Cerrado" no se debe modificar ningun elemento asociado a el.

        public const string etapaencargoPropertyName = "etapaencargo";

        private byte[] _etapaencargo = null;

        public byte[] etapaencargo
        {
            get
            {
                return _etapaencargo;
            }

            set
            {
                if (_etapaencargo == value)
                {
                    return;
                }

                _etapaencargo = value;
                RaisePropertyChanged(etapaencargoPropertyName);
            }
        }

        #endregion

        #region costoejecucionencargo

        public const string costoejecucionencargoPropertyName = "costoejecucionencargo";

        private decimal _costoejecucionencargo = 0;

        public decimal costoejecucionencargo
        {
            get
            {
                return _costoejecucionencargo;
            }

            set
            {
                if (_costoejecucionencargo == value)
                {
                    return;
                }

                _costoejecucionencargo = value;
                RaisePropertyChanged(costoejecucionencargoPropertyName);
            }
        }

        #endregion

        #region honorariosencargo

        public const string honorariosencargoPropertyName = "honorariosencargo";

        private decimal _honorariosencargo = 0;

        public decimal honorariosencargo
        {
            get
            {
                return _honorariosencargo;
            }

            set
            {
                if (_honorariosencargo == value)
                {
                    return;
                }

                _honorariosencargo = value;
                RaisePropertyChanged(honorariosencargoPropertyName);
            }
        }

        #endregion

        #region fechainiperauditencargo

        public const string fechainiperauditencargoPropertyName = "fechainiperauditencargo";

        private DateTime _fechainiperauditencargo;

        public DateTime fechainiperauditencargo
        {
            get
            {
                return _fechainiperauditencargo;
            }

            set
            {
                if (_fechainiperauditencargo == value)
                {
                    return;
                }

                _fechainiperauditencargo = value;
                RaisePropertyChanged(fechainiperauditencargoPropertyName);
            }
        }


        #endregion

        #region fechafinperauditencargo

        public const string fechafinperauditencargoPropertyName = "fechafinperauditencargo";

        private DateTime _fechafinperauditencargo;

        public DateTime fechafinperauditencargo
        {
            get
            {
                return _fechafinperauditencargo;
            }

            set
            {
                if (_fechafinperauditencargo == value)
                {
                    return;
                }

                _fechafinperauditencargo = value;
                RaisePropertyChanged(fechafinperauditencargoPropertyName);
            }
        }


        #endregion

        #region estadoencargo

        public const string estadoencargoPropertyName = "estadoencargo";

        private string _estadoencargo = string.Empty;

        public string estadoencargo
        {
            get
            {
                return _estadoencargo;
            }

            set
            {
                if (_estadoencargo == value)
                {
                    return;
                }

                _estadoencargo = value;
                RaisePropertyChanged(estadoencargoPropertyName);
            }
        }
        #endregion


        #endregion

        #region listas de encargos

        #region lista tipos auditoria modelo

        public const string listaTiposAuditoriaPropertyName = "listaTiposAuditoria";

        private ObservableCollection<TipoAuditoriaModelo> _listaTiposAuditoria;

        public ObservableCollection<TipoAuditoriaModelo> listaTiposAuditoria
        {
            get
            {
                return _listaTiposAuditoria;
            }

            set
            {
                if (_listaTiposAuditoria == value) return;

                _listaTiposAuditoria = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaTiposAuditoriaPropertyName);
            }
        }

        #endregion

        #region listaTiposAuditoria

        public const string listaTipoClienteEncargoPropertyName = "listaTipoClienteEncargo";

        private ObservableCollection<TipoClienteEncargoModelo> _listaTipoClienteEncargo;

        public ObservableCollection<TipoClienteEncargoModelo> listaTipoClienteEncargo
        {
            get
            {
                return _listaTipoClienteEncargo;
            }

            set
            {
                if (_listaTipoClienteEncargo == value) return;

                _listaTipoClienteEncargo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaTipoClienteEncargoPropertyName);
            }
        }

        #endregion

        #region listaClientes

        public const string listaClientesPropertyName = "listaClientes";

        private ObservableCollection<ClienteModelo> _listaClientes;

        public ObservableCollection<ClienteModelo> listaClientes
        {
            get
            {
                return _listaClientes;
            }

            set
            {
                if (_listaClientes == value) return;

                _listaClientes = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaClientesPropertyName);
            }
        }

        #endregion

        #endregion

        #region Sistema contable

        #region ViewModel Property : currentSistemaContable

        public const string currentSistemaContablePropertyName = "currentSistemaContable";

        private SistemaContableModelo _currentSistemaContable;

        public SistemaContableModelo currentSistemaContable
        {
            get
            {
                return _currentSistemaContable;
            }

            set
            {
                if (_currentSistemaContable == value) return;

                _currentSistemaContable = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentSistemaContablePropertyName);
            }
        }

        #endregion

        #region Propiedades

        #region idsc

        public const string idscPropertyName = "idsc";

        private int _idsc = 0;

        public int idsc
        {
            get
            {
                return _idsc;
            }

            set
            {
                if (_idsc == value)
                {
                    return;
                }

                _idsc = value;
                RaisePropertyChanged(idscPropertyName);
            }
        }

        #endregion

        #region idmoneda

        public const string idmonedaPropertyName = "idmoneda";

        private int _idmoneda = 0;

        public int idmoneda
        {
            get
            {
                return _idmoneda;
            }

            set
            {
                if (_idmoneda == value)
                {
                    return;
                }

                _idmoneda = value;
                RaisePropertyChanged(idmonedaPropertyName);
            }
        }

        #endregion


        /*#region idnitcliente

        public const string idnitclientePropertyName = "idnitcliente";

        private string _idnitcliente = string.Empty;

        public string idnitcliente
        {
            get
            {
                return _idnitcliente;
            }

            set
            {
                if (_idnitcliente == value)
                {
                    return;
                }

                _idnitcliente = value;
                RaisePropertyChanged(idnitclientePropertyName);
            }
        }

        #endregion*/

        #region ideef

        public const string ideefPropertyName = "ideef";

        private int _ideef = 0;

        public int ideef
        {
            get
            {
                return _ideef;
            }

            set
            {
                if (_ideef == value)
                {
                    return;
                }

                _ideef = value;
                RaisePropertyChanged(ideefPropertyName);
            }
        }

        #endregion

        #region fechasc

        public const string fechascPropertyName = "fechasc";

        private string _fechasc = string.Empty;

        public string fechasc
        {
            get
            {
                return _fechasc;
            }

            set
            {
                if (_fechasc == value)
                {
                    return;
                }

                _fechasc = value;
                RaisePropertyChanged(fechascPropertyName);
            }
        }

        #endregion

        #region digitoscuentamayorsc

        public const string digitoscuentamayorscPropertyName = "digitoscuentamayorsc";

        private int _digitoscuentamayorsc = 0;

        public int digitoscuentamayorsc
        {
            get
            {
                return _digitoscuentamayorsc;
            }

            set
            {
                if (_digitoscuentamayorsc == value)
                {
                    return;
                }

                _digitoscuentamayorsc = value;
                RaisePropertyChanged(digitoscuentamayorscPropertyName);
            }
        }

        #endregion

        #region digitosrubroscontablessc

        public const string digitosrubroscontablesscPropertyName = "digitosrubroscontablessc";

        private int _digitosrubroscontablessc = 0;

        public int digitosrubroscontablessc
        {
            get
            {
                return _digitosrubroscontablessc;
            }

            set
            {
                if (_digitosrubroscontablessc == value)
                {
                    return;
                }

                _digitosrubroscontablessc = value;
                RaisePropertyChanged(digitosrubroscontablesscPropertyName);
            }
        }

        #endregion


        #region periodoiniciosc

        public const string periodoinicioscPropertyName = "periodoiniciosc";

        private string _periodoiniciosc = string.Empty;

        public string periodoiniciosc
        {
            get
            {
                return _periodoiniciosc;
            }

            set
            {
                if (_periodoiniciosc == value)
                {
                    return;
                }

                _periodoiniciosc = value;
                RaisePropertyChanged(periodoinicioscPropertyName);
            }
        }

        #endregion

        #region periodofinsc

        public const string periodofinscPropertyName = "periodofinsc";

        private string _periodofinsc = string.Empty;

        public string periodofinsc
        {
            get
            {
                return _periodofinsc;
            }

            set
            {
                if (_periodofinsc == value)
                {
                    return;
                }

                _periodofinsc = value;
                RaisePropertyChanged(periodofinscPropertyName);
            }
        }

        #endregion


        #region estadosc

        public const string estadoscPropertyName = "estadosc";

        private string _estadosc = string.Empty;

        public string estadosc
        {
            get
            {
                return _estadosc;
            }

            set
            {
                if (_estadosc == value)
                {
                    return;
                }

                _estadosc = value;
                RaisePropertyChanged(estadoscPropertyName);
            }
        }

        #endregion


        #region estructuraEstadoFinancieroModelo

        public const string estructuraEstadoFinancieroModeloPropertyName = "estructuraEstadoFinancieroModelo";

        private EstructuraEstadoFinancieroModelo _estructuraEstadoFinancieroModelo;

        public EstructuraEstadoFinancieroModelo estructuraEstadoFinancieroModelo
        {
            get
            {
                return _estructuraEstadoFinancieroModelo;
            }

            set
            {
                if (_estructuraEstadoFinancieroModelo == value)
                {
                    return;
                }

                _estructuraEstadoFinancieroModelo = value;
                RaisePropertyChanged(estructuraEstadoFinancieroModeloPropertyName);
            }
        }

        #endregion

        #region monedaModelo

        public const string monedaModeloPropertyName = "monedaModelo";

        private MonedaModelo _monedaModelo;

        public MonedaModelo monedaModelo
        {
            get
            {
                return _monedaModelo;
            }

            set
            {
                if (_monedaModelo == value)
                {
                    return;
                }

                _monedaModelo = value;
                RaisePropertyChanged(monedaModeloPropertyName);
            }
        }

        #endregion


        //#region digitosCuentaMayorSc

        //public const string digitosCuentaMayorScPropertyName = "digitosCuentaMayorSc";

        //private DigitosModelo _digitosCuentaMayorSc;

        //public DigitosModelo digitosCuentaMayorSc
        //{
        //    get
        //    {
        //        return _digitosCuentaMayorSc;
        //    }

        //    set
        //    {
        //        if (_digitosCuentaMayorSc == value)
        //        {
        //            return;
        //        }

        //        _digitosCuentaMayorSc = value;
        //        RaisePropertyChanged(digitosCuentaMayorScPropertyName);
        //    }
        //}

        //#endregion

        //#region digitosRubrosContablesSc

        //public const string digitosRubrosContablesScPropertyName = "digitosRubrosContablesSc";

        //private DigitosModelo _digitosRubrosContablesSc;

        //public DigitosModelo digitosRubrosContablesSc
        //{
        //    get
        //    {
        //        return _digitosRubrosContablesSc;
        //    }

        //    set
        //    {
        //        if (_digitosRubrosContablesSc == value)
        //        {
        //            return;
        //        }

        //        _digitosRubrosContablesSc = value;
        //        RaisePropertyChanged(digitosRubrosContablesScPropertyName);
        //    }
        //}

        //#endregion

        #region elementoModelo

        public const string elementoModeloPropertyName = "elementoModelo";

        private int _elementoModelo = 0;

        public int elementoModelo
        {
            get
            {
                return _elementoModelo;
            }

            set
            {
                if (_elementoModelo == value)
                {
                    return;
                }

                _elementoModelo = value;
                RaisePropertyChanged(elementoModeloPropertyName);
            }
        }

        #endregion


        #endregion

        #region listas sistemas contables

        #region listaRubroContable

        public const string listaRubroContablePropertyName = "listaRubroContable";

        private ObservableCollection<DigitosModelo> _listaRubroContable;

        public ObservableCollection<DigitosModelo> listaRubroContable
        {
            get
            {
                return _listaRubroContable;
            }

            set
            {
                if (_listaRubroContable == value) return;

                _listaRubroContable = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaRubroContablePropertyName);
            }
        }

        #endregion

        #region listaCuentaContable

        public const string listaCuentaContablePropertyName = "listaCuentaContable";

        private ObservableCollection<DigitosModelo> _listaCuentaContable;

        public ObservableCollection<DigitosModelo> listaCuentaContable
        {
            get
            {
                return _listaCuentaContable;
            }

            set
            {
                if (_listaCuentaContable == value) return;

                _listaCuentaContable = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaCuentaContablePropertyName);
            }
        }

        #endregion

        #region listaMonedas

        public const string listaMonedasPropertyName = "listaMonedas";

        private ObservableCollection<MonedaModelo> _listaMonedas;

        public ObservableCollection<MonedaModelo> listaMonedas
        {
            get
            {
                return _listaMonedas;
            }

            set
            {
                if (_listaMonedas == value) return;

                _listaMonedas = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaMonedasPropertyName);
            }
        }

        #endregion

        #region listaEstructuraFinanciera

        public const string listaEstructuraFinancieraPropertyName = "listaEstructuraFinanciera";

        private ObservableCollection<EstructuraEstadoFinancieroModelo> _listaEstructuraFinanciera;

        public ObservableCollection<EstructuraEstadoFinancieroModelo> listaEstructuraFinanciera
        {
            get
            {
                return _listaEstructuraFinanciera;
            }

            set
            {
                if (_listaEstructuraFinanciera == value) return;

                _listaEstructuraFinanciera = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaEstructuraFinancieraPropertyName);
            }
        }

        #endregion

        #endregion

        #endregion


        #region Propiedes de presentacion agregadas

        #region razonsocialcliente

        public const string razonsocialclientePropertyName = "razonsocialcliente";

        private string _razonsocialcliente = string.Empty;

        public string razonsocialcliente
        {
            get
            {
                return _razonsocialcliente;
            }

            set
            {
                if (_razonsocialcliente == value)
                {
                    return;
                }

                _razonsocialcliente = value;
                RaisePropertyChanged(razonsocialclientePropertyName);
            }
        }

        #endregion

        #region descripcionEtapaEncargo

        public const string descripcionEtapaEncargoPropertyName = "descripcionEtapaEncargo";

        private string _descripcionEtapaEncargo = string.Empty;

        public string descripcionEtapaEncargo
        {
            get
            {
                return _descripcionEtapaEncargo;
            }

            set
            {
                if (_descripcionEtapaEncargo == value)
                {
                    return;
                }

                _descripcionEtapaEncargo = value;
                RaisePropertyChanged(descripcionEtapaEncargoPropertyName);
            }
        }

        #endregion

        #region descripcionTipoClienteEncargo

        public const string descripcionTipoClienteEncargoPropertyName = "descripcionTipoClienteEncargo";

        private string _descripcionTipoClienteEncargo = string.Empty;

        public string descripcionTipoClienteEncargo
        {
            get
            {
                return _descripcionTipoClienteEncargo;
            }

            set
            {
                if (_descripcionTipoClienteEncargo == value)
                {
                    return;
                }

                _descripcionTipoClienteEncargo = value;
                RaisePropertyChanged(descripcionTipoClienteEncargoPropertyName);
            }
        }


        #endregion

        #region descripcionTipoAuditoria

        public const string descripcionTipoAuditoriaPropertyName = "descripcionTipoAuditoria";

        private string _descripcionTipoAuditoria = string.Empty;

        public string descripcionTipoAuditoria
        {
            get
            {
                return _descripcionTipoAuditoria;
            }

            set
            {
                if (_descripcionTipoAuditoria == value)
                {
                    return;
                }

                _descripcionTipoAuditoria = value;
                RaisePropertyChanged(descripcionTipoAuditoriaPropertyName);
            }
        }


        #endregion

        #endregion

        #region Entidades en uso de encargos

        #region ViewModel Property : currentEntidadEncargo

        public const string currentEntidadEncargoPropertyName = "currentEntidadEncargo";

        private EncargoModelo _currentEntidadEncargo;

        public EncargoModelo currentEntidadEncargo
        {
            get
            {
                return _currentEntidadEncargo;
            }

            set
            {
                if (_currentEntidadEncargo == value) return;

                _currentEntidadEncargo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadEncargoPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentAsignacion

        public const string currentAsignacionPropertyName = "currentAsignacion";

        private AsignacionModelo _currentAsignacion;

        public AsignacionModelo currentAsignacion
        {
            get
            {
                return _currentAsignacion;
            }

            set
            {
                if (_currentAsignacion == value) return;

                _currentAsignacion = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentAsignacionPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentElementoContable

        public const string currentElementoContablePropertyName = "currentElementoContable";

        private ElementoModelo _currentElementoContable;

        public ElementoModelo currentElementoContable
        {
            get
            {
                return _currentElementoContable;
            }

            set
            {
                if (_currentElementoContable == value) return;

                _currentElementoContable = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentElementoContablePropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentDigitosElementoModelo

        public const string currentDigitosElementoModeloPropertyName = "currentDigitosElementoModelo";

        private DigitosModelo _currentDigitosElementoModelo;

        public DigitosModelo currentDigitosElementoModelo
        {
            get
            {
                return _currentDigitosElementoModelo;
            }

            set
            {
                if (_currentDigitosElementoModelo == value) return;

                _currentDigitosElementoModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentDigitosElementoModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentEntidadEncargoElemento

        public const string currentEntidadEncargoElementoPropertyName = "currentEntidadEncargoElemento";

        private ElementoModelo _currentEntidadEncargoElemento;

        public ElementoModelo currentEntidadEncargoElemento
        {
            get
            {
                return _currentEntidadEncargoElemento;
            }

            set
            {
                if (_currentEntidadEncargoElemento == value) return;

                _currentEntidadEncargoElemento = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadEncargoElementoPropertyName);
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

        #region ViewModel Property : usuarioModelo usuario

        public const string usuarioModeloPropertyName = "usuarioModelo";

        private UsuarioModelo _usuarioModelo;

        public UsuarioModelo usuarioModelo
        {
            get
            {
                return _usuarioModelo;
            }

            set
            {
                if (_usuarioModelo == value) return;

                _usuarioModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(usuarioModeloPropertyName);
            }
        }


        #endregion

        #region ViewModel Property : currentIndiceModelo

        public const string currentIndiceModeloPropertyName = "currentIndiceModelo";

        private IndiceModelo _currentIndiceModelo;

        public IndiceModelo currentIndiceModelo
        {
            get
            {
                return _currentIndiceModelo;
            }

            set
            {
                if (_currentIndiceModelo == value) return;

                _currentIndiceModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentIndiceModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : indiceModelo

        public const string indiceModeloPropertyName = "indiceModelo";

        private IndiceModelo _indiceModelo;

        public IndiceModelo indiceModelo
        {
            get
            {
                return _indiceModelo;
            }

            set
            {
                if (_indiceModelo == value) return;

                _indiceModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(indiceModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : tipoAuditoriaModelo

        public const string tipoAuditoriaModeloPropertyName = "tipoAuditoriaModelo";

        private TipoAuditoriaModelo _tipoAuditoriaModelo;

        public TipoAuditoriaModelo tipoAuditoriaModelo
        {
            get
            {
                return _tipoAuditoriaModelo;
            }

            set
            {
                if (_tipoAuditoriaModelo == value) return;

                _tipoAuditoriaModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(tipoAuditoriaModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : etapaEncargoModelo

        public const string etapaEncargoModeloPropertyName = "etapaEncargoModelo";

        private EtapaEncargoModelo _etapaEncargoModelo;

        public EtapaEncargoModelo etapaEncargoModelo
        {
            get
            {
                return _etapaEncargoModelo;
            }

            set
            {
                if (_etapaEncargoModelo == value) return;

                _etapaEncargoModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(etapaEncargoModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : tipoClienteEncargoModelo

        public const string tipoClienteEncargoModeloPropertyName = "tipoClienteEncargoModelo";

        private TipoClienteEncargoModelo _tipoClienteEncargoModelo;

        public TipoClienteEncargoModelo tipoClienteEncargoModelo
        {
            get
            {
                return _tipoClienteEncargoModelo;
            }

            set
            {
                if (_tipoClienteEncargoModelo == value) return;

                _tipoClienteEncargoModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(tipoClienteEncargoModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : clienteModelo

        public const string clienteModeloPropertyName = "clienteModelo";

        private ClienteModelo _clienteModelo;

        public ClienteModelo clienteModelo
        {
            get
            {
                return _clienteModelo;
            }

            set
            {
                if (_clienteModelo == value) return;

                _clienteModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(clienteModeloPropertyName);
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

        #region ViewModel Properties : habilitarCliente

        public const string habilitarClientePropertyName = "habilitarCliente";

        private bool _habilitarCliente ;

        public bool habilitarCliente
        {
            get
            {
                return _habilitarCliente;
            }

            set
            {
                if (_habilitarCliente == value)
                {
                    return;
                }

                _habilitarCliente = value;
                RaisePropertyChanged(habilitarClientePropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : habilitarEncargo

        public const string habilitarEncargoPropertyName = "habilitarEncargo";

        private bool _habilitarEncargo;

        public bool habilitarEncargo
        {
            get
            {
                return _habilitarEncargo;
            }

            set
            {
                if (_habilitarEncargo == value)
                {
                    return;
                }

                _habilitarEncargo = value;
                RaisePropertyChanged(habilitarEncargoPropertyName);
            }
        }

        #endregion


        #region ViewModel Properties : habilitarBotones

        public const string habilitarBotonesPropertyName = "habilitarBotones";

        private bool _habilitarBotones;

        public bool habilitarBotones
        {
            get
            {
                return _habilitarBotones;
            }

            set
            {
                if (_habilitarBotones == value)
                {
                    return;
                }

                _habilitarBotones = value;
                RaisePropertyChanged(habilitarBotonesPropertyName);
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

        #region MainModel

        private MainModel _AsignacionMainModel = null;

        public MainModel AsignacionMainModel
        {
            get
            {
                return _AsignacionMainModel;
            }

            set
            {
                _AsignacionMainModel = value;
            }
        }
        #endregion

        #endregion

        #region ViewModel Commands

        public RelayCommand AgregarEmpleadoCommand { get; set; }
        public RelayCommand EditarEmpleadoCommand { get; set; }
        public RelayCommand BorrarEmpleadoCommand { get; set; }
        public RelayCommand SeleccionarCommand { get; set; }
        public RelayCommand CopiarCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand GuardarCommand { get; set; }
        public RelayCommand CancelarCommand { get; set; }
        public RelayCommand OkCommand { get; set; }
        public RelayCommand SalirCommand { get; set; }
        public RelayCommand DoubleClickCommand { get; set; }

        public RelayCommand<DigitosModelo> SelectionCodigoCommand { get; set; }
        public RelayCommand<EncargoModelo> SelectionChangedCommand { get; set; }
        public RelayCommand<ElementoModelo> SelectionElementoCommand { get; set; }
        public RelayCommand<TipoAuditoriaModelo> SelectionTipoAuditoriaCommand { get; set; }
        public RelayCommand<ClienteModelo> SelectionClienteCommand { get; set; }
        public RelayCommand<TipoClienteEncargoModelo> SelectionRepetirCommand { get; set; }
        //public RelayCommand<DigitosModelo> SelectionRubroCommand { get; set; }

        //public RelayCommand<DigitosModelo> SelectionCuentasCommand { get; set; }
        public RelayCommand<MonedaModelo> SelectionMonedaCommand { get; set; }
        public RelayCommand<EstructuraEstadoFinancieroModelo> SelectionEEFCommand { get; set; }
        public RelayCommand<ElementoModelo> cellChangedCommand { get; set; }
        
        #endregion

        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public EdicionEncargoCrudControllerViewModel()
        {
            _evaluarCondiciones = false;//Vigila que se valide hasta recibir los mensajes con los datos
            _habilitarCliente = true;
            _controlEdicionElementoContable = true;
            _habilitarBotones = false;
            _tokenRecepcionCrudEncargos = "CrudEdicionEncargos";
            _tokenEnvioCrudEncargos = "CierreCrudEncargoEdicion";//Para comunicarse con Edicion View
            _codigoelemento = 0;
            //Suscribiendo el mensaje
            Messenger.Default.Register<encargosDatosCreacion>(this, tokenRecepcionCrudEncargos, (encargosDatosCreacion) => ControlencargosDatosCreacion(encargosDatosCreacion));
            Messenger.Default.Register<bool>(this, tokenRecepcionCierre, (controlVentanaMensaje) => ControlVentanaMensaje(controlVentanaMensaje));

            //Temporalmente  todos pero deben filtrarse por id de usuario

            listaEncargos = new ObservableCollection<EncargoModelo>();//Lista vacia depende del tipo de usuario

            listaElementos = new ObservableCollection<ElementoModelo>(ElementoModelo.GetAllForEncargo());
            listaElementosTemporal = new ObservableCollection<ElementoModelo>();
            listaDigitosElementoModelo = new ObservableCollection<DigitosModelo>(DigitosModelo.GetAll());

            #region encargos

            listaTipoClienteEncargo = new ObservableCollection<TipoClienteEncargoModelo>(TipoClienteEncargoModelo.GetAll());
            listaTiposAuditoria = new ObservableCollection<TipoAuditoriaModelo>(TipoAuditoriaModelo.GetAll());
            listaClientes = new ObservableCollection<ClienteModelo>(ClienteModelo.GetAll());
            currentEntidadEncargo = new EncargoModelo();

            #endregion


            #region Sistema contable

                //listaSistemaContable = new ObservableCollection<SistemaContableModelo>(SistemaContableModelo.GetAll());
                currentSistemaContable = null;
                listaRubroContable = new ObservableCollection<DigitosModelo>(DigitosModelo.GetAll());
                listaCuentaContable = new ObservableCollection<DigitosModelo>(DigitosModelo.GetAll());
                listaMonedas = new ObservableCollection<MonedaModelo>(MonedaModelo.GetAll());
                listaEstructuraFinanciera = new ObservableCollection<EstructuraEstadoFinancieroModelo>(EstructuraEstadoFinancieroModelo.GetAll());

            #endregion

            currentAsignacion = null;
            encabezadoPantalla = "";
            currentElementoContable = null;
            AsignacionMainModel = new MainModel();
            RegisterCommands();
            dlg = new DialogCoordinator();
            enviarMensajeInhabilitar();
            salida = false;
            accesibilidadWindow = true;
            habilitarEncargo = false;
            activarCarga = false;
            _habilitarEncargo = false;
            Errors = 0;//Control de errores
        }

        private void ControlVentanaMensaje(bool controlVentanaMensaje)
        {
            accesibilidadWindow = true;
            if (controlVentanaMensaje)
            {
                //Para controlar la ventana abierta
                AsignacionMainModel.TypeName = null;
                /*switch (comando)
                {
                    case 1:
                        currentAsignacion = null;
                        if (currentEntidadEncargo.idencargo != 0)
                        {
                            //Cargar lista de asignaciones con baseal encargo
                            listaAsignaciones = new ObservableCollection<AsignacionModelo>(AsignacionModelo.GetAll(currentEntidadEncargo.idencargo));
                        }
                        break;
                    case 2:
                        if (currentEntidadEncargo.idencargo != 0)
                        {
                            //Cargar lista de asignaciones con baseal encargo
                            listaAsignaciones = new ObservableCollection<AsignacionModelo>(AsignacionModelo.GetAll(currentEntidadEncargo.idencargo));
                        }
                        break;
                    case 3:
                        break;
                    case 5:
                        if (currentEntidadEncargo.idencargo != 0)
                        {
                            //Cargar lista de asignaciones con baseal encargo
                            listaAsignaciones = new ObservableCollection<AsignacionModelo>(AsignacionModelo.GetAll(currentEntidadEncargo.idencargo));
                        }
                        break;
                    default:
                        break;
                }*/
                //No se actualiza hasta que de le ok
                comando = 0;
            }
        }
        #endregion


        private void ControlencargosDatosCreacion(encargosDatosCreacion encargosDatosCreacion)
        {
            currentUsuarioModelo = encargosDatosCreacion.usuarioModelo;
            currentSistemaContable = encargosDatosCreacion.sistemaContable;
            if (encargosDatosCreacion.comando == 1)
            {
                //encabezadoPantalla = "Seleccione al usuario a asignar";
                accesibilidadWindow = true;
                visibilidadCrear = Visibility.Visible;
                visibilidadEditar = Visibility.Collapsed;
                visibilidadConsultar = Visibility.Collapsed;
                visibilidadCopiar = Visibility.Collapsed;
                habilitarCliente = true;
            }
            else
            {
                if (encargosDatosCreacion.comando == 2)
                {
                    //encabezadoPantalla = "Modifique al usuario asignado";
                    accesibilidadWindow = true;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Visible;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCopiar = Visibility.Collapsed;
                    habilitarCliente = false;
                    habilitarEncargo = true;
                    habilitarBotones = true;
                }
                else
                {
                    if (encargosDatosCreacion.comando == 5)
                    {
                        //encabezadoPantalla = "Modifique el nombre de asignacion";
                        accesibilidadWindow = true;
                        visibilidadCrear = Visibility.Collapsed;
                        visibilidadEditar = Visibility.Collapsed;
                        visibilidadConsultar = Visibility.Collapsed;
                        visibilidadCopiar = Visibility.Visible;
                        habilitarEncargo = true;
                        habilitarCliente = false;
                        habilitarBotones = true;
                    }
                    else
                    {
                        //encabezadoPantalla = "Consulta de asignacion";
                        accesibilidadWindow = true;
                        visibilidadCrear = Visibility.Collapsed;
                        visibilidadEditar = Visibility.Collapsed;
                        visibilidadConsultar = Visibility.Visible;
                        visibilidadCopiar = Visibility.Collapsed;
                        habilitarEncargo = false;
                        habilitarCliente = false;
                        habilitarBotones = true;
                    }
                }
            }

            if (encargosDatosCreacion.listaElementos != null)
            {
                listaElementos = encargosDatosCreacion.listaElementos;
            }
            currentEntidadEncargo = encargosDatosCreacion.encargoModelo;
            comando = encargosDatosCreacion.comando;

            if (currentEntidadEncargo.idencargo != 0)
            {
                //Cargar lista de asignaciones con baseal encargo
                listaAsignaciones = new ObservableCollection<AsignacionModelo>(AsignacionModelo.GetAll(currentEntidadEncargo.idencargo));
            }
            else
            {
                listaAsignaciones = new ObservableCollection<AsignacionModelo>();
            }

            //Asignacion de valores
            periodoiniciosc = currentSistemaContable.periodoiniciosc;
            periodofinsc = currentSistemaContable.periodofinsc;
            //digitosRubrosContablesSc = listaRubroContable.Single(i => i.idDigitosModelo == currentSistemaContable.digitosrubroscontablessc);
            //digitosCuentaMayorSc = listaCuentaContable.Single(i => i.idDigitosModelo == currentSistemaContable.digitoscuentamayorsc);
            digitoscuentamayorsc = currentSistemaContable.digitoscuentamayorsc;
            digitosrubroscontablessc = currentSistemaContable.digitosrubroscontablessc;

            monedaModelo = listaMonedas.Single(i => i.id == currentSistemaContable.idmoneda);

            estructuraEstadoFinancieroModelo = listaEstructuraFinanciera.Single(i => i.id == currentSistemaContable.ideef);
            #region conversion  de fechas
            //fechainiperauditencargo = currentEntidadEncargo.fechainiperauditencargo;
            try
            {
                fechainiperauditencargo = MetodosModelo.convertirFecha(currentEntidadEncargo.fechainiperauditencargo);
            }
            catch (Exception)
            {
                //await dlg.ShowMessageAsync(this, "No se pudo convertir la fecha de inicio  de la auditoria", "");
                MensajesError("No se pudo convertir la fecha de inicio  de la auditoria", "");
                fechainiperauditencargo = new DateTime((DateTime.Now.Year - 1), 1, 1);
            }

            try
            {
                fechafinperauditencargo = MetodosModelo.convertirFecha(currentEntidadEncargo.fechafinperauditencargo);
            }
            catch (Exception)
            {
                //await dlg.ShowMessageAsync(this, "No se pudo convertir la fecha de fin  de la auditoria", "");
                MensajesError("No se pudo convertir la fecha de fin  de la auditoria", "");
                fechafinperauditencargo = new DateTime((DateTime.Now.Year - 1), 12, 31);
            }

            #endregion

            tipoAuditoriaModelo = listaTiposAuditoria.Single(i => i.id == currentEntidadEncargo.idta);
            tipoClienteEncargoModelo = listaTipoClienteEncargo.Single(i => i.tipoclienteencargo == currentEntidadEncargo.tipoclienteencargo);
            if (!string.IsNullOrEmpty(currentEntidadEncargo.idnitcliente))
            {
                clienteModelo = listaClientes.Single(i => i.idnitcliente == currentEntidadEncargo.idnitcliente);
            }
            evaluarCondiciones = true;//Activar edicion
            Messenger.Default.Unregister<encargosDatosCreacion>(this, tokenRecepcionCrudEncargos);

        }


        #endregion
        private async void MensajesError(string titulo, string subtitulo)
        {
            await dlg.ShowMessageAsync(this, titulo, subtitulo);
        }


        #region Implementacion de comandos
        public void nuevaAsignacion()
        {
            AsignacionMainModel.TypeName = "AsignacionModeloCrearView";
            currentAsignacion = new AsignacionModelo();
            comando = 1;
            accesibilidadWindow = false;
            enviarDatos();
        }

        public async void editarAsignacion()
        {
            if (!(currentAsignacion == null))
            {

                AsignacionMainModel.TypeName = "AsignacionModeloEditarView";
                comando = 2;
                accesibilidadWindow = false;
                enviarDatos();

            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a editar", "");
            }
        }

        public async void borrarAsignacion()
        {
            if (!(currentAsignacion == null))
            {
                if (currentAsignacion.guardadoBase|| currentAsignacion.idasignacion!=0)
                {
                    //Unicamente realiza un borrado lógico cambiando el estadoplantilla a B y actualizando el listado
                    //if (AsignacionModelo.DeleteBorradoLogico(currentAsignacion.idasignacion, true))

                    if (AsignacionModelo.Delete(currentAsignacion.idasignacion, true))
                    {
                        await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                        listaAsignaciones.Remove(currentAsignacion);
                        currentAsignacion = null;
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "No ha sido posible posible eliminar el registro", "");
                    }
                }
                else
                {
                    listaAsignaciones.Remove(currentAsignacion);
                }
            }
            else
            {
                //MessageBox.Show("Debe seleccionar el registro a editar","" ,MessageBoxButton.OKCancel);
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
            }
        }
        #endregion

        private async void Cancelar()
        {
            // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
            //Debe cerrar el sistema
            currentEntidadEncargo = null;
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
                currentEntidadEncargo = null;
                salida = true;
                CloseWindow();
            }
            else
            {
                //Ya procesado
            }
            enviarMensaje();
            enviarMensajeHabilitar();
        }


        public async void Guardar()
        {
            bool éxito = true;
            currentEntidadEncargo.fechafinperauditencargo = MetodosModelo.homologacionFecha(currentEntidadEncargo.fechafinperauditencargo);
            currentEntidadEncargo.fechainiperauditencargo = MetodosModelo.homologacionFecha(currentEntidadEncargo.fechainiperauditencargo);
            #region conversion  de fechas
            //fechainiperauditencargo = currentEntidadEncargo.fechainiperauditencargo;
            try
            {
                fechainiperauditencargo = MetodosModelo.convertirFecha(currentEntidadEncargo.fechainiperauditencargo);
            }
            catch (Exception)
            {
                //await dlg.ShowMessageAsync(this, "No se pudo convertir la fecha de inicio  de la auditoria", "");
                MensajesError("No se pudo convertir la fecha de inicio  de la auditoria", "");
                
                fechainiperauditencargo = new DateTime((DateTime.Now.Year - 1), 1, 1);
            }

            try
            {
                fechafinperauditencargo = MetodosModelo.convertirFecha(currentEntidadEncargo.fechafinperauditencargo);
            }
            catch (Exception)
            {
                // await dlg.ShowMessageAsync(this, "No se pudo convertir la fecha de fin  de la auditoria", "");
                MensajesError("No se pudo convertir la fecha de fin  de la auditoria", "");
                
                fechafinperauditencargo = new DateTime((DateTime.Now.Year - 1), 12, 31);
            }

            #endregion
            var prueba = listaElementos;
            //Guardar el encargo
            if (EncargoModelo.contarRepetidoRegistro(currentEntidadEncargo) == 0)
            {
                if (!(EncargoModelo.Insert(currentEntidadEncargo, true)))
                {
                    éxito = false;
                    //await dlg.ShowMessageAsync(this, "No fue posible insertar registro del encargo ", "");
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Ya existe un encargo para el mismo período y tipo de auditoría ", "");
                éxito = false;
            }
            //Procesar listado de asignaciones
            if (éxito)
            {
                if (listaAsignaciones.Count > 0)
                {
                    for (int i = 0; i < listaAsignaciones.Count; i++)
                    {
                        listaAsignaciones[i].idencargo = currentEntidadEncargo.idencargo;
                        if (AsignacionModelo.Insert(listaAsignaciones[i], true))
                        {
                            listaAsignaciones[i].guardadoBase = true;
                        }
                        else
                        {
                            i = listaAsignaciones.Count;
                            éxito = false;
                        }
                    }
                    if (!éxito)
                    {
                        await dlg.ShowMessageAsync(this, "No fue posible insertar registro del encargo por asignaciones ", "");
                    }
                }
            }
            //Procesar sistema contable
            if (éxito)
            {
                bool evaluacionSistemaContable = false;
                if (currentSistemaContable.idsc == 0)
                {
                    evaluacionSistemaContable = true;
                }
                else
                {
                    //if (SistemaContableModelo.contarRepetidoRegistro(currentSistemaContable) == 1)
                    evaluacionSistemaContable = false;
                }
                currentSistemaContable.idencargodsc = currentEntidadEncargo.idencargo;
                if (evaluacionSistemaContable)
                {
                    //currentEntidad.id = PlantillaModelo.IdAsignar();
                    if (currentSistemaContable.idsc == 0)
                    {
                        if (!(SistemaContableModelo.Insert(currentSistemaContable, true)))
                        {
                            await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro de sistema contable", "");
                            éxito = false;
                        }
                    }
                }
                else
                {
                    //Ya existe el registro del sistema  contable
                    if (!(SistemaContableModelo.UpdateModelo(currentSistemaContable, true)))
                    {
                        await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro de sistema contable", "");
                        éxito = false;
                    }
                }
            }
            //Insertar los elementos del sistema contable
            if (éxito)
            {
                for (int i=0;i<listaElementos.Count;i++)
                {
                    listaElementos[i].idnitcliente = currentSistemaContable.idnitcliente;
                    listaElementos[i].idscelementos = currentSistemaContable.idsc;
                    listaElementos[i].codigoelemento = listaElementos[i].digitosElementoModelo.idDigitosModelo;

                    if (éxito)
                    {
                        if (ElementoModelo.Insert(listaElementos[i], "insertar"))
                        {
                            listaElementos[i].guardadoBase = true;
                        }
                        else
                        {
                            i = listaElementos.Count;
                            éxito = false;
                        }
                    }
                }
                if (!éxito)
                {
                    await dlg.ShowMessageAsync(this, "No fue posible insertar el registro del elementos del sistema contable ", "");
                }
            }
            //Verificacion final
            if (éxito)
            {
                salida = true;
                await dlg.ShowMessageAsync(this, "Registro insertado con éxito", "");
                CloseWindow();
            }
            else
            {
                if(currentEntidadEncargo.idencargo!=0)
                { 
                //Borrar todo elementos, sistema contable, asignaciones, encargo
                if (!(EncargoModelo.Delete(currentEntidadEncargo)))
                {
                    await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro de encargo debe eliminarse manualmente", "");
                }
                }
            }
        }

        public void Copiar()
        {
            throw new NotImplementedException();
        }

        public async void Modificar()
        {
            bool éxito = true;
            int codigoMensaje = 0;
            currentEntidadEncargo.fechafinperauditencargo = MetodosModelo.homologacionFecha(currentEntidadEncargo.fechafinperauditencargo);
            currentEntidadEncargo.fechainiperauditencargo = MetodosModelo.homologacionFecha(currentEntidadEncargo.fechainiperauditencargo);
            #region conversion  de fechas
            //fechainiperauditencargo = currentEntidadEncargo.fechainiperauditencargo;
            try
            {
                fechainiperauditencargo = MetodosModelo.convertirFecha(currentEntidadEncargo.fechainiperauditencargo);
            }
            catch (Exception)
            {
                //await dlg.ShowMessageAsync(this, "No se pudo convertir la fecha de inicio  de la auditoria", "");
                    MensajesError("No se pudo convertir la fecha de inicio  de la auditoria", "");
                
     
                fechainiperauditencargo = new DateTime((DateTime.Now.Year - 1), 1, 1);
            }

            try
            {
                fechafinperauditencargo = MetodosModelo.convertirFecha(currentEntidadEncargo.fechafinperauditencargo);
            }
            catch (Exception)
            {
                //await dlg.ShowMessageAsync(this, "No se pudo convertir la fecha de fin  de la auditoria", "");
                MensajesError("No se pudo convertir la fecha de fin  de la auditoria", "");
                fechafinperauditencargo = new DateTime((DateTime.Now.Year - 1), 12, 31);
            }

            #endregion
            //Guardar el encargo
            if (EncargoModelo.contarRepetidoRegistro(currentEntidadEncargo) == 1)
            {
                if (currentEntidadEncargo.etapaencargo != "C")
                {
                    if (!(EncargoModelo.UpdateModelo(currentEntidadEncargo)))
                    {
                        éxito = false;
                        codigoMensaje = 1; //No pudo actualizarse
                        //await dlg.ShowMessageAsync(this, "No fue posible insertar registro del encargo ", "");
                    }
                }
                else
                {
                    éxito = false;
                    codigoMensaje = 2; //El  encargo esta cerrado no puede editarse
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Ya existe un encargo para el mismo período y tipo de auditoría ", "");
                éxito = false;
            }
            //Procesar listado de asignaciones
            if (éxito)
            {
                if (listaAsignaciones.Count > 0)
                {
                    for (int i = 0; i < listaAsignaciones.Count; i++)
                    {
                        listaAsignaciones[i].idencargo = currentEntidadEncargo.idencargo;
                        if (listaAsignaciones[i].idasignacion == 0)//Inserto una asignacion
                        {
                            if (AsignacionModelo.Insert(listaAsignaciones[i], true))
                            {
                                listaAsignaciones[i].guardadoBase = true;
                            }
                            else
                            {
                                i = listaAsignaciones.Count;
                                éxito = false;
                                codigoMensaje = 3; //Error en la insercion de nuevas asignaciones
                            }
                        }
                        else
                        {
                            if (AsignacionModelo.UpdateModelo(listaAsignaciones[i]))
                            {
                                listaAsignaciones[i].guardadoBase = true;
                            }
                            else
                            {
                                i = listaAsignaciones.Count;
                                éxito = false;
                                codigoMensaje = 4;//Error en la actualizacion de los datos
                            }
                        }
                    }
                    if (!éxito)
                    {
                        await dlg.ShowMessageAsync(this, "No fue posible insertar registro del encargo por asignaciones ", "");
                    }
                }
            }
            //Procesar sistema contable
            if (éxito)
            {
                //currentSistemaContable.idencargodsc = currentEntidadEncargo.idencargo;
                    if (!(SistemaContableModelo.UpdateModelo(currentSistemaContable, true)))
                    {
                        await dlg.ShowMessageAsync(this, "No ha sido posible actualizar el registro de sistema contable", "");
                        éxito = false;
                    }
            }
            //Insertar los elementos del sistema contable
            if (éxito)
            {
                for (int i = 0; i < listaElementos.Count; i++)
                {
                    //listaElementos[i].idnitcliente = currentSistemaContable.idnitcliente;
                    //listaElementos[i].idscelementos = currentSistemaContable.idsc;
                    listaElementos[i].codigoelemento = listaElementos[i].digitosElementoModelo.idDigitosModelo;
                    if (éxito)
                    {
                        if (ElementoModelo.UpdateModelo(listaElementos[i],true))
                        {
                            listaElementos[i].guardadoBase = true;
                        }
                        else
                        {
                            i = listaElementos.Count;
                            éxito = false;
                        }
                    }
                }
                if (!éxito)
                {
                    await dlg.ShowMessageAsync(this, "No fue posible actualizar el registro del elementos del sistema contable ", "");
                }
            }
            //Verificacion final
            if (éxito)
            {
                salida = true;
                await dlg.ShowMessageAsync(this, "Registro actualizado con éxito", "");
                CloseWindow();
            }
            else
            {
                switch (codigoMensaje)
                { 
                    case 1:
                    await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro de encargo debe eliminarse manualmente", "");
                    break;
                    case 2:
                        await dlg.ShowMessageAsync(this, "El encargo ya esta cerrado , no puede actualizare", "");
                        break;
                    case 3:
                        await dlg.ShowMessageAsync(this, "No se puedo  insertar las nuevas asignaciones", "");
                        break;
                    case 4:
                        await dlg.ShowMessageAsync(this, "Error en la actualizacion de las asignaciones", "");
                        break;
                }
            }
        }


        #endregion

        #region Mensajes

        public void enviarMensaje()
        {
            //Creando el mensaje de cierre
            bool cierre = true;
            Messenger.Default.Send(cierre, tokenEnvioCrudEncargos);
        }

        public void enviarMensajeInhabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = false;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }
        public void enviarMensajeHabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = true;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }



        #endregion

        #region Metodos de apoyo

        public bool CanSave()
        {
            
            bool evaluar = false;
            if (evaluarCondiciones)
            {
                if (currentEntidadEncargo == null)
                {
                    return evaluar;
                }
                else
                {
                    evaluar = (Errors == 0) &&
                               controlEdicionElementoContable &&
                               monedaModelo != null &&
                               estructuraEstadoFinancieroModelo != null &&
                               (tipoAuditoriaModelo != null) &&
                               tipoClienteEncargoModelo != null &&
                               unicidadCodigoContable() &&
                               (listaAsignaciones.Count >= 1);

                    return evaluar;
                }
            }
            else
            {
                return evaluar;
            }
        }

        private bool unicidadCodigoContable()
        {
            bool respuesta = true;
            int contador = 0;
            for (int j = 0; j < listaElementos.Count(); j++)
            {
                for (int k = 0; k < listaElementos.Count(); k++)
                {
                    if (listaElementos[j].digitosElementoModelo.idDigitosModelo == listaElementos[k].digitosElementoModelo.idDigitosModelo)
                    {
                        contador++;
                    }
                }
                if (contador > 1)
                {
                    j = listaElementos.Count();
                    respuesta = false;
                    //advertencia();
                }
                else
                {
                    contador = 0;
                }

            }
            return respuesta;
        }

        private void advertencia()
        {
            dlg.ShowMessageAsync(this, "Los valores de elementos contable no deben repetirse", "");
        }

        public bool CanSaveEmpleado()
        {
            bool evaluar = false;

            if (currentAsignacion == null)
            {
                return evaluar;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region ViewModel Private Methods

        private void RegisterCommands()

        {
            AgregarEmpleadoCommand = new RelayCommand(nuevaAsignacion);
            EditarEmpleadoCommand = new RelayCommand(editarAsignacion, CanSaveEmpleado);
            BorrarEmpleadoCommand = new RelayCommand(borrarAsignacion, CanSaveEmpleado);

            SeleccionarCommand = new RelayCommand(Seleccionar, CanSave);
            CopiarCommand = new RelayCommand(Copiar, CanSave);
            EditarCommand = new RelayCommand(Modificar, CanSave);
            GuardarCommand = new RelayCommand(Guardar, CanSave);//Creacion de expediente
            CancelarCommand = new RelayCommand(Cancelar);
            OkCommand = new RelayCommand(Ok);
            DoubleClickCommand = new RelayCommand(DobleClick);
            
            SalirCommand = new RelayCommand(Salir);
            SelectionCodigoCommand = new RelayCommand<DigitosModelo>(entidad =>
            {
                if (entidad == null) return;
                currentElementoContable.digitosElementoModelo = entidad;
                currentElementoContable.modificadoCodigo = true;
            });
            SelectionElementoCommand = new RelayCommand<ElementoModelo>(entidad =>
            {
                if (entidad == null) return;
                currentElementoContable = entidad;
            });
            SelectionChangedCommand = new RelayCommand<EncargoModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidadEncargo = entidad;
            });
            SelectionTipoAuditoriaCommand = new RelayCommand<TipoAuditoriaModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidadEncargo.tipoAuditoriaModelo = entidad;
                tipoAuditoriaModelo = entidad;
                currentEntidadEncargo.idta = entidad.id;
            });
            SelectionClienteCommand = new RelayCommand<ClienteModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidadEncargo.clienteModelo = entidad;
                clienteModelo = entidad;
                currentEntidadEncargo.idnitcliente = entidad.idnitcliente;
                currentSistemaContable.idnitcliente = entidad.idnitcliente;
                //Hacer las asignaciones y busquedas pertinentes
                //Buscar sistema contable si no existe será nuevo al igual que los elementos
                //Verificar que no exista un sistema  contablecon el idcliente y vacio
                SistemaContableModelo temporal = SistemaContableModelo.GetRegistroIdClienteVacio(currentEntidadEncargo.idnitcliente);
                if (temporal != null)
                {
                    currentSistemaContable = temporal;//Se utiliza el sistema contable vacio
                                                      //Buscar si estan creados los elementos del  sistema contable
                                                      //listaElementosTemporal = new ObservableCollection<ElementoModelo>(ElementoModelo.GetAll(currentSistemaContable.idsc));
                   
                    if (temporal.listaElementoModelo.Count > 0)
                    {
                        listaElementos = new ObservableCollection<ElementoModelo>(temporal.listaElementoModelo);
                    }
                    else
                    {
                        //Se utiliza los valores que vienen por defecto
                    }
                }
                else
                {
                    //No esta creado el sistema contable debe generarse, al igual que los  elementos
                }
                //Buscar elementos del sistema contable
                habilitarEncargo = true;
                habilitarBotones = true;

            });
            SelectionRepetirCommand = new RelayCommand<TipoClienteEncargoModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidadEncargo.tipoClienteEncargoModelo = entidad;
                tipoClienteEncargoModelo = entidad;
                currentEntidadEncargo.tipoclienteencargo = (bool)entidad.tipoclienteencargo;
            });


            SelectionMonedaCommand = new RelayCommand<MonedaModelo>(entidad =>
            {
                if (entidad == null) return;
                currentSistemaContable.monedaModelo = entidad;
                monedaModelo = entidad;
                currentSistemaContable.idmoneda = entidad.id;
            });

            SelectionEEFCommand = new RelayCommand<EstructuraEstadoFinancieroModelo>(entidad =>
            {
                if (entidad == null) return;
                currentSistemaContable.estructuraEstadoFinancieroModelo = entidad;
                estructuraEstadoFinancieroModelo = entidad;
                currentSistemaContable.ideef = entidad.id;
            });
            cellChangedCommand = new RelayCommand<ElementoModelo>(async entidad =>
            {
                controlEdicionElementoContable = true;
                if (entidad == null) return;
                currentElementoContable = entidad;
                int cuenta = 0;
                if(controlEdicionElementoContable)
                { 
                foreach (ElementoModelo item in listaElementos)
                {
                    if (item.digitosElementoModelo.idDigitosModelo == currentElementoContable.digitosElementoModelo.idDigitosModelo)
                    {
                        cuenta++;
                    }
                }
                    if (cuenta >= 2)
                    {
                        controlEdicionElementoContable = false;
                        await dlg.ShowMessageAsync(this, "Los valores de código contable no deben repetirse", "");
                    }
                }

            });
    }

        private void DobleClick()
        {
            //throw new NotImplementedException();
        }

        private void Seleccionar()
        {
            salida = true;
            CloseWindow();
        }

        public void enviarDatos()
        {
            //Se crea el mensaje
            AsignacionDatosMensaje mensaje = new AsignacionDatosMensaje();
            mensaje.asignacionModelo = currentAsignacion;
            mensaje.listaAsignacionModelo = listaAsignaciones;
            mensaje.comandoCrud = comando;
            mensaje.usuarioModelo = currentUsuarioModelo;
            Messenger.Default.Send(mensaje, tokenEnvioAsignacion);
        }

        #endregion

        #region Verifica unicidad
        //Cada marca debe ser única
        public int contenidoUnico(EncargoModelo elemento, ObservableCollection<EncargoModelo> listaBusqueda)
        {
            int numeroRegistros;
            EncargoModelo m = elemento;
            numeroRegistros = listaBusqueda.Where(j => (j.clienteModelo.idnitcliente + j.tipoAuditoriaModelo.id + j.fechafinperauditencargo + j.fechainiperauditencargo) == (m.clienteModelo.idnitcliente + m.tipoAuditoriaModelo.id + m.fechafinperauditencargo + m.fechainiperauditencargo)).Count();
            if (numeroRegistros == 1)
            {
                return 1;
            }
            else
            {
                return numeroRegistros;
            }
        }
        #endregion



    }
}

