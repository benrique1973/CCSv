using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using SGPTWpf.Views.Compartidas;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Cuestionarios
{
    /// <summary>
    /// Lógica de interacción para DetalleCuestionarioView.xaml
    /// </summary>
    public partial class DetalleCuestionarioView : UserControl
    {
        public delegate Point GetPosition(IInputElement element);
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

        public DetalleCuestionarioView()
        {
            InitializeComponent();
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

            dataGrid.Height = datosConsulta.Height - 1-gridObjetivos.Height-gridObjetivos2.Height-gridAlcances.Height-gridAlcances2.Height;
            dataGrid.MaxHeight = datosConsulta.MaxHeight - 1;
            dataGrid.MinHeight = datosConsulta.MinHeight - 1;

            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
            //dgContenidoProcedimiento.MaxHeight = largo*0.80 - gridAlcances.Height - gridAlcances2.Height - gridObjetivos.Height - gridObjetivos2.Height;
            //dataGrid.MaxHeight = largo * 0.65;

        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) CuestionarioControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) CuestionarioControllerViewModel.Errors -= 1;
        }


    }
}
