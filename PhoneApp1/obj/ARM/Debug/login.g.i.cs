﻿#pragma checksum "K:\Phone 8 windows projects\PhoneApp1\PhoneApp1\login.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F8B11E7E7697B1080FDE12E6C1FC2C06"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PhoneApp1 {
    
    
    public partial class login : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.PasswordBox pwd;
        
        internal System.Windows.Controls.TextBox user;
        
        internal System.Windows.Controls.Button sign;
        
        internal System.Windows.Controls.StackPanel panel;
        
        internal System.Windows.Controls.RadioButton sign_in_name;
        
        internal System.Windows.Controls.RadioButton sign_up_name;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/PhoneApp1;component/login.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.pwd = ((System.Windows.Controls.PasswordBox)(this.FindName("pwd")));
            this.user = ((System.Windows.Controls.TextBox)(this.FindName("user")));
            this.sign = ((System.Windows.Controls.Button)(this.FindName("sign")));
            this.panel = ((System.Windows.Controls.StackPanel)(this.FindName("panel")));
            this.sign_in_name = ((System.Windows.Controls.RadioButton)(this.FindName("sign_in_name")));
            this.sign_up_name = ((System.Windows.Controls.RadioButton)(this.FindName("sign_up_name")));
        }
    }
}
