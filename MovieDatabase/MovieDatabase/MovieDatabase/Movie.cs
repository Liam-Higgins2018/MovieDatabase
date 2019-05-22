using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase
{
    public class Movie
    {    //Assigns the id as the primary key to the database and autoincrements it
          [PrimaryKey, AutoIncrement]
          public int id { get; set; } 
        //Gets the movie name value
          public string MovieName { get; set;}
        //Gets the movie director value
          public string MovieDirector { get; set; }
    }
}
