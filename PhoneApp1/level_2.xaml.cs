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
    public partial class level_2 : PhoneApplicationPage
    {
        public int score;
        public int count;
        public bool ch;
        public int size;
        public int[] numb;
        public int counter;
        public int count_index;
        public int corr_count;
        public int gameover;

        public int consec_3;
        public int consec_5;
        public int consec_10;


        private const string strConnectionString = @"isostore:/PlayerDB.sdf";

        PlayerDataContext Pldb = new PlayerDataContext(strConnectionString);

        string cur_pl_name = (string)IsolatedStorageSettings.ApplicationSettings["cur_uid"];
        private player pl_cur;

        DateTime d1,d2;
        TimeSpan t,t_parse;
       

       
        
        public level_2()
        {
            corr_count = 0;
            score = 0;
            count = 0;
            gameover = 4;
            consec_10 = 0;
            consec_5 = 0;
            consec_3 = 0;


           

            InitializeComponent();

            IQueryable<player> EmpQuery = from pl in Pldb.Players where pl.pl_name == cur_pl_name select pl;
             pl_cur = EmpQuery.FirstOrDefault();

            rt.Stop();
            wr.Stop();

            d1 = DateTime.Now;

            TimeSpan.TryParse(pl_cur.lvl_1_ht, out t_parse);

            

            check_score.Opacity = 0;
            check_score.IsEnabled = false;
            How.Text = "";
            scoreblock_ent.Text = "0";
            lvl2.IsEnabled = false;
            lvl2_unl.Text = "";

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

            int t;

            Random rnd_sz = new Random();
             size = rnd_sz.Next(14, 21);
             numb = new int[size];

            for(t=0;t<numb.Length;t++)
            {
                numb[t] = rnd.Next(0, 10);
            }

            int count_index = rnd.Next(0, numb.Length);
            
            counter = 0;

            for (t = 0; t < numb.Length; t++)
            {
                if(numb[t]==numb[count_index])
                {
                    counter++;
                }
            }


            String sh = "";
            String counter_str = counter.ToString();

            if (corr_count > 5)
            {
                lvl2.IsEnabled = true;
                lvl2_unl.Text = "CONGRATURATIONS!!!!!\r\n\r\nLEVEL 2 UNLOCKED";
            }


            for (t = 0; t < numb.Length; t++)
            {
                sh = sh + numb[t].ToString();
            }

            String How_many = "How many times did " + numb[count_index].ToString() + " occur?";



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
            if (textBox1.Text ==counter.ToString() )
            {
                score=score+size;

                consec_3++;
                consec_5++;
                consec_10++;
                //if (pl_cur.lvl_1_sc < score)
                //{
                //    pl_cur.lvl_1_sc = score;

                //}
                corr_count++;

                String t = score.ToString();
                scoreblock_ent.Text = t;

                textBox1.Text = "";
                rt.Play();
                wrong1.Stop();
                right1.Begin();
                ch = true;
                gameover = 4;

                if(consec_10 == 3)
                {
                    pl_cur.corr_3 = true;

                    Pldb.SubmitChanges();


                }

                if (consec_10 == 5)
                {
                    pl_cur.corr_5 = true;
                    Pldb.SubmitChanges();

                }

                if (consec_10 == 10)
                {
                    pl_cur.corr_10 = true;
                    Pldb.SubmitChanges();

                }






            }

            else
            {
                right1.Stop();
                wr.Play();
                wrong1.Begin();
                ch = false;
                consec_10 = 0;
                gameover--;
                if(gameover==0)
                {
                  MessageBoxResult q=  MessageBox.Show("Sorry!!you gave 4 consecutive wrong answers...Try Again!!!And burn the scoreboard with your concentration and reflexes!!!!!", "Game Over", MessageBoxButton.OK);
                    if(q==MessageBoxResult.OK)
                    {
                        d2 = DateTime.Now;
                        t = d2 - d1;

                        if (pl_cur.lvl_1_sc < score)
                        {
                            pl_cur.lvl_1_sc = score;

                        }

                        if (t > t_parse)
                        {
                            pl_cur.lvl_1_ht = t.Hours.ToString() + ":" + t.Minutes.ToString() + ":" + t.Seconds; ;
                        }
                        Pldb.SubmitChanges();
                        NavigationService.Navigate(new Uri("/level_2.xaml", UriKind.Relative));
                        //NavigationService.Navigate(new Uri(string.Format(NavigationService.Source +
                        //            "?Refresh=true&random={0}", Guid.NewGuid())));
                    }
                }
            }

            disp_num.IsEnabled = true;
            disp_num.Opacity = 100;
            check_score.Opacity = 0;
            check_score.IsEnabled = false;
            if (corr_count > 5)
            {
                lvl2.IsEnabled = true;
                lvl2_unl.Text = "CONGRATURATIONS!!!!!\r\nLEVEL 2 UNLOCKED";
            }


        }

        private void level2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/level_3.xaml", UriKind.Relative));
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
            shareLinkTask.Message = "My Level 1 score is " + score.ToString() + " This game is simply outstanding.Lets you test and improve your memory,reflexes and concentration.The challenging and extremely interesting levels just don't let you blink your eye and let you enjoy yourself to the fullest. ";
            shareLinkTask.Show();


        }


        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            d2 = DateTime.Now;
            t = d2 - d1;

            if (pl_cur.lvl_1_sc<score)
            {
                pl_cur.lvl_1_sc = score;

            }

            if (t > t_parse)
            {
                pl_cur.lvl_1_ht = t.Hours.ToString() + ":" + t.Minutes.ToString() + ":" + t.Seconds; ;
            }
            Pldb.SubmitChanges();

            //base.OnNavigatingFrom(e);
            

        }

        //  building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{s
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