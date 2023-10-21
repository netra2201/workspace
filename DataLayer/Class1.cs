using Entity;
namespace DataLayer;
public class DataAccess
{
public static List<Movie> movies = new List<Movie>(){
    new Movie{Id=1,Name="Toofan",Ryear=2021,Rating=3},
    new Movie{Id=2,Name="Ludo",Ryear=2022,Rating=4},
    new Movie{Id=3,Name="Gundey",Ryear=2023,Rating=1},
    new Movie{Id=4,Name="Leo",Ryear=2020,Rating=5},
    new Movie{Id=5,Name="Mersal",Ryear=2021,Rating=5},
};

public List<Movie> GetMovies()
{
    return movies;
}

}
