/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:SGPTWpf.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.ViewModel.Crud.Actividad;
using SGPTWpf.ViewModel.Crud.ClaseBalance;
using SGPTWpf.ViewModel.Crud.ClaseCuenta;
using SGPTWpf.ViewModel.Crud.CorrespondenciaTipo;
using SGPTWpf.ViewModel.Crud.Departamento;
using SGPTWpf.ViewModel.Crud.Documento;
using SGPTWpf.ViewModel.Crud.Elemento;
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
using SGPTmvvm.ViewModel;
using SGPTmvvm.Modales;
using SGPTWpf.ViewModel.Administracion.Crud.DetalleDocumentos;

namespace SGPTWpf.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {

        /*
        #region Actividad

        #region Actividad ViewModel


        private static ActividadViewModel _ActividadViewModel;

        public static ActividadViewModel ActividadViewModelStatic
        {
            get
            {
                if (_ActividadViewModel == null)
                {
                    CreateActividadViewModel();
                }

                return _ActividadViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ActividadViewModel ActividadViewModel
        {
            get
            {
                return ActividadViewModelStatic;
            }
        }

        public static void ClearActividadViewModel()
        {
            _ActividadViewModel.Cleanup();
            _ActividadViewModel = null;
        }

        public static void CreateActividadViewModel()
        {
            if (_ActividadViewModel == null)
            {
                _ActividadViewModel = new ActividadViewModel();
            }
        }

        #endregion

        #region ActividadController ViewModel


        private static ActividadControllerViewModel _ActividadControllerViewModel;

        public static ActividadControllerViewModel ActividadControllerViewModelStatic
        {
            get
            {
                if (_ActividadControllerViewModel == null)
                {
                    CreateActividadControllerViewModel();
                }

                return _ActividadControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ActividadControllerViewModel ActividadControllerViewModel
        {
            get
            {
                return ActividadControllerViewModelStatic;
            }
        }

        public static void ClearActividadControllerViewModel()
        {
            _ActividadControllerViewModel.Cleanup();
            _ActividadControllerViewModel = null;
        }

        public static void CreateActividadControllerViewModel()
        {
            if (_ActividadControllerViewModel == null)
            {
                _ActividadControllerViewModel = new ActividadControllerViewModel();
            }
        }

        #endregion

        #endregion


        #region ClaseCuenta

        #region ClaseCuenta ViewModel


        private static ClaseCuentaViewModel _ClaseCuentaViewModel;

        public static ClaseCuentaViewModel ClaseCuentaViewModelStatic
        {
            get
            {
                if (_ClaseCuentaViewModel == null)
                {
                    CreateClaseCuentaViewModel();
                }

                return _ClaseCuentaViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public ClaseCuentaViewModel ClaseCuentaViewModel
        {
            get
            {
                return ClaseCuentaViewModelStatic;
            }
        }

        public static void ClearClaseCuentaViewModel()
        {
            _ClaseCuentaViewModel.Cleanup();
            _ClaseCuentaViewModel = null;
        }

        public static void CreateClaseCuentaViewModel()
        {
            if (_ClaseCuentaViewModel == null)
            {
                _ClaseCuentaViewModel = new ClaseCuentaViewModel();
            }
        }

        #endregion

        #region ClaseCuentaController ViewModel


        private static ClaseCuentaControllerViewModel _ClaseCuentaControllerViewModel;

        public static ClaseCuentaControllerViewModel ClaseCuentaControllerViewModelStatic
        {
            get
            {
                if (_ClaseCuentaControllerViewModel == null)
                {
                    CreateClaseCuentaControllerViewModel();
                }

                return _ClaseCuentaControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ClaseCuentaControllerViewModel ClaseCuentaControllerViewModel
        {
            get
            {
                return ClaseCuentaControllerViewModelStatic;
            }
        }

        public static void ClearClaseCuentaControllerViewModel()
        {
            _ClaseCuentaControllerViewModel.Cleanup();
            _ClaseCuentaControllerViewModel = null;
        }

        public static void CreateClaseCuentaControllerViewModel()
        {
            if (_ClaseCuentaControllerViewModel == null)
            {
                _ClaseCuentaControllerViewModel = new ClaseCuentaControllerViewModel();
            }
        }

        #endregion

        #endregion


        #region ClaseBalance

        #region ClaseBalanceController ViewModel


        private static ClaseBalanceControllerViewModel _ClaseBalanceControllerViewModel;

        public static ClaseBalanceControllerViewModel ClaseBalanceControllerViewModelStatic
        {
            get
            {
                if (_ClaseBalanceControllerViewModel == null)
                {
                    CreateClaseBalanceControllerViewModel();
                }

                return _ClaseBalanceControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ClaseBalanceControllerViewModel ClaseBalanceControllerViewModel
        {
            get
            {
                return ClaseBalanceControllerViewModelStatic;
            }
        }

        public static void ClearClaseBalanceControllerViewModel()
        {
            _ClaseBalanceControllerViewModel.Cleanup();
            _ClaseBalanceControllerViewModel = null;
        }

        public static void CreateClaseBalanceControllerViewModel()
        {
            if (_ClaseBalanceControllerViewModel == null)
            {
                _ClaseBalanceControllerViewModel = new ClaseBalanceControllerViewModel();
            }
        }

        #endregion


        #region ClaseBalanceViewModel ViewModel


        private static ClaseBalanceViewModel _ClaseBalanceViewModel;

        public static ClaseBalanceViewModel ClaseBalanceViewModelStatic
        {
            get
            {
                if (_ClaseBalanceViewModel == null)
                {
                    CreateClaseBalanceViewModel();
                }

                return _ClaseBalanceViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public ClaseBalanceViewModel ClaseBalanceViewModel
        {
            get
            {
                return ClaseBalanceViewModelStatic;
            }
        }

        public static void ClearClaseBalanceViewModel()
        {
            _ClaseBalanceViewModel.Cleanup();
            _ClaseBalanceViewModel = null;
        }

        public static void CreateClaseBalanceViewModel()
        {
            if (_ClaseBalanceViewModel == null)
            {
                _ClaseBalanceViewModel = new ClaseBalanceViewModel();
            }
        }
        #endregion

        #endregion */

        #region Loguin ViewModel


        private static LoguinViewModel _LoguinViewModel;

        public static LoguinViewModel LoguinViewModelStatic
        {
            get
            {
                if (_LoguinViewModel == null)
                {
                    CreateLoguinViewModel();
                }

                return _LoguinViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public LoguinViewModel LoguinViewModel
        {
            get
            {
                return LoguinViewModelStatic;
            }
        }

        public static void ClearLoguinViewModel()
        {
            _LoguinViewModel.Cleanup();
            _LoguinViewModel = null;
        }

        public static void CreateLoguinViewModel()
        {
            if (_LoguinViewModel == null)
            {
                _LoguinViewModel = new LoguinViewModel();
            }
        }

        #endregion


        #region Inicial ViewModel


        private static InicialViewModel _InicialViewModel;

        public static InicialViewModel InicialViewModelStatic
        {
            get
            {
                if (_InicialViewModel == null)
                {
                    CreateInicialViewModel();
                }

                return _InicialViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public InicialViewModel InicialViewModel
        {
            get
            {
                return InicialViewModelStatic;
            }
        }

        public static void ClearInicialViewModel()
        {
            _InicialViewModel.Cleanup();
            _InicialViewModel = null;
        }

        public static void CreateInicialViewModel()
        {
            if (_InicialViewModel == null)
            {
                _InicialViewModel = new InicialViewModel();
            }
        }

        #endregion

        #region Principal Alterna ViewModel


        private static PrincipalAlternaViewModel _PrincipalAlternaViewModel;

        public static PrincipalAlternaViewModel PrincipalAlternaViewModelStatic
        {
            get
            {
                if (_PrincipalAlternaViewModel == null)
                {
                    CreatePrincipalAlternaViewModel();
                }

                return _PrincipalAlternaViewModel;
            }
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public PrincipalAlternaViewModel PrincipalAlternaViewModel
        {
            get
            {
                return PrincipalAlternaViewModelStatic;
            }
        }

        public static void ClearPrincipalAlternaViewModel()
        {
            _PrincipalAlternaViewModel.Cleanup();
            _PrincipalAlternaViewModel = null;
        }

        public static void CreatePrincipalAlternaViewModel()
        {
            if (_PrincipalAlternaViewModel == null)
            {
                _PrincipalAlternaViewModel = new PrincipalAlternaViewModel();
            }
        }


        #endregion


        /*

        #region CorrespondenciaTipo

        #region CorrespondenciaTipo ViewModel


        private static CorrespondenciaTipoViewModel _CorrespondenciaTipoViewModel;

        public static CorrespondenciaTipoViewModel CorrespondenciaTipoViewModelStatic
        {
            get
            {
                if (_CorrespondenciaTipoViewModel == null)
                {
                    CreateCorrespondenciaTipoViewModel();
                }

                return _CorrespondenciaTipoViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public CorrespondenciaTipoViewModel CorrespondenciaTipoViewModel
        {
            get
            {
                return CorrespondenciaTipoViewModelStatic;
            }
        }

        public static void ClearCorrespondenciaTipoViewModel()
        {
            _CorrespondenciaTipoViewModel.Cleanup();
            _CorrespondenciaTipoViewModel = null;
        }

        public static void CreateCorrespondenciaTipoViewModel()
        {
            if (_CorrespondenciaTipoViewModel == null)
            {
                _CorrespondenciaTipoViewModel = new CorrespondenciaTipoViewModel();
            }
        }

        #endregion

        #region ClaseCuentaController ViewModel


        private static CorrespondenciaTipoControllerViewModel _CorrespondenciaTipoControllerViewModel;

        public static CorrespondenciaTipoControllerViewModel CorrespondenciaTipoControllerViewModelStatic
        {
            get
            {
                if (_CorrespondenciaTipoControllerViewModel == null)
                {
                    CreateCorrespondenciaTipoControllerViewModel();
                }

                return _CorrespondenciaTipoControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public CorrespondenciaTipoControllerViewModel CorrespondenciaTipoControllerViewModel
        {
            get
            {
                return CorrespondenciaTipoControllerViewModelStatic;
            }
        }

        public static void ClearCorrespondenciaTipoControllerViewModel()
        {
            _CorrespondenciaTipoControllerViewModel.Cleanup();
            _CorrespondenciaTipoControllerViewModel = null;
        }

        public static void CreateCorrespondenciaTipoControllerViewModel()
        {
            if (_CorrespondenciaTipoControllerViewModel == null)
            {
                _CorrespondenciaTipoControllerViewModel = new CorrespondenciaTipoControllerViewModel();
            }
        }

        #endregion

        #endregion


        #region Documento

        #region Documento ViewModel


        private static DocumentoViewModel _DocumentoViewModel;

        public static DocumentoViewModel DocumentoViewModelStatic
        {
            get
            {
                if (_DocumentoViewModel == null)
                {
                    CreateDocumentoViewModel();
                }

                return _DocumentoViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public DocumentoViewModel DocumentoViewModel
        {
            get
            {
                return DocumentoViewModelStatic;
            }
        }

        public static void ClearDocumentoViewModel()
        {
            _DocumentoViewModel.Cleanup();
            _DocumentoViewModel = null;
        }

        public static void CreateDocumentoViewModel()
        {
            if (_DocumentoViewModel == null)
            {
                _DocumentoViewModel = new DocumentoViewModel();
            }
        }

        #endregion

        #region DocumentoController ViewModel


        private static DocumentoControllerViewModel _DocumentoControllerViewModel;

        public static DocumentoControllerViewModel DocumentoControllerViewModelStatic
        {
            get
            {
                if (_DocumentoControllerViewModel == null)
                {
                    CreateDocumentoControllerViewModel();
                }

                return _DocumentoControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public DocumentoControllerViewModel DocumentoControllerViewModel
        {
            get
            {
                return DocumentoControllerViewModelStatic;
            }
        }

        public static void ClearDocumentoControllerViewModel()
        {
            _DocumentoControllerViewModel.Cleanup();
            _DocumentoControllerViewModel = null;
        }

        public static void CreateDocumentoControllerViewModel()
        {
            if (_DocumentoControllerViewModel == null)
            {
                _DocumentoControllerViewModel = new DocumentoControllerViewModel();
            }
        }

        #endregion

        #endregion


        #region LegalNorma

        #region LegalNorma ViewModel


        private static LegalNormaViewModel _LegalNormaViewModel;

        public static LegalNormaViewModel LegalNormaViewModelStatic
        {
            get
            {
                if (_LegalNormaViewModel == null)
                {
                    CreateLegalNormaViewModel();
                }

                return _LegalNormaViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public LegalNormaViewModel LegalNormaViewModel
        {
            get
            {
                return LegalNormaViewModelStatic;
            }
        }

        public static void ClearLegalNormaViewModel()
        {
            _LegalNormaViewModel.Cleanup();
            _LegalNormaViewModel = null;
        }

        public static void CreateLegalNormaViewModel()
        {
            if (_LegalNormaViewModel == null)
            {
                _LegalNormaViewModel = new LegalNormaViewModel();
            }
        }

        #endregion

        #region ClaseCuentaController ViewModel


        private static LegalNormaControllerViewModel _LegalNormaControllerViewModel;

        public static LegalNormaControllerViewModel LegalNormaControllerViewModelStatic
        {
            get
            {
                if (_LegalNormaControllerViewModel == null)
                {
                    CreateLegalNormaControllerViewModel();
                }

                return _LegalNormaControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public LegalNormaControllerViewModel LegalNormaControllerViewModel
        {
            get
            {
                return LegalNormaControllerViewModelStatic;
            }
        }

        public static void ClearLegalNormaControllerViewModel()
        {
            _LegalNormaControllerViewModel.Cleanup();
            _LegalNormaControllerViewModel = null;
        }

        public static void CreateLegalNormaControllerViewModel()
        {
            if (_LegalNormaControllerViewModel == null)
            {
                _LegalNormaControllerViewModel = new LegalNormaControllerViewModel();
            }
        }

        #endregion

        #endregion

        #region Materialidad

        #region Materialidad ViewModel


        private static MaterialidadViewModel _MaterialidadViewModel;

        public static MaterialidadViewModel MaterialidadViewModelStatic
        {
            get
            {
                if (_MaterialidadViewModel == null)
                {
                    CreateMaterialidadViewModel();
                }

                return _MaterialidadViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public MaterialidadViewModel MaterialidadViewModel
        {
            get
            {
                return MaterialidadViewModelStatic;
            }
        }

        public static void ClearMaterialidadViewModel()
        {
            _MaterialidadViewModel.Cleanup();
            _MaterialidadViewModel = null;
        }

        public static void CreateMaterialidadViewModel()
        {
            if (_MaterialidadViewModel == null)
            {
                _MaterialidadViewModel = new MaterialidadViewModel();
            }
        }

        #endregion

        #region ClaseCuentaController ViewModel


        private static MaterialidadControllerViewModel _MaterialidadControllerViewModel;

        public static MaterialidadControllerViewModel MaterialidadControllerViewModelStatic
        {
            get
            {
                if (_MaterialidadControllerViewModel == null)
                {
                    CreateMaterialidadControllerViewModel();
                }

                return _MaterialidadControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MaterialidadControllerViewModel MaterialidadControllerViewModel
        {
            get
            {
                return MaterialidadControllerViewModelStatic;
            }
        }

        public static void ClearMaterialidadControllerViewModel()
        {
            _MaterialidadControllerViewModel.Cleanup();
            _MaterialidadControllerViewModel = null;
        }

        public static void CreateMaterialidadControllerViewModel()
        {
            if (_MaterialidadControllerViewModel == null)
            {
                _MaterialidadControllerViewModel = new MaterialidadControllerViewModel();
            }
        }

        #endregion

        #endregion


        #region Pais

        #region Pais ViewModel


        private static PaisViewModel _PaisViewModel;

        public static PaisViewModel PaisViewModelStatic
        {
            get
            {
                if (_PaisViewModel == null)
                {
                    CreatePaisViewModel();
                }

                return _PaisViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public PaisViewModel PaisViewModel
        {
            get
            {
                return PaisViewModelStatic;
            }
        }

        public static void ClearPaisViewModel()
        {
            _PaisViewModel.Cleanup();
            _PaisViewModel = null;
        }

        public static void CreatePaisViewModel()
        {
            if (_PaisViewModel == null)
            {
                _PaisViewModel = new PaisViewModel();
            }
        }

        #endregion

        #region PaisController ViewModel


        private static PaisControllerViewModel _PaisControllerViewModel;

        public static PaisControllerViewModel PaisControllerViewModelStatic
        {
            get
            {
                if (_PaisControllerViewModel == null)
                {
                    CreatePaisControllerViewModel();
                }

                return _PaisControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public PaisControllerViewModel PaisControllerViewModel
        {
            get
            {
                return PaisControllerViewModelStatic;
            }
        }

        public static void ClearPaisControllerViewModel()
        {
            _PaisControllerViewModel.Cleanup();
            _PaisControllerViewModel = null;
        }

        public static void CreatePaisControllerViewModel()
        {
            if (_PaisControllerViewModel == null)
            {
                _PaisControllerViewModel = new PaisControllerViewModel();
            }
        }

        #endregion

        #endregion

        #region Periodo

        #region Periodo ViewModel


        private static PeriodoViewModel _PeriodoViewModel;

        public static PeriodoViewModel PeriodoViewModelStatic
        {
            get
            {
                if (_PeriodoViewModel == null)
                {
                    CreatePeriodoViewModel();
                }

                return _PeriodoViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public PeriodoViewModel PeriodoViewModel
        {
            get
            {
                return PeriodoViewModelStatic;
            }
        }

        public static void ClearPeriodoViewModel()
        {
            _PeriodoViewModel.Cleanup();
            _PeriodoViewModel = null;
        }

        public static void CreatePeriodoViewModel()
        {
            if (_PeriodoViewModel == null)
            {
                _PeriodoViewModel = new PeriodoViewModel();
            }
        }

        #endregion

        #region PeriodoController ViewModel


        private static PeriodoControllerViewModel _PeriodoControllerViewModel;

        public static PeriodoControllerViewModel PeriodoControllerViewModelStatic
        {
            get
            {
                if (_PeriodoControllerViewModel == null)
                {
                    CreatePeriodoControllerViewModel();
                }

                return _PeriodoControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public PeriodoControllerViewModel PeriodoControllerViewModel
        {
            get
            {
                return PeriodoControllerViewModelStatic;
            }
        }

        public static void ClearPeriodoControllerViewModel()
        {
            _PeriodoControllerViewModel.Cleanup();
            _PeriodoControllerViewModel = null;
        }

        public static void CreatePeriodoControllerViewModel()
        {
            if (_PeriodoControllerViewModel == null)
            {
                _PeriodoControllerViewModel = new PeriodoControllerViewModel();
            }
        }

        #endregion

        #endregion

        #region ProcesoAuditoria

        #region ProcesoAuditoria ViewModel


        private static ProcesoAuditoriaViewModel _ProcesoAuditoriaViewModel;

        public static ProcesoAuditoriaViewModel ProcesoAuditoriaViewModelStatic
        {
            get
            {
                if (_ProcesoAuditoriaViewModel == null)
                {
                    CreateProcesoAuditoriaViewModel();
                }

                return _ProcesoAuditoriaViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public ProcesoAuditoriaViewModel ProcesoAuditoriaViewModel
        {
            get
            {
                return ProcesoAuditoriaViewModelStatic;
            }
        }

        public static void ClearProcesoAuditoriaViewModel()
        {
            _ProcesoAuditoriaViewModel.Cleanup();
            _ProcesoAuditoriaViewModel = null;
        }

        public static void CreateProcesoAuditoriaViewModel()
        {
            if (_ProcesoAuditoriaViewModel == null)
            {
                _ProcesoAuditoriaViewModel = new ProcesoAuditoriaViewModel();
            }
        }

        #endregion

        #region ClaseCuentaController ViewModel


        private static ProcesoAuditoriaControllerViewModel _ProcesoAuditoriaControllerViewModel;

        public static ProcesoAuditoriaControllerViewModel ProcesoAuditoriaControllerViewModelStatic
        {
            get
            {
                if (_ProcesoAuditoriaControllerViewModel == null)
                {
                    CreateProcesoAuditoriaControllerViewModel();
                }

                return _ProcesoAuditoriaControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ProcesoAuditoriaControllerViewModel ProcesoAuditoriaControllerViewModel
        {
            get
            {
                return ProcesoAuditoriaControllerViewModelStatic;
            }
        }

        public static void ClearProcesoAuditoriaControllerViewModel()
        {
            _ProcesoAuditoriaControllerViewModel.Cleanup();
            _ProcesoAuditoriaControllerViewModel = null;
        }

        public static void CreateProcesoAuditoriaControllerViewModel()
        {
            if (_ProcesoAuditoriaControllerViewModel == null)
            {
                _ProcesoAuditoriaControllerViewModel = new ProcesoAuditoriaControllerViewModel();
            }
        }

        #endregion

        #endregion


        #region Rol

        #region Rol ViewModel


        private static RolViewModel _RolViewModel;

        public static RolViewModel RolViewModelStatic
        {
            get
            {
                if (_RolViewModel == null)
                {
                    CreateRolViewModel();
                }

                return _RolViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public RolViewModel RolViewModel
        {
            get
            {
                return RolViewModelStatic;
            }
        }

        public static void ClearRolViewModel()
        {
            _RolViewModel.Cleanup();
            _RolViewModel = null;
        }

        public static void CreateRolViewModel()
        {
            if (_RolViewModel == null)
            {
                _RolViewModel = new RolViewModel();
            }
        }

        #endregion

        #region RolController ViewModel


        private static RolControllerViewModel _RolControllerViewModel;

        public static RolControllerViewModel RolControllerViewModelStatic
        {
            get
            {
                if (_RolControllerViewModel == null)
                {
                    CreateRolControllerViewModel();
                }

                return _RolControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public RolControllerViewModel RolControllerViewModel
        {
            get
            {
                return RolControllerViewModelStatic;
            }
        }

        public static void ClearRolControllerViewModel()
        {
            _RolControllerViewModel.Cleanup();
            _RolControllerViewModel = null;
        }

        public static void CreateRolControllerViewModel()
        {
            if (_RolControllerViewModel == null)
            {
                _RolControllerViewModel = new RolControllerViewModel();
            }
        }

        #endregion

        #endregion


        #region TipoCarpeta

        #region TipoCarpeta ViewModel


        private static TipoCarpetaViewModel _TipoCarpetaViewModel;

        public static TipoCarpetaViewModel TipoCarpetaViewModelStatic
        {
            get
            {
                if (_TipoCarpetaViewModel == null)
                {
                    CreateTipoCarpetaViewModel();
                }

                return _TipoCarpetaViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public TipoCarpetaViewModel TipoCarpetaViewModel
        {
            get
            {
                return TipoCarpetaViewModelStatic;
            }
        }

        public static void ClearTipoCarpetaViewModel()
        {
            _TipoCarpetaViewModel.Cleanup();
            _TipoCarpetaViewModel = null;
        }

        public static void CreateTipoCarpetaViewModel()
        {
            if (_TipoCarpetaViewModel == null)
            {
                _TipoCarpetaViewModel = new TipoCarpetaViewModel();
            }
        }

        #endregion

        #region TipoCarpetaController ViewModel


        private static TipoCarpetaControllerViewModel _TipoCarpetaControllerViewModel;

        public static TipoCarpetaControllerViewModel TipoCarpetaControllerViewModelStatic
        {
            get
            {
                if (_TipoCarpetaControllerViewModel == null)
                {
                    CreateTipoCarpetaControllerViewModel();
                }

                return _TipoCarpetaControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public TipoCarpetaControllerViewModel TipoCarpetaControllerViewModel
        {
            get
            {
                return TipoCarpetaControllerViewModelStatic;
            }
        }

        public static void ClearTipoCarpetaControllerViewModel()
        {
            _TipoCarpetaControllerViewModel.Cleanup();
            _TipoCarpetaControllerViewModel = null;
        }

        public static void CreateTipoCarpetaControllerViewModel()
        {
            if (_TipoCarpetaControllerViewModel == null)
            {
                _TipoCarpetaControllerViewModel = new TipoCarpetaControllerViewModel();
            }
        }

        #endregion

        #endregion


        */

        #region ViewModelLocator
        private static MainViewModel _main;

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>


        public ViewModelLocator()
        {

            CreateMain();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        public static MainViewModel MainStatic
        {
            get
            {
                if (_main == null)
                {
                    CreateMain();
                }

                return _main;
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public static void ClearMain()
        {
            _main.Cleanup();
            _main = null;
        }

        public static void CreateMain()
        {
            if (_main == null)
            {
                _main = new MainViewModel();
            }
        }
        #endregion


        /*
        #region TipoPartida

        #region TipoPartida ViewModel


        private static TipoPartidaViewModel _TipoPartidaViewModel;

        public static TipoPartidaViewModel TipoPartidaViewModelStatic
        {
            get
            {
                if (_TipoPartidaViewModel == null)
                {
                    CreateTipoPartidaViewModel();
                }

                return _TipoPartidaViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public TipoPartidaViewModel TipoPartidaViewModel
        {
            get
            {
                return TipoPartidaViewModelStatic;
            }
        }

        public static void ClearTipoPartidaViewModel()
        {
            _TipoPartidaViewModel.Cleanup();
            _TipoPartidaViewModel = null;
        }

        public static void CreateTipoPartidaViewModel()
        {
            if (_TipoPartidaViewModel == null)
            {
                _TipoPartidaViewModel = new TipoPartidaViewModel();
            }
        }

        #endregion

        #region ClaseCuentaController ViewModel


        private static TipoPartidaControllerViewModel _TipoPartidaControllerViewModel;

        public static TipoPartidaControllerViewModel TipoPartidaControllerViewModelStatic
        {
            get
            {
                if (_TipoPartidaControllerViewModel == null)
                {
                    CreateTipoPartidaControllerViewModel();
                }

                return _TipoPartidaControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public TipoPartidaControllerViewModel TipoPartidaControllerViewModel
        {
            get
            {
                return TipoPartidaControllerViewModelStatic;
            }
        }

        public static void ClearTipoPartidaControllerViewModel()
        {
            _TipoPartidaControllerViewModel.Cleanup();
            _TipoPartidaControllerViewModel = null;
        }

        public static void CreateTipoPartidaControllerViewModel()
        {
            if (_TipoPartidaControllerViewModel == null)
            {
                _TipoPartidaControllerViewModel = new TipoPartidaControllerViewModel();
            }
        }

        #endregion

        #endregion


        #region TipoConfirmacion

        #region TipoConfirmacion ViewModel


        private static TipoConfirmacionViewModel _TipoConfirmacionViewModel;

        public static TipoConfirmacionViewModel TipoConfirmacionViewModelStatic
        {
            get
            {
                if (_TipoConfirmacionViewModel == null)
                {
                    CreateTipoConfirmacionViewModel();
                }

                return _TipoConfirmacionViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public TipoConfirmacionViewModel TipoConfirmacionViewModel
        {
            get
            {
                return TipoConfirmacionViewModelStatic;
            }
        }

        public static void ClearTipoConfirmacionViewModel()
        {
            _TipoConfirmacionViewModel.Cleanup();
            _TipoConfirmacionViewModel = null;
        }

        public static void CreateTipoConfirmacionViewModel()
        {
            if (_TipoConfirmacionViewModel == null)
            {
                _TipoConfirmacionViewModel = new TipoConfirmacionViewModel();
            }
        }

        #endregion

        #region TipoConfirmacionController ViewModel


        private static TipoConfirmacionControllerViewModel _TipoConfirmacionControllerViewModel;

        public static TipoConfirmacionControllerViewModel TipoConfirmacionControllerViewModelStatic
        {
            get
            {
                if (_TipoConfirmacionControllerViewModel == null)
                {
                    CreateTipoConfirmacionControllerViewModel();
                }

                return _TipoConfirmacionControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public TipoConfirmacionControllerViewModel TipoConfirmacionControllerViewModel
        {
            get
            {
                return TipoConfirmacionControllerViewModelStatic;
            }
        }

        public static void ClearTipoConfirmacionControllerViewModel()
        {
            _TipoConfirmacionControllerViewModel.Cleanup();
            _TipoConfirmacionControllerViewModel = null;
        }

        public static void CreateTipoConfirmacionControllerViewModel()
        {
            if (_TipoConfirmacionControllerViewModel == null)
            {
                _TipoConfirmacionControllerViewModel = new TipoConfirmacionControllerViewModel();
            }
        }

        #endregion

        #endregion


        #region TipoProcedimiento

        #region TipoProcedimiento ViewModel


        private static TipoProcedimientoViewModel _TipoProcedimientoViewModel;

        public static TipoProcedimientoViewModel TipoProcedimientoViewModelStatic
        {
            get
            {
                if (_TipoProcedimientoViewModel == null)
                {
                    CreateTipoProcedimientoViewModel();
                }

                return _TipoProcedimientoViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public TipoProcedimientoViewModel TipoProcedimientoViewModel
        {
            get
            {
                return TipoProcedimientoViewModelStatic;
            }
        }

        public static void ClearTipoProcedimientoViewModel()
        {
            _TipoProcedimientoViewModel.Cleanup();
            _TipoProcedimientoViewModel = null;
        }

        public static void CreateTipoProcedimientoViewModel()
        {
            if (_TipoProcedimientoViewModel == null)
            {
                _TipoProcedimientoViewModel = new TipoProcedimientoViewModel();
            }
        }

        #endregion

        #region ClaseCuentaController ViewModel


        private static TipoProcedimientoControllerViewModel _TipoProcedimientoControllerViewModel;

        public static TipoProcedimientoControllerViewModel TipoProcedimientoControllerViewModelStatic
        {
            get
            {
                if (_TipoProcedimientoControllerViewModel == null)
                {
                    CreateTipoProcedimientoControllerViewModel();
                }

                return _TipoProcedimientoControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public TipoProcedimientoControllerViewModel TipoProcedimientoControllerViewModel
        {
            get
            {
                return TipoProcedimientoControllerViewModelStatic;
            }
        }

        public static void ClearTipoProcedimientoControllerViewModel()
        {
            _TipoProcedimientoControllerViewModel.Cleanup();
            _TipoProcedimientoControllerViewModel = null;
        }

        public static void CreateTipoProcedimientoControllerViewModel()
        {
            if (_TipoProcedimientoControllerViewModel == null)
            {
                _TipoProcedimientoControllerViewModel = new TipoProcedimientoControllerViewModel();
            }
        }

        #endregion

        #endregion


        #region TipoRespuestaCuestionario

        #region TipoRespuestaCuestionario ViewModel


        private static TipoRespuestaCuestionarioViewModel _TipoRespuestaCuestionarioViewModel;

        public static TipoRespuestaCuestionarioViewModel TipoRespuestaCuestionarioViewModelStatic
        {
            get
            {
                if (_TipoRespuestaCuestionarioViewModel == null)
                {
                    CreateTipoRespuestaCuestionarioViewModel();
                }

                return _TipoRespuestaCuestionarioViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public TipoRespuestaCuestionarioViewModel TipoRespuestaCuestionarioViewModel
        {
            get
            {
                return TipoRespuestaCuestionarioViewModelStatic;
            }
        }

        public static void ClearTipoRespuestaCuestionarioViewModel()
        {
            _TipoRespuestaCuestionarioViewModel.Cleanup();
            _TipoRespuestaCuestionarioViewModel = null;
        }

        public static void CreateTipoRespuestaCuestionarioViewModel()
        {
            if (_TipoRespuestaCuestionarioViewModel == null)
            {
                _TipoRespuestaCuestionarioViewModel = new TipoRespuestaCuestionarioViewModel();
            }
        }

        #endregion

        #region ClaseCuentaController ViewModel


        private static TipoRespuestaCuestionarioControllerViewModel _TipoRespuestaCuestionarioControllerViewModel;

        public static TipoRespuestaCuestionarioControllerViewModel TipoRespuestaCuestionarioControllerViewModelStatic
        {
            get
            {
                if (_TipoRespuestaCuestionarioControllerViewModel == null)
                {
                    CreateTipoRespuestaCuestionarioControllerViewModel();
                }

                return _TipoRespuestaCuestionarioControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public TipoRespuestaCuestionarioControllerViewModel TipoRespuestaCuestionarioControllerViewModel
        {
            get
            {
                return TipoRespuestaCuestionarioControllerViewModelStatic;
            }
        }

        public static void ClearTipoRespuestaCuestionarioControllerViewModel()
        {
            _TipoRespuestaCuestionarioControllerViewModel.Cleanup();
            _TipoRespuestaCuestionarioControllerViewModel = null;
        }

        public static void CreateTipoRespuestaCuestionarioControllerViewModel()
        {
            if (_TipoRespuestaCuestionarioControllerViewModel == null)
            {
                _TipoRespuestaCuestionarioControllerViewModel = new TipoRespuestaCuestionarioControllerViewModel();
            }
        }

        #endregion

        #endregion

        #region TipoAuditoria

        #region TipoAuditoria ViewModel


        private static TipoAuditoriaViewModel _TipoAuditoriaViewModel;

        public static TipoAuditoriaViewModel TipoAuditoriaViewModelStatic
        {
            get
            {
                if (_TipoAuditoriaViewModel == null)
                {
                    CreateTipoAuditoriaViewModel();
                }

                return _TipoAuditoriaViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public TipoAuditoriaViewModel TipoAuditoriaViewModel
        {
            get
            {
                return TipoAuditoriaViewModelStatic;
            }
        }

        public static void ClearTipoAuditoriaViewModel()
        {
            _TipoAuditoriaViewModel.Cleanup();
            _TipoAuditoriaViewModel = null;
        }

        public static void CreateTipoAuditoriaViewModel()
        {
            if (_TipoAuditoriaViewModel == null)
            {
                _TipoAuditoriaViewModel = new TipoAuditoriaViewModel();
            }
        }

        #endregion

        #region TipoAuditoriaController ViewModel


        private static TipoAuditoriaControllerViewModel _TipoAuditoriaControllerViewModel;

        public static TipoAuditoriaControllerViewModel TipoAuditoriaControllerViewModelStatic
        {
            get
            {
                if (_TipoAuditoriaControllerViewModel == null)
                {
                    CreateTipoAuditoriaControllerViewModel();
                }

                return _TipoAuditoriaControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public TipoAuditoriaControllerViewModel TipoAuditoriaControllerViewModel
        {
            get
            {
                return TipoAuditoriaControllerViewModelStatic;
            }
        }

        public static void ClearTipoAuditoriaControllerViewModel()
        {
            _TipoAuditoriaControllerViewModel.Cleanup();
            _TipoAuditoriaControllerViewModel = null;
        }

        public static void CreateTipoAuditoriaControllerViewModel()
        {
            if (_TipoAuditoriaControllerViewModel == null)
            {
                _TipoAuditoriaControllerViewModel = new TipoAuditoriaControllerViewModel();
            }
        }

        #endregion

        #endregion


        #region TipoCedula

        #region TipoCedula ViewModel


        private static TipoCedulaViewModel _TipoCedulaViewModel;

        public static TipoCedulaViewModel TipoCedulaViewModelStatic
        {
            get
            {
                if (_TipoCedulaViewModel == null)
                {
                    CreateTipoCedulaViewModel();
                }

                return _TipoCedulaViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public TipoCedulaViewModel TipoCedulaViewModel
        {
            get
            {
                return TipoCedulaViewModelStatic;
            }
        }

        public static void ClearTipoCedulaViewModel()
        {
            _TipoCedulaViewModel.Cleanup();
            _TipoCedulaViewModel = null;
        }

        public static void CreateTipoCedulaViewModel()
        {
            if (_TipoCedulaViewModel == null)
            {
                _TipoCedulaViewModel = new TipoCedulaViewModel();
            }
        }

        #endregion

        #region TipoCedulaController ViewModel


        private static TipoCedulaControllerViewModel _TipoCedulaControllerViewModel;

        public static TipoCedulaControllerViewModel TipoCedulaControllerViewModelStatic
        {
            get
            {
                if (_TipoCedulaControllerViewModel == null)
                {
                    CreateTipoCedulaControllerViewModel();
                }

                return _TipoCedulaControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public TipoCedulaControllerViewModel TipoCedulaControllerViewModel
        {
            get
            {
                return TipoCedulaControllerViewModelStatic;
            }
        }

        public static void ClearTipoCedulaControllerViewModel()
        {
            _TipoCedulaControllerViewModel.Cleanup();
            _TipoCedulaControllerViewModel = null;
        }

        public static void CreateTipoCedulaControllerViewModel()
        {
            if (_TipoCedulaControllerViewModel == null)
            {
                _TipoCedulaControllerViewModel = new TipoCedulaControllerViewModel();
            }
        }

        #endregion

        #endregion


        #region TipoDescriptor

        #region TipoDescriptor ViewModel


        private static TipoDescriptorViewModel _TipoDescriptorViewModel;

        public static TipoDescriptorViewModel TipoDescriptorViewModelStatic
        {
            get
            {
                if (_TipoDescriptorViewModel == null)
                {
                    CreateTipoDescriptorViewModel();
                }

                return _TipoDescriptorViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public TipoDescriptorViewModel TipoDescriptorViewModel
        {
            get
            {
                return TipoDescriptorViewModelStatic;
            }
        }

        public static void ClearTipoDescriptorViewModel()
        {
            _TipoDescriptorViewModel.Cleanup();
            _TipoDescriptorViewModel = null;
        }

        public static void CreateTipoDescriptorViewModel()
        {
            if (_TipoDescriptorViewModel == null)
            {
                _TipoDescriptorViewModel = new TipoDescriptorViewModel();
            }
        }

        #endregion

        #region ClaseCuentaController ViewModel


        private static TipoDescriptorControllerViewModel _TipoDescriptorControllerViewModel;

        public static TipoDescriptorControllerViewModel TipoDescriptorControllerViewModelStatic
        {
            get
            {
                if (_TipoDescriptorControllerViewModel == null)
                {
                    CreateTipoDescriptorControllerViewModel();
                }

                return _TipoDescriptorControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public TipoDescriptorControllerViewModel TipoDescriptorControllerViewModel
        {
            get
            {
                return TipoDescriptorControllerViewModelStatic;
            }
        }

        public static void ClearTipoDescriptorControllerViewModel()
        {
            _TipoDescriptorControllerViewModel.Cleanup();
            _TipoDescriptorControllerViewModel = null;
        }

        public static void CreateTipoDescriptorControllerViewModel()
        {
            if (_TipoDescriptorControllerViewModel == null)
            {
                _TipoDescriptorControllerViewModel = new TipoDescriptorControllerViewModel();
            }
        }

        #endregion

        #endregion

        #region TipoHerramienta

        #region TipoHerramienta ViewModel


        private static TipoHerramientaViewModel _TipoHerramientaViewModel;

        public static TipoHerramientaViewModel TipoHerramientaViewModelStatic
        {
            get
            {
                if (_TipoHerramientaViewModel == null)
                {
                    CreateTipoHerramientaViewModel();
                }

                return _TipoHerramientaViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public TipoHerramientaViewModel TipoHerramientaViewModel
        {
            get
            {
                return TipoHerramientaViewModelStatic;
            }
        }

        public static void ClearTipoHerramientaViewModel()
        {
            _TipoHerramientaViewModel.Cleanup();
            _TipoHerramientaViewModel = null;
        }

        public static void CreateTipoHerramientaViewModel()
        {
            if (_TipoHerramientaViewModel == null)
            {
                _TipoHerramientaViewModel = new TipoHerramientaViewModel();
            }
        }

        #endregion

        #region TipoHerramientaController ViewModel


        private static TipoHerramientaControllerViewModel _TipoHerramientaControllerViewModel;

        public static TipoHerramientaControllerViewModel TipoHerramientaControllerViewModelStatic
        {
            get
            {
                if (_TipoHerramientaControllerViewModel == null)
                {
                    CreateTipoHerramientaControllerViewModel();
                }

                return _TipoHerramientaControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public TipoHerramientaControllerViewModel TipoHerramientaControllerViewModel
        {
            get
            {
                return TipoHerramientaControllerViewModelStatic;
            }
        }

        public static void ClearTipoHerramientaControllerViewModel()
        {
            _TipoHerramientaControllerViewModel.Cleanup();
            _TipoHerramientaControllerViewModel = null;
        }

        public static void CreateTipoHerramientaControllerViewModel()
        {
            if (_TipoHerramientaControllerViewModel == null)
            {
                _TipoHerramientaControllerViewModel = new TipoHerramientaControllerViewModel();
            }
        }

        #endregion

        #endregion

        #region TipoPrograma

        #region TipoPrograma ViewModel


        private static TipoProgramaViewModel _TipoProgramaViewModel;

        public static TipoProgramaViewModel TipoProgramaViewModelStatic
        {
            get
            {
                if (_TipoProgramaViewModel == null)
                {
                    CreateTipoProgramaViewModel();
                }

                return _TipoProgramaViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public TipoProgramaViewModel TipoProgramaViewModel
        {
            get
            {
                return TipoProgramaViewModelStatic;
            }
        }

        public static void ClearTipoProgramaViewModel()
        {
            _TipoProgramaViewModel.Cleanup();
            _TipoProgramaViewModel = null;
        }

        public static void CreateTipoProgramaViewModel()
        {
            if (_TipoProgramaViewModel == null)
            {
                _TipoProgramaViewModel = new TipoProgramaViewModel();
            }
        }

        #endregion

        #region TipoProgramaController ViewModel


        private static TipoProgramaControllerViewModel _TipoProgramaControllerViewModel;

        public static TipoProgramaControllerViewModel TipoProgramaControllerViewModelStatic
        {
            get
            {
                if (_TipoProgramaControllerViewModel == null)
                {
                    CreateTipoProgramaControllerViewModel();
                }

                return _TipoProgramaControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public TipoProgramaControllerViewModel TipoProgramaControllerViewModel
        {
            get
            {
                return TipoProgramaControllerViewModelStatic;
            }
        }

        public static void ClearTipoProgramaControllerViewModel()
        {
            _TipoProgramaControllerViewModel.Cleanup();
            _TipoProgramaControllerViewModel = null;
        }

        public static void CreateTipoProgramaControllerViewModel()
        {
            if (_TipoProgramaControllerViewModel == null)
            {
                _TipoProgramaControllerViewModel = new TipoProgramaControllerViewModel();
            }
        }

        #endregion

        #endregion


        #region TipoTelefono

        #region TipoTelefono ViewModel


        private static TipoTelefonoViewModel _TipoTelefonoViewModel;

        public static TipoTelefonoViewModel TipoTelefonoViewModelStatic
        {
            get
            {
                if (_TipoTelefonoViewModel == null)
                {
                    CreateTipoTelefonoViewModel();
                }

                return _TipoTelefonoViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public TipoTelefonoViewModel TipoTelefonoViewModel
        {
            get
            {
                return TipoTelefonoViewModelStatic;
            }
        }

        public static void ClearTipoTelefonoViewModel()
        {
            _TipoTelefonoViewModel.Cleanup();
            _TipoTelefonoViewModel = null;
        }

        public static void CreateTipoTelefonoViewModel()
        {
            if (_TipoTelefonoViewModel == null)
            {
                _TipoTelefonoViewModel = new TipoTelefonoViewModel();
            }
        }

        #endregion

        #region TipoTelefonoController ViewModel


        private static TipoTelefonoControllerViewModel _TipoTelefonoControllerViewModel;

        public static TipoTelefonoControllerViewModel TipoTelefonoControllerViewModelStatic
        {
            get
            {
                if (_TipoTelefonoControllerViewModel == null)
                {
                    CreateTipoTelefonoControllerViewModel();
                }

                return _TipoTelefonoControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public TipoTelefonoControllerViewModel TipoTelefonoControllerViewModel
        {
            get
            {
                return TipoTelefonoControllerViewModelStatic;
            }
        }

        public static void ClearTipoTelefonoControllerViewModel()
        {
            _TipoTelefonoControllerViewModel.Cleanup();
            _TipoTelefonoControllerViewModel = null;
        }

        public static void CreateTipoTelefonoControllerViewModel()
        {
            if (_TipoTelefonoControllerViewModel == null)
            {
                _TipoTelefonoControllerViewModel = new TipoTelefonoControllerViewModel();
            }
        }

        #endregion

        #endregion


        #region Visita

        #region Visita ViewModel


        private static VisitaViewModel _VisitaViewModel;

        public static VisitaViewModel VisitaViewModelStatic
        {
            get
            {
                if (_VisitaViewModel == null)
                {
                    CreateVisitaViewModel();
                }

                return _VisitaViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public VisitaViewModel VisitaViewModel
        {
            get
            {
                return VisitaViewModelStatic;
            }
        }

        public static void ClearVisitaViewModel()
        {
            _VisitaViewModel.Cleanup();
            _VisitaViewModel = null;
        }

        public static void CreateVisitaViewModel()
        {
            if (_VisitaViewModel == null)
            {
                _VisitaViewModel = new VisitaViewModel();
            }
        }

        #endregion

        #region VisitaController ViewModel


        private static VisitaControllerViewModel _VisitaControllerViewModel;

        public static VisitaControllerViewModel VisitaControllerViewModelStatic
        {
            get
            {
                if (_VisitaControllerViewModel == null)
                {
                    CreateVisitaControllerViewModel();
                }

                return _VisitaControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public VisitaControllerViewModel VisitaControllerViewModel
        {
            get
            {
                return VisitaControllerViewModelStatic;
            }
        }

        public static void ClearVisitaControllerViewModel()
        {
            _VisitaControllerViewModel.Cleanup();
            _VisitaControllerViewModel = null;
        }

        public static void CreateVisitaControllerViewModel()
        {
            if (_VisitaControllerViewModel == null)
            {
                _VisitaControllerViewModel = new VisitaControllerViewModel();
            }
        }

        #endregion

        #endregion

        #region Departamento

        #region Departamento

        #region Departamento ViewModel


        private static DepartamentoViewModel _DepartamentoViewModel;

        public static DepartamentoViewModel DepartamentoViewModelStatic
        {
            get
            {
                if (_DepartamentoViewModel == null)
                {
                    CreateDepartamentoViewModel();
                }

                return _DepartamentoViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public DepartamentoViewModel DepartamentoViewModel
        {
            get
            {
                return DepartamentoViewModelStatic;
            }
        }

        public static void ClearDepartamentoViewModel()
        {
            _DepartamentoViewModel.Cleanup();
            _DepartamentoViewModel = null;
        }

        public static void CreateDepartamentoViewModel()
        {
            if (_DepartamentoViewModel == null)
            {
                _DepartamentoViewModel = new DepartamentoViewModel();
            }
        }

        #endregion

        #region ClaseCuentaController ViewModel


        private static DepartamentoControllerViewModel _DepartamentoControllerViewModel;

        public static DepartamentoControllerViewModel DepartamentoControllerViewModelStatic
        {
            get
            {
                if (_DepartamentoControllerViewModel == null)
                {
                    CreateDepartamentoControllerViewModel();
                }

                return _DepartamentoControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public DepartamentoControllerViewModel DepartamentoControllerViewModel
        {
            get
            {
                return DepartamentoControllerViewModelStatic;
            }
        }

        public static void ClearDepartamentoControllerViewModel()
        {
            _DepartamentoControllerViewModel.Cleanup();
            _DepartamentoControllerViewModel = null;
        }

        public static void CreateDepartamentoControllerViewModel()
        {
            if (_DepartamentoControllerViewModel == null)
            {
                _DepartamentoControllerViewModel = new DepartamentoControllerViewModel();
            }
        }

        #endregion

        #endregion


        #endregion

        #region Municipio

        #region Municipio

        #region Municipio ViewModel


        private static MunicipioViewModel _MunicipioViewModel;

        public static MunicipioViewModel MunicipioViewModelStatic
        {
            get
            {
                if (_MunicipioViewModel == null)
                {
                    CreateMunicipioViewModel();
                }

                return _MunicipioViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public MunicipioViewModel MunicipioViewModel
        {
            get
            {
                return MunicipioViewModelStatic;
            }
        }

        public static void ClearMunicipioViewModel()
        {
            _MunicipioViewModel.Cleanup();
            _MunicipioViewModel = null;
        }

        public static void CreateMunicipioViewModel()
        {
            if (_MunicipioViewModel == null)
            {
                _MunicipioViewModel = new MunicipioViewModel();
            }
        }

        #endregion

        #region MunicipioController ViewModel


        private static MunicipioControllerViewModel _MunicipioControllerViewModel;

        public static MunicipioControllerViewModel MunicipioControllerViewModelStatic
        {
            get
            {
                if (_MunicipioControllerViewModel == null)
                {
                    CreateMunicipioControllerViewModel();
                }

                return _MunicipioControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MunicipioControllerViewModel MunicipioControllerViewModel
        {
            get
            {
                return MunicipioControllerViewModelStatic;
            }
        }

        public static void ClearMunicipioControllerViewModel()
        {
            _MunicipioControllerViewModel.Cleanup();
            _MunicipioControllerViewModel = null;
        }

        public static void CreateMunicipioControllerViewModel()
        {
            if (_MunicipioControllerViewModel == null)
            {
                _MunicipioControllerViewModel = new MunicipioControllerViewModel();
            }
        }

        #endregion

        #endregion


        #endregion


        #region Elemento

        #region Elemento

        #region Elemento ViewModel


        private static ElementoViewModel _ElementoViewModel;

        public static ElementoViewModel ElementoViewModelStatic
        {
            get
            {
                if (_ElementoViewModel == null)
                {
                    CreateElementoViewModel();
                }

                return _ElementoViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public ElementoViewModel ElementoViewModel
        {
            get
            {
                return ElementoViewModelStatic;
            }
        }

        public static void ClearElementoViewModel()
        {
            _ElementoViewModel.Cleanup();
            _ElementoViewModel = null;
        }

        public static void CreateElementoViewModel()
        {
            if (_ElementoViewModel == null)
            {
                _ElementoViewModel = new ElementoViewModel();
            }
        }

        #endregion

        #region ElementoController ViewModel


        private static ElementoControllerViewModel _ElementoControllerViewModel;

        public static ElementoControllerViewModel ElementoControllerViewModelStatic
        {
            get
            {
                if (_ElementoControllerViewModel == null)
                {
                    CreateElementoControllerViewModel();
                }

                return _ElementoControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ElementoControllerViewModel ElementoControllerViewModel
        {
            get
            {
                return ElementoControllerViewModelStatic;
            }
        }

        public static void ClearElementoControllerViewModel()
        {
            _ElementoControllerViewModel.Cleanup();
            _ElementoControllerViewModel = null;
        }

        public static void CreateElementoControllerViewModel()
        {
            if (_ElementoControllerViewModel == null)
            {
                _ElementoControllerViewModel = new ElementoControllerViewModel();
            }
        }

        #endregion

        #endregion


        #endregion


        #region Moneda

        #region Moneda

        #region Moneda ViewModel


        private static MonedaViewModel _MonedaViewModel;

        public static MonedaViewModel MonedaViewModelStatic
        {
            get
            {
                if (_MonedaViewModel == null)
                {
                    CreateMonedaViewModel();
                }

                return _MonedaViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public MonedaViewModel MonedaViewModel
        {
            get
            {
                return MonedaViewModelStatic;
            }
        }

        public static void ClearMonedaViewModel()
        {
            _MonedaViewModel.Cleanup();
            _MonedaViewModel = null;
        }

        public static void CreateMonedaViewModel()
        {
            if (_MonedaViewModel == null)
            {
                _MonedaViewModel = new MonedaViewModel();
            }
        }

        #endregion

        #region ElementoController ViewModel


        private static MonedaControllerViewModel _MonedaControllerViewModel;

        public static MonedaControllerViewModel MonedaControllerViewModelStatic
        {
            get
            {
                if (_MonedaControllerViewModel == null)
                {
                    CreateMonedaControllerViewModel();
                }

                return _MonedaControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MonedaControllerViewModel MonedaControllerViewModel
        {
            get
            {
                return MonedaControllerViewModelStatic;
            }
        }

        public static void ClearMonedaControllerViewModel()
        {
            _MonedaControllerViewModel.Cleanup();
            _MonedaControllerViewModel = null;
        }

        public static void CreateMonedaControllerViewModel()
        {
            if (_MonedaControllerViewModel == null)
            {
                _MonedaControllerViewModel = new MonedaControllerViewModel();
            }
        }

        #endregion

        #endregion


        #endregion

        #region Simbolo

        #region Simbolo

        #region Simbolo ViewModel


        private static SimboloViewModel _SimboloViewModel;

        public static SimboloViewModel SimboloViewModelStatic
        {
            get
            {
                if (_SimboloViewModel == null)
                {
                    CreateSimboloViewModel();
                }

                return _SimboloViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public SimboloViewModel SimboloViewModel
        {
            get
            {
                return SimboloViewModelStatic;
            }
        }

        public static void ClearSimboloViewModel()
        {
            _SimboloViewModel.Cleanup();
            _SimboloViewModel = null;
        }

        public static void CreateSimboloViewModel()
        {
            if (_SimboloViewModel == null)
            {
                _SimboloViewModel = new SimboloViewModel();
            }
        }

        #endregion

        #region ClaseCuentaController ViewModel


        private static SimboloControllerViewModel _SimboloControllerViewModel;

        public static SimboloControllerViewModel SimboloControllerViewModelStatic
        {
            get
            {
                if (_SimboloControllerViewModel == null)
                {
                    CreateSimboloControllerViewModel();
                }

                return _SimboloControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public SimboloControllerViewModel SimboloControllerViewModel
        {
            get
            {
                return SimboloControllerViewModelStatic;
            }
        }

        public static void ClearSimboloControllerViewModel()
        {
            _SimboloControllerViewModel.Cleanup();
            _SimboloControllerViewModel = null;
        }

        public static void CreateSimboloControllerViewModel()
        {
            if (_SimboloControllerViewModel == null)
            {
                _SimboloControllerViewModel = new SimboloControllerViewModel();
            }
        }

        #endregion

        #endregion


        #endregion

        #region TipoElementoIndice

        #region ClaseBalanceController ViewModel


        private static TipoElementoIndiceControllerViewModel _TipoElementoIndiceControllerViewModel;

        public static TipoElementoIndiceControllerViewModel TipoElementoIndiceControllerViewModelStatic
        {
            get
            {
                if (_TipoElementoIndiceControllerViewModel == null)
                {
                    CreateTipoElementoIndiceControllerViewModel();
                }

                return _TipoElementoIndiceControllerViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public TipoElementoIndiceControllerViewModel TipoElementoIndiceControllerViewModel
        {
            get
            {
                return TipoElementoIndiceControllerViewModelStatic;
            }
        }

        public static void ClearTipoElementoIndiceControllerViewModel()
        {
            _TipoElementoIndiceControllerViewModel.Cleanup();
            _TipoElementoIndiceControllerViewModel = null;
        }

        public static void CreateTipoElementoIndiceControllerViewModel()
        {
            if (_TipoElementoIndiceControllerViewModel == null)
            {
                _TipoElementoIndiceControllerViewModel = new TipoElementoIndiceControllerViewModel();
            }
        }

        #endregion


        #region TipoElementoIndiceViewModel ViewModel


        private static TipoElementoIndiceViewModel _TipoElementoIndiceViewModel;

        public static TipoElementoIndiceViewModel TipoElementoIndiceViewModelStatic
        {
            get
            {
                if (_TipoElementoIndiceViewModel == null)
                {
                    CreateTipoElementoIndiceViewModel();
                }

                return _TipoElementoIndiceViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public TipoElementoIndiceViewModel TipoElementoIndiceViewModel
        {
            get
            {
                return TipoElementoIndiceViewModelStatic;
            }
        }

        public static void ClearTipoElementoIndiceViewModel()
        {
            _TipoElementoIndiceViewModel.Cleanup();
            _TipoElementoIndiceViewModel = null;
        }

        public static void CreateTipoElementoIndiceViewModel()
        {
            if (_TipoElementoIndiceViewModel == null)
            {
                _TipoElementoIndiceViewModel = new TipoElementoIndiceViewModel();
            }
        }
        #endregion

        #endregion

        #region Firma_Configuracion
        #region Firma ViewModel


        private static tabconenedorFirmaConfiguracionViewModel _tabconenedorFirmaConfiguracionViewModel;

        public static tabconenedorFirmaConfiguracionViewModel tabconenedorFirmaConfiguracionViewModelStatic
        {
            get
            {
                if (_tabconenedorFirmaConfiguracionViewModel == null)
                {
                    CreatetabconenedorFirmaConfiguracionViewModel();
                }

                return _tabconenedorFirmaConfiguracionViewModel;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public tabconenedorFirmaConfiguracionViewModel tabconenedorFirmaConfiguracionViewModel
        {
            get
            {
                return tabconenedorFirmaConfiguracionViewModelStatic;
            }
        }

        public static void CleartabconenedorFirmaConfiguracionViewModel()
        {
            // _tabconenedorFirmaConfiguracionViewModel.Cleanup();
            _tabconenedorFirmaConfiguracionViewModel = null;
        }

        public static void CreatetabconenedorFirmaConfiguracionViewModel()
        {
            if (_tabconenedorFirmaConfiguracionViewModel == null)
            {
                _tabconenedorFirmaConfiguracionViewModel = new tabconenedorFirmaConfiguracionViewModel();
            }
        }

        #endregion
        #endregion

        */

        #region Registro
        public static void Cleanup()
        {
            ClearMain();
            ClearInicialViewModel();
            ClearLoguinViewModel();
            ClearPrincipalAlternaViewModel();
            /*ClearActividadViewModel();
            ClearActividadControllerViewModel();
            ClearClaseCuentaViewModel();
            ClearClaseCuentaControllerViewModel();
            ClearClaseBalanceViewModel();
            ClearClaseBalanceControllerViewModel();
            ClearCorrespondenciaTipoViewModel();
            ClearCorrespondenciaTipoControllerViewModel();
            ClearDocumentoViewModel();
            ClearDocumentoControllerViewModel();
            ClearLegalNormaViewModel();
            ClearLegalNormaControllerViewModel();
            ClearMaterialidadViewModel();
            ClearMaterialidadControllerViewModel();
            ClearPaisViewModel();
            ClearPaisControllerViewModel();
            ClearPeriodoViewModel();
            ClearPeriodoControllerViewModel();
            ClearProcesoAuditoriaViewModel();
            ClearProcesoAuditoriaControllerViewModel();
            ClearRolViewModel();
            ClearRolControllerViewModel();
            ClearTipoCarpetaViewModel();
            ClearTipoCarpetaControllerViewModel();
            ClearTipoConfirmacionViewModel();
            ClearTipoConfirmacionControllerViewModel();
            ClearTipoPartidaViewModel();
            ClearTipoPartidaControllerViewModel();
            ClearTipoProcedimientoViewModel();
            ClearTipoProcedimientoControllerViewModel();
            ClearTipoRespuestaCuestionarioViewModel();
            ClearTipoRespuestaCuestionarioControllerViewModel();
            ClearTipoAuditoriaViewModel();
            ClearTipoAuditoriaControllerViewModel();
            ClearTipoCedulaViewModel();
            ClearTipoCedulaControllerViewModel();
            ClearTipoDescriptorViewModel();
            ClearTipoDescriptorControllerViewModel();
            ClearTipoHerramientaViewModel();
            ClearTipoHerramientaControllerViewModel();
            ClearTipoProgramaViewModel();
            ClearTipoProgramaControllerViewModel();
            ClearTipoTelefonoViewModel();
            ClearTipoTelefonoControllerViewModel();
            ClearVisitaViewModel();
            ClearVisitaControllerViewModel();
            ClearDepartamentoViewModel();
            ClearDepartamentoControllerViewModel();
            ClearMunicipioViewModel();
            ClearMunicipioControllerViewModel();
            ClearElementoViewModel();
            ClearElementoControllerViewModel();
            ClearMonedaViewModel();
            ClearMonedaControllerViewModel();
            ClearSimboloViewModel();
            ClearSimboloControllerViewModel();
            ClearTipoElementoIndiceViewModel();
            ClearTipoElementoIndiceControllerViewModel();*/
        }

        #endregion

    }
}