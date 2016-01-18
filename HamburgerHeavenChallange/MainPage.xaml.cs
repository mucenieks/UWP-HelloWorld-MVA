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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HamburgerHeavenChallange
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
            MyFrame.Navigate(typeof(Financial));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MyFrame.CanGoBack)
                {
                    MyFrame.GoBack();
                    BackButton.Visibility=Visibility.Visible;
                }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FinancialListBoxItem.IsSelected) {
                PageTitleTextBlock.Text = "Financial";
                MyFrame.Navigate(typeof(Financial));
            }
            else if (FoodListBoxItem.IsSelected) {
                PageTitleTextBlock.Text = "Food";

                MyFrame.Navigate(typeof(Food));
            }
        }

        /*
        private void MyFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (MyFrame.CanGoBack)
            {
                BackButton.Visibility = Visibility.Visible;
            } else {
                BackButton.Visibility = Visibility.Collapsed;
            }
        }
        */

        private void MyFrame_LayoutUpdated(object sender, object e)
        {
            if (MyFrame.CanGoBack)
            {
                BackButton.Visibility = Visibility.Visible;
            }
            else {
                BackButton.Visibility = Visibility.Collapsed;
            }
        }
    }
}
