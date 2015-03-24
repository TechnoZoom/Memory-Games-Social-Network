using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using PhoneApp1.ViewModels;
using System.Diagnostics;
using System.IO.IsolatedStorage;

namespace PhoneApp1
{
    public partial class leaderboard : PhoneApplicationPage
    {
        private int lastSelectedIndex = -1;
        private Brush lastSelectedItemBackground;
        private ItemViewModel lastSelectedItem = null;

        public leaderboard()
        {
            InitializeComponent();
            App.ViewModel.LoadData();
            DataContext = App.ViewModel;
            
            this.Loaded += new RoutedEventHandler(Page_Loaded);
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //App.ViewModel.FilesUpdated();
            lastSelectedIndex = -1;
            lastSelectedItem = null;
        }

        private void RecordingsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected index is -1 (no selection) do nothing
            if (MainListBox.SelectedIndex == -1)
                return;

            //if (playbackStarted)
            //    return;

            if (lastSelectedIndex != -1)
            {
                var listBox = sender as ListBox;
                var listBoxItem = listBox.ItemContainerGenerator.ContainerFromIndex(lastSelectedIndex) as ListBoxItem;

                listBoxItem.Background = lastSelectedItemBackground;
            }

            ItemViewModel ivm = (ItemViewModel)MainListBox.SelectedItem;

            if (ivm != null)
            {
                Debug.WriteLine("Selection: " + ivm.UserName + " / " + ivm.Level1Score);

                var listBox = sender as ListBox;
                var listBoxItem = listBox.ItemContainerGenerator.ContainerFromItem(listBox.SelectedItem) as ListBoxItem;

                lastSelectedItemBackground = listBoxItem.Background;
                lastSelectedIndex = MainListBox.SelectedIndex;
                System.Windows.Media.Color currentAccentColorHex = (System.Windows.Media.Color)Application.Current.Resources["PhoneAccentColor"];
                listBoxItem.Background = new SolidColorBrush(currentAccentColorHex);
                lastSelectedItem = ivm;
            }
        }

        //private void l1_leader_Checked(object sender, RoutedEventArgs e)
        //{
        //    IsolatedStorageSettings.ApplicationSettings["lvl_leader"] = 1;
        //   // InitializeComponent();
        //    //App.ViewModel.LoadData();
        //    //DataContext = App.ViewModel;
        //    //this.Loaded += new RoutedEventHandler(Page_Loaded);
        //    //NavigationService.Navigate(new Uri(string.Format("/leaderboard.xaml?Refresh=true&random={0}", Guid.NewGuid()), UriKind.Absolute));
        //    App.ViewModel.LoadData();
        //    DataContext = null;           
        //    DataContext = App.ViewModel;
        //    this.Loaded += new RoutedEventHandler(Page_Loaded);
        //}

        //private void l2_leader_Checked(object sender, RoutedEventArgs e)
        //{
        //    IsolatedStorageSettings.ApplicationSettings["lvl_leader"] = 2;
        //    ////InitializeComponent();
        //    //App.ViewModel.LoadData();
        //    //DataContext = App.ViewModel;
        //    //this.Loaded += new RoutedEventHandler(Page_Loaded);
        //    App.ViewModel.LoadData();
        //    DataContext = null;
        //    DataContext = App.ViewModel;
        //    this.Loaded += new RoutedEventHandler(Page_Loaded);
        //}

        //private void l3_leader_Checked(object sender, RoutedEventArgs e)
        //{
        //    IsolatedStorageSettings.ApplicationSettings["lvl_leader"] = 3;
        //    //InitializeComponent();
        //    //App.ViewModel.LoadData();
        //    //DataContext = App.ViewModel;
        //    //this.Loaded += new RoutedEventHandler(Page_Loaded);

        //    App.ViewModel.LoadData();
        //    DataContext = null;
        //    DataContext = App.ViewModel;
        //    this.Loaded += new RoutedEventHandler(Page_Loaded);
        //}
    
    
    
    
    
    }
}