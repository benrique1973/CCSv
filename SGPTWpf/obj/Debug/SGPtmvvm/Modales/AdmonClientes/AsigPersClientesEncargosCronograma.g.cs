﻿#pragma checksum "..\..\..\..\..\SGPtmvvm\Modales\AdmonClientes\AsigPersClientesEncargosCronograma.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FF65203755D4DC394C1B8B2D203DD5E2"
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
using SGPTmvvm.Modales;
using SGPTmvvm.Soporte;
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


namespace SGPTmvvm.Modales.AdmonClientes {
    
    
    /// <summary>
    /// AsigPersClientesEncargosCronograma
    /// </summary>
    public partial class AsigPersClientesEncargosCronograma : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\..\..\SGPtmvvm\Modales\AdmonClientes\AsigPersClientesEncargosCronograma.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.Modales.AdmonClientes.AsigPersClientesEncargosCronograma root;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\..\SGPtmvvm\Modales\AdmonClientes\AsigPersClientesEncargosCronograma.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MessageTextBlock;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\..\SGPtmvvm\Modales\AdmonClientes\AsigPersClientesEncargosCronograma.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBanderax;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\..\SGPtmvvm\Modales\AdmonClientes\AsigPersClientesEncargosCronograma.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbPersonal;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\..\SGPtmvvm\Modales\AdmonClientes\AsigPersClientesEncargosCronograma.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtHorasAsignadas;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\..\SGPtmvvm\Modales\AdmonClientes\AsigPersClientesEncargosCronograma.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCostoHora;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\..\..\SGPtmvvm\Modales\AdmonClientes\AsigPersClientesEncargosCronograma.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ValidacionNumeroDecimal CostoHorasValidacion1;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\..\SGPtmvvm\Modales\AdmonClientes\AsigPersClientesEncargosCronograma.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdAgregarFila;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\..\..\SGPtmvvm\Modales\AdmonClientes\AsigPersClientesEncargosCronograma.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dGPersonalz;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\..\..\SGPtmvvm\Modales\AdmonClientes\AsigPersClientesEncargosCronograma.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdGuardar;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\..\..\..\SGPtmvvm\Modales\AdmonClientes\AsigPersClientesEncargosCronograma.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdCancelar;
        
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
            System.Uri resourceLocater = new System.Uri("/SGPTWpf;component/sgptmvvm/modales/admonclientes/asigpersclientesencargoscronogr" +
                    "ama.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\SGPtmvvm\Modales\AdmonClientes\AsigPersClientesEncargosCronograma.xaml"
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
            this.root = ((SGPTmvvm.Modales.AdmonClientes.AsigPersClientesEncargosCronograma)(target));
            return;
            case 2:
            this.MessageTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.txtBanderax = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.cmbPersonal = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.txtHorasAsignadas = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtCostoHora = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.CostoHorasValidacion1 = ((SGPTmvvm.CustomValidationAttributes.ValidacionNumeroDecimal)(target));
            return;
            case 8:
            this.cmdAgregarFila = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.dGPersonalz = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 10:
            this.cmdGuardar = ((System.Windows.Controls.Button)(target));
            return;
            case 11:
            this.cmdCancelar = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
