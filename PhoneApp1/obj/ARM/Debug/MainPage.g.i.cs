﻿#pragma checksum "K:\Phone 8 windows projects\PhoneApp1\PhoneApp1\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "52A9CD1FCFDAD6A07EB6DD8A6F6157D9"
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
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Media.Animation.Storyboard Storyboard1;
        
        internal System.Windows.Media.Animation.Storyboard Storyboard2;
        
        internal System.Windows.Media.Animation.Storyboard right1;
        
        internal System.Windows.Media.Animation.Storyboard wrong1;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock textBlock;
        
        internal System.Windows.Controls.TextBlock textBlock3;
        
        internal System.Windows.Controls.TextBlock textBlock1;
        
        internal System.Windows.Controls.TextBox textBox1;
        
        internal System.Windows.Controls.TextBlock textBlock2;
        
        internal System.Windows.Controls.MediaElement rt;
        
        internal System.Windows.Controls.MediaElement wr;
        
        internal System.Windows.Controls.Button disp_num;
        
        internal System.Windows.Controls.TextBlock scoreblock;
        
        internal System.Windows.Controls.TextBlock scoreblock_ent;
        
        internal System.Windows.Controls.TextBlock test;
        
        internal System.Windows.Controls.TextBlock correct;
        
        internal System.Windows.Controls.TextBlock wrong;
        
        internal System.Windows.Controls.TextBlock tick;
        
        internal System.Windows.Controls.TextBlock cross;
        
        internal System.Windows.Controls.TextBlock notify;
        
        internal System.Windows.Controls.Button check_score;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/PhoneApp1;component/MainPage.xaml", System.UriKind.Relative));
            this.Storyboard1 = ((System.Windows.Media.Animation.Storyboard)(this.FindName("Storyboard1")));
            this.Storyboard2 = ((System.Windows.Media.Animation.Storyboard)(this.FindName("Storyboard2")));
            this.right1 = ((System.Windows.Media.Animation.Storyboard)(this.FindName("right1")));
            this.wrong1 = ((System.Windows.Media.Animation.Storyboard)(this.FindName("wrong1")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.textBlock = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock")));
            this.textBlock3 = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock3")));
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock1")));
            this.textBox1 = ((System.Windows.Controls.TextBox)(this.FindName("textBox1")));
            this.textBlock2 = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock2")));
            this.rt = ((System.Windows.Controls.MediaElement)(this.FindName("rt")));
            this.wr = ((System.Windows.Controls.MediaElement)(this.FindName("wr")));
            this.disp_num = ((System.Windows.Controls.Button)(this.FindName("disp_num")));
            this.scoreblock = ((System.Windows.Controls.TextBlock)(this.FindName("scoreblock")));
            this.scoreblock_ent = ((System.Windows.Controls.TextBlock)(this.FindName("scoreblock_ent")));
            this.test = ((System.Windows.Controls.TextBlock)(this.FindName("test")));
            this.correct = ((System.Windows.Controls.TextBlock)(this.FindName("correct")));
            this.wrong = ((System.Windows.Controls.TextBlock)(this.FindName("wrong")));
            this.tick = ((System.Windows.Controls.TextBlock)(this.FindName("tick")));
            this.cross = ((System.Windows.Controls.TextBlock)(this.FindName("cross")));
            this.notify = ((System.Windows.Controls.TextBlock)(this.FindName("notify")));
            this.check_score = ((System.Windows.Controls.Button)(this.FindName("check_score")));
        }
    }
}
