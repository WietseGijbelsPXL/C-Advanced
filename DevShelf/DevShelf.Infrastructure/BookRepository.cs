using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevShelf.Application;
using DevShelf.Domain;

namespace DevShelf.Infrastructure
{
    public class BookRepository : IBookRepository
    {
        private List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Clean Code", Author = "Robert C. Martin", Rating = 4.7, Pages = 464, Year = 2008 },
            new Book { Id = 2, Title = "The Pragmatic Programmer", Author = "Andrew Hunt", Rating = 4.6, Pages = 352, Year = 1999 },
            new Book { Id = 3, Title = "Design Patterns", Author = "Erich Gamma", Rating = 4.5, Pages = 395, Year = 1994 },
            new Book { Id = 4, Title = "Refactoring", Author = "Martin Fowler", Rating = 4.4, Pages = 448, Year = 2018 },
            new Book { Id = 5, Title = "Head First C#", Author = "Andrew Stellman", Rating = 4.3, Pages = 720, Year = 2021 },
            new Book { Id = 6, Title = "C# in Depth", Author = "Jon Skeet", Rating = 4.8, Pages = 528, Year = 2019 },
            new Book { Id = 7, Title = "Pro ASP.NET Core", Author = "Adam Freeman", Rating = 4.6, Pages = 1080, Year = 2022 },
            new Book { Id = 8, Title = "You Don't Know JS", Author = "Kyle Simpson", Rating = 4.5, Pages = 278, Year = 2015 },
            new Book { Id = 9, Title = "Effective Java", Author = "Joshua Bloch", Rating = 4.7, Pages = 416, Year = 2018 },
            new Book { Id = 10, Title = "Code Complete", Author = "Steve McConnell", Rating = 4.6, Pages = 960, Year = 2004 },
            new Book { Id = 11, Title = "The Art of Computer Programming", Author = "Donald Knuth", Rating = 4.9, Pages = 672, Year = 1968 },
            new Book { Id = 12, Title = "Algorithms", Author = "Robert Sedgewick", Rating = 4.3, Pages = 992, Year = 2011 },
            new Book { Id = 13, Title = "CLR via C#", Author = "Jeffrey Richter", Rating = 4.6, Pages = 826, Year = 2012 },
            new Book { Id = 14, Title = "Working Effectively with Legacy Code", Author = "Michael Feathers", Rating = 4.5, Pages = 456, Year = 2004 },
            new Book { Id = 15, Title = "The Clean Coder", Author = "Robert C. Martin", Rating = 4.3, Pages = 256, Year = 2011 },
            new Book { Id = 16, Title = "Test-Driven Development", Author = "Kent Beck", Rating = 4.1, Pages = 240, Year = 2002 },
            new Book { Id = 17, Title = "Agile Principles, Patterns, and Practices", Author = "Robert C. Martin", Rating = 4.4, Pages = 552, Year = 2006 },
            new Book { Id = 18, Title = "Soft Skills", Author = "John Sonmez", Rating = 4.3, Pages = 504, Year = 2015 },
            new Book { Id = 19, Title = "The Mythical Man-Month", Author = "Frederick P. Brooks Jr.", Rating = 4.0, Pages = 336, Year = 1975 },
            new Book { Id = 20, Title = "Structure and Interpretation of Computer Programs", Author = "Harold Abelson", Rating = 4.7, Pages = 657, Year = 1996 },
            new Book { Id = 21, Title = "Head First Design Patterns", Author = "Eric Freeman", Rating = 4.5, Pages = 694, Year = 2004 },
            new Book { Id = 22, Title = "JavaScript: The Good Parts", Author = "Douglas Crockford", Rating = 4.2, Pages = 176, Year = 2008 },
            new Book { Id = 23, Title = "Introduction to Algorithms", Author = "Thomas H. Cormen", Rating = 4.4, Pages = 1312, Year = 2009 },
            new Book { Id = 24, Title = "Functional Programming in C#", Author = "Enrico Buonanno", Rating = 4.3, Pages = 360, Year = 2017 },
            new Book { Id = 25, Title = "Blazor in Action", Author = "Chris Sainty", Rating = 4.6, Pages = 384, Year = 2023 },
            new Book { Id = 26, Title = "Entity Framework Core in Action", Author = "Jon P Smith", Rating = 4.4, Pages = 514, Year = 2021 },
            new Book { Id = 27, Title = "ASP.NET Core in Action", Author = "Andrew Lock", Rating = 4.7, Pages = 688, Year = 2021 },
            new Book { Id = 28, Title = "Programming Entity Framework", Author = "Julia Lerman", Rating = 4.3, Pages = 896, Year = 2010 },
            new Book { Id = 29, Title = "LINQ in Action", Author = "Fabrice Marguerie", Rating = 4.1, Pages = 504, Year = 2008 },
            new Book { Id = 30, Title = "C# 10 and .NET 6 – Modern Cross-Platform Development", Author = "Mark J. Price", Rating = 4.4, Pages = 752, Year = 2021 },
            new Book { Id = 31, Title = "Programming .NET MAUI", Author = "Roger Johansson", Rating = 4.2, Pages = 388, Year = 2022 },
            new Book { Id = 32, Title = "Hands-On Design Patterns with C#", Author = "Ghazanfar Ali", Rating = 4.1, Pages = 452, Year = 2020 },
            new Book { Id = 33, Title = "Pro C# 8 with .NET Core 3", Author = "Andrew Troelsen", Rating = 4.3, Pages = 1376, Year = 2020 },
            new Book { Id = 34, Title = "Microservices in .NET", Author = "Christian Horsdal", Rating = 4.0, Pages = 320, Year = 2017 },
            new Book { Id = 35, Title = "Docker for .NET Developers", Author = "Christian Nagel", Rating = 4.2, Pages = 312, Year = 2020 },
            new Book { Id = 36, Title = "Extreme Programming Explained", Author = "Kent Beck", Rating = 4.0, Pages = 190, Year = 2000 },
            new Book { Id = 37, Title = "The Art of Unit Testing", Author = "Roy Osherove", Rating = 4.4, Pages = 312, Year = 2013 },
            new Book { Id = 38, Title = "Metaprogramming in .NET", Author = "Kevin Hazzard", Rating = 4.1, Pages = 368, Year = 2012 },
            new Book { Id = 39, Title = "Concurrency in C#", Author = "Riccardo Terrell", Rating = 4.2, Pages = 464, Year = 2018 },
            new Book { Id = 40, Title = "Reactive Programming with Rx.NET", Author = "Tamir Dresher", Rating = 4.3, Pages = 344, Year = 2017 },
            new Book { Id = 41, Title = "Mastering C#", Author = "Elliot Forbes", Rating = 4.2, Pages = 498, Year = 2019 },
            new Book { Id = 42, Title = "C# Data Structures and Algorithms", Author = "Marwan Alsabbagh", Rating = 4.1, Pages = 382, Year = 2020 },
            new Book { Id = 43, Title = "C# and the .NET Framework", Author = "Peter Drayton", Rating = 4.0, Pages = 450, Year = 2002 },
            new Book { Id = 44, Title = "Developing Windows Applications with C#", Author = "Tom Archer", Rating = 4.1, Pages = 784, Year = 2003 },
            new Book { Id = 45, Title = "Beginning C# Object-Oriented Programming", Author = "Dan Clark", Rating = 4.2, Pages = 440, Year = 2013 },
            new Book { Id = 46, Title = "Unity in Action", Author = "Joseph Hocking", Rating = 4.5, Pages = 400, Year = 2021 },
            new Book { Id = 47, Title = "Learning ASP.NET Core MVC", Author = "Mugilan T. S. Ragupathi", Rating = 4.0, Pages = 350, Year = 2021 },
            new Book { Id = 48, Title = "Programming C# 8.0", Author = "Ian Griffiths", Rating = 4.4, Pages = 800, Year = 2020 },
            new Book { Id = 49, Title = "Getting Started with Blazor", Author = "Toi B. Wright", Rating = 4.3, Pages = 256, Year = 2020 },
            new Book { Id = 50, Title = "ASP.NET Core Web API", Author = "Valerio De Sanctis", Rating = 4.6, Pages = 420, Year = 2022 }
        };

        public IEnumerable<Book> GetBooks()
        {
            return books;
        }
    }
}
