using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YCloud.Mobile.Pages.Directory
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DirectoryPage : ContentPage
    {
        public DirectoryPage()
        {
            InitializeComponent();

            directoryItems.ItemsSource = new List<string>()
            {
                "asdsad", "asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad", "asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad","asdsad"
            };
        }
    }
}