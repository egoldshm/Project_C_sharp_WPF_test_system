﻿#pragma checksum "..\..\AddUser.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "457F40125FB4D523358AC5C1B3317C49"
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
    /// AddUser
    /// </summary>
    public partial class AddUser : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\AddUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid types;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\AddUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton adminRadio;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\AddUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton traineeRadio;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\AddUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton testerRadion;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\AddUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton teacherRadion;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\AddUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton SchoolRadion;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\AddUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Username;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\AddUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PLWPF.myPasswordBox password;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\AddUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label chooseType;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\AddUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox items;
        
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
            System.Uri resourceLocater = new System.Uri("/PLWPF;component/adduser.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddUser.xaml"
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
            this.types = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.adminRadio = ((System.Windows.Controls.RadioButton)(target));
            
            #line 29 "..\..\AddUser.xaml"
            this.adminRadio.Checked += new System.Windows.RoutedEventHandler(this.AdminRadio_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.traineeRadio = ((System.Windows.Controls.RadioButton)(target));
            
            #line 30 "..\..\AddUser.xaml"
            this.traineeRadio.Checked += new System.Windows.RoutedEventHandler(this.TraineeRadio_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.testerRadion = ((System.Windows.Controls.RadioButton)(target));
            
            #line 31 "..\..\AddUser.xaml"
            this.testerRadion.Checked += new System.Windows.RoutedEventHandler(this.TesterRadion_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.teacherRadion = ((System.Windows.Controls.RadioButton)(target));
            
            #line 32 "..\..\AddUser.xaml"
            this.teacherRadion.Checked += new System.Windows.RoutedEventHandler(this.TeacherRadion_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SchoolRadion = ((System.Windows.Controls.RadioButton)(target));
            
            #line 33 "..\..\AddUser.xaml"
            this.SchoolRadion.Checked += new System.Windows.RoutedEventHandler(this.SchoolRadion_Checked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Username = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\AddUser.xaml"
            this.Username.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Username_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.password = ((PLWPF.myPasswordBox)(target));
            return;
            case 9:
            this.chooseType = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.items = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            
            #line 41 "..\..\AddUser.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

