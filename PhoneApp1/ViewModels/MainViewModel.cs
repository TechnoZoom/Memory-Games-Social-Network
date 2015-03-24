//using System;
//using System.ComponentModel;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Text;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;
//using System.Collections.ObjectModel;
//using System.Xml.Linq;
//using System.IO.IsolatedStorage;
//using System.IO;
//using System.Diagnostics;
//using System.Linq;
//using PhoneApp1.ViewModels;


using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.IO.IsolatedStorage;
using System.IO;
using System.Diagnostics;
using System.Linq;


namespace PhoneApp1.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
        {
            private const string strConnectionString = @"isostore:/PlayerDB.sdf";

            PlayerDataContext Pldb = new PlayerDataContext(strConnectionString);
            //public int state = (int)IsolatedStorageSettings.ApplicationSettings["lvl_leader"];

            public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }


        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
            List<leaders> itemValues = new List<leaders>();

            IList<player> playerlist = null;

            //if (state == 1)
            //{
            //    IQueryable<player> plQuery = from pl in Pldb.Players orderby pl.lvl_1_sc descending select pl;
            //    playerlist = plQuery.ToList();
            //}

            //else if(state==2)
            //{
            //    IQueryable<player> plQuery = from pl in Pldb.Players orderby pl.lvl_2_sc descending select pl;
            //    playerlist = plQuery.ToList();
            //}

           
            
                IQueryable<player> plQuery = from pl in Pldb.Players orderby pl.lvl_1_sc + pl.lvl_2_sc + pl.lvl_3_sc descending select pl;
                playerlist = plQuery.ToList();
           


            foreach (player pl_mod  in playerlist)
            {
                itemValues.Add(new leaders
                {
                    username = pl_mod.pl_name,
                    sc = "Level 1:- " + pl_mod.lvl_1_sc.ToString() + "    " + "Level 2:- " + pl_mod.lvl_2_sc.ToString() + "    "+"Level 3:- " + pl_mod.lvl_3_sc.ToString()
                    //lv_2_sre = pl_mod.lvl_2_sc.ToString(),
                    //lv_3_sre = pl_mod.lvl_3_sc.ToString(),

                
                });

            }

            var lis = from s in itemValues
                      select s;

            foreach (leaders s in lis)
            {
                ItemViewModel ivm = new ItemViewModel();
                ivm.UserName = s.username;
                ivm.Level1Score = s.sc;
                this.Items.Add(ivm);
            }






            //foreach (string fileName in fileNames)
            //{
            //    if (fileName.EndsWith(".info"))
            //    {
            //        IsolatedStorageFileStream f = isoStore.OpenFile(fileName, System.IO.FileMode.Open);
            //        StreamReader sr = new StreamReader(f);
            //        string data = sr.ReadLine();
            //        sr.Close();
            //        f.Close();
            //        string[] dataParts = data.Split('|');
            //        Debug.WriteLine("File Name: " + dataParts[0] + " - date string: " + dataParts[1]);
            //        itemValues.Add(new leaders
            //        {
            //            displayString = dataParts[1],
            //            fileName = dataParts[0]
            //        });
            //    }
            //}

            //if (itemValues.Count == 0)
            //{
            //    ItemViewModel ivm = new ItemViewModel();
            //    ivm.FileName = "No Files Have Been Recorded";
            //    this.Items.Add(ivm);
            //}
            //else
            //{
            //    var descList = from s in itemValues
            //               orderby s.displayString descending
            //               select s;

            //    foreach (leaders s in descList)
            //    {
            //        ItemViewModel ivm = new ItemViewModel();
            //        ivm.DisplayString = s.displayString;
            //        ivm.FileName = s.fileName;
            //        this.Items.Add(ivm);
            //    }
            //}
        }

        public void FilesUpdated()
        {
            NotifyPropertyChanged("Items");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
 