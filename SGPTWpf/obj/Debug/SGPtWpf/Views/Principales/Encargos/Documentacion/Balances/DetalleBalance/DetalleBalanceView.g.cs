﻿#pragma checksum "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B36D9A7D3FF8069F95BB33DA174349BC"
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


namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Balances.DetalleBalance {
    
    
    /// <summary>
    /// DetalleBalanceView
    /// </summary>
    public partial class DetalleBalanceView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdDatosCuerpo;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdDatosElemento;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdDatosClaseCuenta2;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdDatosTipoSaldo;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpkfechabalance;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid datosConsulta;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 201 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn codCuentaContable;
        
        #line default
        #line hidden
        
        
        #line 220 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn codcodigoccdb;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn codigoCuentaCatalogo;
        
        #line default
        #line hidden
        
        
        #line 258 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn codtiposaldo;
        
        #line default
        #line hidden
        
        
        #line 267 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn codsaldoanteriordb;
        
        #line default
        #line hidden
        
        
        #line 285 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn codcargodb;
        
        #line default
        #line hidden
        
        
        #line 302 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn codabonodb;
        
        #line default
        #line hidden
        
        
        #line 319 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn codsaldofinaldb;
        
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
            System.Uri resourceLocater = new System.Uri("/SGPTWpf;component/sgptwpf/views/principales/encargos/documentacion/balances/deta" +
                    "llebalance/detallebalanceview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceView.xaml"
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
            this.GrdDatosCuerpo = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.GrdDatosElemento = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.GrdDatosClaseCuenta2 = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.GrdDatosTipoSaldo = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.dpkfechabalance = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.datosConsulta = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.codCuentaContable = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 9:
            this.codcodigoccdb = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 10:
            this.codigoCuentaCatalogo = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 11:
            this.codtiposaldo = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 12:
            this.codsaldoanteriordb = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 13:
            this.codcargodb = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 14:
            this.codabonodb = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 15:
            this.codsaldofinaldb = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
