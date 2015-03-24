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
using System.Data.Linq;
using PhoneApp1;

namespace PhoneApp1
{
    public class PlayerDataContext : DataContext
    {
        public PlayerDataContext(string connectionString)
            : base(connectionString)
        {
        }
        public Table<player> Players
        {
            get
            {
                return this.GetTable<player>();
            }
        }
    }
}