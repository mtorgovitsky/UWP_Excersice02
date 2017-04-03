using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP_Excersice02.Pages;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_Excersice02
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            frmMainApp.Navigate(typeof(HomePage));
        }

        private void btnHamburger_Click(object sender, RoutedEventArgs e)
        {
            mySplit.IsPaneOpen = !mySplit.IsPaneOpen;
        }

        private void lstMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = sender as ListBox;

            switch (lb.SelectedIndex)
            {
                case 0:
                    frmMainApp.Navigate(typeof(HomePage));
                    break;
                case 1:
                    frmMainApp.Navigate(typeof(PowerSettingsPage));
                    break;
                case 2:
                    frmMainApp.Navigate(typeof(FavoritesPage));
                    break;
                case 3:
                    RunAsyncDialog();
                    break;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (frmMainApp.CanGoBack)
            {
                frmMainApp.GoBack();
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (frmMainApp.CanGoForward)
            {
                frmMainApp.GoForward();
            }
        }

        private async void RunAsyncDialog()
        {
            MessageDialog msgClose = new MessageDialog("");

            msgClose.Title = "Closing Confirmation";

            msgClose.Content = "are Yopu sure??!!";

            msgClose.Commands.Add(new UICommand() { Id = 0, Label = "Yes" });
            msgClose.Commands.Add(new UICommand() { Id = 1, Label = "No" });

            IUICommand result = await msgClose.ShowAsync();
            if((int)result.Id == 0)
            {
                Application.Current.Exit();
            }
        }
    }
}
