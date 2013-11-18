using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Ch.Epyx.WindMobile.WP8.Resources;
using System.IO.IsolatedStorage;

namespace Ch.Epyx.WindMobile.WP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            (ApplicationBar.Buttons[0] as ApplicationBarIconButton).Text = AppResources.AppBarSearchText;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            (this.DataContext as Core.Viewmodel.IMainViewModel).Init();

            SystemTray.ProgressIndicator = new ProgressIndicator()
            {
                Text = "WindMobile",
                IsVisible = true,
                IsIndeterminate = false,
            };
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (IsolatedStorageSettings.ApplicationSettings.Contains("LocationConsent"))
            {
                // User has opted in or out of Location
                return;
            }
            else
            {
                MessageBoxResult result =
                    MessageBox.Show(AppResources.LocationConsentDetailText, AppResources.LocationConsentTitleText, MessageBoxButton.OKCancel);

                if (result == MessageBoxResult.OK)
                {
                    IsolatedStorageSettings.ApplicationSettings["LocationConsent"] = true;
                }
                else
                {
                    IsolatedStorageSettings.ApplicationSettings["LocationConsent"] = false;
                }

                IsolatedStorageSettings.ApplicationSettings.Save();
                // TODO settings to change this after
            }
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is Pivot)
            {
                if ((sender as Pivot).SelectedIndex == 0)
                {
                    VisualStateManager.GoToState(this, "BackgroundVisible", true);
                }
                else
                {
                    VisualStateManager.GoToState(this, "BackgroundCollapsed", true);
                }
            }
        }

        private void searchStation_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/SearchPage.xaml", UriKind.Relative));
        }
    }
}