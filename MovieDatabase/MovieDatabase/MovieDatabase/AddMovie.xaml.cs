using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieDatabase
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddMovie : ContentPage
	{
		public AddMovie ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Creates a new Movie object and takes in input values from the Movie class
            Movie movie = new Movie()
            {
                MovieName = movieName.Text,
                MovieDirector = movieDirector.Text
            };
            //Using SQLite to create a table and populate each row in the database
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                //Connects to table
               conn.CreateTable<Movie>();
                //Inserts values into database
               var numOfRows = conn.Insert(movie);
                //Displayes success message to the user
                if (numOfRows > 0)
                {
                    DisplayAlert("Success", "Your movie has been added to the database", "OK");
                }
                //Displays error message to the user
                else
                {
                    DisplayAlert("Error", "Your movie has failed to be added to the database", "OK");
                }
                
            }
        }
    }
}