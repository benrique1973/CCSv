using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using System.Collections.ObjectModel;
using System;
using SGPTWpf.Model;
using System.Windows;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using SGPTWpf.Model.Modelo.Encargos;
using System.Windows.Input;
using SGPTWpf.Messages;
using SGPTWpf.ViewModel;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using System.Linq;
using System.ComponentModel;
using SGPTWpf.SGPtWpf.Model.Modelo.Menus;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using Word = NetOffice.WordApi;
//using NetOffice.OfficeApi.Tools;
using Excel = NetOffice.ExcelApi;

using PowerPoint = NetOffice.PowerPointApi;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Repositorio
{

    public sealed class RepositorioViewModel : ViewModeloBase
    {

        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;
        public static int Errors { get; set; }//Para controllar los errores de edición

        #region origenLlamada

        private string _origenLlamada;
        private string origenLlamada
        {
            get { return _origenLlamada; }
            set { _origenLlamada = value; }
        }

        #endregion

        #region fileName

        private string _fileName;
        private string fileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        #endregion

        #region tablaDetalle

        private string _tablaDetalle;
        private string tablaDetalle
        {
            get { return _tablaDetalle; }
            set { _tablaDetalle = value; }
        }

        #endregion

        #region tokenRecepcionPadre

        private string _tokenRecepcionPadre;
        private string tokenRecepcionPadre
        {
            get { return _tokenRecepcionPadre; }
            set { _tokenRecepcionPadre = value; }
        }

        #endregion

        #region tokenRecepcionHijo

        private string _tokenRecepcionHijo;
        private string tokenRecepcionHijo
        {
            get { return _tokenRecepcionHijo; }
            set { _tokenRecepcionHijo = value; }
        }

        #endregion

        #region tokenRecepcionSubMenu

        private string _tokenRecepcionSubMenu;
        private string tokenRecepcionSubMenu
        {
            get { return _tokenRecepcionSubMenu; }
            set { _tokenRecepcionSubMenu = value; }
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

        #region comando

        private int _comando;
        private int comando
        {
            get { return _comando; }
            set { _comando = value; }
        }

        #endregion

        #region fuenteLlamado //Sirve para diferenciar las fuentas de  la llamada para las vistas
        //0 Sin identificar
        //1 Plan Indices
        //2 Plan Indices detalle
        //3 Documentacion indice
        //4 Documentacion detalle indice

        private int _fuenteLlamado;
        private int fuenteLlamado
        {
            get { return _fuenteLlamado; }
            set { _fuenteLlamado = value; }
        }

        #endregion


        #region iddocumento //Sirve para diferenciar las fuentas de  la llamada para las vistas

        //1;"Actas";"A";TRUE
        //2;"Carta";"A";TRUE
        //3;"Cédula";"A";TRUE
        //4;"Confirmación";"A";TRUE
        //5;"Email";"A";TRUE
        //6;"Estados financieros";"A";TRUE
        //7;"Informe de auditoría";"A";TRUE
        //8;"Memorando";"A";TRUE
        //9;"Reunión";"A";TRUE
        //10;"Otros";"A";TRUE

        //Indica la clase de documento
        private int _iddocumento;
        private int iddocumento
        {
            get { return _iddocumento; }
            set { _iddocumento = value; }
        }

        #endregion

        private DialogCoordinator dlg;

        #region tokenRecepcionCierrePreView

        private string _tokenRecepcionCierrePreView;
        private string tokenRecepcionCierrePreView
        {
            get { return _tokenRecepcionCierrePreView; }
            set { _tokenRecepcionCierrePreView = value; }
        }

        #endregion

        #endregion

        #region tokenEnvioDatosAHijo

        private string _tokenEnvioDatosAHijo;
        private string tokenEnvioDatosAHijo
        {
            get { return _tokenEnvioDatosAHijo; }
            set { _tokenEnvioDatosAHijo = value; }
        }

        #endregion

        #region tokenEnvioDatosAVistaPreview

        private string _tokenEnvioDatosAVistaPreview;
        private string tokenEnvioDatosAVistaPreview
        {
            get { return _tokenEnvioDatosAVistaPreview; }
            set { _tokenEnvioDatosAVistaPreview = value; }
        }

        #endregion

        #region tokenEnvioDatosCarga

        private string _tokenEnvioDatosCarga;
        private string tokenEnvioDatosCarga
        {
            get { return _tokenEnvioDatosCarga; }
            set { _tokenEnvioDatosCarga = value; }
        }

        #endregion


        #region tokenRecepcionDatosCarga

        private string _tokenRecepcionDatosCarga;
        private string tokenRecepcionDatosCarga
        {
            get { return _tokenRecepcionDatosCarga; }
            set { _tokenRecepcionDatosCarga = value; }
        }

        #endregion

        #region ViewModel Properties : SelectedItems

        public const string SelectedItemsPropertyName = "SelectedItems";

        private ObservableCollection<RepositorioModelo> _SelectedItems;

        public ObservableCollection<RepositorioModelo> SelectedItems
        {
            get
            {
                return _SelectedItems;
            }
            set
            {
                if (_SelectedItems == value) return;

                _SelectedItems = value;

                RaisePropertyChanged(SelectedItemsPropertyName);
            }
        }

        #endregion

        #region Nombre tipo auditoria

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


        #region Visibilidad de  botones



        #region visibilidadMCrear

        public const string visibilidadMCrearPropertyName = "visibilidadMCrear";

        private Visibility _visibilidadMCrear = Visibility.Collapsed;

        public Visibility visibilidadMCrear
        {
            get
            {
                return _visibilidadMCrear;
            }

            set
            {
                if (_visibilidadMCrear == value)
                {
                    return;
                }

                _visibilidadMCrear = value;
                RaisePropertyChanged(visibilidadMCrearPropertyName);
            }
        }

        #endregion

        #region visibilidadMEditar

        public const string visibilidadMEditarPropertyName = "visibilidadMEditar";

        private Visibility _visibilidadMEditar = Visibility.Collapsed;

        public Visibility visibilidadMEditar
        {
            get
            {
                return _visibilidadMEditar;
            }

            set
            {
                if (_visibilidadMEditar == value)
                {
                    return;
                }

                _visibilidadMEditar = value;
                RaisePropertyChanged(visibilidadMEditarPropertyName);
            }
        }

        #endregion

        #region visibilidadMReferenciar

        public const string visibilidadMReferenciarPropertyName = "visibilidadMReferenciar";

        private Visibility _visibilidadMReferenciar = Visibility.Collapsed;

        public Visibility visibilidadMReferenciar
        {
            get
            {
                return _visibilidadMReferenciar;
            }

            set
            {
                if (_visibilidadMReferenciar == value)
                {
                    return;
                }

                _visibilidadMReferenciar = value;
                RaisePropertyChanged(visibilidadMReferenciarPropertyName);
            }
        }

        #endregion

        #region visibilidadMCerrar

        public const string visibilidadMCerrarPropertyName = "visibilidadMCerrar";

        private Visibility _visibilidadMCerrar = Visibility.Collapsed;

        public Visibility visibilidadMCerrar
        {
            get
            {
                return _visibilidadMCerrar;
            }

            set
            {
                if (_visibilidadMCerrar == value)
                {
                    return;
                }

                _visibilidadMCerrar = value;
                RaisePropertyChanged(visibilidadMCerrarPropertyName);
            }
        }

        #endregion

        #region visibilidadMSupervisar

        public const string visibilidadMSupervisarPropertyName = "visibilidadMSupervisar";

        private Visibility _visibilidadMSupervisar = Visibility.Collapsed;

        public Visibility visibilidadMSupervisar
        {
            get
            {
                return _visibilidadMSupervisar;
            }

            set
            {
                if (_visibilidadMSupervisar == value)
                {
                    return;
                }

                _visibilidadMSupervisar = value;
                RaisePropertyChanged(visibilidadMSupervisarPropertyName);
            }
        }

        #endregion

        #region visibilidadMAprobar

        public const string visibilidadMAprobarPropertyName = "visibilidadMAprobar";

        private Visibility _visibilidadMAprobar = Visibility.Collapsed;

        public Visibility visibilidadMAprobar
        {
            get
            {
                return _visibilidadMAprobar;
            }

            set
            {
                if (_visibilidadMAprobar == value)
                {
                    return;
                }

                _visibilidadMAprobar = value;
                RaisePropertyChanged(visibilidadMAprobarPropertyName);
            }
        }

        #endregion

        #region visibilidadMBorrar

        public const string visibilidadMBorrarPropertyName = "visibilidadMBorrar";

        private Visibility _visibilidadMBorrar = Visibility.Collapsed;

        public Visibility visibilidadMBorrar
        {
            get
            {
                return _visibilidadMBorrar;
            }

            set
            {
                if (_visibilidadMBorrar == value)
                {
                    return;
                }

                _visibilidadMBorrar = value;
                RaisePropertyChanged(visibilidadMBorrarPropertyName);
            }
        }

        #endregion

        #region visibilidadMConsulta

        public const string visibilidadMConsultaPropertyName = "visibilidadMConsulta";

        private Visibility _visibilidadMConsulta = Visibility.Collapsed;

        public Visibility visibilidadMConsulta
        {
            get
            {
                return _visibilidadMConsulta;
            }

            set
            {
                if (_visibilidadMConsulta == value)
                {
                    return;
                }

                _visibilidadMConsulta = value;
                RaisePropertyChanged(visibilidadMConsultaPropertyName);
            }
        }

        #endregion

        #region visibilidadMDetalle

        public const string visibilidadMDetallePropertyName = "visibilidadMDetalle";

        private Visibility _visibilidadMDetalle = Visibility.Collapsed;

        public Visibility visibilidadMDetalle
        {
            get
            {
                return _visibilidadMDetalle;
            }

            set
            {
                if (_visibilidadMDetalle == value)
                {
                    return;
                }

                _visibilidadMDetalle = value;
                RaisePropertyChanged(visibilidadMDetallePropertyName);
            }
        }

        #endregion

        #region visibilidadMVista

        public const string visibilidadMVistaPropertyName = "visibilidadMVista";

        private Visibility _visibilidadMVista = Visibility.Collapsed;

        public Visibility visibilidadMVista
        {
            get
            {
                return _visibilidadMVista;
            }

            set
            {
                if (_visibilidadMVista == value)
                {
                    return;
                }

                _visibilidadMVista = value;
                RaisePropertyChanged(visibilidadMVistaPropertyName);
            }
        }

        #endregion

        #region visibilidadMTask

        public const string visibilidadMTaskPropertyName = "visibilidadMTask";

        private Visibility _visibilidadMTask = Visibility.Collapsed;

        public Visibility visibilidadMTask
        {
            get
            {
                return _visibilidadMTask;
            }

            set
            {
                if (_visibilidadMTask == value)
                {
                    return;
                }

                _visibilidadMTask = value;
                RaisePropertyChanged(visibilidadMTaskPropertyName);
            }
        }

        #endregion


        #region visibilidadMRegresar

        public const string visibilidadMRegresarPropertyName = "visibilidadMRegresar";

        private Visibility _visibilidadMRegresar = Visibility.Hidden;

        public Visibility visibilidadMRegresar
        {
            get
            {
                return _visibilidadMRegresar;
            }

            set
            {
                if (_visibilidadMRegresar == value)
                {
                    return;
                }

                _visibilidadMRegresar = value;
                RaisePropertyChanged(visibilidadMRegresarPropertyName);
            }
        }

        #endregion


        #region visibilidadMImportar

        public const string visibilidadMImportarPropertyName = "visibilidadMImportar";

        private Visibility _visibilidadMImportar = Visibility.Hidden;

        public Visibility visibilidadMImportar
        {
            get
            {
                return _visibilidadMImportar;
            }

            set
            {
                if (_visibilidadMImportar == value)
                {
                    return;
                }

                _visibilidadMImportar = value;
                RaisePropertyChanged(visibilidadMImportarPropertyName);
            }
        }

        #endregion

        #region visibilidadMImprimir

        public const string visibilidadMImprimirPropertyName = "visibilidadMImprimir";

        private Visibility _visibilidadMImprimir = Visibility.Hidden;

        public Visibility visibilidadMImprimir
        {
            get
            {
                return _visibilidadMImprimir;
            }

            set
            {
                if (_visibilidadMImprimir == value)
                {
                    return;
                }

                _visibilidadMImprimir = value;
                RaisePropertyChanged(visibilidadMImprimirPropertyName);
            }
        }

        #endregion

        #endregion

        //http://stackoverflow.com/questions/14918602/isselected-binding-in-wpf-datagrid

        #region ViewModel Properties : IsSelected

        public const string IsSelectedPropertyName = "IsSelected";

        private bool _IsSelected;

        public bool IsSelected
        {
            get
            {
                return _IsSelected;
            }

            set
            {
                if (_IsSelected == value)
                {
                    return;
                }

                _IsSelected = value;
                RaisePropertyChanged(IsSelectedPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : isListaCargada

        public const string isListaCargadaPropertyName = "isListaCargada";

        private bool _isListaCargada;

        public bool isListaCargada
        {
            get
            {
                return _isListaCargada;
            }

            set
            {
                if (_isListaCargada == value)
                {
                    return;
                }

                _isListaCargada = value;
                RaisePropertyChanged(isListaCargadaPropertyName);
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

        #region ViewModel Property : currentEncargo

        public const string currentEncargoPropertyName = "currentEncargo";

        private EncargoModelo _currentEncargo;

        public EncargoModelo currentEncargo
        {
            get
            {
                return _currentEncargo;
            }

            set
            {
                if (_currentEncargo == value) return;

                _currentEncargo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEncargoPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties publicas

        #region encabezadoPrograma

        public const string encabezadoProgramaPropertyName = "encabezadoPrograma";

        private string _encabezadoPrograma = string.Empty;

        public string encabezadoPrograma
        {
            get
            {
                return _encabezadoPrograma;
            }

            set
            {
                if (_encabezadoPrograma == value)
                {
                    return;
                }

                _encabezadoPrograma = value;
                RaisePropertyChanged(encabezadoProgramaPropertyName);
            }
        }

        #endregion

        #region visibilidadTipoPrograma

        public const string visibilidadTipoProgramaPropertyName = "visibilidadTipoPrograma";

        private Visibility _visibilidadTipoPrograma = Visibility.Visible;

        public Visibility visibilidadTipoPrograma
        {
            get
            {
                return _visibilidadTipoPrograma;
            }

            set
            {
                if (_visibilidadTipoPrograma == value)
                {
                    return;
                }

                _visibilidadTipoPrograma = value;
                RaisePropertyChanged(visibilidadTipoProgramaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : lista

        public const string listaPropertyName = "lista";

        private ObservableCollection<RepositorioModelo> _lista;

        public ObservableCollection<RepositorioModelo> lista
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

        #region listaArchivosCreados entidades

        //Mantendra un histórico de los archivos que se descargan y los borrará

        public const string listaArchivosCreadosPropertyName = "listaArchivosCreados";


        private ObservableCollection<string> _listaArchivosCreados;

        public ObservableCollection<string> listaArchivosCreados
        {
            get
            {
                return _listaArchivosCreados;
            }

            set
            {
                if (_listaArchivosCreados == value) return;

                _listaArchivosCreados = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaArchivosCreadosPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaCompleta

        public const string listaCompletaPropertyName = "listaCompleta";

        private ObservableCollection<RepositorioModelo> _listaCompleta;

        public ObservableCollection<RepositorioModelo> listaCompleta
        {
            get
            {
                return _listaCompleta;
            }

            set
            {
                if (_listaCompleta == value) return;

                _listaCompleta = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaCompletaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaDetalles

        public const string listaDetallesPropertyName = "listaDetalles";

        private ObservableCollection<BitacoraModelo> _listaDetalles;

        public ObservableCollection<BitacoraModelo> listaDetalles
        {
            get
            {
                return _listaDetalles;
            }

            set
            {
                if (_listaDetalles == value) return;

                _listaDetalles = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaDetallesPropertyName);
            }
        }

        #endregion

        #region Entidades

        #region ViewModel Property : currentEntidad 

        public const string currentEntidadPropertyName = "currentEntidad";

        private RepositorioModelo _currentEntidad;

        public RepositorioModelo currentEntidad
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

        #endregion


        #region Propiedades Catalogo Contale

        #region idCorrelativo

        public const string idCorrelativoPropertyName = "idCorrelativo";

        private int _idCorrelativo = 0;

        public int idCorrelativo
        {
            get
            {
                return _idCorrelativo;
            }

            set
            {
                if (_idCorrelativo == value)
                {
                    return;
                }

                _idCorrelativo = value;
                RaisePropertyChanged(idCorrelativoPropertyName);
            }
        }

        #endregion

        #region idcc

        public const string idccPropertyName = "idcc";

        private int _idcc = 0;

        public int idcc
        {
            get
            {
                return _idcc;
            }

            set
            {
                if (_idcc == value)
                {
                    return;
                }

                _idcc = value;
                RaisePropertyChanged(idccPropertyName);
            }
        }

        #endregion

        #region idelementos

        public const string idelementosPropertyName = "idelementos";

        private int _idelementos = 0;

        public int idelementos
        {
            get
            {
                return _idelementos;
            }

            set
            {
                if (_idelementos == value)
                {
                    return;
                }

                _idelementos = value;
                RaisePropertyChanged(idelementosPropertyName);
            }
        }

        #endregion

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


        #region catidcc

        public const string catidccPropertyName = "catidcc";

        private int _catidcc = 0;

        public int catidcc
        {
            get
            {
                return _catidcc;
            }

            set
            {
                if (_catidcc == value)
                {
                    return;
                }

                _catidcc = value;
                RaisePropertyChanged(catidccPropertyName);
            }
        }

        #endregion

        #region idccuentas

        public const string idccuentasPropertyName = "idccuentas";

        private int _idccuentas = 0;

        public int idccuentas
        {
            get
            {
                return _idccuentas;
            }

            set
            {
                if (_idccuentas == value)
                {
                    return;
                }

                _idccuentas = value;
                RaisePropertyChanged(idccuentasPropertyName);
            }
        }

        #endregion


        #region codigocc

        public const string usuarioModificoPropertyName = "codigocc";

        private string _usuarioModifico = string.Empty;

        public string codigocc
        {
            get
            {
                return _usuarioModifico;
            }

            set
            {
                if (_usuarioModifico == value)
                {
                    return;
                }

                _usuarioModifico = value;
                RaisePropertyChanged(usuarioModificoPropertyName);
            }
        }

        #endregion

        #region codigoContablePadre
        public string codigoContablePadre
        {
            get
            {
                return _usuarioModifico;
            }

            set
            {
                if (_usuarioModifico == value)
                {
                    return;
                }

                _usuarioModifico = value;
                RaisePropertyChanged(usuarioModificoPropertyName);
            }
        }

        #endregion

        #region descripcioncc

        public const string nombreHerramientaPropertyName = "descripcioncc";

        private string _nombreHerramienta = string.Empty;

        public string descripcioncc
        {
            get
            {
                return _nombreHerramienta;
            }

            set
            {
                if (_nombreHerramienta == value)
                {
                    return;
                }

                _nombreHerramienta = value;
                RaisePropertyChanged(nombreHerramientaPropertyName);
            }
        }

        #endregion

        #region tiposaldocc

        public const string autorizadoPorHerramientaPropertyName = "tiposaldocc";

        private string _autorizadoPorHerramienta = string.Empty;

        public string tiposaldocc
        {
            get
            {
                return _autorizadoPorHerramienta;
            }

            set
            {
                if (_autorizadoPorHerramienta == value)
                {
                    return;
                }

                _autorizadoPorHerramienta = value;
                RaisePropertyChanged(autorizadoPorHerramientaPropertyName);
            }
        }

        #endregion

        #region fechacreacioncc

        public const string fechacreadoherramientaPropertyName = "fechacreacioncc";

        private DateTime _fechacreadoherramienta = DateTime.Now;

        public DateTime fechacreacioncc
        {
            get
            {
                return _fechacreadoherramienta;
            }

            set
            {
                if (_fechacreadoherramienta == value)
                {
                    return;
                }

                _fechacreadoherramienta = value;
                RaisePropertyChanged(fechacreadoherramientaPropertyName);
            }
        }

        #endregion


        #region ordencc

        public const string ordenccPropertyName = "ordencc";

        private decimal _ordencc = 0;

        public decimal ordencc
        {
            get
            {
                return _ordencc;
            }

            set
            {
                if (_ordencc == value)
                {
                    return;
                }

                _ordencc = value;
                RaisePropertyChanged(ordenccPropertyName);
            }
        }

        #endregion

        #region estadocc

        public const string estadoccPropertyName = "estadocc";

        private string _estadocc = string.Empty;

        public string estadocc
        {
            get
            {
                return _estadocc;
            }

            set
            {
                if (_estadocc == value)
                {
                    return;
                }

                _estadocc = value;
                RaisePropertyChanged(estadoccPropertyName);
            }
        }

        #endregion


        #endregion

        #region ViewModel Properties : accesibilidadWindow

        public const string accesibilidadWindowPropertyName = "accesibilidadWindow";

        private bool _accesibilidadWindow;

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

        #region Properties : cursorWindow

        public const string cursorWindowPropertyName = "cursorWindow";

        private Cursor _cursorWindow;

        public Cursor cursorWindow
        {
            get
            {
                return _cursorWindow;
            }

            set
            {
                if (_cursorWindow == value)
                {
                    return;
                }

                _cursorWindow = value;
                RaisePropertyChanged(cursorWindowPropertyName);
            }
        }

        #endregion


        #endregion

        #region ViewModel Commands
        //public RelayCommand cmdCargarCatalogo { get; set; }


        public RelayCommand NuevoCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand BorrarCommand { get; set; }
        public RelayCommand ConsultarCommand { get; set; }
        public RelayCommand copiarCommand { get; set; }
        public RelayCommand DoubleClickCommand { get; set; }
        public RelayCommand XImprimirCommand { get; set; }
        public RelayCommand VistaProgramaCommand { get; set; }
        public RelayCommand<RepositorioModelo> SelectionChangedCommand { get; set; }
        public RelayCommand detalleCommand { get; set; }

        public RelayCommand vistaCommand { get; set; }
        public RelayCommand ImportarCommand { get; set; }
        public RelayCommand referenciarCommand { get; set; }
        public RelayCommand terminarPapelCommand { get; set; }
        public RelayCommand supervisarCommand { get; set; }

        public RelayCommand aprobarCommand { get; set; }
        public RelayCommand agendaCommand { get; set; }

        public RelayCommand ItemSeleccionadoCommand { get; set; }
        #endregion

        #region EDRepositorioMainModel

        private MainModel _mainModel = null;

        public MainModel EDRepositorioMainModel
        {
            get
            {
                return _mainModel;
            }

            set
            {
                _mainModel = value;
            }
        }


        #endregion

        #region activarCaptura

        public const string activarCapturaPropertyName = "activarCaptura";

        private bool _activarCaptura;

        public bool activarCaptura
        {
            get
            {
                return _activarCaptura;
            }

            set
            {
                if (_activarCaptura == value)
                {
                    return;
                }

                _activarCaptura = value;
                RaisePropertyChanged(activarCapturaPropertyName);
            }
        }

        public int NumberOfItemsSelected { get; private set; }

        #endregion

        #region ViewModel Public Methods

        #region Constructores

        public RepositorioViewModel()//Caso Encargo/PlanIndice
        {
        }

        public RepositorioViewModel(string origen)
        {
            _origenLlamada = origen;
            _descripcion = string.Empty;
            _fileName = string.Empty;
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _isListaCargada = false;
            _dialogCoordinator = new DialogCoordinator();
            _cursorWindow = Cursors.Hand;
            _accesibilidadWindow = false;
            _IsSelected = false;
            dlg = new DialogCoordinator();
            lista = new ObservableCollection<RepositorioModelo>();//Lista vacia no se conoce el encargo y el cliente
            _listaDetalles = new ObservableCollection<BitacoraModelo>();
            _listaCompleta = new ObservableCollection<RepositorioModelo>();
            _listaArchivosCreados = new ObservableCollection<string>();
            EDRepositorioMainModel = new MainModel();
            _tokenEnvioDatosAVistaPreview = "LlamadaDePrincipalRepositorio";
            #region comunicacion universal

            _tokenEnvioDatosAHijo = "datosEDCartas";//Para control de los datos que  remite programas a sub-ventanas
            _tokenRecepcionHijo = "datosControllerCartas";
            _tokenRecepcionSubMenu = "DocumentacionDetalleCartasRegreso";
            //_tokenEnvioPadre = "inicioEncargoDocumentacionRepositorio";
            _tokenRecepcionCierrePreView = "Retorno" + "EncargoDocumentacionCartas" + "LlamadaDePrincipalRepositorio";//Sirve la vista del indice como tal;

            #endregion
            switch (origen)
            {
                case "opcionCartas"://Llamada desde documentacion plan indices
                    #region Configuracion plan
                    tablaDetalle = "CartasRepositorio";
                    fuenteLlamado = 1;
                    //0 Sin identificar
                    //1 Plan Indices
                    //2 Plan Indices detalle
                    iddocumento = 2;//Permite inicializar segun el tipo  de documento
                    //1;"Actas";"A";TRUE
                    //2;"Carta";"A";TRUE
                    //3;"Cédula";"A";TRUE
                    //4;"Confirmación";"A";TRUE
                    //5;"Email";"A";TRUE
                    //6;"Estados financieros";"A";TRUE
                    //7;"Informe de auditoría";"A";TRUE
                    //8;"Memorando";"A";TRUE
                    //9;"Reunión";"A";TRUE
                    //10;"Otros";"A";TRUE
                    _tokenRecepcionPadre = "Cartas" + "Documentacion";//Permite captar los mensajes del  menú planificacion
                    //_tokenEnvioDatosAHijo = "datosEDCartas";//Para control de los datos que  remite programas a sub-ventanas
                    //_tokenRecepcionHijo = "datosControllerCartas";
                    //_tokenRecepcionSubMenu = "DocumentacionDetalleCartasRegreso";
                    ////_tokenEnvioPadre = "inicioEncargoDocumentacionRepositorio";
                    //_tokenRecepcionCierrePreView = "Retorno" + "EncargoDocumentacionCartas" + "LlamadaDePrincipalRepositorio";//Sirve la vista del indice como tal;
                    #endregion
                    break;
                case "opcionMemorandos"://Llamada desde documentacion plan indices
                    #region Configuracion plan
                    tablaDetalle = "Memorandos";
                    fuenteLlamado = 1;
                    //0 Sin identificar
                    //1 Plan Indices
                    //2 Plan Indices detalle
                    iddocumento = 7;//Permite inicializar segun el tipo  de documento
                    //7;"Informe de auditoría";"A";TRUE
                    _tokenRecepcionPadre = "Memorandos" + "Documentacion";//Permite captar los mensajes del  menú planificacion
                    //_tokenEnvioDatosAHijo = "datosEDMemorandos";//Para control de los datos que  remite programas a sub-ventanas
                    //_tokenRecepcionHijo = "datosControllerMemorandos";
                    //_tokenRecepcionSubMenu = "DocumentacionDetalleMemorandosRegreso";
                    ////_tokenEnvioPadre = "inicioEncargoDocumentacionRepositorio";
                    //_tokenRecepcionCierrePreView = "Retorno" + "EncargoDocumentacionMemorandos" + "LlamadaDePrincipalRepositorio";//Sirve la vista del indice como tal;
                    #endregion
                    break;
                case "opcionInformes"://Llamada desde documentacion plan indices
                    #region Configuracion plan
                    tablaDetalle = "Informe auditoría";
                    fuenteLlamado = 1;
                    //0 Sin identificar
                    //1 Plan Indices
                    //2 Plan Indices detalle
                    iddocumento = 8;//Permite inicializar segun el tipo  de documento
                    //8;"Memorando";"A";TRUE
                    _tokenRecepcionPadre = "Informe auditoría" + "Documentacion";//Permite captar los mensajes del  menú planificacion
                    //_tokenEnvioDatosAHijo = "datosEDInformes";//Para control de los datos que  remite programas a sub-ventanas
                    //_tokenRecepcionHijo = "datosControllerInformes";
                    //_tokenRecepcionSubMenu = "DocumentacionDetalleInformesRegreso";
                    ////_tokenEnvioPadre = "inicioEncargoDocumentacionRepositorio";
                    //_tokenRecepcionCierrePreView = "Retorno" + "EncargoDocumentacionInformes" + "LlamadaDePrincipalRepositorio";//Sirve la vista del indice como tal;
                    #endregion
                    break;
                case "opcionOtros"://Llamada desde documentacion plan indices
                    #region Configuracion plan
                    tablaDetalle = "Otros documentos";
                    fuenteLlamado = 1;
                    //0 Sin identificar
                    //1 Plan Indices
                    //2 Plan Indices detalle
                    iddocumento = 0;//Permite inicializar segun el tipo  de documento
                    //8;"Memorando";"A";TRUE
                    _tokenRecepcionPadre = "Otros documentos" + "Documentacion";//Permite captar los mensajes del  menú planificacion
                    //_tokenEnvioDatosAHijo = "datosEDOtros";//Para control de los datos que  remite programas a sub-ventanas
                    //_tokenRecepcionHijo = "datosControllerOtros";
                    //_tokenRecepcionSubMenu = "DocumentacionDetalleOtrosRegreso";
                    ////_tokenEnvioPadre = "inicioEncargoDocumentacionRepositorio";
                    //_tokenRecepcionCierrePreView = "Retorno" + "EncargoDocumentacionOtros" + "LlamadaDePrincipalRepositorio";//Sirve la vista del indice como tal;
                    #endregion
                    break;
            }
            #region  menu
            _visibilidadMCrear = Visibility.Visible;
            _visibilidadMEditar = Visibility.Visible;
            _visibilidadMBorrar = Visibility.Visible;
            _visibilidadMConsulta = Visibility.Visible;
            _visibilidadMReferenciar = Visibility.Visible;//Pendiente
            _visibilidadMRegresar = Visibility.Visible;
            _visibilidadMVista = Visibility.Visible;
            _visibilidadMImportar = Visibility.Visible;
            _visibilidadMDetalle = Visibility.Collapsed;

            _visibilidadMCerrar = Visibility.Visible;
            _visibilidadMSupervisar = Visibility.Visible;
            _visibilidadMAprobar = Visibility.Visible;
            _visibilidadMTask = Visibility.Collapsed;
            _visibilidadMImprimir = Visibility.Collapsed;
            #endregion
            RegisterCommands();

            Messenger.Default.Register<EncargosDatosMsj>(this, tokenRecepcionPadre, (recepcionDatos) => ControlRecepcionDatos(recepcionDatos));
            currentEncargo = null;
            currentEntidad = null;
            _comando = 0;
            Messenger.Default.Register<int>(this, tokenRecepcionSubMenu, (detalleTerminado) => ControlVentanaMensaje(detalleTerminado));

        }



        private bool CanDocumentacionCommand()
        {
            return true;
        }

        private void ControlRecepcionDatos(EncargosDatosMsj msj)
        {
            usuarioModelo = msj.usuarioModelo;
            currentEncargo = msj.encargoModelo;  //El encargo puede estar cambiando.
            //currentSistemaContable = SistemaContableModelo.GetRegistroByIdEncargo(currentEncargo.idencargo);
            actualizarLista();
            accesibilidadWindow = true;
            inicializacionTerminada();
            tokenEnvioPadre = msj.tokenRespuesta;
            Messenger.Default.Unregister<EncargosDatosMsj>(this, tokenRecepcionPadre);

        }


        private void actualizarLista()
        {
            //guardarlista();
            try
            {
                //Internamenteo consigo el id del sistema contable
                //lista = new ObservableCollection<RepositorioModelo>(RepositorioModelo.GetAll(currentEncargo.idencargo));
                isListaCargada = false;
                if (iddocumento == 0)
                {
                    lista = new ObservableCollection<RepositorioModelo>(RepositorioModelo.GetAllEncabezadosOtros(currentEncargo, iddocumento));
                }
                else
                {
                    lista = new ObservableCollection<RepositorioModelo>(RepositorioModelo.GetAllEncabezado(currentEncargo, iddocumento));
                }
                ControlCambioLista();
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de lista " + e, "");

                }
            }
            //Se manda a la vista actualizada
            ///enviarMensaje();No aplica porque no  se envia  la lista a la vista
        }

        private void ControlCambioLista()
        {
            BackgroundWorker worker = new BackgroundWorker();
            //var secureString = passwordContainer.Password;
            worker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                if (currentEntidad != null && currentEntidad.idrepositorio != 0 && iddocumento != 0)
                {
                    if (iddocumento == 0)
                    {
                        listaCompleta = new ObservableCollection<RepositorioModelo>(RepositorioModelo.GetAllOtros(currentEncargo, iddocumento));
                    }
                    else
                    {
                        listaCompleta = new ObservableCollection<RepositorioModelo>(RepositorioModelo.GetAll(currentEncargo, iddocumento));
                    }
                }
            };
            worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
            {
                if (listaCompleta != null)
                {
                    isListaCargada = true;
                }
            };
            worker.Dispose();
            worker.RunWorkerAsync();
        }


        #endregion

        #region Envio mensajes


        //Caso de nuevo registro 
        public void enviarMensaje()
        {
            //Se crea el mensaje
            RepositorioMsj elemento = new RepositorioMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = usuarioModelo;
            elemento.opcionMenuCrud = comando;
            elemento.entidadTrasladada = currentEntidad;
            elemento.lista = lista;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRespuestaVista = tokenRecepcionCierrePreView;
            elemento.fuenteLlamado = fuenteLlamado; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }

        public void enviarPreVistaMensaje()
        {
            //Se crea el mensaje
            RepositorioMsj elemento = new RepositorioMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = usuarioModelo;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadTrasladada = currentEntidad;//Para el caso de  edicion de programas
            elemento.lista = lista;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRespuestaVista = tokenRecepcionCierrePreView;
            elemento.fuenteLlamado = fuenteLlamado; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAVistaPreview);
        }

        #endregion

        #region Receptor de mensajes

        private void ControlVentanaMensaje(int controlVentanaCrearMensaje)
        {
            EDRepositorioMainModel.TypeName = null;
            switch (comando)
            {
                case 1:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }

                    break;
                case 2:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    break;
                case 3:
                    break;
                case 4:
                    //caso de vista de programa
                    break;
                case 5://Programa vista
                    //if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    //{
                    //    actualizarLista();
                    //}
                    enviarMensajeHabilitar();
                    break;
                case 6:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    break;
                case 7:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    //enviarMensajeHabilitar();
                    break;
                case 8:
                    //if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    //{
                    //    actualizarLista();
                    //}

                    //enviarMensajeHabilitar();
                    //controlVentanaCrearMensaje
                    break;
                case 9://Desplazamiento a ver el detalle del usuario
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    //enviarMensajeHabilitar();
                    break;
                default:
                    break;
            }
            comando = 0;
            currentEntidad = null;
            Messenger.Default.Unregister<int>(this, tokenRecepcionSubMenu);
            finComando();
        }

        #endregion

        #region Implementacion de comandos
        public void Nuevo()
        {
            iniciarComando();
            //Para guardar lo que esta en la  pantalla
            comando = 1;
            #region Inicializacion de herramienta 
            currentEntidad = new RepositorioModelo(currentEncargo, usuarioModelo);
            currentEntidad.iddocumento = iddocumento;//Inicialia la clase  de documento
            EDRepositorioMainModel.TypeName = "RepositorioModeloCrearview";
            #endregion

            activarCaptura = true;
            #endregion

            enviarMensaje();
        }

        public async void Editar()
        {
            //Para guardar lo que esta en la  pantalla
            //ControlCambioLista(true);

            if (lista.Where(x => x.IsSelected).Count() == 1)
            {
                if (!(currentEntidad == null))
                {
                    iniciarComando();
                    comando = 2;
                    if (isListaCargada && listaCompleta.Count > 0)
                    {
                        currentEntidad = listaCompleta.Single(x => x.idrepositorio == currentEntidad.idrepositorio);
                    }
                    else
                    {
                        currentEntidad = RepositorioModelo.Find(currentEntidad.idrepositorio);
                    }
                    if (currentEntidad.idrepositorio != 0)
                    {
                        currentEntidad.usuarioModelo = usuarioModelo;
                        EDRepositorioMainModel.TypeName = "RepositorioModeloEditarView";
                        enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
                    }
                    else
                    {
                        finComando();
                        await dlg.ShowMessageAsync(this, "Error al recuperar el  registro", "");
                    }
                }
                else
                {
                    finComando();
                    await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a editar", "");
                }
            }
            else
            {
                finComando();
                await dlg.ShowMessageAsync(this, "Debe seleccionar solo un registro para editar", "");
            }
        }
        public async void Consultar()
        {
            //Para guardar lo que esta en la  pantalla
            // ControlCambioLista(true);
            if (lista.Where(x => x.IsSelected).Count() == 1)
            {
                if (!(currentEntidad == null))
                {
                    iniciarComando();
                    comando = 3;
                    EDRepositorioMainModel.TypeName = "RepositorioModeloConsultarView";
                    enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse

                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar solo un registro para consultar", "");
            }
        }


        public async void Borrar()
        {

            if (!(currentEntidad == null))
            {
                accesibilidadWindow = false;
                //Mouse.OverrideCursor = Cursors.Wait;
                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Ok",
                    NegativeButtonText = "Cancelar",
                };

                MessageDialogResult result = await dlg.ShowMessageAsync(this, "La acción no podrá revertirse y se incluirá a los registros dependientes", "¿Desea eliminar el o los  registros?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {
                    iniciarComando();
                    //Repite el  ciclo para evitar errores

                    if (lista.Where(x => x.IsSelected).Count() == 1)
                    {
                        //switch (IndiceModelo.EvaluarBorrar(currentEntidad.idrepositorio))
                        switch (RepositorioModelo.evaluarBorrar(currentEntidad))
                        {
                            case -1:
                                finComando();
                                await dlg.ShowMessageAsync(this, "Se produjo un error ", "intentelo en otro momento");
                                //Hay error en el procedimiento
                                break;
                            case 1:
                                //Puede borrarse por completo
                                switch (RepositorioModelo.Delete(currentEntidad))
                                {
                                    case -1:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "Se produjo un error ", "intentelo en otro momento");
                                        break;
                                    case 0:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "El registro estaba vacio ", "no puede eliminarse por ese motivo");
                                        break;
                                    case 1:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "Se borro el registro ", "");
                                        actualizarLista();
                                        currentEntidad = new RepositorioModelo();
                                        break;
                                }
                                break;
                            default:
                                finComando();
                                await dlg.ShowMessageAsync(this, "No puede eliminarse ", "porque hay papeles referenciados");
                                break;
                        }
                    }
                    else
                    {
                        //Evaluar que registros pueden eliminarse
                        ObservableCollection<RepositorioModelo> temporal = new ObservableCollection<RepositorioModelo>();
                        foreach (RepositorioModelo item in lista)
                        {
                            if (item.IsSelected)
                            {
                                //switch (IndiceModelo.EvaluarBorrar(currentEntidad.idrepositorio))
                                switch (RepositorioModelo.evaluarBorrar(currentEntidad))
                                //switch (IndiceModelo.EvaluarBorrar(currentEntidad.idrepositorio))
                                {
                                    case -1:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "Se produjo un error al eliminar a " + item.nombrerepositorio, " intentelo en otro momento");
                                        iniciarComando();
                                        //Hay error en el procedimiento
                                        break;
                                    case 0:
                                        //Puede borrarse por completo
                                        temporal.Add(item);
                                        break;
                                    case 1:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "No puede eliminarse la carpeta " + item.nombrerepositorio, " porque hay papeles referenciados");
                                        iniciarComando();
                                        break;
                                }
                            }
                        }
                        if (temporal.Count > 0)
                        {
                            //caso de muchos registros
                            switch (RepositorioModelo.Delete(temporal))
                            {
                                case -1:
                                    finComando();
                                    await dlg.ShowMessageAsync(this, "Se produjo un error ", "intentelo en otro momento");
                                    break;
                                case 0:
                                    finComando();
                                    await dlg.ShowMessageAsync(this, "Los registros estaban estaba vacio ", "no puede eliminarse por ese motivo");
                                    break;
                                case 1:
                                    finComando();
                                    await dlg.ShowMessageAsync(this, "Se borro el registro ", "");
                                    actualizarLista();
                                    currentEntidad = new RepositorioModelo();
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    finComando();
                    await dlg.ShowMessageAsync(this, "Canceló la eliminacion", "");
                }
            }
            else
            {
                finComando();
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
            }
            finComando();
        }


        public async void BorrarLogico()
        {

            if (!(currentEntidad == null))
            {
                accesibilidadWindow = false;
                //Mouse.OverrideCursor = Cursors.Wait;
                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Ok",
                    NegativeButtonText = "Cancelar",
                };

                MessageDialogResult result = await dlg.ShowMessageAsync(this, "La acción no podrá revertirse y se incluirá a los registros dependientes", "¿Desea eliminar el o los  registros?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {
                    iniciarComando();
                    //Repite el  ciclo para evitar errores

                    if (lista.Where(x => x.IsSelected).Count() == 1)
                    {
                        //switch (IndiceModelo.EvaluarBorrar(currentEntidad.idrepositorio))
                        switch (RepositorioModelo.evaluarBorrar(currentEntidad))
                        {
                            case -1:
                                finComando();
                                await dlg.ShowMessageAsync(this, "Se produjo un error ", "intentelo en otro momento");
                                //Hay error en el procedimiento
                                break;
                            case 1:
                                //Puede borrarse por completo
                                switch (RepositorioModelo.DeleteLogico(currentEntidad))
                                {
                                    case -1:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "Se produjo un error ", "intentelo en otro momento");
                                        break;
                                    case 0:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "El registro estaba vacio ", "no puede eliminarse por ese motivo");
                                        break;
                                    case 1:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "Se borro el registro ", "");
                                        actualizarLista();
                                        currentEntidad = new RepositorioModelo();
                                        break;
                                }
                                break;
                            default:
                                finComando();
                                await dlg.ShowMessageAsync(this, "No puede eliminarse ", "porque hay papeles referenciados");
                                break;
                        }
                    }
                    else
                    {
                        //Evaluar que registros pueden eliminarse
                        ObservableCollection<RepositorioModelo> temporal = new ObservableCollection<RepositorioModelo>();
                        foreach (RepositorioModelo item in lista)
                        {
                            if (item.IsSelected)
                            {
                                //switch (IndiceModelo.EvaluarBorrar(currentEntidad.idrepositorio))
                                switch (RepositorioModelo.evaluarBorrar(currentEntidad))
                                //switch (IndiceModelo.EvaluarBorrar(currentEntidad.idrepositorio))
                                {
                                    case -1:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "Se produjo un error al eliminar a " + item.nombrerepositorio, " intentelo en otro momento");
                                        iniciarComando();
                                        //Hay error en el procedimiento
                                        break;
                                    case 0:
                                        //Puede borrarse por completo
                                        temporal.Add(item);
                                        break;
                                    case 1:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "No puede eliminarse la carpeta " + item.nombrerepositorio, " porque hay papeles referenciados");
                                        iniciarComando();
                                        break;
                                }
                            }
                        }
                        if (temporal.Count > 0)
                        {
                            //caso de muchos registros
                            switch (RepositorioModelo.DeleteBorradoLogico(temporal))
                            {
                                case -1:
                                    finComando();
                                    await dlg.ShowMessageAsync(this, "Se produjo un error ", "intentelo en otro momento");
                                    break;
                                case 0:
                                    finComando();
                                    await dlg.ShowMessageAsync(this, "Los registros estaban estaba vacio ", "no puede eliminarse por ese motivo");
                                    break;
                                case 1:
                                    finComando();
                                    await dlg.ShowMessageAsync(this, "Se borro el registro ", "");
                                    actualizarLista();
                                    currentEntidad = new RepositorioModelo();
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    finComando();
                    await dlg.ShowMessageAsync(this, "Canceló la eliminacion", "");
                }
            }
            else
            {
                finComando();
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
            }
            finComando();
        }

        #endregion

        public bool CanSave()
        {
            return !(currentEntidad.idrepositorio == 0);
        }

        #region Verificaciones

        public void Actualizar(ObservableCollection<RepositorioModelo> listaEntidad)
        {
            lista = listaEntidad;
        }

        public bool CanDelete()
        {
            return currentEntidad != null;
        }

        public bool CanCommand()
        {
            if (!(currentEntidad == null))
            {
                try
                {
                    return currentEntidad.idrepositorio != 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        #endregion


        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            //cmdCargarCatalogo = new RelayCommand(cargarCC, null);//ok
            NuevoCommand = new RelayCommand(Nuevo, null);//ok
            EditarCommand = new RelayCommand(Editar, CanEditar);
            BorrarCommand = new RelayCommand(Borrar, CanBorrar);//ok
            ConsultarCommand = new RelayCommand(Consultar);
            //ConsultarCommand = new RelayCommand(ConsultarDocumentacion, CanCommand);
            //ConsultarCommand = new RelayCommand(ConsultarCierre, CanCommand);

            copiarCommand = new RelayCommand(Importar);
            DoubleClickCommand = new RelayCommand(Nada);
            SelectionChangedCommand = new RelayCommand<RepositorioModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
            //detalleCommand = new RelayCommand(detalleIndiceDocumentacion, CanCommand);

            vistaCommand = new RelayCommand(VistaDocumentoEjecucion, CanCommand);
            ImportarCommand = new RelayCommand(Importar, null);//ok
            //ItemSeleccionadoCommand = new RelayCommand(itemDetalleSeleccion, CanDocumentacionCommand);
            //ItemSeleccionadoCommand = new RelayCommand(itemDetalleSeleccionImpresion, CanDocumentacionCommand);
            terminarPapelCommand = new RelayCommand(cerrarPrograma, CanTerminar);
            supervisarCommand = new RelayCommand(supervisarPrograma, CanSupervisar);
            aprobarCommand = new RelayCommand(aprobarPrograma, CanAprobar);
            agendaCommand = new RelayCommand(tareasPrograma, CanCommand);
            referenciarCommand = new RelayCommand(referenciarPrograma, CanCommand);//Para guardar la referencia

        }

        private async void referenciarPrograma()
        {
            {
                if (!(currentEntidad == null))
                {
                    iniciarComando();
                    comando = 8;//Referenciacion
                    EDRepositorioMainModel.TypeName = "RepositorioReferenciarView";
                    #region Configuracion
                    currentEntidad.usuarioModelo = usuarioModelo;
                    #endregion
                    enviarMensaje();  //Debe ir antes, porque evalua si la ventana es cero para enviarse
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a referenciar", "");
                }

            }
        }
        private bool CanReferenciarSave()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                evaluar = (Errors == 0);
                return evaluar;
            }
        }
        private bool CanEditar()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                return (string.IsNullOrEmpty(currentEntidad.usuariocerro))
                        && (string.IsNullOrEmpty(currentEntidad.usuariosuperviso));
            }
        }

        private bool CanBorrar()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                return ((string.IsNullOrEmpty(currentEntidad.usuariocerro))
                        && (string.IsNullOrEmpty(currentEntidad.usuariosuperviso))
                        && (string.IsNullOrEmpty(currentEntidad.usuarioaprobo)));
            }
        }

        private bool CanAprobar()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                return (((!string.IsNullOrEmpty(currentEntidad.usuariocerro))
                    || (string.IsNullOrEmpty(currentEntidad.usuariosuperviso)))
                    && ((string.IsNullOrEmpty(currentEntidad.usuarioaprobo))));
            }
        }

        private bool CanSupervisar()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                return (!(string.IsNullOrEmpty(currentEntidad.usuariocerro))
                && (string.IsNullOrEmpty(currentEntidad.usuariosuperviso))
                && (!string.IsNullOrEmpty(currentEntidad.nombrepdf)));
            }
        }

        private void tareasPrograma()
        {
            throw new NotImplementedException();
        }

        private async void aprobarPrograma()
        {
            if (!(currentEntidad == null))
            {
                comando = 12;//Supervisar
                iniciarComando();

                EDRepositorioMainModel.TypeName = "RepositorioAprobarView";
                #region Configuracion
                currentEntidad.usuarioModelo = usuarioModelo;
                #endregion
                enviarMensaje();  //Debe ir antes, porque evalua si la ventana es cero para enviarse
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro ", "");
            }

        }

        private async void supervisarPrograma()
        {
            {
                if (!(currentEntidad == null))
                {
                    comando = 11;//Supervisar
                    iniciarComando();

                    EDRepositorioMainModel.TypeName = "RepositorioSupervisarView";
                    #region Configuracion
                    currentEntidad.usuarioModelo = usuarioModelo;
                    #endregion
                    enviarMensaje();  //Debe ir antes, porque evalua si la ventana es cero para enviarse
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Debe seleccionar el registro", "");
                }

            }
        }

        private bool CanTerminar()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                return ((string.IsNullOrEmpty(currentEntidad.usuariocerro))
                && (string.IsNullOrEmpty(currentEntidad.usuariosuperviso))
                && (string.IsNullOrEmpty(currentEntidad.usuariocerro))
                && (!string.IsNullOrEmpty(currentEntidad.nombrepdf)));
            }
        }

        private async void cerrarPrograma()
        {

            if (!(currentEntidad == null))
            {
                iniciarComando();
                //decimal avance = (decimal)currentEntidad.indiceEjecucionprograma;
                //int estadoDocumento = BitacoraModelo.evaluarEstado(currentEntidad,4,"MATRIZRIESGOS");//Etapa 4 es cerrado
                int estadoDocumento = RepositorioModelo.evaluarCerrar(currentEntidad);
                if (estadoDocumento == 1) //Hay cero procedimientos diferentes a iniciados
                {
                    //if (currentEntidad.pdfrepositorio != null && currentEntidad.referenciarepositorio != string.Empty)
                    if (currentEntidad.referenciarepositorio != string.Empty && currentEntidad.nombrepdf != string.Empty)
                    {
                        comando = 10;//Referenciacion
                        iniciarComando();

                        EDRepositorioMainModel.TypeName = "RepositorioCerrarView";
                        #region Configuracion
                        currentEntidad.usuarioModelo = usuarioModelo;
                        #endregion
                        enviarMensaje();  //Debe ir antes, porque evalua si la ventana es cero para enviarse
                    }
                    else
                    {
                        finComando();
                        await dlg.ShowMessageAsync(this, "Debe referenciar y colocar el  pdf ", "antes de cerrarlo");
                    }
                }
                else
                {
                    if (estadoDocumento != -1)
                    {
                        finComando();
                        await dlg.ShowMessageAsync(this, "El documento ya esta cerrado", "No puede cerrarse dos veces");
                    }
                    else
                    {
                        finComando();
                        await dlg.ShowMessageAsync(this, "Se produjo un error", "intentelo mas tarde");
                    }
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a cerrar", "");
            }
            finComando();
        }
        private void Nada()
        {
            // throw new NotImplementedException();
            //Para anular el doble click
        }

        private async void ConsultarCierre()
        {
            //Para guardar lo que esta en la  pantalla
            // ControlCambioLista(true);
            if (lista.Where(x => x.IsSelected).Count() == 1)
            {
                if (!(currentEntidad == null))
                {
                    comando = 3;
                    iniciarComando();

                    EDRepositorioMainModel.TypeName = "CierreRepositorioModeloConsultarView";
                    enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse

                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar solo un registro para consultar", "");
            }

        }

        private async void ConsultarDocumentacion()
        {
            //Para guardar lo que esta en la  pantalla
            // ControlCambioLista(true);
            if (lista.Where(x => x.IsSelected).Count() == 1)
            {
                if (!(currentEntidad == null))
                {
                    comando = 3;
                    iniciarComando();

                    EDRepositorioMainModel.TypeName = "DocumentacionRepositorioModeloConsultarView";
                    enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse

                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar solo un registro para consultar", "");
            }

        }

        private async void VistaDocumentoEjecucion()
        {
            //Preguntar si quiere ver documento  fuente o documento PDF
            //Siempre y cuando exista
            if (!(currentEntidad == null))
            {
                if (string.IsNullOrEmpty(currentEntidad.usuariocerro))
                {
                    #region Proceso de importacion

                    var mySettings = new MetroDialogSettings()
                    {
                        AffirmativeButtonText = "Documentos fuente",
                        FirstAuxiliaryButtonText = "Cancelar",
                        NegativeButtonText = "PDF",
                    };
                    finComando();
                    MessageDialogResult result = await dlg.ShowMessageAsync(this, "Seleccione si quiere ver el documento  fuente o el PDF", "El fuente permitirá la edición",
                    MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, mySettings);
                    iniciarComando();
                    if (result == MessageDialogResult.Affirmative)
                    {
                        if (currentEntidad.nombrebinariorepositorio != null && !string.IsNullOrEmpty(currentEntidad.nombrebinariorepositorio) && !string.IsNullOrWhiteSpace(currentEntidad.nombrebinariorepositorio))
                        {
                            if (isListaCargada && listaCompleta.Count > 0)
                            {
                                currentEntidad = listaCompleta.Single(x => x.idrepositorio == currentEntidad.idrepositorio);
                            }
                            else
                            {
                                currentEntidad = RepositorioModelo.Find(currentEntidad.idrepositorio);
                            }
                            if (currentEntidad.idrepositorio != 0)
                            {
                                //Editará el documento
                                comando = 5;
                                VistaPlantilla(currentEntidad);
                                //enviarPreVistaMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse

                                //enviarMensaje();
                            }
                            else
                            {
                                finComando();
                                await dlg.ShowMessageAsync(this, "Error al recuperar el  registro", "");
                            }

                        }
                        else
                        {
                            finComando();
                            await dlg.ShowMessageAsync(this, "El registro no contiene  el archivo fuente", "Debe cargarlo antes de examinarlo");
                        }
                    }
                    else
                    {
                        if (result == MessageDialogResult.Negative)
                        {
                            if (currentEntidad.nombrepdf != null && !string.IsNullOrEmpty(currentEntidad.nombrepdf) && !string.IsNullOrWhiteSpace(currentEntidad.nombrepdf))

                            {
                                if (isListaCargada && listaCompleta.Count > 0)
                                {
                                    currentEntidad = listaCompleta.Single(x => x.idrepositorio == currentEntidad.idrepositorio);
                                }
                                else
                                {
                                    currentEntidad = RepositorioModelo.Find(currentEntidad.idrepositorio);
                                }
                                if (currentEntidad.idrepositorio != 0)
                                {

                                    comando = 5;
                                    iniciarComando();
                                    EDRepositorioMainModel.TypeName = "RepositorioVistaPDFPreviaView";
                                    //enviarPreVistaMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
                                    enviarMensaje();
                                }
                                else
                                {
                                    finComando();
                                    await dlg.ShowMessageAsync(this, "Error al recuperar el  registro", "");
                                }


                            }
                            else
                            {
                                finComando();
                                await dlg.ShowMessageAsync(this, "El registro no contiene  el archivo pdf", "Debe cargarlo antes de  examinarlo");
                            }

                        }
                        else
                        {
                            finComando();
                            await dlg.ShowMessageAsync(this, "Canceló operación", "");

                        }
                    }
                    #endregion fin de proceso
                }
                else
                {
                    #region solo PDF

                    if (currentEntidad.nombrepdf != null && !string.IsNullOrEmpty(currentEntidad.nombrepdf) && !string.IsNullOrWhiteSpace(currentEntidad.nombrepdf))

                    {
                        if (isListaCargada && listaCompleta.Count > 0)
                        {
                            currentEntidad = listaCompleta.Single(x => x.idrepositorio == currentEntidad.idrepositorio);
                        }
                        else
                        {
                            currentEntidad = RepositorioModelo.Find(currentEntidad.idrepositorio);
                        }
                        if (currentEntidad.idrepositorio != 0)
                        {

                            comando = 5;
                            iniciarComando();
                            EDRepositorioMainModel.TypeName = "RepositorioVistaPDFPreviaView";
                            //enviarPreVistaMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
                            enviarMensaje();
                        }
                        else
                        {
                            finComando();
                            await dlg.ShowMessageAsync(this, "Error al recuperar el  registro", "");
                        }


                    }
                    else
                    {
                        finComando();
                        await dlg.ShowMessageAsync(this, "El registro no contiene  el archivo pdf", "Debe cargarlo antes de  examinarlo");
                    }



                    #endregion
                }


            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }
        }

         private async void mostrarCantidad(int i)
        {
            await dlg.ShowMessageAsync(this, "Hay " + i + " registros seleccionados", "");
        }


        public void Importar()
        {
            //Evaluar  si procede la importacion
            iniciarComando();

            #region Proceso de importacion
            comando = 7;//Importa de los encargos de  años anteriores
            iniciarComando();
            EDRepositorioMainModel.TypeName = "RepositorioModeloImportarView";
            currentEntidad = new RepositorioModelo(currentEncargo);
            currentEntidad.iddocumento = iddocumento;
            activarCaptura = true;
            enviarMensaje();
            #endregion fin de proceso

        }


        private void Buscar()
        {
            throw new NotImplementedException();
        }

        private void XImprimir()
        {
            //throw new NotImplementedException();
        }

        public void enviarMensajeInhabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = false;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }
        public void inicializacionTerminada()
        {
            //Se crea el mensaje
            ComandoTerminado cursor = new ComandoTerminado();
            cursor.cursorWindow = Cursors.Hand;
            Messenger.Default.Send<ComandoTerminado>(cursor, tokenRecepcionPadre);
        }
        public void enviarMensajeHabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = true;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }


        private void iniciarComandoBorrar()
        {
            //cursorWindow = Cursors.Wait;
            Mouse.OverrideCursor = Cursors.Wait;
            enviarMensajeInhabilitar();
            accesibilidadWindow = false;
        }

        private void finComandoBorrar()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            enviarMensajeHabilitar();
            accesibilidadWindow = true;
        }
        private void iniciarComando()
        {
            //cursorWindow = Cursors.Wait;
            Mouse.OverrideCursor = Cursors.Wait;
            Messenger.Default.Register<int>(this, tokenRecepcionHijo, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
            Messenger.Default.Register<int>(this, tokenRecepcionCierrePreView, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
            //Messenger.Default.Register<bool>(this, tokenRecepcionHijo, (recepcionDatos) => ControlCambioLista(recepcionDatos));
            accesibilidadWindow = false;
            if (comando == 5)
            {
                enviarMensajeInhabilitar();
            }
        }

        private void finComando()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            Messenger.Default.Unregister<int>(this, tokenRecepcionHijo);
            //Messenger.Default.Unregister<bool>(this, tokenRecepcionHijo);
            Messenger.Default.Unregister<int>(this, tokenRecepcionCierrePreView);
            accesibilidadWindow = true;
            //if (comando != 9)
            //{
            //    enviarMensajeHabilitar();
            //}
        }

        private void iniciarComandoLocal()
        {
            //cursorWindow = Cursors.Wait;
            Mouse.OverrideCursor = Cursors.Wait;
            accesibilidadWindow = false;
        }

        private void finComandoLocal()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            accesibilidadWindow = true;
        }

        #endregion Fin de comando


        #region Gestion  de archivos


        private async void VistaPlantilla(RepositorioModelo entidad)
        {

            if (lista.Where(x => x.IsSelected).Count() == 1)
            {
                if (!(currentEntidad == null))
                {
                    if (currentEntidad.idrepositorio != 0)
                    {
                        currentEntidad.usuarioModelo = usuarioModelo;
                        editDocument();
                    }
                    else
                    {
                        finComando();
                        await dlg.ShowMessageAsync(this, "Error al recuperar el  registro", "");
                    }
                }
                else
                {
                    finComando();
                    await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a editar", "");
                }
            }
            else
            {
                finComando();
                await dlg.ShowMessageAsync(this, "Debe seleccionar solo un registro para editar", "");
            }
        }


        private static string GetDefaultExtension(Excel.Application application)
        {
            double Version = Convert.ToDouble(application.Version, CultureInfo.InvariantCulture);
            if (Version >= 12.00)
                return ".xlsx";
            else
                return ".xls";
        }

        private static string GetDefaultExtension(PowerPoint.Application application)
        {
            double Version = Convert.ToDouble(application.Version, CultureInfo.InvariantCulture);
            if (Version >= 12.00)
                return ".pptx";
            else
                return ".ppt";
        }
        private static string GetDefaultExtension(Word.Application application)
        {
            double version = Convert.ToDouble(application.Version, CultureInfo.InvariantCulture);
            if (version >= 12.00)
                return ".docx";
            else
                return ".doc";
        }

        private void TryDeleteDocument(string _documentPath)
        {
            try
            {
                if (File.Exists(_documentPath))
                    File.Delete(_documentPath);
            }
            catch
            {
                // its already open - aren't so?
                // we ignore this and dont refuse the user
                Console.WriteLine("Unable to delete {0}.", _documentPath);
            }
        }
        private string TryDeleteFile(string _documentPath)
        {
            try
            {
                if (File.Exists(_documentPath))
                {
                    File.Delete(_documentPath);
                    return "1";//Existe
                }
                else
                {
                    return "0";//No existe
                }
            }
            catch
            {
                // its already open - aren't so?
                // we ignore this and dont refuse the user
                Console.WriteLine("Unable to delete {0}.", _documentPath);
                return _documentPath; //Esta siendo ocupado
            }
        }
        private void borrarTemporales()
        {

            if (listaArchivosCreados.Count >= 1)
            {
                var itemsToRemove = new ObservableCollection<string>();
                for (int i = 0; i < listaArchivosCreados.Count; i++)
                {
                    listaArchivosCreados[i] = TryDeleteFile(listaArchivosCreados[i]);
                    if (listaArchivosCreados[i] == "0" || listaArchivosCreados[i] == "1")
                    {
                        itemsToRemove.Add(listaArchivosCreados[i]);
                    }

                }
                foreach (var item in itemsToRemove)
                {
                    listaArchivosCreados.Remove(item);
                }
            }
        }
        //https://geeks.ms/lfranco/2011/08/19/editar-documentos-almacenados-como-array-de-bits-en-sql-server-filestream-3n/
        List<ProcessController> Processes = new List<ProcessController>();

        private void editDocument()
        {
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Guid guidId;
            // Create and display the value of two GUIDs.
            guidId = Guid.NewGuid();
            currentEntidad.guId = guidId;
            //fileName = Path.g.GetTempPath() + currentEntidad.nombrearchivonormativa;
            if (!string.IsNullOrEmpty(mydocpath))
            {
                //https://msdn.microsoft.com/es-es/library/6ka1wd3w(v=vs.110).aspx
                fileName = mydocpath + @"\" + currentEntidad.nombrebinariorepositorio;
            }
            else
            {
                //http://stackoverflow.com/questions/7867254/create-a-temporary-file-from-stream-object-in-c-sharp
                fileName = Path.GetTempPath() + currentEntidad.nombrebinariorepositorio;
            }
            listaArchivosCreados.Add(fileName);
            File.WriteAllBytes(fileName, currentEntidad.binariorepositorio);
            if (currentEntidad.binariorepositorio == null) return;
            ProcessController process = new ProcessController(
                currentEntidad.binariorepositorio,
                currentEntidad.guId, currentEntidad.nombrebinariorepositorio, fileName, currentEntidad.idrepositorio);
            process.Exited += process_Exited;
            process.EditInAssociatedApplication();
            Processes.Add(process);
            finComando();
        }

        void process_Exited(object sender, EventArgs e)
        {

            ProcessController process = sender as ProcessController;
            if (process == null) return;
            if (process.HasChanged())
            {
                string message = "Usted ha hecho cambios en  el  archivo. Desea que se actualicela version en la base de datos?";
                string caption = "Se detecto cambios en el archivo";
                System.Windows.Forms.MessageBoxButtons buttons = System.Windows.Forms.MessageBoxButtons.YesNo;
                System.Windows.Forms.DialogResult result;
                // Displays the MessageBox.

                result = System.Windows.Forms.MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    //Guardar en la entidad y guardarla
                    saveDocument(process.FileId, process.TempFileName, process.idrepositorio);
                    Processes.Remove(process);//Se remueve del listado el proceso creado
                }
            }
            else
            {
                TryDeleteDocument(process.TempFileName);
                Processes.Remove(process);
                borrarTemporales();
            }
        }

        private void saveDocument(Guid docId, string filename, int idrepositorio)
        {
            DialogCoordinator dlg = new DialogCoordinator();
            var filestreamDoc = RepositorioModelo.Find(idrepositorio);
            if (filestreamDoc == null) return;
            if (File.Exists(filename))
            {
                filestreamDoc.usuarioModelo = usuarioModelo;
                filestreamDoc.binariorepositorio = File.ReadAllBytes(filename);
                if (RepositorioModelo.UpdateArchivo(filestreamDoc))
                {
                    borrarTemporales();
                    TryDeleteDocument(filename);
                    MessageBox.Show("Registro actualizado con éxito");
                }
                else
                {
                    MessageBox.Show("Registro actualizado con éxito");
                    listaArchivosCreados.Remove(filename);//No debe eliminarse porque no pudo actualizarse el archivo en la base
                }
            }
        }

        #endregion
    }
}
