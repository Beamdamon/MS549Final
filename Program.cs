using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Transactions;

class HT
{   // Creates the Hashtable "Movie List"
    static Hashtable MovieList = new Hashtable();
    
    //Adds a movie into the HT with a random key (1-1000)
    public void addMovie(string key, string movie)
    {
        Random random= new Random();

        movie = Console.ReadLine();
        key = random.Next(1, 1000).ToString();
        MovieList.Add(key, movie);
        Console.WriteLine("The movie was added to your list.");
    }

    //Removes a movie from the list by it's key. If the key does not exist, states it.
    public void removeMovie(string key)
    {
        key = Console.ReadLine();
        if (MovieList.ContainsKey(key)) 
        {
            MovieList.Remove(key);
            Console.WriteLine("The movie was deleted.");
        }
        else
        {
            Console.WriteLine("There is no movie that matches the given key.");
        }
    }

    //Finds a movie by title. If it does not exist, states it.
    public void findMovie(string input)
    {
        bool found = false;
        input = Console.ReadLine();

        foreach (DictionaryEntry movie in MovieList)
        {
            if (movie.Value.ToString() == input)
            {
                Console.WriteLine("Key: " + movie.Key.ToString() + " Title: " + movie.Value.ToString() + " is on your Movie List");
                found = true;
            }
        }
        if (found == false)
        {
            Console.WriteLine("This movie is not on your Movie List");
        }
    }

    //Picks a random movie from the sorted Array list.
    public void pickRandomMovie()
    {
        string[] sortedArray = new string[MovieList.Count];
        int count = 0;

        Console.WriteLine("Your random movie is....  ");
        foreach (DictionaryEntry movie in MovieList)
        {
            sortedArray[count] = movie.Value.ToString();
            count++;
        }
        Array.Sort(sortedArray);
        Random rand = new Random();
        int randomMovie = rand.Next(0, sortedArray.Length);
        Console.WriteLine(sortedArray[randomMovie]);
    }

    //Displays the movies by both their key and their title.
    public void displayKey() 
    {
        Console.WriteLine("Movie List by Key: ");
        string[] sortedArray = new string[MovieList.Count];
        int count = 0;

        foreach (DictionaryEntry movie in MovieList)
        {
            sortedArray[count] = movie.Key + ": Title: " + movie.Value.ToString();
            count++;
        }
        Array.Sort(sortedArray);
        foreach (var item in sortedArray)
        {
            Console.WriteLine(item);
        }
    }

    //Displays the movies in alphabetical order by filling an array with movies and sorting it.
    public void displayABC()
    {
        string[] sortedArray = new string[MovieList.Count];
        int count = 0;

        Console.WriteLine("Movie List in Alphabetical Order: ");
        foreach (DictionaryEntry movie in MovieList)
        {
            sortedArray[count] = movie.Value.ToString();
            count++;
        }
        Array.Sort(sortedArray);
        foreach (var item in sortedArray)
        {
            Console.WriteLine(item);
        }

    }
    public static void Main ()
    {

        HT ht = new HT();
        int num = MovieList.Count;

        string movie = "";
        string key = "";
        int selection = 0;

        //Main Menu and user selection. 1 Adds movie, 2 deletes, 3 Finds, 4 Displays by key, 5 displays by alphabetical, 6 is random movie, 10 closes

        while (selection != 10)
        {
            Console.WriteLine();
            Console.WriteLine("Main Menu");
            Console.WriteLine("Press 1 to add a movie.");
            Console.WriteLine("Press 2 to delete.");
            Console.WriteLine("Press 3 to find a movie.");
            Console.WriteLine("Press 4 to display the movie list by Key");
            Console.WriteLine("Press 5 to display the movie list by title in Alphabetical order.");
            Console.WriteLine("Press 6 to pick a random movie.");
            Console.WriteLine("Press 10 to close the program.");

            int.TryParse(Console.ReadLine(), out selection);
           

            switch (selection) 
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("What movie would you like to add?");
                    ht.addMovie(key, movie);
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine("Please enter the key of the movie that you would like to delete: ");
                    ht.removeMovie(key);
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("Enter the movie that you would like to find:");
                    ht.findMovie(movie);
                    break;
                case 4:
                    Console.WriteLine();
                    ht.displayKey(); 
                    break;
                case 5:
                    Console.WriteLine();
                    ht.displayABC();
                    break;
                case 6:
                    Console.WriteLine();
                    ht.pickRandomMovie();
                    break;
                default:
                    break;
            }
        }
    }
}