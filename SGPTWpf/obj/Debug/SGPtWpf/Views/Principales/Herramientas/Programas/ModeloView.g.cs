﻿#pragma checksum "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\ModeloView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "947A054839CCE26320831DDE35B449BC"
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
using SGPTWpf.Recursos.controles.Administracion.Crud;
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


namespace SGPTWpf.Views.Principales.Herramientas.Programas {
    
    
    /// <summary>
    /// ModeloView
    /// </summary>
    public partial class ModeloView : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\ModeloView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSalir;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\ModeloView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgFirma;
        
        #line default
        #line hidden
        
        
        #line 317 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\ModeloView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgContenidoProcedimiento;
        
        #line default
        #line hidden
        
        
        #line 336 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\ModeloView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn datosOrden;
        
        #line default
        #line hidden
        
        
        #line 343 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\ModeloView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn procecimiento;
        
        #line default
        #line hidden
        
        
        #line 365 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\ModeloView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn datosTiempo;
        
        #line default
        #line hidden
        
        
        #line 374 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\ModeloView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn datosDependencia;
        
        #line default
        #line hidden
        
        
        #line 384 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\ModeloView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn datosVisita;
        
        #line default
        #line hidden
        
        
        #line 393 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\ModeloView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn datosHecho;
        
        #line default
        #line hidden
        
        
        #line 400 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\ModeloView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn datosPt;
        
        #line default
        #line hidden
        
        
        #line 407 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\ModeloView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn comentario;
        
        #line default
        #line hidden
        
        
        #line 428 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\ModeloView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn datosEstado;
        
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
            System.Uri resourceLocater = new System.Uri("/SGPTWpf;component/sgptwpf/views/principales/herramientas/programas/modeloview.xa" +
                    "ml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Programas\ModeloView.xaml"
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
            this.btnSalir = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.imgFirma = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.dgContenidoProcedimiento = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.datosOrden = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 5:
            this.procecimiento = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 6:
            this.datosTiempo = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 7:
            this.datosDependencia = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 8:
            this.datosVisita = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 9:
            this.datosHecho = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 10:
            this.datosPt = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 11:
            this.comentario = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 12:
            this.datosEstado = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

