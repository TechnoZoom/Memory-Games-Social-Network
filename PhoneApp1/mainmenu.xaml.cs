using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System.Text;

using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;


namespace PhoneApp1
{
    public partial class mainmenu : PhoneApplicationPage
    {

        private const string strConnectionString = @"isostore:/PlayerDB.sdf";

        PlayerDataContext Pldb = new PlayerDataContext(strConnectionString);

        //string cur_pl_name = (string)IsolatedStorageSettings.ApplicationSettings["cur_uid"];
        //private List<player> playerlist;
        //int i;
        public mainmenu()
        {
            InitializeComponent();
            //i = 0;
            //IQueryable<player> plQuery = from pl in Pldb.Players orderby pl.lvl_1_sc + pl.lvl_2_sc + pl.lvl_3_sc descending select pl;
            //playerlist = plQuery.ToList();
            //foreach(player p in playerlist)
            //{
            //    i++;

            //    if(p.pl_name == cur_pl_name)
            //    {
            //        p.rank = i;
            //    }
            //}
        }

        private void lvel1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/level_2.xaml", UriKind.Relative));
        }

        private void lvel2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void abt(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void lvl2_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/level_3.xaml", UriKind.Relative));
        }

        private void ins(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/instructions.xaml", UriKind.Relative));
        }


        private void contact(object sender, EventArgs e)
        {
            Microsoft.Phone.Tasks.EmailComposeTask emailTask = new Microsoft.Phone.Tasks.EmailComposeTask();
            emailTask.Subject = "";
            emailTask.To = "akapil167@yahoo.com";
            emailTask.Show();
        }

        private void favs(object sender, EventArgs e)
        {
            MarketplaceReviewTask task = new MarketplaceReviewTask();
            task.Show();
        }

        private void mor(object sender, EventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.URL = "http://www.windowsphone.com/en-IN/store/publishers?publisherId=Kapil%2BBakshi&appId=41a28a4d-aadf-4d69-aa96-4cef55a6bdc9";
            webBrowserTask.Show();

            //ShareStatusTask shareStatusTask = new ShareStatusTask();

            //shareStatusTask.Status = "JNJNNKKJNKKJNJN";

            //shareStatusTask.Show();
        }

        private void prog_handler(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Prog.xaml",UriKind.Relative));
        }

        private void signout_hand(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/login.xaml", UriKind.Relative));
        }

        private void Leader_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/leaderboard.xaml", UriKind.Relative));
        }

        private void badg_nav(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/badges.xaml", UriKind.Relative));
        }


    }
}