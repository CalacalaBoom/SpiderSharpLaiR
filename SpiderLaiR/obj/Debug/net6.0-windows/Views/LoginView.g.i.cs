﻿#pragma checksum "..\..\..\..\Views\LoginView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A0648B64303CAE2CAD2BF15C1C3A20172937C41D"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Expression.Media;
using HandyControl.Expression.Shapes;
using HandyControl.Interactivity;
using HandyControl.Media.Animation;
using HandyControl.Media.Effects;
using HandyControl.Properties.Langs;
using HandyControl.Themes;
using HandyControl.Tools;
using HandyControl.Tools.Converter;
using HandyControl.Tools.Extension;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace SpiderLaiR.Views {
    
    
    /// <summary>
    /// LoginView
    /// </summary>
    public partial class LoginView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\..\Views\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SpiderLaiR.Views.LoginView LoginWindow;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Views\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Loading;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Views\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button eventExit;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Views\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button eventInfo;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\Views\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.PasswordBox Password;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\Views\LoginView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Login;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SpiderLaiR;V1.0.0.0;component/views/loginview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\LoginView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LoginWindow = ((SpiderLaiR.Views.LoginView)(target));
            return;
            case 2:
            this.Loading = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            
            #line 29 "..\..\..\..\Views\LoginView.xaml"
            ((HandyControl.Controls.Watermark)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Watermark_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.eventExit = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\Views\LoginView.xaml"
            this.eventExit.Click += new System.Windows.RoutedEventHandler(this.eventExit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.eventInfo = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\Views\LoginView.xaml"
            this.eventInfo.Click += new System.Windows.RoutedEventHandler(this.eventInfo_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 40 "..\..\..\..\Views\LoginView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Au_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 41 "..\..\..\..\Views\LoginView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 42 "..\..\..\..\Views\LoginView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.HP_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Password = ((HandyControl.Controls.PasswordBox)(target));
            return;
            case 10:
            this.Login = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\..\Views\LoginView.xaml"
            this.Login.Click += new System.Windows.RoutedEventHandler(this.Login_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
