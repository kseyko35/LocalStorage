using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace LocalStorage
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()    {
            InitializeComponent();

            
            mLabel.Text = Preferences.Get("username", ""); // Used Xamarin.Essentials to save primitive data for local storage

            mLabel1.Text = Settings.GeneralSettings; // Used xam.plugins.settings to save primitive data for local storage

            var list = new List<Personal>
            {
               Settings.CurrentUser // Used xam.plugins.settings to save model data for local storage
            };
            lstview.ItemsSource = list;
        }

        void onSave(System.Object sender, System.EventArgs e)
        {
            mLabel.Text = mEntry.Text;
            Preferences.Set("username", mEntry.Text);
        }

        void onDelete(System.Object sender, System.EventArgs e)
        {
            mLabel.Text = "";
            Settings.Delete(); 
        }
        void onSave1(System.Object sender, System.EventArgs e)
        {
            mLabel1.Text = mEntry1.Text;
            Settings.GeneralSettings = mEntry1.Text;
            Settings.CurrentUser = new Personal { Name = "ALI", Money = 200, ImgUrl = "https://picsum.photos/200"};
        }

        void onDelete1(System.Object sender, System.EventArgs e)
        {
            mLabel1.Text = "";
            lstview.ItemsSource = "";
            Settings.Delete();
        }
    }
}
// Download Xam.Plugins.Settings package. It will save primitive data for local storage all phones.
// Settings classi olusturmamiz gerekiyor. Icerisindekiler static olmali cunku uygulamanin her yerinden bu
// classa ulasmak isteyebiliriz. 