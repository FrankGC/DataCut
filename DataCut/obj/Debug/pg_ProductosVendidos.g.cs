﻿#pragma checksum "..\..\pg_ProductosVendidos.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "68FE9722F16D00B1B1D9DF4FCB372302"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DataCut;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
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


namespace DataCut {
    
    
    /// <summary>
    /// pg_ProductosVendidos
    /// </summary>
    public partial class pg_ProductosVendidos : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\pg_ProductosVendidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagrid_TR_list;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\pg_ProductosVendidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbx_PV_productos;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\pg_ProductosVendidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox cbx_PV_cantidad;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\pg_ProductosVendidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_PV_ok;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\pg_ProductosVendidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_PV_eliminar;
        
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
            System.Uri resourceLocater = new System.Uri("/DataCut;component/pg_productosvendidos.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\pg_ProductosVendidos.xaml"
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
            this.datagrid_TR_list = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            
            #line 19 "..\..\pg_ProductosVendidos.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbx_PV_productos = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.cbx_PV_cantidad = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.bt_PV_ok = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\pg_ProductosVendidos.xaml"
            this.bt_PV_ok.Click += new System.Windows.RoutedEventHandler(this.bt_PV_ok_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.bt_PV_eliminar = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\pg_ProductosVendidos.xaml"
            this.bt_PV_eliminar.Click += new System.Windows.RoutedEventHandler(this.bt_PV_eliminar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
