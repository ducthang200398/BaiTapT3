using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chapter6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            BindingContext = new HomePageViewModel(Navigation);
        }
    }


    public class HomePageViewModel : BindableObject
    {

        private readonly INavigation navigation;

        public Command<string> NavigateCommand
        {
            get;
            set;
        }

        public HomePageViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            NavigateCommand = new Command<string>(NagivigateRequested);
        }


        async void NagivigateRequested(string pageName)
        {
            var pageType = Type.GetType("Chapter6." + pageName);
            Page page = (Page)Activator.CreateInstance(pageType);
            await navigation.PushAsync(page);
        }
    }
}