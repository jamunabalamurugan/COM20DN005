using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieIndexerEg
{
    class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        int duration;
        string[] cast = new string[3];

        public string this[int index]
        {
            get { return cast[index]; }
            set { cast[index] = value; }
        }
        public int this[string name]
        {
            get
            {
                int idx = -1;
                for (int i = 0; i < cast.Length; i++)
                {
                    if (name == cast[i])
                        idx = i;
                }
                return idx;
            }
        }

        public Movie()
        {
            Id = 101;
            Name = "ABC";
            Console.WriteLine("Default constructor invoked");
        }
        public Movie(int id, string name)
        {
            Id = id;
            Name = name;
            Console.WriteLine("Parameterized constructor invoked");
        }
        public Movie(int id, string name, int duration)
        {
            Id = id;
            Name = name;
            this.duration = duration;//instance variable = parameter
            Console.WriteLine("Parameterized constructor invoked");
        }
        public static Movie operator +(Movie m1, Movie m2)
        {
            Movie m3 = new Movie();
            m3.Id = m1.Id + m2.Id;
            m3.Name = m1.Name + " " + m2.Name;
            return m3;
        }
        public void PrintMovie()
        {
            Console.WriteLine("Movie ID " + Id);
            Console.WriteLine("Movie Name " + Name);
            Console.WriteLine("The cast details are: ");
            foreach (var item in cast)
            {
                Console.WriteLine(item);
            }
        }


    }

    class UseMovie
    {
        static void Main(string[] args)
        {

            Movie movie = new Movie(20, "Rio");
            movie[0] = "ABC";
            movie[1] = "XYZ";
            movie[2] = "AAC";
            movie.PrintMovie();
            Console.WriteLine("Print the cast is position 1 " + movie[1]);
            //int findIdx = movie["XYZ"];
            Console.WriteLine("The cast is at position " + movie["AAC"]);

            Movie[] movies = new Movie[5];

            movies[0] = new Movie(101, "Gunjan Saxena");
            movies[1] = new Movie(102, "RIO");
            movies[2] = new Movie(103, "Mulan");
            movies[3] = new Movie(104, "Lion King");
            movies[4] = new Movie(105, "Finding Nemo");
            movies[0][0] = "Jhanvi Kapoor";
            movies[0][1] = "Pankaj Tripati";
            foreach (var item in movies)
            {
                item.PrintMovie();
            }

            Console.ReadKey();
        }
    }
}

