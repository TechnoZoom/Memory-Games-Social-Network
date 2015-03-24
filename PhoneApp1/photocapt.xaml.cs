using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Devices;
using System.IO.IsolatedStorage;
using System.IO;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Tasks;

namespace PhoneApp1
{
    public partial class photocapt : PhoneApplicationPage
    {
       
        CameraCaptureTask _cameraTask;
        BitmapImage _imageToBeSaved;
        public string cur_pl_name = (string)IsolatedStorageSettings.ApplicationSettings["cur_uid"];
        
        // Constructor
        public photocapt()
        {
            InitializeComponent();
            _cameraTask = new CameraCaptureTask();
            _cameraTask.Completed += _cameraTask_Completed;

            

        }

        

        private void button_capture_Click(object sender, RoutedEventArgs e)
        {
            _cameraTask.Show();
        }

        void _cameraTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                _imageToBeSaved = new System.Windows.Media.Imaging.BitmapImage();

                _imageToBeSaved.SetSource(e.ChosenPhoto);
                image_result.Source = _imageToBeSaved;
                
            }
        }

        public static BitmapImage LoadImage(string fileName)
        {
            BitmapImage retreivedImage = new BitmapImage();
            using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {

                using (var isoFileStream = isoStore.OpenFile(fileName, System.IO.FileMode.Open))
                    retreivedImage.SetSource(isoFileStream);

                return retreivedImage;
            }
        }

        private void button_loadFromIsolatedStorage_Click(object sender, RoutedEventArgs e)
        {
            image_result.Source = LoadImage("fun.jpg");
        }


        //private void MainPage_Loaded(object sender, RoutedEventArgs e);




        public static void SaveImage(BitmapImage imageToBeSaved, string fileName)
        {
            using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                var wb = new WriteableBitmap(imageToBeSaved);

                using (var isoFileStream = isoStore.CreateFile(fileName))
                    Extensions.SaveJpeg(wb, isoFileStream, wb.PixelWidth, wb.PixelHeight, 0, 100);
                
            }

            
        }

        private void button_saveInIsolatedStorage_Click(object sender, RoutedEventArgs e)
        {
            SaveImage(this._imageToBeSaved, cur_pl_name +".jpg");

            NavigationService.Navigate(new Uri("/mainmenu.xaml", UriKind.Relative));
        }

        
       
    }
}
        