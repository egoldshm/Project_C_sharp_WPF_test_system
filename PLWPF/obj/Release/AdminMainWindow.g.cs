﻿#pragma checksum "..\..\AdminMainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AC53CAE083DFF07AC97D4C610F710397"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PLWPF;
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


namespace PLWPF {
    
    
    /// <summary>
    /// AdminMainWindow
    /// </summary>
    public partial class AdminMainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\AdminMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PLWPF.title title;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\AdminMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid details;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\AdminMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem delete;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\AdminMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PLWPF.DeleteTrainee deleteTrainee_uc;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\AdminMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PLWPF.DeleteTester deleteTester_uc;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\AdminMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem update;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\AdminMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem view;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\AdminMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PLWPF.ViewTrainees viewTraineeUserconrol;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\AdminMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PLWPF.ViewTesters viewTestersUsercontrol;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\AdminMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PLWPF.ViewTests ViewTest;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\AdminMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PLWPF.LoginAs loginas;
        
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
            System.Uri resourceLocater = new System.Uri("/PLWPF;component/adminmainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminMainWindow.xaml"
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
            this.title = ((PLWPF.title)(target));
            return;
            case 2:
            this.details = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            
            #line 17 "..\..\AdminMainWindow.xaml"
            ((System.Windows.Controls.TabControl)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TabControl_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.delete = ((System.Windows.Controls.TabItem)(target));
            return;
            case 5:
            this.deleteTrainee_uc = ((PLWPF.DeleteTrainee)(target));
            return;
            case 6:
            this.deleteTester_uc = ((PLWPF.DeleteTester)(target));
            return;
            case 7:
            this.update = ((System.Windows.Controls.TabItem)(target));
            return;
            case 8:
            this.view = ((System.Windows.Controls.TabItem)(target));
            return;
            case 9:
            this.viewTraineeUserconrol = ((PLWPF.ViewTrainees)(target));
            return;
            case 10:
            this.viewTestersUsercontrol = ((PLWPF.ViewTesters)(target));
            return;
            case 11:
            this.ViewTest = ((PLWPF.ViewTests)(target));
            return;
            case 12:
            this.loginas = ((PLWPF.LoginAs)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

