﻿#pragma checksum "..\..\pg_registro_productos.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E5AC393056EB093EBECEEF52B4961290"
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


namespace Vistas_Datacut {
    
    
    /// <summary>
    /// pg_registro_productos
    /// </summary>
    public partial class pg_registro_productos : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\pg_registro_productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_personal_back;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\pg_registro_productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbx_nombre_personal;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\pg_registro_productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbx_apellidos_personal;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\pg_registro_productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbx_CURP_personal;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\pg_registro_productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_cancelarregistro_personal;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\pg_registro_productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_guardarregistro_personal;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\pg_registro_productos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagrid_PR_list;
        
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
            System.Uri resourceLocater = new System.Uri("/DataCut;component/pg_registro_productos.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\pg_registro_productos.xaml"
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
            this.btn_personal_back = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\pg_registro_productos.xaml"
            this.btn_personal_back.Click += new System.Windows.RoutedEventHandler(this.btn_personal_back_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbx_nombre_personal = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbx_apellidos_personal = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbx_CURP_personal = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btn_cancelarregistro_personal = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\pg_registro_productos.xaml"
            this.btn_cancelarregistro_personal.Click += new System.Windows.RoutedEventHandler(this.btn_cancelarregistro_personal_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_guardarregistro_personal = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\pg_registro_productos.xaml"
            this.btn_guardarregistro_personal.Click += new System.Windows.RoutedEventHandler(this.btn_guardarregistro_personal_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.datagrid_PR_list = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

