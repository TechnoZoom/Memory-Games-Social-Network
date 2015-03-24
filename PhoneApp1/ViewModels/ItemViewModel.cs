using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;


namespace PhoneApp1.ViewModels
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        private string _username;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string UserName
        {
            get
            {
                return _username;
            }
            set
            {
                if (value != _username)
                {
                    _username = value;
                    NotifyPropertyChanged("UserName");
                }
            }
        }

        public string _level1score;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Level1Score
        {
            get
            {
                
                return _level1score;
            }
            set
            {
                if (value != this._level1score)
                {
                    this._level1score = value;
                    NotifyPropertyChanged("Level1Score");
                }
            }
        }
       
        
        //public string _level2score;
        ///// <summary>
        ///// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        ///// </summary>
        ///// <returns></returns>
        //public string Level2Score
        //{
        //    get
        //    {
        //        return _level2score;
        //    }
        //    set
        //    {
        //        if (value != _level2score)
        //        {
        //            _level1score = value;
        //            NotifyPropertyChanged("Level2Score");
        //        }
        //    }
        //}


        //public string _level3score;
        ///// <summary>
        ///// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        ///// </summary>
        ///// <returns></returns>
        //public string Level3Score
        //{
        //    get
        //    {
        //        return _level3score;
        //    }
        //    set
        //    {
        //        if (value != _level3score)
        //        {
        //            _level1score = value;
        //            NotifyPropertyChanged("Level3Score");
        //        }
        //    }
        //}

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