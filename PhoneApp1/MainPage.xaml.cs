using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp1.Resources;
using Microsoft.Phone.Tasks;
using System.IO.IsolatedStorage;

namespace PhoneApp1
{
    public partial class MainPage : PhoneApplicationPage
    {
        public int score;
        public int count;
        public bool ch;
        public int corr_count;

        private const string strConnectionString = @"isostore:/PlayerDB.sdf";

        PlayerDataContext Pldb = new PlayerDataContext(strConnectionString);

        string cur_pl_name = (string)IsolatedStorageSettings.ApplicationSettings["cur_uid"];
        private player pl_cur;
        
        
        // Constructor
        public MainPage()
        {
            score = 0;
            count = 0;
            
            InitializeComponent();

            IQueryable<player> EmpQuery = from pl in Pldb.Players where pl.pl_name == cur_pl_name select pl;
            pl_cur = EmpQuery.FirstOrDefault();

            rt.Stop();
            wr.Stop();

            check_score.Opacity = 0;
            check_score.IsEnabled = false;
            scoreblock_ent.Text = "0";
            notify.Text = "";

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(ch)
            {
                right1.Stop();
                rt.Stop();
            }
            else
            {
                wrong1.Stop();
                wr.Stop();

            }

            Random rnd = new Random();

            count = rnd.Next(4, 10);
            //count++;
            if(count<=6)
            {
            Storyboard1.Begin();
            }
            else
            {
                Storyboard2.Begin();
            }

            

            int nu;
            double left, right;
            left=Math.Pow(10,(count-1));
            right = Math.Pow(10, count);
            int left_int, right_int;
            if (count <= 9)
            {
                left_int = Convert.ToInt32(left);
                right_int = Convert.ToInt32(right);



                nu = rnd.Next(left_int, right_int);
            }

            else
            {
                nu = rnd.Next(Convert.ToInt32(Math.Pow(10, 8)), Convert.ToInt32(Math.Pow(10, 9)));
            }
            
            String s = nu.ToString();
            textBlock1.Text = s ;
            textBox1.Text = "";

            //while(test.Opacity != 0)
            //{

            //}

            //textBox1.Focus();

            //while (true)
            //{
            //    if (test.Opacity == 0)
            //    {
            //        break;
            //    }


            //}

            //textBox1.Focus();
            
            //if (Storyboard1.GetCurrentTime()=)
            //{
            //    textBox1.Focus();
            //}

            textBox1.Focus();

            disp_num.IsEnabled = false;
            disp_num.Opacity = 0;
            check_score.Opacity = 100;
            check_score.IsEnabled = true;
            notify.Text = "Enter the number you just saw and press check";
            
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(textBox1.Text==textBlock1.Text)
            { score=score+count;

            String t = score.ToString();
            scoreblock_ent.Text = t;

            textBox1.Text = "";
            rt.Play();
            wrong1.Stop();
            right1.Begin();
            ch = true;
            

            

            }

            else
            {
                wr.Play();
                right1.Stop();
                wrong1.Begin();
                ch = false;
            }

            disp_num.IsEnabled = true;
            disp_num.Opacity = 100;
            check_score.Opacity = 0;
            check_score.IsEnabled = false;
            notify.Text = "";
            

        }

        

        private void level1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/level_2.xaml", UriKind.Relative));
        }


        private void favs(object sender, EventArgs e)
        {
            MarketplaceReviewTask task = new MarketplaceReviewTask();
            task.Show();
        }


        private void menu(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/mainmenu.xaml", UriKind.Relative));

        }

        private void mor(object sender, EventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.URL = "http://www.windowsphone.com/en-IN/store/publishers?publisherId=Kapil%2BBakshi&appId=41a28a4d-aadf-4d69-aa96-4cef55a6bdc9";
            webBrowserTask.Show();

            
        }

        private void sh(object sender, EventArgs e)
        {
            ShareLinkTask shareLinkTask = new ShareLinkTask();
            shareLinkTask.Title = "Try this awesome REFLEXES + MEMORY GAME";
            shareLinkTask.LinkUri = new Uri("http://www.windowsphone.com/en-in/store/app/reflexes-memory-game/41a28a4d-aadf-4d69-aa96-4cef55a6bdc9", UriKind.Absolute);
            shareLinkTask.Message = "My Level 3 score is " + score.ToString() + " This game is simply outstanding.Lets you test and improve your memory,reflexes and concentration.The challenging and extremely interesting levels just don't let you blink your eye and let you enjoy yourself to the fullest. ";
            shareLinkTask.Show();


        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {

            if (pl_cur.lvl_3_sc < score)
            {
                pl_cur.lvl_3_sc = score;

            }
            Pldb.SubmitChanges();

            //base.OnNavigatingFrom(e);

        }



        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}