﻿#pragma checksum "..\..\SetingSystem.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D807DEFAF08C8796A61BC90D860F6506"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using SSM;
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


namespace SSM {
    
    
    /// <summary>
    /// SetingSystem
    /// </summary>
    public partial class SetingSystem : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\SetingSystem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Seting_win;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\SetingSystem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Win_DataBaseIP;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\SetingSystem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Win_DataBaseInstance;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\SetingSystem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Win_DataBaseName;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\SetingSystem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Win_DataBaseUser;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\SetingSystem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Win_DataBasePassword;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\SetingSystem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Grid_Close;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\SetingSystem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Image_Close;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\SetingSystem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Message_Close;
        
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
            System.Uri resourceLocater = new System.Uri("/SSM;component/setingsystem.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SetingSystem.xaml"
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
            this.Seting_win = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Win_DataBaseIP = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Win_DataBaseInstance = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Win_DataBaseName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Win_DataBaseUser = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Win_DataBasePassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 7:
            
            #line 36 "..\..\SetingSystem.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Seting_Win_Save_Letf_Down);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Grid_Close = ((System.Windows.Controls.Grid)(target));
            
            #line 38 "..\..\SetingSystem.xaml"
            this.Grid_Close.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Seting_Win_Close_left_Down);
            
            #line default
            #line hidden
            
            #line 39 "..\..\SetingSystem.xaml"
            this.Grid_Close.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Seting_Win_Close_Mouse_Enter);
            
            #line default
            #line hidden
            
            #line 40 "..\..\SetingSystem.xaml"
            this.Grid_Close.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Seting_Win_Close_Mouse_Leave);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Image_Close = ((System.Windows.Controls.Image)(target));
            return;
            case 10:
            this.Message_Close = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

