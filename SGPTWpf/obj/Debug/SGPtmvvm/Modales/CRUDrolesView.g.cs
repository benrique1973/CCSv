﻿#pragma checksum "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "04627403388F00891D8262345382FB07"
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


namespace SGPTmvvm.Modales {
    
    
    /// <summary>
    /// CRUDRolesView
    /// </summary>
    public partial class CRUDRolesView : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.Modales.CRUDRolesView root;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MessageTextBlock;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNombreRol;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.TextBoxNoVacioValidationRule NombreRolValidacion1;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ExcluirChar NombreRolValidacion2;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue NombreRolvalidacion3;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescripcionRol;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.TextBoxNoVacioValidationRule DescripcionRolValidation;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ExcluirChar DescripcionRolValidation2;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue DescripcionRolvalidation4;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbRolesSistema;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dGRoles;
        
        #line default
        #line hidden
        
        
        #line 154 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridCheckBoxColumn puedeCrear;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridCheckBoxColumn puedeEliminar;
        
        #line default
        #line hidden
        
        
        #line 162 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridCheckBoxColumn puedeConsultar;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridCheckBoxColumn puedeEditar;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridCheckBoxColumn puedeImprimir;
        
        #line default
        #line hidden
        
        
        #line 174 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridCheckBoxColumn puedeExportar;
        
        #line default
        #line hidden
        
        
        #line 178 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridCheckBoxColumn puedeRevisar;
        
        #line default
        #line hidden
        
        
        #line 182 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridCheckBoxColumn puedeAprobar;
        
        #line default
        #line hidden
        
        
        #line 248 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdGuardar;
        
        #line default
        #line hidden
        
        
        #line 269 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdRestablecerRol;
        
        #line default
        #line hidden
        
        
        #line 270 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdCancelarRolx;
        
        #line default
        #line hidden
        
        
        #line 303 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ProgressTextBlock;
        
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
            System.Uri resourceLocater = new System.Uri("/SGPTWpf;component/sgptmvvm/modales/crudrolesview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\SGPtmvvm\Modales\CRUDrolesView.xaml"
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
            this.root = ((SGPTmvvm.Modales.CRUDRolesView)(target));
            return;
            case 2:
            this.MessageTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.txtNombreRol = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.NombreRolValidacion1 = ((SGPTmvvm.CustomValidationAttributes.TextBoxNoVacioValidationRule)(target));
            return;
            case 5:
            this.NombreRolValidacion2 = ((SGPTmvvm.CustomValidationAttributes.ExcluirChar)(target));
            return;
            case 6:
            this.NombreRolvalidacion3 = ((SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue)(target));
            return;
            case 7:
            this.txtDescripcionRol = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.DescripcionRolValidation = ((SGPTmvvm.CustomValidationAttributes.TextBoxNoVacioValidationRule)(target));
            return;
            case 9:
            this.DescripcionRolValidation2 = ((SGPTmvvm.CustomValidationAttributes.ExcluirChar)(target));
            return;
            case 10:
            this.DescripcionRolvalidation4 = ((SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue)(target));
            return;
            case 11:
            this.cmbRolesSistema = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 12:
            this.dGRoles = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 13:
            this.puedeCrear = ((System.Windows.Controls.DataGridCheckBoxColumn)(target));
            return;
            case 14:
            this.puedeEliminar = ((System.Windows.Controls.DataGridCheckBoxColumn)(target));
            return;
            case 15:
            this.puedeConsultar = ((System.Windows.Controls.DataGridCheckBoxColumn)(target));
            return;
            case 16:
            this.puedeEditar = ((System.Windows.Controls.DataGridCheckBoxColumn)(target));
            return;
            case 17:
            this.puedeImprimir = ((System.Windows.Controls.DataGridCheckBoxColumn)(target));
            return;
            case 18:
            this.puedeExportar = ((System.Windows.Controls.DataGridCheckBoxColumn)(target));
            return;
            case 19:
            this.puedeRevisar = ((System.Windows.Controls.DataGridCheckBoxColumn)(target));
            return;
            case 20:
            this.puedeAprobar = ((System.Windows.Controls.DataGridCheckBoxColumn)(target));
            return;
            case 21:
            this.cmdGuardar = ((System.Windows.Controls.Button)(target));
            return;
            case 22:
            this.cmdRestablecerRol = ((System.Windows.Controls.Button)(target));
            return;
            case 23:
            this.cmdCancelarRolx = ((System.Windows.Controls.Button)(target));
            return;
            case 24:
            this.ProgressTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
