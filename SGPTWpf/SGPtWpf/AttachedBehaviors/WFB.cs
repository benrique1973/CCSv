//http://stackoverflow.com/questions/20242817/resolving-windows-in-structure-map-or-how-to-manage-multiple-windows-in-wpf-mvvm
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.SGPtWpf.Views.Principales.Administracion.Catalogos.Generico.ClaseCuenta;
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
using SGPTWpf.ViewModel.Crud.Generico.Normal;
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
using SGPTWpf.Views.Catalogos.Generico.Departamento;
using SGPTWpf.Views.Catalogos.Generico.Elemento;
using SGPTWpf.Views.Catalogos.Generico.Id;
using SGPTWpf.Views.Catalogos.Generico.Moneda;
using SGPTWpf.Views.Catalogos.Generico.Municipio;
using SGPTWpf.Views.Catalogos.Generico.Simbolo;
using SGPTWpf.Views.Catalogos.Generico.TipoElementoIndice;
using SGPTWpf.Views.Principales.Administracion.Catalogos.Generico.DetalleDocumentos;
using SGPTWpf.Views.Principales.Administracion.Catalogos.Generico.TipoProcedimiento;
using System;
using System.Windows;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFB
    {
        #region Private Section
        private static string vista= string.Empty;
        private static string vistaAnterior = string.Empty;
        private static bool controlStrin=true;
        #endregion

        #region Name Dependency Property

        public static readonly DependencyProperty NameProperty;

        public static void SetName(DependencyObject DepObject, string value)
        {
            DepObject.SetValue(NameProperty, value);
        }

        public static string GetName(DependencyObject DepObject)
        {
            return (string)DepObject.GetValue(NameProperty);
        }

        #endregion

        #region WFB Constructor

        static WFB()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFB),
                                                               new UIPropertyMetadata(String.Empty, IsFactoryStart));
        }

        #endregion

        #region IsFactoryStart

        private static void IsFactoryStart(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {


            if (e.NewValue is String && String.IsNullOrEmpty((string)e.NewValue) == false)
            {
                if (controlStrin)
                {
                    vista = e.NewValue.ToString();
                    controlStrin = false;
                }
                else
                {
                    vistaAnterior = e.NewValue.ToString();
                    controlStrin = true;
                }
                if (vistaAnterior == vista)
                {
                    //Repetido
                }
                else
                {
                    var crearVentana = new MetroWindow();
                    string searchCrear = "CrearView";
                    string searchEditar = "EditarView";
                    string searchConsultar = "ConsultarView";
                    string searchActividad = "Actividad";
                    string encabezado = "";

                    switch (e.NewValue.ToString())
                    {
                        case "DetalleDocumentoCrearView":
                            crearVentana = new DetalleDocumentoCrearView();
                            crearVentana.DataContext = new DetalleDocumentosControllerViewModel();
                            encabezado = "Creación de detalle de tipo de documentos";
                            break;
                        case "DetalleDocumentoConsultarView":
                            crearVentana = new DetalleDocumentoCrearView();
                            crearVentana.DataContext = new DetalleDocumentosControllerViewModel();
                            encabezado = "Consulta de detalle de tipo de documentos";
                            break;
                        case "DetalleDocumentoEditarView":
                            crearVentana = new DetalleDocumentoCrearView();
                            crearVentana.DataContext = new DetalleDocumentosControllerViewModel();
                            encabezado = "Edición de detalle de tipo de documentos";
                            break;
                        case "DepartamentoCrearView":
                            crearVentana = new DepartamentoCrearView();
                            crearVentana.DataContext = new DepartamentoControllerViewModel();
                            encabezado = "Departamentos por país";
                            break;
                        case "DepartamentoConsultarView":
                            crearVentana = new DepartamentoConsultarView();
                            crearVentana.DataContext = new DepartamentoControllerViewModel();
                            encabezado = "Departamentos por país";
                            break;
                        case "DepartamentoEditarView":
                            crearVentana = new DepartamentoEditarView();
                            crearVentana.DataContext = new DepartamentoControllerViewModel();
                            encabezado = "Departamentos por país";
                            break;
                        case "MunicipioCrearView":
                            crearVentana = new MunicipioCrearView();
                            crearVentana.DataContext = new MunicipioControllerViewModel();
                            encabezado = "Municipios por departamento y por país";
                            break;
                        case "MunicipioConsultarView":
                            crearVentana = new MunicipioConsultarView();
                            crearVentana.DataContext = new MunicipioControllerViewModel();
                            encabezado = "Municipios por departamento y por país";
                            break;
                        case "MunicipioEditarView":
                            crearVentana = new MunicipioEditarView();
                            crearVentana.DataContext = new MunicipioControllerViewModel();
                            encabezado = "Municipios por departamento y por país";
                            break;
                        case "MonedaCrearView":
                            crearVentana = new MonedaCrearView();
                            crearVentana.DataContext = new MonedaControllerViewModel();
                            encabezado = "Monedas y símbolos";
                            break;
                        case "MonedaConsultarView":
                            crearVentana = new MonedaConsultarView();
                            crearVentana.DataContext = new MonedaControllerViewModel();
                            encabezado = "Monedas y símbolos";
                            break;
                        case "MonedaEditarView":
                            crearVentana = new MonedaEditarView();
                            crearVentana.DataContext = new MonedaControllerViewModel();
                            encabezado = "Monedas y símbolos";
                            break;
                        case "ElementoCrearView":
                            crearVentana = new ElementoCrearView();
                            crearVentana.DataContext = new ElementoControllerViewModel();
                            encabezado = "Elemento contable y código por defecto";
                            break;
                        case "ElementoConsultarView":
                            crearVentana = new ElementoCrearView();
                            crearVentana.DataContext = new ElementoControllerViewModel();
                            encabezado = "Elemento contable y código por defecto";
                            break;
                        case "ElementoEditarView":
                            crearVentana = new ElementoCrearView();
                            crearVentana.DataContext = new ElementoControllerViewModel();
                            encabezado = "Elemento contable y código por defecto";
                            break;
                        case "SimboloCrearView":
                            crearVentana = new SimboloCrearView();
                            crearVentana.DataContext = new SimboloControllerViewModel();
                            encabezado = "Símbolos de fórmulas";
                            break;
                        case "SimboloConsultarView":
                            crearVentana = new SimboloConsultarView();
                            crearVentana.DataContext = new SimboloControllerViewModel();
                            encabezado = "Símbolos de fórmulas";
                            break;
                        case "SimboloEditarView":
                            crearVentana = new SimboloEditarView();
                            crearVentana.DataContext = new SimboloControllerViewModel();
                            encabezado = "Símbolos de fórmulas";
                            break;
                        case "TipoElementoIndiceCrearView":
                            crearVentana = new TipoElementoIndiceCrearView();
                            crearVentana.DataContext = new TipoElementoIndiceControllerViewModel();
                            encabezado = "Tipo de elementos de índices";
                            break;
                        case "TipoElementoIndiceConsultarView":
                            crearVentana = new TipoElementoIndiceConsultarView();
                            crearVentana.DataContext = new TipoElementoIndiceControllerViewModel();
                            encabezado = "Tipo de elementos de índices";
                            break;
                        case "TipoElementoIndiceEditarView":
                            crearVentana = new TipoElementoIndiceEditarView();
                            crearVentana.DataContext = new TipoElementoIndiceControllerViewModel();
                            encabezado = "Tipo de elementos de índices";
                            break;
                        case "TipoProcedimientoCrearView":
                            crearVentana = new TipoProcedimientoCrearView();
                            encabezado = "Tipos de procedimientos de auditoría";
                            crearVentana.DataContext = new TipoProcedimientoControllerViewModel();
                            break;
                        case "TipoProcedimientoEditarView":
                            crearVentana = new TipoProcedimientoEditarView();
                            encabezado = "Tipos de procedimientos de auditoría";
                            crearVentana.DataContext = new TipoProcedimientoControllerViewModel();
                            break;
                        case "TipoProcedimientoConsultarView":
                            crearVentana = new TipoProcedimientoConsultarView();
                            encabezado = "Tipos de procedimientos de auditoría";
                            crearVentana.DataContext = new TipoProcedimientoControllerViewModel();
                            break;

                        case "ClaseCuentaCrearView":
                            crearVentana = new ClaseCuentaCrearView();
                            encabezado = "Tipos de procedimientos de auditoría";
                            crearVentana.DataContext = new ClaseCuentaControllerViewModel(); 
                            break;
                        case "ClaseCuentaEditarView":
                            crearVentana = new ClaseCuentaEditarView();
                            encabezado = "Tipos de procedimientos de auditoría";
                            crearVentana.DataContext = new ClaseCuentaControllerViewModel();
                            break;
                        case "ClaseCuentaConsultarView":
                            crearVentana = new ClaseCuentaConsultarView();
                            encabezado = "Tipos de procedimientos de auditoría";
                            crearVentana.DataContext = new ClaseCuentaControllerViewModel();
                            break;

                        default:
                            if (e.NewValue.ToString().IndexOf(searchCrear) == -1)
                            {
                                if (e.NewValue.ToString().IndexOf(searchEditar) == -1)
                                {
                                    if (e.NewValue.ToString().IndexOf(searchConsultar) == -1)
                                    {
                                        //Error
                                    }
                                    else
                                    {
                                        if (e.NewValue.ToString().IndexOf(searchActividad) == -1)
                                        { crearVentana = new GenericoConsultarView(); }
                                        else
                                        { crearVentana = new GenericoIdConsultarView(); }
                                    }
                                }
                                else
                                {
                                    if (e.NewValue.ToString().IndexOf(searchActividad) == -1)
                                    { crearVentana = new GenericoEditarView(); }
                                    else
                                    { crearVentana = new GenericoIdEditarView(); }
                                }
                            }
                            else
                            {
                                if (e.NewValue.ToString().IndexOf(searchActividad) == -1)
                                { crearVentana = new GenericoCrearView(); }
                                else
                                { crearVentana = new GenericoIdCrearView(); }

                            }

                            switch (e.NewValue.ToString())
                            {

                                case "ClaseBalanceCrearView":
                                    crearVentana.DataContext = new ClaseBalanceControllerViewModel();
                                    encabezado = "Clase de balance";
                                    break;
                                case "ClaseBalanceEditarView":
                                    crearVentana.DataContext = new ClaseBalanceControllerViewModel();
                                    encabezado = "Clase de balance";
                                    break;
                                case "ClaseBalanceConsultarView":
                                    crearVentana.DataContext = new ClaseBalanceControllerViewModel();
                                    encabezado = "Clase de balance";
                                    break;
                                case "ClasificacionCrearView":
                                    encabezado = "Naturaleza jurídica de la persona";
                                    crearVentana.DataContext = new ClasificacionControllerViewModel();
                                    break;
                                case "ClasificacionEditarView":
                                    encabezado = "Naturaleza jurídica de la persona";
                                    crearVentana.DataContext = new ClasificacionControllerViewModel();
                                    break;
                                case "ClasificacionConsultarView":
                                    encabezado = "Naturaleza jurídica de la persona";
                                    crearVentana.DataContext = new ClasificacionControllerViewModel();
                                    break;
                                case "CorrespondenciaTipoCrearView":
                                    encabezado = "Tipo de correspondencia";
                                    crearVentana.DataContext = new CorrespondenciaTipoControllerViewModel();
                                    break;
                                case "CorrespondenciaTipoEditarView":
                                    encabezado = "Tipo de correspondencia";
                                    crearVentana.DataContext = new CorrespondenciaTipoControllerViewModel();
                                    break;
                                case "CorrespondenciaTipoConsultarView":
                                    encabezado = "Tipo de correspondencia";
                                    crearVentana.DataContext = new CorrespondenciaTipoControllerViewModel();
                                    break;
                                case "DocumentoCrearView":
                                    encabezado = "Tipo de documentos";
                                    crearVentana.DataContext = new DocumentoControllerViewModel();
                                    break;
                                case "DocumentoEditarView":
                                    encabezado = "Tipo de documentos";
                                    crearVentana.DataContext = new DocumentoControllerViewModel();
                                    break;
                                case "DocumentoConsultarView":
                                    encabezado = "Tipo de documentos";
                                    crearVentana.DataContext = new DocumentoControllerViewModel();
                                    break;
                                case "EstructuraEstadoFinancieroCrearView":
                                    encabezado = "Tipo de estructura de estados financieros";
                                    crearVentana.DataContext = new EstructuraEstadoFinancieroControllerViewModel();
                                    break;
                                case "EstructuraEstadoFinancieroEditarView":
                                    encabezado = "Tipo de estructura de estados financieros";
                                    crearVentana.DataContext = new EstructuraEstadoFinancieroControllerViewModel();
                                    break;
                                case "EstructuraEstadoFinancieroConsultarView":
                                    encabezado = "Tipo de estructura de estados financieros";
                                    crearVentana.DataContext = new EstructuraEstadoFinancieroControllerViewModel();
                                    break;
                                case "LegalNormaCrearView":
                                    encabezado = "Tipo de normas aplicables";
                                    crearVentana.DataContext = new LegalNormaControllerViewModel();
                                    break;
                                case "LegalNormaEditarView":
                                    encabezado = "Tipo de normas aplicables";
                                    crearVentana.DataContext = new LegalNormaControllerViewModel();
                                    break;
                                case "LegalNormaConsultarView":
                                    encabezado = "Tipo de normas aplicables";
                                    crearVentana.DataContext = new LegalNormaControllerViewModel();
                                    break;
                                case "MaterialidadCrearView":
                                    encabezado = "Criterios de materialidad";
                                    crearVentana.DataContext = new MaterialidadControllerViewModel();
                                    break;
                                case "MaterialidadEditarView":
                                    encabezado = "Criterios de materialidad";
                                    crearVentana.DataContext = new MaterialidadControllerViewModel();
                                    break;
                                case "MaterialidadConsultarView":
                                    encabezado = "Criterios de materialidad";
                                    crearVentana.DataContext = new MaterialidadControllerViewModel();
                                    break;
                                case "PaisCrearView":
                                    encabezado = "Paises disponibles";
                                    crearVentana.DataContext = new PaisControllerViewModel();
                                    break;
                                case "PaisEditarView":
                                    encabezado = "Paises disponibles";
                                    crearVentana.DataContext = new PaisControllerViewModel();
                                    break;
                                case "PaisConsultarView":
                                    encabezado = "Paises disponibles";
                                    crearVentana.DataContext = new PaisControllerViewModel();
                                    break;
                                case "PeriodoCrearView":
                                    encabezado = "Períodos de tiempo";
                                    crearVentana.DataContext = new PeriodoControllerViewModel();
                                    break;
                                case "PeriodoEditarView":
                                    encabezado = "Períodos de tiempo";
                                    crearVentana.DataContext = new PeriodoControllerViewModel();
                                    break;
                                case "PeriodoConsultarView":
                                    encabezado = "Períodos de tiempo";
                                    crearVentana.DataContext = new PeriodoControllerViewModel();
                                    break;
                                case "ProcesoAuditoriaCrearView":
                                    encabezado = "Etapas de proceso de auditoría";
                                    crearVentana.DataContext = new ProcesoAuditoriaControllerViewModel();
                                    break;
                                case "ProcesoAuditoriaEditarView":
                                    encabezado = "Etapas de proceso de auditoría";
                                    crearVentana.DataContext = new ProcesoAuditoriaControllerViewModel();
                                    break;
                                case "ProcesoAuditoriaConsultarView":
                                    encabezado = "Etapas de proceso de auditoría";
                                    crearVentana.DataContext = new ProcesoAuditoriaControllerViewModel();
                                    break;
                                case "RolCrearView":
                                    encabezado = "Roles de usuarios";
                                    crearVentana.DataContext = new RolControllerViewModel();
                                    break;
                                case "RolEditarView":
                                    encabezado = "Roles de usuarios";
                                    crearVentana.DataContext = new RolControllerViewModel();
                                    break;
                                case "RolConsultarView":
                                    encabezado = "Roles de usuarios";
                                    crearVentana.DataContext = new RolControllerViewModel();
                                    break;
                                case "TipoHerramientaCrearView":
                                    encabezado = "Tipos de herramientas para auditoría";
                                    crearVentana.DataContext = new TipoHerramientaControllerViewModel();
                                    break;
                                case "TipoHerramientaEditarView":
                                    encabezado = "Tipos de herramientas para auditoría";
                                    crearVentana.DataContext = new TipoHerramientaControllerViewModel();
                                    break;
                                case "TipoHerramientaConsultarView":
                                    encabezado = "Tipos de herramientas para auditoría";
                                    crearVentana.DataContext = new TipoHerramientaControllerViewModel();
                                    break;
                                case "TipoCarpetaCrearView":
                                    encabezado = "Tipos de carpetas para archivo";
                                    crearVentana.DataContext = new TipoCarpetaControllerViewModel();
                                    break;
                                case "TipoCarpetaEditarView":
                                    encabezado = "Tipos de carpetas para archivo";
                                    crearVentana.DataContext = new TipoCarpetaControllerViewModel();
                                    break;
                                case "TipoCarpetaConsultarView":
                                    encabezado = "Tipos de carpetas para archivo";
                                    crearVentana.DataContext = new TipoCarpetaControllerViewModel();
                                    break;
                                case "TipoConfirmacionCrearView":
                                    encabezado = "Tipos de confirmaciones";
                                    crearVentana.DataContext = new TipoConfirmacionControllerViewModel();
                                    break;
                                case "TipoConfirmacionEditarView":
                                    encabezado = "Tipos de confirmaciones";
                                    crearVentana.DataContext = new TipoConfirmacionControllerViewModel();
                                    break;
                                case "TipoConfirmacionConsultarView":
                                    encabezado = "Tipos de confirmaciones";
                                    crearVentana.DataContext = new TipoConfirmacionControllerViewModel();
                                    break;
                                case "TipoProgramaCrearView":
                                    encabezado = "Tipos de programas de auditoría";
                                    crearVentana.DataContext = new TipoProgramaControllerViewModel();
                                    break;
                                case "TipoProgramaEditarView":
                                    encabezado = "Tipos de programas de auditoría";
                                    crearVentana.DataContext = new TipoProgramaControllerViewModel();
                                    break;
                                case "TipoProgramaConsultarView":
                                    encabezado = "Tipos de programas de auditoría";
                                    crearVentana.DataContext = new TipoProgramaControllerViewModel();
                                    break;
                                case "TipoPartidaCrearView":
                                    encabezado = "Tipos de partidas contables";
                                    crearVentana.DataContext = new TipoPartidaControllerViewModel();
                                    break;
                                case "TipoPartidaEditarView":
                                    encabezado = "Tipos de partidas contables";
                                    crearVentana.DataContext = new TipoPartidaControllerViewModel();
                                    break;
                                case "TipoPartidaConsultarView":
                                    encabezado = "Tipos de partidas contables";
                                    crearVentana.DataContext = new TipoPartidaControllerViewModel();
                                    break;
                                case "TipoRespuestaCuestionarioCrearView":
                                    encabezado = "Opciones de respuesta en cuestionarios";
                                    crearVentana.DataContext = new TipoRespuestaCuestionarioControllerViewModel();
                                    break;
                                case "TipoRespuestaCuestionarioEditarView":
                                    encabezado = "Opciones de respuesta en cuestionarios";
                                    crearVentana.DataContext = new TipoRespuestaCuestionarioControllerViewModel();
                                    break;
                                case "TipoRespuestaCuestionarioConsultarView":
                                    encabezado = "Opciones de respuesta en cuestionarios";
                                    crearVentana.DataContext = new TipoRespuestaCuestionarioControllerViewModel();
                                    break;
                                case "TipoAuditoriaCrearView":
                                    encabezado = "Tipos de encargos de auditoría";
                                    crearVentana.DataContext = new TipoAuditoriaControllerViewModel();
                                    break;
                                case "TipoAuditoriaEditarView":
                                    encabezado = "Tipos de encargos de auditoría";
                                    crearVentana.DataContext = new TipoAuditoriaControllerViewModel();
                                    break;
                                case "TipoAuditoriaConsultarView":
                                    encabezado = "Tipos de encargos de auditoría";
                                    crearVentana.DataContext = new TipoAuditoriaControllerViewModel();
                                    break;
                                case "TipoCedulaCrearView":
                                    encabezado = "Tipos de cédulas de auditoría";
                                    crearVentana.DataContext = new TipoCedulaControllerViewModel();
                                    break;
                                case "TipoCedulaEditarView":
                                    encabezado = "Tipos de cédulas de auditoría";
                                    crearVentana.DataContext = new TipoCedulaControllerViewModel();
                                    break;
                                case "TipoCedulaConsultarView":
                                    encabezado = "Tipos de cédulas de auditoría";
                                    crearVentana.DataContext = new TipoCedulaControllerViewModel();
                                    break;
                                case "TipoDescriptorCrearView":
                                    encabezado = "Tipos de signos de agrupación y símbolos para fórmulas";
                                    crearVentana.DataContext = new TipoDescriptorControllerViewModel();
                                    break;
                                case "TipoDescriptorEditarView":
                                    encabezado = "Tipos de signos de agrupación y símbolos para fórmulas";
                                    crearVentana.DataContext = new TipoDescriptorControllerViewModel();
                                    break;
                                case "TipoDescriptorConsultarView":
                                    encabezado = "Tipos de signos de agrupación y símbolos para fórmulas";
                                    crearVentana.DataContext = new TipoDescriptorControllerViewModel();
                                    break;
                                case "ActividadCrearView":
                                    encabezado = "Actividad económica de clientes";
                                    crearVentana.DataContext = new ActividadControllerViewModel();
                                    break;
                                case "ActividadEditarView":
                                    encabezado = "Actividad económica de clientes";
                                    crearVentana.DataContext = new ActividadControllerViewModel();
                                    break;
                                case "ActividadConsultarView":
                                    encabezado = "Actividad económica de clientes";
                                    crearVentana.DataContext = new ActividadControllerViewModel();
                                    break;
                                case "TipoTelefonoCrearView":
                                    encabezado = "Tipos de teléfono";
                                    crearVentana.DataContext = new TipoTelefonoControllerViewModel();
                                    break;
                                case "TipoTelefonoEditarView":
                                    encabezado = "Tipos de teléfono";
                                    crearVentana.DataContext = new TipoTelefonoControllerViewModel();
                                    break;
                                case "TipoTelefonoConsultarView":
                                    encabezado = "Tipos de teléfono";
                                    crearVentana.DataContext = new TipoTelefonoControllerViewModel();
                                    break;
                                case "VisitaCrearView":
                                    encabezado = "Clase de visita a clientes";
                                    crearVentana.DataContext = new VisitaControllerViewModel();
                                    break;
                                case "VisitaEditarView":
                                    encabezado = "Clase de visita a clientes";
                                    crearVentana.DataContext = new VisitaControllerViewModel();
                                    break;
                                case "VisitaConsultarView":
                                    encabezado = "Clase de visita a clientes";
                                    crearVentana.DataContext = new VisitaControllerViewModel();
                                    break;
                                default:
                                    encabezado = "Error en la frase revisa bien";
                                    break;
                            }
                            break;
                    }
                    crearVentana.Width = 550;
                    crearVentana.Height = 300;
                    crearVentana.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    crearVentana.Title = encabezado;
                    crearVentana.Owner = Application.Current.MainWindow;
                    crearVentana.Show();
                }
            }
            else
            {
                vista = string.Empty;
                vistaAnterior = string.Empty;
                controlStrin = true;
            }
        }

        #endregion
    }
}