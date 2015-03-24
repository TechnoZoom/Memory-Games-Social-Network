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
using System.Windows.Media.Imaging;

namespace PhoneApp1
{
    public partial class Page1 : PhoneApplicationPage
    {
        private const string strConnectionString = @"isostore:/PlayerDB.sdf";

        PlayerDataContext Pldb = new PlayerDataContext(strConnectionString);

        string cur_pl_name = (string)IsolatedStorageSettings.ApplicationSettings["cur_uid"];
        private List<player> playerlist;
        public Page1()
        {
            InitializeComponent();
            int i = 0;
            IQueryable<player> EmpQuery = from pl in Pldb.Players where pl.pl_name == cur_pl_name select pl;
            player pl_cur = EmpQuery.FirstOrDefault();
            pl_name_prog.Text = cur_pl_name;
            l_1_sc.Text = pl_cur.lvl_1_sc.ToString();
            l_2_sc.Text = pl_cur.lvl_2_sc.ToString();
            l_3_sc.Text = pl_cur.lvl_3_sc.ToString();
            ht_lvl_1.Text = pl_cur.lvl_1_ht;
            ht_lvl_2.Text = pl_cur.lvl_2_ht;
            ht_lvl_3.Text = pl_cur.lvl_3_ht;

            IQueryable<player> plQuery = from pl in Pldb.Players orderby pl.lvl_1_sc + pl.lvl_2_sc + pl.lvl_3_sc descending select pl;
            playerlist = plQuery.ToList();
            foreach (player p in playerlist)
            {
                i++;

                if (p.pl_name == cur_pl_name)
                {
                    p.rank = i;
                    Pldb.SubmitChanges();
                    break;
                }
            }

            rank_dat.Text = i.ToString();

            BitmapImage retreivedImage = new BitmapImage();
            using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {

                using (var isoFileStream = isoStore.OpenFile(cur_pl_name + ".jpg", System.IO.FileMode.Open))
                    retreivedImage.SetSource(isoFileStream);
                user_image.Source = retreivedImage;



            }
        }
    }
}