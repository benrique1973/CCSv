﻿#pragma checksum "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Cedulas\Sumarias\ReferenciarView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E18DC189F0F427B5B3E4D03F34E88198"
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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using RootLibrary.WPF.Localization;
using SGPTWpf.Helpers;
using SGPTWpf.Recursos.controles;
using SGPTWpf.Recursos.controles.Herramientas;
using SGPTWpf.SGPtWpf.Recursos.controles.Encargos;
using SGPTWpf.SGPtWpf.Support.Validaciones.Reglas;
using SGPTWpf.Support.Conversores;
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


namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Sumarias {
    
    
    /// <summary>
    /// ReferenciarView
    /// </summary>
    public partial class ReferenciarView : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Cedulas\Sumarias\ReferenciarView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel GrdDatosCuerpo;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Cedulas\Sumarias\ReferenciarView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel encabezadoCrud;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Cedulas\Sumarias\ReferenciarView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtReferencia;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Cedulas\Sumarias\ReferenciarView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ejecucionCrud;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Cedulas\Sumarias\ReferenciarView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpkfechacierre;
        
        #line default
        #line hidden
        
        
        #line 193 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Cedulas\Sumarias\ReferenciarView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel skfechasupervision;
        
        #line default
        #line hidden
        
        
        #line 208 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Cedulas\Sumarias\ReferenciarView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpkfechasupervision;
        
        #line default
        #line hidden
        
        
        #line 248 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Cedulas\Sumarias\ReferenciarView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel skfechaaprobacion;
        
        #line default
        #line hidden
        
        
        #line 263 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Cedulas\Sumarias\ReferenciarView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpkfechaaprobacion;
        
        #line default
        #line hidden
        
        
        #line 305 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Cedulas\Sumarias\ReferenciarView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid botones;
        
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
            System.Uri resourceLocater = new System.Uri("/SGPTWpf;component/sgptwpf/views/principales/encargos/cedulas/sumarias/referencia" +
                    "rview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Cedulas\Sumarias\ReferenciarView.xaml"
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
            this.GrdDatosCuerpo = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.encabezadoCrud = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.txtReferencia = ((System.Windows.Controls.TextBox)(target));
            
            #line 75 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Cedulas\Sumarias\ReferenciarView.xaml"
            this.txtReferencia.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            case 4:
            this.ejecucionCrud = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.dpkfechacierre = ((System.Windows.Controls.DatePicker)(target));
            
            #line 133 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Cedulas\Sumarias\ReferenciarView.xaml"
            this.dpkfechacierre.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            case 6:
            this.skfechasupervision = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.dpkfechasupervision = ((System.Windows.Controls.DatePicker)(target));
            
            #line 222 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Cedulas\Sumarias\ReferenciarView.xaml"
            this.dpkfechasupervision.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            case 8:
            this.skfechaaprobacion = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 9:
            this.dpkfechaaprobacion = ((System.Windows.Controls.DatePicker)(target));
            
            #line 277 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Cedulas\Sumarias\ReferenciarView.xaml"
            this.dpkfechaaprobacion.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            case 10:
            this.botones = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
