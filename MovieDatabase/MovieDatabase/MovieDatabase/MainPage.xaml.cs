using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MovieDatabase
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //Creates the table on the display page of the app
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Movie>();
                //Reads in the movie values to the table
                var movie = conn.Table<Movie>().ToList();
                MovieListView.ItemsSource = movie;
            }
        }
        //Navigates to AddMovie Page
        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddMovie());
        }
    }
}
