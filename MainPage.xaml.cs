using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.ViewManagement;
using Windows.UI.Popups;
using Windows.UI.Core;
using Windows.System;
using System.Collections.ObjectModel;

namespace App1
{
    /// <summary>
    /// The main page that handles all the downloading and playing.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // User's Settings
        static public bool WaitForSelection = false;
        static public string Quantity = "Videos";
        static public string Media = "Audio";
        static public int Quality = 100;

        /// <summary>
        /// Class to hold the variables of a download
        /// </summary>
        public class TitleToDownload
        {
            public string Title { get; set; }
            public string Quantity = MainPage.Quantity;
            public string Media = MainPage.Media;
            public int Quality = MainPage.Quality;
            public int Percentage = 0;
            public bool IsPaused = true;
        }

        // List to keep track of all that's been downloaded
        static public ObservableCollection<TitleToDownload> DownloadingTitles = new ObservableCollection<TitleToDownload>();

        // Initializing Function
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Function to prepare a title for download
        /// </summary>
        /// <param name="NewTitle">Title of the YouTube video or audio to download</param>
        public void PrepareDownload(string NewTitle)
        {
            MainPage.TitleToDownload NewDownload = new MainPage.TitleToDownload();
            NewDownload.Title = NewTitle;
            DownloadingTitles.Add(NewDownload);
            NowDownloadingCollection.ItemsSource = DownloadingTitles;
        }

        /// <summary>
        /// Function that is called in the event that a user presses one of the media settings.
        /// Used to select whether to download whole videos or just their audio.
        /// </summary>
        /// <param name="sender">The media radio button that was pressed.</param>
        /// <param name="e"></param>
        private void MediaRadioButton_Changed(object sender, RoutedEventArgs e)
        {
            Media = Convert.ToString( ( (RadioButton)sender ).Tag );
        }

        /// <summary>
        /// Function that is called in the event that a user adjusts the quality slider.
        /// Used to select the quality of the download.
        /// </summary>
        /// <remarks>
        /// Quality is on a scale from 0% to 100%, the available qualities are divided.
        /// For example, in the case that only two are available, Low or High, less than 50% would be Low and greater than or equal to 50% would be high.
        /// </remarks>
        /// <param name="sender">The quality slider.</param>
        /// <param name="e"></param>
        private void Slider_QualityChanged(object sender, RoutedEventArgs e)
        {
            Quality = Convert.ToInt16( ( (Slider)sender ).Value );
        }

        /// <summary>
        /// Function that is called in the event that a user presses one of the quantity settings.
        /// Used to select whether to look for videos or whole playlists.
        /// </summary>
        /// <param name="sender">The quantity radio button that was pressed.</param>
        /// <param name="e"></param>
        private void QuantityRadioButton_Changed(object sender, RoutedEventArgs e)
        {
            Quantity = Convert.ToString( ( (RadioButton)sender ).Tag );
        }

        /// <summary>
        /// Function that is called in the event that a user checks or unchecks the wait for option.
        /// Used to select whether the download starts instantly or waits for the user to press play.
        /// </summary>
        /// <param name="sender">The wait for checkbox.</param>
        /// <param name="e"></param>
        private void WaitForCheckbox_Changed(object sender, RoutedEventArgs e)
        {
            WaitForSelection = Convert.ToBoolean(((CheckBox)sender).IsChecked);
        }

        /// <summary>
        /// Function that is called in the event that a user presses enter or return inside the title textbox.
        /// Used to start or queue a download, depending on the wait for variable.
        /// </summary>
        /// <param name="sender">The title textbox.</param>
        /// <param name="e"></param>
        private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if(e.Key == VirtualKey.Enter)
            {
                TextBox titleBox = (TextBox)sender;
                PrepareDownload(Convert.ToString(titleBox.Text));
                titleBox.Text = "";
            }
        }
    }

}

namespace Converters
{
    public class BooleanBitmapConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool IsPaused = (bool)value;
            if (IsPaused == true)
            {
                return "5";
            }
            else
            {
                return "10";
            }
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
