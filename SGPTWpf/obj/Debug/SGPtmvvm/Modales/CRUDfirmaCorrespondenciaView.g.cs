﻿#pragma checksum "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "09AB60006C361DCE0965B3A33370C7BC"
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


namespace SGPTmvvm.Modales {
    
    
    /// <summary>
    /// CRUDfirmaCorrespondenciaView
    /// </summary>
    public partial class CRUDfirmaCorrespondenciaView : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.Modales.CRUDfirmaCorrespondenciaView root;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MessageTextBlock;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBanderax;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbClienteCorrespondencia;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNumeroCorrespondencia;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.TextBoxNoVacioValidationRule numerocorrexValidation;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ExcluirChar Respuestapistausuariovalidation2;
        
        #line default
        #line hidden
        
        
        #line 171 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue numercorrexvalidation4;
        
        #line default
        #line hidden
        
        
        #line 178 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAsuntoCorrespondencia;
        
        #line default
        #line hidden
        
        
        #line 182 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.TextBoxNoVacioValidationRule AsuntoCartaxValidation;
        
        #line default
        #line hidden
        
        
        #line 183 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ExcluirChar AsuntoCartaValidation2;
        
        #line default
        #line hidden
        
        
        #line 184 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue AsuntoCartaxvalidation4;
        
        #line default
        #line hidden
        
        
        #line 188 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbUsuarioRecibe;
        
        #line default
        #line hidden
        
        
        #line 193 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbClienteEmite;
        
        #line default
        #line hidden
        
        
        #line 198 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdNuevoContacto;
        
        #line default
        #line hidden
        
        
        #line 201 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbTipoCorrespondencia;
        
        #line default
        #line hidden
        
        
        #line 206 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpickFechaRecepcion;
        
        #line default
        #line hidden
        
        
        #line 212 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtComentario;
        
        #line default
        #line hidden
        
        
        #line 216 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.TextBoxNoVacioValidationRule TareaxValidation;
        
        #line default
        #line hidden
        
        
        #line 217 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ExcluirChar TareaxValidation2;
        
        #line default
        #line hidden
        
        
        #line 218 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue tareaxvalidation4;
        
        #line default
        #line hidden
        
        
        #line 227 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdCargarPDF;
        
        #line default
        #line hidden
        
        
        #line 234 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdGuardar;
        
        #line default
        #line hidden
        
        
        #line 257 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
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
            System.Uri resourceLocater = new System.Uri("/SGPTWpf;component/sgptmvvm/modales/crudfirmacorrespondenciaview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\SGPtmvvm\Modales\CRUDfirmaCorrespondenciaView.xaml"
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
            this.root = ((SGPTmvvm.Modales.CRUDfirmaCorrespondenciaView)(target));
            return;
            case 2:
            this.MessageTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.txtBanderax = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.cmbClienteCorrespondencia = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.txtNumeroCorrespondencia = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.numerocorrexValidation = ((SGPTmvvm.CustomValidationAttributes.TextBoxNoVacioValidationRule)(target));
            return;
            case 7:
            this.Respuestapistausuariovalidation2 = ((SGPTmvvm.CustomValidationAttributes.ExcluirChar)(target));
            return;
            case 8:
            this.numercorrexvalidation4 = ((SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue)(target));
            return;
            case 9:
            this.txtAsuntoCorrespondencia = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.AsuntoCartaxValidation = ((SGPTmvvm.CustomValidationAttributes.TextBoxNoVacioValidationRule)(target));
            return;
            case 11:
            this.AsuntoCartaValidation2 = ((SGPTmvvm.CustomValidationAttributes.ExcluirChar)(target));
            return;
            case 12:
            this.AsuntoCartaxvalidation4 = ((SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue)(target));
            return;
            case 13:
            this.cmbUsuarioRecibe = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 14:
            this.cmbClienteEmite = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 15:
            this.cmdNuevoContacto = ((System.Windows.Controls.Button)(target));
            return;
            case 16:
            this.cmbTipoCorrespondencia = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 17:
            this.dpickFechaRecepcion = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 18:
            this.txtComentario = ((System.Windows.Controls.TextBox)(target));
            return;
            case 19:
            this.TareaxValidation = ((SGPTmvvm.CustomValidationAttributes.TextBoxNoVacioValidationRule)(target));
            return;
            case 20:
            this.TareaxValidation2 = ((SGPTmvvm.CustomValidationAttributes.ExcluirChar)(target));
            return;
            case 21:
            this.tareaxvalidation4 = ((SGPTmvvm.CustomValidationAttributes.ValidacionMenorQue)(target));
            return;
            case 22:
            this.cmdCargarPDF = ((System.Windows.Controls.Button)(target));
            return;
            case 23:
            this.cmdGuardar = ((System.Windows.Controls.Button)(target));
            return;
            case 24:
            this.cmdCancelar = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

