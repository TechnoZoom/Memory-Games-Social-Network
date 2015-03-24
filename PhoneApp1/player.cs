using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using PhoneApp1;

namespace PhoneApp1
{
    [Table]
    public class player
    {

        [Column(CanBeNull = false, IsPrimaryKey = true)]
        public string pl_name
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public string pl_pwrd
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public int lvl_1_sc
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public int lvl_2_sc
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public int lvl_3_sc
        {
            get;
            set;
        }


        [Column(CanBeNull = true)]
        public string lvl_1_ht
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public string lvl_2_ht
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public string lvl_3_ht
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public int rank
        {
            get;
            set;
        }


        [Column(CanBeNull = true)]
        public bool corr_5
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public bool corr_3
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public bool corr_10
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public bool rn_1
        {
            get;
            set;
        }
    }
}