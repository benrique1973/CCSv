﻿#pragma checksum "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\BalancesCrudView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D350E65BC26A4980F5EE9143117403A2"
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


namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Balances {
    
    
    /// <summary>
    /// BalancesCrudView
    /// </summary>
    public partial class BalancesCrudView : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\BalancesCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdDatosEncabezado;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\BalancesCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdDatosCuerpo;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\BalancesCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdDatosElemento;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\BalancesCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboClaseBalance;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\BalancesCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdDatosClaseCuenta2;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\BalancesCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox seleccionPeriodo;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\BalancesCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdDatosTipoSaldo;
        
        #line default
        #line hidden
        
        
        #line 172 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\BalancesCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpkfechabalance;
        
        #line default
        #line hidden
        
        
        #line 201 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\BalancesCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdDatosMensaje;
        
        #line default
        #line hidden
        
        
        #line 216 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\BalancesCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GrdBotones;
        
        #line default
        #line hidden
        
        
        #line 230 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\BalancesCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel GrdBitacora;
        
        #line default
        #line hidden
        
        
        #line 251 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\BalancesCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgContenido;
        
        #line default
        #line hidden
        
        
        #line 280 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\BalancesCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn codidCorrelativoBit;
        
        #line default
        #line hidden
        
        
        #line 299 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\BalancesCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn codfechahorabitacora;
        
        #line default
        #line hidden
        
        
        #line 318 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\BalancesCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn codaccionbitacora;
        
        #line default
        #line hidden
        
        
        #line 336 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\BalancesCrudView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn codinicialesusuariobitacora;
        
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
            System.Uri resourceLocater = new System.Uri("/SGPTWpf;component/sgptwpf/views/principales/encargos/documentacion/balances/bala" +
                    "ncescrudview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\BalancesCrudView.xaml"
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
            this.GrdDatosElemento = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.comboClaseBalance = ((System.Windows.Controls.ComboBox)(target));
            
            #line 75 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\BalancesCrudView.xaml"
            this.comboClaseBalance.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            case 5:
            this.GrdDatosClaseCuenta2 = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.seleccionPeriodo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.GrdDatosTipoSaldo = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.dpkfechabalance = ((System.Windows.Controls.DatePicker)(target));
            
            #line 183 "..\..\..\..\..\..\..\..\SGPtWpf\Views\Principales\Encargos\Documentacion\Balances\BalancesCrudView.xaml"
            this.dpkfechabalance.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            case 9:
            this.GrdDatosMensaje = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            this.GrdBotones = ((System.Windows.Controls.Grid)(target));
            return;
            case 11:
            this.GrdBitacora = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 12:
            this.dgContenido = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 13:
            this.codidCorrelativoBit = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 14:
            this.codfechahorabitacora = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 15:
            this.codaccionbitacora = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 16:
            this.codinicialesusuariobitacora = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

