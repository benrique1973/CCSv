﻿#pragma checksum "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3CD08D7D0FE453E9801296061B6D3EFA"
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


namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Balances.DetalleBalance {
    
    
    /// <summary>
    /// DetalleBalanceCrudView
    /// </summary>
    public partial class DetalleBalanceCrudView : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdDatosEncabezado;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdDatosCuerpo;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdDatosClaseCuenta2;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdDatosCodigo;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCodigoContable;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdDatosTipoSaldo;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboSaldo;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Grdsaldoanteriordb;
        
        #line default
        #line hidden
        
        
        #line 180 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.NumericUpDown codSaldoInicial;
        
        #line default
        #line hidden
        
        
        #line 209 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Grdcargodb;
        
        #line default
        #line hidden
        
        
        #line 230 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.NumericUpDown codCargos;
        
        #line default
        #line hidden
        
        
        #line 261 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Grdabonodb;
        
        #line default
        #line hidden
        
        
        #line 282 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.NumericUpDown codAbonos;
        
        #line default
        #line hidden
        
        
        #line 313 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Grdsaldofinaldb;
        
        #line default
        #line hidden
        
        
        #line 334 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.NumericUpDown codSaldoFinal;
        
        #line default
        #line hidden
        
        
        #line 366 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdDatosMensaje;
        
        #line default
        #line hidden
        
        
        #line 381 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdBotones;
        
        #line default
        #line hidden
        
        
        #line 382 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spMenu;
        
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
                    "llebalance/detallebalancecrudview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
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
            this.GrdDatosEncabezado = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.GrdDatosCuerpo = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.GrdDatosClaseCuenta2 = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.GrdDatosCodigo = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.txtCodigoContable = ((System.Windows.Controls.TextBox)(target));
            
            #line 64 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
            this.txtCodigoContable.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            
            #line 65 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
            this.txtCodigoContable.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtCodigoKeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.GrdDatosTipoSaldo = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.comboSaldo = ((System.Windows.Controls.ComboBox)(target));
            
            #line 133 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
            this.comboSaldo.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            case 8:
            this.Grdsaldoanteriordb = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.codSaldoInicial = ((MahApps.Metro.Controls.NumericUpDown)(target));
            
            #line 181 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
            this.codSaldoInicial.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtSaldoInicialKeyDown);
            
            #line default
            #line hidden
            
            #line 182 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
            this.codSaldoInicial.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            case 10:
            this.Grdcargodb = ((System.Windows.Controls.Grid)(target));
            return;
            case 11:
            this.codCargos = ((MahApps.Metro.Controls.NumericUpDown)(target));
            
            #line 231 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
            this.codCargos.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtCargosKeyDown);
            
            #line default
            #line hidden
            
            #line 232 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
            this.codCargos.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            case 12:
            this.Grdabonodb = ((System.Windows.Controls.Grid)(target));
            return;
            case 13:
            this.codAbonos = ((MahApps.Metro.Controls.NumericUpDown)(target));
            
            #line 283 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
            this.codAbonos.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtAbonosKeyDown);
            
            #line default
            #line hidden
            
            #line 284 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
            this.codAbonos.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            case 14:
            this.Grdsaldofinaldb = ((System.Windows.Controls.Grid)(target));
            return;
            case 15:
            this.codSaldoFinal = ((MahApps.Metro.Controls.NumericUpDown)(target));
            
            #line 335 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
            this.codSaldoFinal.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtSaldoFinalKeyDown);
            
            #line default
            #line hidden
            
            #line 336 "..\..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\DetalleBalance\DetalleBalanceCrudView.xaml"
            this.codSaldoFinal.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            case 16:
            this.GrdDatosMensaje = ((System.Windows.Controls.Grid)(target));
            return;
            case 17:
            this.GrdBotones = ((System.Windows.Controls.Grid)(target));
            return;
            case 18:
            this.spMenu = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
