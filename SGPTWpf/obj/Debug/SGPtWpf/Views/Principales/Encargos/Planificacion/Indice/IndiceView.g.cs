﻿#pragma checksum "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Indice\IndiceView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1672E55A99D2522C63B0DCA679DE921D"
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
using Microsoft.Expression.Interactivity.Core;
using Microsoft.Expression.Interactivity.Input;
using Microsoft.Expression.Interactivity.Layout;
using Microsoft.Expression.Interactivity.Media;
using RootLibrary.WPF.Localization;
using SGPTWpf.AttachedBehaviors;
using SGPTWpf.Helpers;
using SGPTWpf.SGPtWpf.Recursos.controles.Encargos;
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


namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Indice {
    
    
    /// <summary>
    /// IndiceView
    /// </summary>
    public partial class IndiceView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Indice\IndiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid datosConsulta;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Indice\IndiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Indice\IndiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn codidCorrelativo;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Indice\IndiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn coddescripcion;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Indice\IndiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn codindiceCarpeta;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Indice\IndiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn coditemsTotales;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Indice\IndiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn coditemsTotalesReferenciados;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Indice\IndiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn gfechacierre;
        
        #line default
        #line hidden
        
        
        #line 162 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Indice\IndiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn gfechasupervision;
        
        #line default
        #line hidden
        
        
        #line 180 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Indice\IndiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn gfechaaprobacion;
        
        #line default
        #line hidden
        
        
        #line 198 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Indice\IndiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn gusuariocerro;
        
        #line default
        #line hidden
        
        
        #line 218 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Indice\IndiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn gusuariosuperviso;
        
        #line default
        #line hidden
        
        
        #line 236 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Indice\IndiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn gusuarioaprobo;
        
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
            System.Uri resourceLocater = new System.Uri("/SGPTWpf;component/sgptwpf/views/principales/encargos/planificacion/indice/indice" +
                    "view.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Planificacion\Indice\IndiceView.xaml"
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
            this.datosConsulta = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.codidCorrelativo = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 4:
            this.coddescripcion = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 5:
            this.codindiceCarpeta = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 6:
            this.coditemsTotales = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 7:
            this.coditemsTotalesReferenciados = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 8:
            this.gfechacierre = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 9:
            this.gfechasupervision = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 10:
            this.gfechaaprobacion = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 11:
            this.gusuariocerro = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 12:
            this.gusuariosuperviso = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 13:
            this.gusuarioaprobo = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
