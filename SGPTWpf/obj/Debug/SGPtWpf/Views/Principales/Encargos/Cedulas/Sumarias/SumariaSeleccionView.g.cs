﻿#pragma checksum "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Cedulas\Sumarias\SumariaSeleccionView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5802408535A5E3030A33367BFE90A5C1"
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


namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Sumarias {
    
    
    /// <summary>
    /// SumariaSeleccionView
    /// </summary>
    public partial class SumariaSeleccionView : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Cedulas\Sumarias\SumariaSeleccionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel GrdDatosCuerpo;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Cedulas\Sumarias\SumariaSeleccionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdVisita;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Cedulas\Sumarias\SumariaSeleccionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboVisita;
        
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
            System.Uri resourceLocater = new System.Uri("/SGPTWpf;component/sgptwpf/views/principales/encargos/cedulas/sumarias/sumariasel" +
                    "eccionview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Cedulas\Sumarias\SumariaSeleccionView.xaml"
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
            this.GrdVisita = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.comboVisita = ((System.Windows.Controls.ComboBox)(target));
            
            #line 84 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Cedulas\Sumarias\SumariaSeleccionView.xaml"
            this.comboVisita.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
