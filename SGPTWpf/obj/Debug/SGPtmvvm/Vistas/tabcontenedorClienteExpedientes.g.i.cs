﻿#pragma checksum "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D47529D6A57EFEAB6C19E6C1AE220FA1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using GalaSoft.MvvmLight.Command;
using MahApps.Metro.Behaviours;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using RootLibrary.WPF.Localization;
using SGPTWpf.Helpers;
using SGPTmvvm.CustomValidationAttributes;
using SGPTmvvm.ViewModel;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SGPTmvvm.Vistas {
    
    
    /// <summary>
    /// tabcontenedorClienteExpedientes
    /// </summary>
    public partial class tabcontenedorClienteExpedientes : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 117 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Fondo;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBandera;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBanderaNuevo;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBanderaEditar;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBanderaConsultar;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBanderaEliminar;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBanderaAgregar;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBanderaCancelar;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBanderaRegresar;
        
        #line default
        #line hidden
        
        
        #line 550 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridClientes;
        
        #line default
        #line hidden
        
        
        #line 558 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn IDCli;
        
        #line default
        #line hidden
        
        
        #line 559 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn CliRazonSocial;
        
        #line default
        #line hidden
        
        
        #line 636 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MessageTextBlock;
        
        #line default
        #line hidden
        
        
        #line 651 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRazonSocial;
        
        #line default
        #line hidden
        
        
        #line 654 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.TextBoxNoVacioValidationRule PrimerNombreValidation;
        
        #line default
        #line hidden
        
        
        #line 655 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ExcluirChar PrimerNombreValidation2;
        
        #line default
        #line hidden
        
        
        #line 656 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue PrimerNombrevalidation4;
        
        #line default
        #line hidden
        
        
        #line 660 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDireccion;
        
        #line default
        #line hidden
        
        
        #line 664 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.TextBoxNoVacioValidationRule DireccionValidation;
        
        #line default
        #line hidden
        
        
        #line 665 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue Direccionpersonavalidation4;
        
        #line default
        #line hidden
        
        
        #line 666 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ExcluirChar DireccionpersonaValidacion1;
        
        #line default
        #line hidden
        
        
        #line 671 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpickFechaCVPA;
        
        #line default
        #line hidden
        
        
        #line 675 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbTipoEntidad;
        
        #line default
        #line hidden
        
        
        #line 684 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbPaises;
        
        #line default
        #line hidden
        
        
        #line 690 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbDepartamentos;
        
        #line default
        #line hidden
        
        
        #line 703 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbActividadEc;
        
        #line default
        #line hidden
        
        
        #line 709 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtActividad;
        
        #line default
        #line hidden
        
        
        #line 713 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ExcluirChar PaginaWebValidacion1;
        
        #line default
        #line hidden
        
        
        #line 714 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue ActividadClValidation4;
        
        #line default
        #line hidden
        
        
        #line 719 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNIT;
        
        #line default
        #line hidden
        
        
        #line 723 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.TextBoxNoVacioValidationRule NitClienteValidation;
        
        #line default
        #line hidden
        
        
        #line 724 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ValidacionNIT NitClienteValidation3;
        
        #line default
        #line hidden
        
        
        #line 725 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue Nitpersonavalidation4;
        
        #line default
        #line hidden
        
        
        #line 730 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNRC;
        
        #line default
        #line hidden
        
        
        #line 734 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.TextBoxNoVacioValidationRule NRCValidation;
        
        #line default
        #line hidden
        
        
        #line 735 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ExcluirChar NumNRCValidacion2;
        
        #line default
        #line hidden
        
        
        #line 736 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue NumeroNRCvalidation4;
        
        #line default
        #line hidden
        
        
        #line 741 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPaginaWeb;
        
        #line default
        #line hidden
        
        
        #line 745 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue PaginaWebvalidation4;
        
        #line default
        #line hidden
        
        
        #line 757 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel GridTelefonos;
        
        #line default
        #line hidden
        
        
        #line 760 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTelef;
        
        #line default
        #line hidden
        
        
        #line 764 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue Telefonovalidation4;
        
        #line default
        #line hidden
        
        
        #line 765 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ValidacionTelefono Telefonovalidation2;
        
        #line default
        #line hidden
        
        
        #line 766 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.TextBoxNoVacioValidationRule TelefonoValidacion1;
        
        #line default
        #line hidden
        
        
        #line 771 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbTipoTelefonos;
        
        #line default
        #line hidden
        
        
        #line 777 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdAgreTelef;
        
        #line default
        #line hidden
        
        
        #line 814 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbTelefonos;
        
        #line default
        #line hidden
        
        
        #line 857 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.UniformGrid GridCorreos;
        
        #line default
        #line hidden
        
        
        #line 860 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCorreo;
        
        #line default
        #line hidden
        
        
        #line 865 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue Correovalidation4;
        
        #line default
        #line hidden
        
        
        #line 866 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ValidacionEmail Correovalidation3;
        
        #line default
        #line hidden
        
        
        #line 867 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.TextBoxNoVacioValidationRule correovalidation2;
        
        #line default
        #line hidden
        
        
        #line 916 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdAgreCorreos;
        
        #line default
        #line hidden
        
        
        #line 956 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstCorreos;
        
        #line default
        #line hidden
        
        
        #line 960 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdQuitCorreos;
        
        #line default
        #line hidden
        
        
        #line 1230 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dGContactosz;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SGPTWpf;component/sgptmvvm/vistas/tabcontenedorclienteexpedientes.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\SGPtmvvm\Vistas\tabcontenedorClienteExpedientes.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Fondo = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.txtBandera = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtBanderaNuevo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtBanderaEditar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtBanderaConsultar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtBanderaEliminar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtBanderaAgregar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txtBanderaCancelar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.txtBanderaRegresar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.dataGridClientes = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 11:
            this.IDCli = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 12:
            this.CliRazonSocial = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 13:
            this.MessageTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 14:
            this.txtRazonSocial = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            this.PrimerNombreValidation = ((SGPTmvvm.CustomValidationAttributes.TextBoxNoVacioValidationRule)(target));
            return;
            case 16:
            this.PrimerNombreValidation2 = ((SGPTmvvm.CustomValidationAttributes.ExcluirChar)(target));
            return;
            case 17:
            this.PrimerNombrevalidation4 = ((SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue)(target));
            return;
            case 18:
            this.txtDireccion = ((System.Windows.Controls.TextBox)(target));
            return;
            case 19:
            this.DireccionValidation = ((SGPTmvvm.CustomValidationAttributes.TextBoxNoVacioValidationRule)(target));
            return;
            case 20:
            this.Direccionpersonavalidation4 = ((SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue)(target));
            return;
            case 21:
            this.DireccionpersonaValidacion1 = ((SGPTmvvm.CustomValidationAttributes.ExcluirChar)(target));
            return;
            case 22:
            this.dpickFechaCVPA = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 23:
            this.cmbTipoEntidad = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 24:
            this.cmbPaises = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 25:
            this.cmbDepartamentos = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 26:
            this.cmbActividadEc = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 27:
            this.txtActividad = ((System.Windows.Controls.TextBox)(target));
            return;
            case 28:
            this.PaginaWebValidacion1 = ((SGPTmvvm.CustomValidationAttributes.ExcluirChar)(target));
            return;
            case 29:
            this.ActividadClValidation4 = ((SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue)(target));
            return;
            case 30:
            this.txtNIT = ((System.Windows.Controls.TextBox)(target));
            return;
            case 31:
            this.NitClienteValidation = ((SGPTmvvm.CustomValidationAttributes.TextBoxNoVacioValidationRule)(target));
            return;
            case 32:
            this.NitClienteValidation3 = ((SGPTmvvm.CustomValidationAttributes.ValidacionNIT)(target));
            return;
            case 33:
            this.Nitpersonavalidation4 = ((SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue)(target));
            return;
            case 34:
            this.txtNRC = ((System.Windows.Controls.TextBox)(target));
            return;
            case 35:
            this.NRCValidation = ((SGPTmvvm.CustomValidationAttributes.TextBoxNoVacioValidationRule)(target));
            return;
            case 36:
            this.NumNRCValidacion2 = ((SGPTmvvm.CustomValidationAttributes.ExcluirChar)(target));
            return;
            case 37:
            this.NumeroNRCvalidation4 = ((SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue)(target));
            return;
            case 38:
            this.txtPaginaWeb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 39:
            this.PaginaWebvalidation4 = ((SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue)(target));
            return;
            case 40:
            this.GridTelefonos = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 41:
            this.txtTelef = ((System.Windows.Controls.TextBox)(target));
            return;
            case 42:
            this.Telefonovalidation4 = ((SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue)(target));
            return;
            case 43:
            this.Telefonovalidation2 = ((SGPTmvvm.CustomValidationAttributes.ValidacionTelefono)(target));
            return;
            case 44:
            this.TelefonoValidacion1 = ((SGPTmvvm.CustomValidationAttributes.TextBoxNoVacioValidationRule)(target));
            return;
            case 45:
            this.cmbTipoTelefonos = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 46:
            this.cmdAgreTelef = ((System.Windows.Controls.Button)(target));
            return;
            case 47:
            this.cmbTelefonos = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 48:
            this.GridCorreos = ((System.Windows.Controls.Primitives.UniformGrid)(target));
            return;
            case 49:
            this.txtCorreo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 50:
            this.Correovalidation4 = ((SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue)(target));
            return;
            case 51:
            this.Correovalidation3 = ((SGPTmvvm.CustomValidationAttributes.ValidacionEmail)(target));
            return;
            case 52:
            this.correovalidation2 = ((SGPTmvvm.CustomValidationAttributes.TextBoxNoVacioValidationRule)(target));
            return;
            case 53:
            this.cmdAgreCorreos = ((System.Windows.Controls.Button)(target));
            return;
            case 54:
            this.lstCorreos = ((System.Windows.Controls.ListBox)(target));
            return;
            case 55:
            this.cmdQuitCorreos = ((System.Windows.Controls.Button)(target));
            return;
            case 56:
            this.dGContactosz = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

