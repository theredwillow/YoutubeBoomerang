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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // User's Settings
        public bool WaitForSelection = false;
        public string Quantity = "Videos";
        public string Media = "Audio";
        public int Quality = 100;

        public MainPage()
        {
            this.InitializeComponent();
        }

        // Event for handling video or playlist selection
        private void MediaRadioButton_Changed(object sender, RoutedEventArgs e)
        {
            Media = Convert.ToString( ( (RadioButton)sender ).Tag );
        }

        // Event for handling quality level selection
        private void Slider_QualityChanged(object sender, RoutedEventArgs e)
        {
            Quality = Convert.ToInt16( ( (Slider)sender ).Value );
        }

        // Event for handling music or video selection
        private void QuantityRadioButton_Changed(object sender, RoutedEventArgs e)
        {
            Quantity = Convert.ToString( ( (RadioButton)sender ).Tag );
        }

        // Event for handling automatic or manual selection
        private void WaitForCheckbox_Changed(object sender, RoutedEventArgs e)
        {
            WaitForSelection = Convert.ToBoolean(((CheckBox)sender).IsChecked);
        }

        private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {

        }
    }
}
