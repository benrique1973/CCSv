﻿#pragma checksum "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Cuestionario\CuestionarioCrearView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7DC8289738A4AF53288B002C484B99AC"
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


namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Cuestionario {
    
    
    /// <summary>
    /// CuestionarioCrearView
    /// </summary>
    public partial class CuestionarioCrearView : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Cuestionario\CuestionarioCrearView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel GrdDatosCuerpo;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Cuestionario\CuestionarioCrearView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel encabezadoCrud;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Cuestionario\CuestionarioCrearView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel seleccionCrud;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Cuestionario\CuestionarioCrearView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox seleccionComboPrograma;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Cuestionario\CuestionarioCrearView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel cuerpoCrud;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Cuestionario\CuestionarioCrearView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdDatos;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Cuestionario\CuestionarioCrearView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNombreHerramienta;
        
        #line default
        #line hidden
        
        
        #line 194 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Cuestionario\CuestionarioCrearView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel objetivoCrud;
        
        #line default
        #line hidden
        
        
        #line 206 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Cuestionario\CuestionarioCrearView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdObjetivo;
        
        #line default
        #line hidden
        
        
        #line 212 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Cuestionario\CuestionarioCrearView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtObjetivoDetalleHerramienta;
        
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
            System.Uri resourceLocater = new System.Uri("/SGPTWpf;component/sgptwpf/views/principales/encargos/planificacion/cuestionario/" +
                    "cuestionariocrearview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Cuestionario\CuestionarioCrearView.xaml"
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
            this.seleccionCrud = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.seleccionComboPrograma = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            
            #line 125 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Cuestionario\CuestionarioCrearView.xaml"
            ((MahApps.Metro.Controls.NumericUpDown)(target)).AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            case 6:
            this.cuerpoCrud = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.GrdDatos = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.txtNombreHerramienta = ((System.Windows.Controls.TextBox)(target));
            
            #line 162 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Cuestionario\CuestionarioCrearView.xaml"
            this.txtNombreHerramienta.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            case 9:
            this.objetivoCrud = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 10:
            this.GrdObjetivo = ((System.Windows.Controls.Grid)(target));
            return;
            case 11:
            this.txtObjetivoDetalleHerramienta = ((System.Windows.Controls.TextBox)(target));
            
            #line 211 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Cuestionario\CuestionarioCrearView.xaml"
            this.txtObjetivoDetalleHerramienta.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

