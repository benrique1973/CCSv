﻿#pragma checksum "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Gestion\GestionEncargos.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E36F770ED4C733D36C655B88E980BF82"
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
using SGPTWpf.Recursos.controles.Administracion;
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


namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Gestion {
    
    
    /// <summary>
    /// GestionEncargos
    /// </summary>
    public partial class GestionEncargos : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Gestion\GestionEncargos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridMenu;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Gestion\GestionEncargos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn contenidoMenu;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Gestion\GestionEncargos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gtiDatos;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Gestion\GestionEncargos.xaml"
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
            System.Uri resourceLocater = new System.Uri("/SGPTWpf;component/sgptwpf/views/principales/encargos/gestion/gestionencargos.xam" +
                    "l", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Gestion\GestionEncargos.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            this.dataGridMenu = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.contenidoMenu = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 3:
            this.gtiDatos = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.EditFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

