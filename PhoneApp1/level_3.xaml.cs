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
using System.IO.IsolatedStorage;

namespace PhoneApp1
{
    public partial class level_3 : PhoneApplicationPage
    {
        public int score;
        public int count;
        public bool ch;
        public int size;
        public int[] numb;
        public int[] num_f;
        public int[] num_f_2;
        public int[] numb_2;
        public int counter;
        public int count_index;
        public int count_comm;
        public int corr_count;

        private const string strConnectionString = @"isostore:/PlayerDB.sdf";

        PlayerDataContext Pldb = new PlayerDataContext(strConnectionString);

        string cur_pl_name = (string)IsolatedStorageSettings.ApplicationSettings["cur_uid"];
        private player pl_cur;

        DateTime d1, d2;
        TimeSpan t, t_parse;

        public level_3()
        {
            score = 0;
            count = 0;
            corr_count = 0;

            InitializeComponent();

            IQueryable<player> EmpQuery = from pl in Pldb.Players where pl.pl_name == cur_pl_name select pl;
            pl_cur = EmpQuery.FirstOrDefault();

            rt.Stop();
            wr.Stop();

            d1 = DateTime.Now;

            TimeSpan.TryParse(pl_cur.lvl_2_ht, out t_parse);

            check_score.Opacity = 0;
            check_score.IsEnabled = false;
            How.Text = "";
            scoreblock_ent.Text = "0";
            lvl2.IsEnabled = false;
            lvl2_unl.Text = "";
            textBlock1.Text = "";
            number2.Text = "";

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ch)
            {
                right1.Stop();
                rt.Stop();
            }
            else
            {
                wrong1.Stop();
                wr.Stop();
            }

            //count++;
            //if (count <= 6)
            //{
            //    Storyboard1.Begin();
            //}
            //else
            //{
            //    Storyboard2.Begin();
            //}

            Storyboard1_1.Begin();
            Random rnd = new Random();

            int t, i,j;

            Random rnd_sz = new Random();
            size = rnd_sz.Next(4, 7);
            numb = new int[size];
            numb_2 = new int[size];
            int[] accum = new int[size];
            count_comm = 0;

            for (t = 0; t < numb.Length; t++)
            {
                numb[t] = rnd.Next(0, 10);
                numb_2[t] = rnd.Next(0, 10);
            }

            
            num_f=numb.Distinct().ToArray();
            num_f_2=numb_2.Distinct().ToArray();

            for(i=0;i<num_f.Length;i++)
            {
                if(num_f_2.Contains(num_f[i]))
                {
                    count_comm++;
                }
            }




            int count_index = rnd.Next(0, numb.Length);

            counter = 0;

            for (t = 0; t < numb.Length; t++)
            {
                if (numb[t] == numb[count_index])
                {
                    counter++;
                }
            }


            String sh = "";
            String sh_2 = "";
            String counter_str = counter.ToString();

            if (corr_count > 5)
            {
                lvl2.IsEnabled = true;
                lvl2_unl.Text = "CONGRATURATIONS!!!!!\r\n\r\nLEVEL 3 UNLOCKED";
            }


            for (t = 0; t < numb.Length; t++)
            {
                sh = sh + numb[t].ToString();
                sh_2 = sh_2 + numb_2[t].ToString();
            }

            String How_many = "How many distinct numbers were common in the two numbers you just saw ?";



            int nu;
            double left, right;
            left = Math.Pow(10, (count - 1));
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
            textBlock1.Text = sh;
            number2.Text = sh_2;
            textBox1.Text = "";
            How.Text = How_many;

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

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text ==count_comm.ToString())
            {
                score = score + size;
                corr_count++;

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
            if (corr_count > 5)
            {
                lvl2.IsEnabled = true;
                lvl2_unl.Text = "CONGRATURATIONS!!!!!\r\nLEVEL 3 UNLOCKED";
            }


        }

        private void level2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
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
            shareLinkTask.Message = "My Level 2 score is " + score.ToString() + " This game is simply outstanding.Lets you test and improve your memory,reflexes and concentration.The challenging and extremely interesting levels just don't let you blink your eye and let you enjoy yourself to the fullest. ";
            shareLinkTask.Show();


        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            d2 = DateTime.Now;
            t = d2 - d1;

            if (pl_cur.lvl_2_sc < score)
            {
                pl_cur.lvl_2_sc = score;

            }
            if (t > t_parse)
            {
                pl_cur.lvl_2_ht = t.Hours.ToString() + ":" + t.Minutes.ToString() + ":" + t.Seconds; ;
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

        // Informs when full resolution photo has been taken, saves to local media library and the local folder

    }
}