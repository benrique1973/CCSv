﻿#pragma checksum "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Normativa\NormativaCrudView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FFF475F3CBCE207BF0FFACB5B2E19ACA"
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
using SGPTWpf.Recursos.controles.Administracion;
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
    /// NormativaCrudView
    /// </summary>
    public partial class NormativaCrudView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 22 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Normativa\NormativaCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Principal;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Normativa\NormativaCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridMenu;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Normativa\NormativaCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView dataGrid;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Normativa\NormativaCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridMenuLateral;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Normativa\NormativaCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridMenuNorma;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Normativa\NormativaCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn contenidoMenuNorma;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Normativa\NormativaCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gtiDatosNorma;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Normativa\NormativaCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame EditFrameNorma;
        
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
            System.Uri resourceLocater = new System.Uri("/SGPTWpf;component/sgptwpf/views/principales/herramientas/normativa/normativacrud" +
                    "view.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Normativa\NormativaCrudView.xaml"
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
            this.Principal = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.gridMenu = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.dataGrid = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.gridMenuLateral = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.dataGridMenuNorma = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.contenidoMenuNorma = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 8:
            this.gtiDatosNorma = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.EditFrameNorma = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 4:
            
            #line 63 "..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Herramientas\Normativa\NormativaCrudView.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.RadioButton_Checked);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

