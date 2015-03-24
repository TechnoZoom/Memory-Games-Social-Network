using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.Data.Linq;

namespace PhoneApp1
{
    public partial class login : PhoneApplicationPage
    {
        private const string strConnectionString = @"isostore:/PlayerDB.sdf";

        public login()
        {
            InitializeComponent();
            sign_in_name.IsChecked = true;
            sign.Content = "Sign In";
        }

        private void sign_Click(object sender, RoutedEventArgs e)
        {
                using (PlayerDataContext Pldb = new PlayerDataContext(strConnectionString))
                 {
            if (Pldb.DatabaseExists() == false)
        {
        Pldb.CreateDatabase();

                    }

                    if(sign_up_name.IsChecked==true)
                    {
                        player newPlayer = new player
                        {
                            pl_name = user.Text,
                            lvl_1_sc = 0,
                            lvl_2_sc = 0,
                            lvl_3_sc = 0,
                            pl_pwrd = pwd.Password,
                            lvl_1_ht = "00:00:00",
                            lvl_2_ht = "00:00:00",
                            lvl_3_ht = "00:00:00",
                            corr_10 =false,
                            corr_3 = false,
                            corr_5 = false,
                            rn_1 = false



                        };

                        try
                        {
                            Pldb.Players.InsertOnSubmit(newPlayer);
                            Pldb.SubmitChanges();
                            IsolatedStorageSettings.ApplicationSettings["cur_uid"] = user.Text;
                            NavigationService.Navigate(new Uri("/photocapt.xaml", UriKind.Relative));

                        }
                        catch
                        {
                            MessageBox.Show("The username already exists.Enter a different username OR Sign in with this username.");
                        }
                    }

                    else
                    {
                        IQueryable<player> EmpQuery = from pl in Pldb.Players where pl.pl_pwrd == pwd.Password && pl.pl_name==user.Text select pl;
                        player pl_cur = EmpQuery.FirstOrDefault();
                        if (pl_cur == null)
                        {
                            MessageBox.Show("Either username or password is incorrect or both are incorrect");

                        }
                        else
                        {
                            IsolatedStorageSettings.ApplicationSettings["cur_uid"] = user.Text;
                            NavigationService.Navigate(new Uri("/mainmenu.xaml", UriKind.Relative));
                        }
                    }
            //IQueryable<player> EmpQuery = from pl in Pldb.Players where pl.pl_pwrd == pwd.Password select pl;
            //player pl_cur = EmpQuery.FirstOrDefault();

            //        if(pl_cur==null)
            //        {
            //            pl_cur.lvl_1_sc = 0;
            //            pl_cur.lvl_2_sc = 0;
            //            pl_cur.lvl_3_sc = 0;
            //            Pldb.Players.InsertOnSubmit(pl_cur);
            //            Pldb.SubmitChanges();
                      
            //        }

            //player newPlayer = new player
            //{
            //    pl_name = user.Text,
            //    lvl_1_sc = 0,
            //    lvl_2_sc = 0,
            //    lvl_3_sc = 0,
            //    pl_pwrd=pwd.Password
            //};


            //            Pldb.Players.InsertOnSubmit(newPlayer);
            //            Pldb.SubmitChanges();
                    //IsolatedStorageSettings.ApplicationSettings["cur_uid"] = user.Text;
            
                }

               // NavigationService.Navigate(new Uri("/Prog.xaml", UriKind.Relative));

        }

        private void user_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void in_hand(object sender, RoutedEventArgs e)
        {
            sign.Content = "Sign In";
        }

        private void up_hand(object sender, RoutedEventArgs e)
        {
            sign.Content = "Sign Up";

        }
    
    
    }

}