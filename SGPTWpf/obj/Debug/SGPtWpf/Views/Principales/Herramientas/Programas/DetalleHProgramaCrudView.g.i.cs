﻿#pragma checksum "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\DetalleHProgramaCrudView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "261CF57FA0611D6712DDC8F79A8694B8"
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


namespace SGPTWpf.SGPtWpf.Views.Principales.Herramientas.Programas {
    
    
    /// <summary>
    /// DetalleHProgramaCrudView
    /// </summary>
    public partial class DetalleHProgramaCrudView : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\DetalleHProgramaCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblEncabezado;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\DetalleHProgramaCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel datosEntidad;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\DetalleHProgramaCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdDatosEntidad;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\DetalleHProgramaCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdDatosCuerpo;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\DetalleHProgramaCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtdescripcionDh;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\DetalleHProgramaCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spElecciones;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\DetalleHProgramaCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid datosEntidadNumericos;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\DetalleHProgramaCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox seleccionTipoProcedimiento;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\DetalleHProgramaCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbidVisitaDh;
        
        #line default
        #line hidden
        
        
        #line 258 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\DetalleHProgramaCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdtipoProcedimiento;
        
        #line default
        #line hidden
        
        
        #line 269 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\DetalleHProgramaCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox seleccionDependencia;
        
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
            System.Uri resourceLocater = new System.Uri("/SGPTWpf;component/sgptwpf/views/principales/herramientas/programas/detallehprogr" +
                    "amacrudview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\DetalleHProgramaCrudView.xaml"
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
            this.lblEncabezado = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.datosEntidad = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.GrdDatosEntidad = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.GrdDatosCuerpo = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.txtdescripcionDh = ((System.Windows.Controls.TextBox)(target));
            
            #line 67 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\DetalleHProgramaCrudView.xaml"
            this.txtdescripcionDh.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            case 6:
            this.spElecciones = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.datosEntidadNumericos = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.seleccionTipoProcedimiento = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.cbidVisitaDh = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            
            #line 208 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\DetalleHProgramaCrudView.xaml"
            ((MahApps.Metro.Controls.NumericUpDown)(target)).AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            case 11:
            this.grdtipoProcedimiento = ((System.Windows.Controls.Grid)(target));
            return;
            case 12:
            this.seleccionDependencia = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

