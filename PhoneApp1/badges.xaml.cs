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
    public partial class badges : PhoneApplicationPage
    {

        private const string strConnectionString = @"isostore:/PlayerDB.sdf";

        PlayerDataContext Pldb = new PlayerDataContext(strConnectionString);

        string cur_pl_name = (string)IsolatedStorageSettings.ApplicationSettings["cur_uid"];

        public badges()
        {
            InitializeComponent();
            IQueryable<player> EmpQuery = from pl in Pldb.Players where pl.pl_name == cur_pl_name select pl;
            player pl_cur = EmpQuery.FirstOrDefault();

            if(pl_cur.corr_3 == true)
            {
                BitmapImage tn = new BitmapImage();
                tn.SetSource(Application.GetResourceStream(new Uri(@"badges/3_corr.jpg", UriKind.Relative)).Stream);
                curroo_3.Source = tn;
            }

            if (pl_cur.corr_5 == true)
            {
                BitmapImage tn = new BitmapImage();
                tn.SetSource(Application.GetResourceStream(new Uri(@"badges/number-5-md.png", UriKind.Relative)).Stream);
                corr_5.Source = tn;
            }

            if (pl_cur.corr_10 == true)
            {
                BitmapImage tn = new BitmapImage();
                tn.SetSource(Application.GetResourceStream(new Uri(@"badges/10_super.jpg", UriKind.Relative)).Stream);
                corroo_10.Source = tn;
            }
            
        }
    }
}