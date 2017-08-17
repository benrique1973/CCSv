using CapaDatos;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.SGPtWpf.Views.Principales.Administracion.Catalogos;
using SGPTWpf.Support;
using SGPTWpf.ViewModel;
using SGPTWpf.ViewModel.Administracion.Crud.DetalleDocumentos;
using SGPTWpf.ViewModel.Crud.Actividad;
using SGPTWpf.ViewModel.Crud.ClaseBalance;
using SGPTWpf.ViewModel.Crud.ClaseCuenta;
using SGPTWpf.ViewModel.Crud.Clasificacion;
using SGPTWpf.ViewModel.Crud.CorrespondenciaTipo;
using SGPTWpf.ViewModel.Crud.Departamento;
using SGPTWpf.ViewModel.Crud.Documento;
using SGPTWpf.ViewModel.Crud.Elemento;
using SGPTWpf.ViewModel.Crud.EstructuraEstadoFinanciero;
using SGPTWpf.ViewModel.Crud.LegalNorma;
using SGPTWpf.ViewModel.Crud.Materialidad;
using SGPTWpf.ViewModel.Crud.Moneda;
using SGPTWpf.ViewModel.Crud.Municipio;
using SGPTWpf.ViewModel.Crud.Pais;
using SGPTWpf.ViewModel.Crud.Periodo;
using SGPTWpf.ViewModel.Crud.ProcesoAuditoria;
using SGPTWpf.ViewModel.Crud.Rol;
using SGPTWpf.ViewModel.Crud.Simbolo;
using SGPTWpf.ViewModel.Crud.TipoAuditoria;
using SGPTWpf.ViewModel.Crud.TipoCarpeta;
using SGPTWpf.ViewModel.Crud.TipoCedula;
using SGPTWpf.ViewModel.Crud.TipoConfirmacion;
using SGPTWpf.ViewModel.Crud.TipoElementoIndice;
using SGPTWpf.ViewModel.Crud.TipoHerramienta;
using SGPTWpf.ViewModel.Crud.TipoPartida;
using SGPTWpf.ViewModel.Crud.TipoProcedimiento;
using SGPTWpf.ViewModel.Crud.TipoPrograma;
using SGPTWpf.ViewModel.Crud.TipoRespuestaCuestionario;
using SGPTWpf.ViewModel.Crud.TiposDescriptor;
using SGPTWpf.ViewModel.Crud.TipoTelefono;
using SGPTWpf.ViewModel.Crud.Visita;
using SGPTWpf.Views.Catalogos;
using SGPTWpf.Views.Principales.Administracion.Catalogos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Controls;

namespace SGPTWpf.Model
{
    public class MenuCatalogoModelo : UIBase
    {
        #region Model Attributes

        #endregion

        #region Model Properties

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id
        {
            get { return GetValue(() => id); }
            set { SetValue(() => id, value); }
        }

        public string tabla
        {
            get { return GetValue(() => tabla); }
            set { SetValue(() => tabla, value); }
        }
        public Type ViewType
        {
            get { return GetValue(() => ViewType); }
            set { SetValue(() => ViewType, value); }
        }
        public string ViewDisplay
        {
            get { return GetValue(() => ViewDisplay); }
            set { SetValue(() => ViewDisplay, value); }
        }
        //public virtual ICollection<cedulas> cedulas { get; set; }
        public bool IsSelected
        {
            get { return GetValue(() => IsSelected); }
            set { SetValue(() => IsSelected, value); }
        }
        public bool opcionSeleccionada
        {
            get { return GetValue(() => opcionSeleccionada); }
            set { SetValue(() => opcionSeleccionada, value); }
        }
        #endregion

        #region Menu catalogo
        public Type ViewModelType { get; set; }
        public UserControl View { get; set; }
        public RelayCommand Navegar { get; set; }

        public ViewModeloBase Contexto { get; set; }

        #region token

        private string _token;
        private string token
        {
            get { return _token; }
            set { _token = value; }
        }

        #endregion
        public MenuCatalogoModelo NewCatalogoModelo
        {
            get { return GetValue(() => NewCatalogoModelo); }
            set { SetValue(() => NewCatalogoModelo, value); }
        }


        public MenuCatalogoModelo()
        {
            _token = "MenuCatalogo"; 
            Navegar = new RelayCommand(NavigateExecute);
        }
        public void NavigateExecute()
        {
            switch (ViewDisplay)
            {
                case "Actividades":
                    ViewType = typeof(ActividadCrudView);
                    break;
                case "Departamentos por país":
                    ViewType = typeof(DepartamentoCrudView);
                    break;
                case "Municipos por depto":
                    ViewType = typeof(MunicipioCrudView);
                    break;
                case "Elementos contables":
                    ViewType = typeof(ElementoCrudView);
                    break;
                case "Monedas y símbolos":
                    ViewType = typeof(MonedaCrudView);
                    break;
                case "Símbolos para fórmulas":
                    ViewType = typeof(SimboloCrudView);
                    break;
                case "Elementos de Indice":
                    ViewType = typeof(TipoElementoIndiceCrudView);
                    break;
                case "Tipos de procedimiento programas":
                    ViewType = typeof(TipoProcedimientoCrudView);
                    break;
                case "Detalle de clase de documentos":
                    ViewType = typeof(DetalleDocumentosCrudView);
                    break;
                case "Clase de cuentas":
                    ViewType = typeof(ClaseCuentaCrudView);
                    break;
                default:
                    ViewType = typeof(GenericoCrudView);
                    break;
            }

            if ((View != null) && ViewType != null)
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
            }
            else
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
                //View = (UserControl)Activator.CreateInstance(ViewType);ç

                switch (ViewDisplay)
                {
                    case "Actividades":
                        ViewModelType = typeof(ActividadViewModel);
                        Contexto = new ActividadViewModel();
                        break;
                    case "Clase de balances":
                        ViewModelType = typeof(ClaseBalanceViewModel);
                        Contexto = new ClaseBalanceViewModel();
                        break;
                    case "Clase de cuentas":
                        ViewModelType = typeof(ClaseCuentaViewModel);
                        Contexto = new ClaseCuentaViewModel();
                        break;
                    case "Clase de herramientas":
                        ViewModelType = typeof(TipoHerramientaViewModel);
                        Contexto = new TipoHerramientaViewModel();
                        break;
                    case "Clase de programas":
                        ViewModelType = typeof(TipoProgramaViewModel);
                        Contexto = new TipoProgramaViewModel();
                        break;
                    case "Clase de simbolos":
                        ViewModelType = typeof(TipoDescriptorViewModel);
                        Contexto = new TipoDescriptorViewModel();
                        break;
                    case "Clase de teléfonos":
                        ViewModelType = typeof(TipoTelefonoViewModel);
                        Contexto = new TipoTelefonoViewModel();
                        break;
                    case "Clase de visitas":
                        ViewModelType = typeof(VisitaViewModel);
                        Contexto = new VisitaViewModel();
                        break;
                    case "Clases de auditoría":
                        ViewModelType = typeof(TipoAuditoriaViewModel);
                        Contexto = new TipoAuditoriaViewModel();
                        break;
                    case "Clases de cédula":
                        ViewModelType = typeof(TipoCedulaViewModel);
                        Contexto = new TipoCedulaViewModel();
                        break;
                    case "Clases de personas":
                        ViewModelType = typeof(ClasificacionViewModel);
                        Contexto = new ClasificacionViewModel();
                        break;
                    case "Criterios de materialidad":
                        ViewModelType = typeof(MaterialidadViewModel);
                        Contexto = new MaterialidadViewModel();
                        break;
                    case "Departamentos por país":
                        ViewModelType = typeof(DepartamentoViewModel);
                        Contexto = new DepartamentoViewModel();
                        break;
                    case "Municipos por depto":
                        ViewModelType = typeof(MunicipioViewModel);
                        Contexto = new MunicipioViewModel();
                        break;
                    case "Monedas y símbolos":
                        ViewModelType = typeof(MonedaViewModel);
                        Contexto = new MonedaViewModel();
                        break;
                    case "Elementos contables":
                        ViewModelType = typeof(ElementoViewModel);
                        Contexto = new ElementoViewModel();
                        break;
                    case "Elementos de Indice":
                        ViewModelType = typeof(TipoElementoIndiceViewModel);
                        Contexto = new TipoElementoIndiceViewModel();
                        break;
                    case "Estructuras de EF":
                        ViewModelType = typeof(EstructuraEstadoFinancieroViewModel);
                        Contexto = new EstructuraEstadoFinancieroViewModel();
                        break;
                    case "Estructuras de normas":
                        ViewModelType = typeof(LegalNormaViewModel);
                        Contexto = new LegalNormaViewModel();
                        break;
                    case "Paises":
                        ViewModelType = typeof(PaisViewModel);
                        Contexto = new PaisViewModel();
                        break;
                    case "Períodos":
                        ViewModelType = typeof(PeriodoViewModel);
                        Contexto = new PeriodoViewModel();
                        break;
                    case "Procesos de auditoría":
                        ViewModelType = typeof(ProcesoAuditoriaViewModel);
                        Contexto = new ProcesoAuditoriaViewModel();
                        break;
                    case "Respuesta de cuestionarios":
                        ViewModelType = typeof(TipoRespuestaCuestionarioViewModel);
                        Contexto = new TipoRespuestaCuestionarioViewModel();
                        break;
                    case "Roles de usuario":
                        ViewModelType = typeof(RolViewModel);
                        Contexto = new RolViewModel();
                        break;
                    case "Tipo de correspondencia":
                        ViewModelType = typeof(CorrespondenciaTipoViewModel);
                        Contexto = new CorrespondenciaTipoViewModel();
                        break;
                    case "Tipos de carpetas":
                        ViewModelType = typeof(TipoCarpetaViewModel);
                        Contexto = new TipoCarpetaViewModel();
                        break;
                    case "Tipos de confirmaciones":
                        ViewModelType = typeof(TipoConfirmacionViewModel);
                        Contexto = new TipoConfirmacionViewModel();
                        break;
                    case "Clase de documentos":
                        ViewModelType = typeof(DocumentoViewModel);
                        Contexto = new DocumentoViewModel();
                        break;
                    case "Tipos de partidas contables":
                        ViewModelType = typeof(TipoPartidaViewModel);
                        Contexto = new TipoPartidaViewModel();
                        break;
                    case "Tipos de procedimiento programas":
                        ViewModelType = typeof(TipoProcedimientoViewModel);
                        Contexto = new TipoProcedimientoViewModel();
                        break;
                    case "Símbolos para fórmulas":
                        ViewModelType = typeof(SimboloViewModel);
                        Contexto = new SimboloViewModel();
                        break;
                    case "Detalle de clase de documentos":
                        ViewModelType = typeof(DetalleDocumentosViewModel);
                        Contexto = new DetalleDocumentosViewModel();
                        break;
                    default:
                        //MessageDialog("Error en el switch");
                        break;
                }
            }
            var msg = new NavegacionSgpt { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto };
            Messenger.Default.Send(msg, token);
        }

        #endregion


        #region Public Model Methods

        public static List<MenuCatalogoModelo> GetAll()
        {
        var lista = new ObservableCollection<MenuCatalogoModelo>
        {
               new MenuCatalogoModelo {
                                id=1,
                                tabla="Actividades",
                                ViewType=typeof(ActividadViewModel),
                                ViewDisplay="Actividades"
                                },
               new MenuCatalogoModelo {
                                id=2,
                                tabla="clasesbalance",
                                ViewType=typeof(ClaseBalanceViewModel),
                                ViewDisplay="Clase de balances"
                                },
               new MenuCatalogoModelo {
                                id=3,
                                tabla="clasecuentas",
                                ViewType=typeof(ClaseCuentaViewModel),
                                ViewDisplay="Clase de cuentas"
                                },
               new MenuCatalogoModelo {
                                id=4,
                                tabla="tiposherramientas",
                                ViewType=typeof(TipoHerramientaViewModel),
                                ViewDisplay="Clase de herramientas"
                                },
               new MenuCatalogoModelo {
                                id=5,
                                tabla="tiposprograma",
                                ViewType=typeof(TipoProgramaViewModel),
                                ViewDisplay="Clase de programas"
                                },

               new MenuCatalogoModelo {
                                id=6,
                                tabla="tiposdescriptores",
                                ViewType=typeof(TipoDescriptorViewModel),
                                ViewDisplay="Clase de simbolos"
                                },
               new MenuCatalogoModelo {
                                id=7,
                                tabla="tipostelefonos",
                                ViewType=typeof(TipoTelefonoViewModel),
                                ViewDisplay="Clase de teléfonos"
                                },
               new MenuCatalogoModelo {
                                id=8,
                                tabla="visitas",
                                ViewType=typeof(VisitaViewModel),
                                ViewDisplay="Clase de visitas"
                                },
               new MenuCatalogoModelo {
                                id=9,
                                tabla="tiposauditoria",
                                ViewType=typeof(TipoAuditoriaViewModel),
                                ViewDisplay="Clases de auditoría"
                                },
               new MenuCatalogoModelo {
                                id=10,
                                tabla="tiposcedulas",
                                ViewType=typeof(TipoCedulaViewModel),
                                ViewDisplay="Clases de cédula"
                                },
               new MenuCatalogoModelo {
                                id=11,
                                tabla="clasificaciones",
                                ViewType=typeof(ClasificacionViewModel),
                                ViewDisplay="Clases de personas"
                                },
               new MenuCatalogoModelo {
                                id=12,
                                tabla="materialidad",
                                ViewType=typeof(MaterialidadViewModel),
                                ViewDisplay="Criterios de materialidad"
                                },
               new MenuCatalogoModelo {
                                id=13,
                                tabla="departamentos",
                                ViewType=typeof(DepartamentoViewModel),
                                ViewDisplay="Departamentos por país"
                                },

               new MenuCatalogoModelo {
                                id=14,
                                tabla="municipios",
                                ViewType=typeof(MunicipioViewModel),
                                ViewDisplay="Municipos por depto"
                                },
               new MenuCatalogoModelo {
                                id=15,
                                tabla="monedas",
                                ViewType=typeof(MonedaViewModel),
                                ViewDisplay="Monedas y símbolos"
                                },
               new MenuCatalogoModelo {
                                id=16,
                                tabla="elementos",
                                ViewType=typeof(ElementoViewModel),
                                ViewDisplay="Elementos contables"
                                },
               new MenuCatalogoModelo {
                                id=17,
                                tabla="tipoelementoindice",
                                ViewType=typeof(TipoElementoIndiceViewModel),
                                ViewDisplay="Elementos de Indice"
                                },

               new MenuCatalogoModelo {
                                id=18,
                                tabla="estructuraestadofinancieros",
                                ViewType=typeof(EstructuraEstadoFinancieroViewModel),
                                ViewDisplay="Estructuras de EF"
                                },
               new MenuCatalogoModelo {
                                id=19,
                                tabla="legalnormas",
                                ViewType=typeof(LegalNormaViewModel),
                                ViewDisplay="Estructuras de normas"
                                },
               new MenuCatalogoModelo {
                                id=20,
                                tabla="paises",
                                ViewType=typeof(PaisViewModel),
                                ViewDisplay="Paises"
                                },
               new MenuCatalogoModelo {
                                id=21,
                                tabla="periodos",
                                ViewType=typeof(PeriodoViewModel),
                                ViewDisplay="Períodos"
                                },
               new MenuCatalogoModelo {
                                id=22,
                                tabla="procesosauditoria",
                                ViewType=typeof(ProcesoAuditoriaViewModel),
                                ViewDisplay="Procesos de auditoría"
                                },

               new MenuCatalogoModelo {
                                id=23,
                                tabla="tiporespuestacuestionario",
                                ViewType=typeof(TipoRespuestaCuestionarioViewModel),
                                ViewDisplay="Respuesta de cuestionarios"
                                },
              /* new CatalogoModelo {
                                id=24,
                                tabla="roles",
                                ViewType=typeof(RolViewModel),
                                ViewDisplay="Roles de usuario"
                                },*/
               new MenuCatalogoModelo {
                                id=25,
                                tabla="correspondenciatipos",
                                ViewType=typeof(CorrespondenciaTipoViewModel),
                                ViewDisplay="Tipo de correspondencia"
                                },
               new MenuCatalogoModelo {
                                id=26,
                                tabla="tipocarpeta",
                                ViewType=typeof(TipoCarpetaViewModel),
                                ViewDisplay="Tipos de carpetas"
                                },
               new MenuCatalogoModelo {
                                id=27,
                                tabla="tipoconfirmaciones",
                                ViewType=typeof(TipoConfirmacionViewModel),
                                ViewDisplay="Tipos de confirmaciones"
                                },
               new MenuCatalogoModelo {
                                id=28,
                                tabla="documentos",
                                ViewType=typeof(DocumentoViewModel),
                                ViewDisplay="Clase de documentos"
                                },
               new MenuCatalogoModelo {
                                id=29,
                                tabla="tipopartidas",
                                ViewType=typeof(TipoPartidaViewModel),
                                ViewDisplay="Tipos de partidas contables"
                                },
               new MenuCatalogoModelo {
                                id=30,
                                tabla="tipoprocedimiento",
                                ViewType=typeof(TipoProcedimientoViewModel),
                                ViewDisplay="Tipos de procedimiento programas"
                                },

               new MenuCatalogoModelo {
                                id=31,
                                tabla="simbolos",
                                ViewType=typeof(SimboloViewModel),
                                ViewDisplay="Símbolos para fórmulas"
                                },
               new MenuCatalogoModelo {
                                id=32,
                                tabla="detalledocumentos",
                                ViewType=typeof(DetalleDocumentosViewModel),
                                ViewDisplay="Detalle de clase de documentos"
                                },
                    };
                        return lista.OrderBy(x=>x.ViewDisplay).ToList();
                    }
        #endregion

        public MenuCatalogoModelo(int i)
        {
            _token = "Menu";
        }
    }
}