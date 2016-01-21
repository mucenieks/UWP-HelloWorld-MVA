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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StupendousStylesChallange.Assets
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CoffeePage : Page
    {
        public CoffeePage()
        {
            this.InitializeComponent();
        }

        /*
        private void MyCalendarView_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            var selectedDates = sender.SelectedDates.Select(P => P.Date.Month.ToString() + "/" + P.Date.Day.ToString()).ToArray();
            var values = string.Join(", ", selectedDates);
            CalendarViewResultTextBlock.Text = values;
        }
        */
        private void MenuFlyout_Closed(MenuFlyout sender, ContextMenuEventArgs e)
        {
            /*
            var selectedRoast = sender.GetValue.ToString();
                Select(P => P.Date.Month.ToString() + "/" + P.Date.Day.ToString()).ToArray();
            var values = string.Join(", ", selectedDates);
            CalendarViewResultTextBlock.Text = values;
            */
        }

    }
    }
}
