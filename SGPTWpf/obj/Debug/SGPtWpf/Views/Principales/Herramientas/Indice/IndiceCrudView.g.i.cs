﻿#pragma checksum "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Indice\IndiceCrudView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "ADC6AA9AC4F7E4E8B2A909E88BFD216F"
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
using SGPTWpf.AttachedBehaviors;
using SGPTWpf.Helpers;
using SGPTWpf.Recursos.controles.Administracion.Crud;
using SGPTWpf.Support.Conversores;
using SGPTWpf.Views.Principales.Administracion;
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


namespace SGPTWpf.Views.Administracion.Herramientas {
    
    
    /// <summary>
    /// IndiceCrudView
    /// </summary>
    public partial class IndiceCrudView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Indice\IndiceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Principal;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Indice\IndiceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridMenu;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Indice\IndiceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txttipoAuditoriaModelo;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Indice\IndiceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtnickUsuarioUsuario;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Indice\IndiceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNombreIndice;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Indice\IndiceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridMenuLateral;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Indice\IndiceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridMenuIndice;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Indice\IndiceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn indicesMenu;
        
        #line default
        #line hidden
        
        
        #line 175 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Indice\IndiceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gtiDatos;
        
        #line default
        #line hidden
        
        
        #line 176 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Indice\IndiceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame EditFrame;
        
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
            System.Uri resourceLocater = new System.Uri("/SGPTWpf;component/sgptwpf/views/principales/herramientas/indice/indicecrudview.x" +
                    "aml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Indice\IndiceCrudView.xaml"
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
            this.Principal = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.gridMenu = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.txttipoAuditoriaModelo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtnickUsuarioUsuario = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtNombreIndice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.gridMenuLateral = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.dataGridMenuIndice = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.indicesMenu = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 9:
            this.gtiDatos = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            this.EditFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

