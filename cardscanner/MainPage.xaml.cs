using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace cardscanner
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            bool connected = false; 
            scanCard.Clicked += (s, e) =>
            {
                App.CardScanner.Present();
                if (!connected)
                {
                    connected = true; 
                    App.CardScanner.ScanningDone += (s1, e1) =>
                    {
                        Console.WriteLine(e1.ToString());
                    };
                }
            };

        }
    }
}
