﻿#pragma checksum "..\..\ViewTrainees.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93241B3F5E364EB778012DEB71DDECEFB88EB424"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BE;
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
    /// ViewTrainees
    /// </summary>
    public partial class ViewTrainees : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ViewLicenseOwners;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ShowNoLicense;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton SearchID;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton SearchTeacher;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton SearchSchool;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton SearchName;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchBar;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchButton;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox sortByComboBox;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sortByButton;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid list;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView traineeListView;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn idColumn;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn familyNameColumn;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn firstNameColumn;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn birthdayColumn;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn addressColumn;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn genderColumn;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn lessonsNumberColumn;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn phoneNumberColumn;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn schoolNameColumn;
        
        #line default
        #line hidden
        
        
        #line 154 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn teacherNameColumn;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn transmissionLearnedColumn;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\ViewTrainees.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn typeCarLearnedColumn;
        
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
            System.Uri resourceLocater = new System.Uri("/PLWPF;component/viewtrainees.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ViewTrainees.xaml"
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
            this.ViewLicenseOwners = ((System.Windows.Controls.CheckBox)(target));
            
            #line 28 "..\..\ViewTrainees.xaml"
            this.ViewLicenseOwners.Click += new System.Windows.RoutedEventHandler(this.ViewLicenseOwners_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ShowNoLicense = ((System.Windows.Controls.CheckBox)(target));
            
            #line 30 "..\..\ViewTrainees.xaml"
            this.ShowNoLicense.Click += new System.Windows.RoutedEventHandler(this.ViewLicenseOwners_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SearchID = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.SearchTeacher = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.SearchSchool = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.SearchName = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.SearchBar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.SearchButton = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\ViewTrainees.xaml"
            this.SearchButton.Click += new System.Windows.RoutedEventHandler(this.Search);
            
            #line default
            #line hidden
            return;
            case 9:
            this.sortByComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.sortByButton = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\ViewTrainees.xaml"
            this.sortByButton.Click += new System.Windows.RoutedEventHandler(this.sortByButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.list = ((System.Windows.Controls.Grid)(target));
            return;
            case 12:
            this.traineeListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 13:
            this.idColumn = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 14:
            this.familyNameColumn = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 15:
            this.firstNameColumn = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 16:
            this.birthdayColumn = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 17:
            this.addressColumn = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 18:
            this.genderColumn = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 19:
            this.lessonsNumberColumn = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 20:
            this.phoneNumberColumn = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 21:
            this.schoolNameColumn = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 22:
            this.teacherNameColumn = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 23:
            this.transmissionLearnedColumn = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 24:
            this.typeCarLearnedColumn = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

