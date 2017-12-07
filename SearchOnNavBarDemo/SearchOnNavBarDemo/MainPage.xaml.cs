using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SearchOnNavBarDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false); // This removes Navigation Bar

            MyListView.ItemsSource = GetList();
        }

        /// <summary>
        /// Mock data of Persons
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        private static IEnumerable<Person> GetList(string searchText = null)
        {
            List<Person> contacts = new List<Person>
            {
                new Person{Name = "Archie", Detail = "Online", Image = "http://lorempixel.com/100/100/people/2"},
                new Person{Name = "Devlin", Detail = "Online", Image = "http://lorempixel.com/100/100/people/3"},
                new Person{Name = "Ruby", Detail = "Offline", Image = "http://lorempixel.com/100/100/people/1"},
                new Person{Name = "Jena", Detail = "Online", Image = "http://lorempixel.com/100/100/people/4"},
                new Person{Name = "Fin", Detail = "Offline", Image = "http://lorempixel.com/100/100/people/6"},
                new Person{Name = "Gukachata", Detail = "Offline", Image = "http://lorempixel.com/100/100/people/8"},
                new Person{Name = "Falum", Detail = "Online", Image = "http://lorempixel.com/100/100/people/7"},
                new Person{Name = "Christina", Detail = "Offline", Image = "http://lorempixel.com/100/100/people/9"},
                new Person{Name = "Leo", Detail = "Online", Image = "http://lorempixel.com/100/100/people/5"},
            };
            
            return string.IsNullOrEmpty(searchText) ? contacts : contacts
                .Where(c => c.Name.ToLower()
                .StartsWith(searchText.ToLower()));
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Person contact) DisplayAlert("Following", contact.Name, "Ok", "Cancel");
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MyListView.SelectedItem = null;
        }

        private void ListView_OnRefreshing(object sender, EventArgs e)
        {
            MyListView.ItemsSource = GetList();
            MyListView.EndRefresh();
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            MyListView.ItemsSource = GetList(e.NewTextValue);
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NextPage());
        }
    }
}