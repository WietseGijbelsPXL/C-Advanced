using LibraryManager.Application.Abstractions;
using LibraryManager.Domain.Common;
using LibraryManager.Domain.Entities;

namespace LibraryManager.Infrastructure.Repositories
{
    public class ItemRepository : ILibraryItemRepository
    {
        private readonly List<LibraryItem> _items = new List<LibraryItem>();

        public ItemRepository()
        {
            LoadSampleData();
        }

        public void Add(LibraryItem item)
        {
            _items.Add(item);
        }

        public IEnumerable<LibraryItem> GetAll()
        {
            return _items.OrderBy(i => i.Title).ToList();
        }

        public LibraryItem GetById(Guid id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                throw new KeyNotFoundException($"No library item found with ID: {id}");
            return item;
        }

        public void Update(LibraryItem updatedItem)
        {
            var index = _items.FindIndex(i => i.Id == updatedItem.Id);
            if (index == -1)
                throw new KeyNotFoundException($"No library item found with ID: {updatedItem.Id}");
            _items[index] = updatedItem;
        }

        private void LoadSampleData()
        {
            _items.Add(new Book(
                Guid.NewGuid(),
                "The Great Gatsby",
                1925,
                "A1-01",
                "Classic Fiction",
                "978-0-7432-7356-5",
                "F. Scott Fitzgerald"
            ));

            _items.Add(new Book(
                Guid.NewGuid(),
                "1984",
                1949,
                "A1-02",
                "Dystopian Fiction",
                "978-0-452-28423-4",
                "George Orwell"
            ));

            _items.Add(new Book(
                Guid.NewGuid(),
                "To Kill a Mockingbird",
                1960,
                "A1-03",
                "Classic Fiction",
                "978-0-06-112008-4",
                "Harper Lee"
            ));

            _items.Add(new Book(
                Guid.NewGuid(),
                "Harry Potter and the Philosopher's Stone",
                1997,
                "A2-01",
                "Fantasy",
                "978-0-7475-3269-9",
                "J.K. Rowling"
            ));

            _items.Add(new Book(
                Guid.NewGuid(),
                "The Hobbit",
                1937,
                "A2-02",
                "Fantasy",
                "978-0-547-92822-7",
                "J.R.R. Tolkien"
            ));

            _items.Add(new Book(
                Guid.NewGuid(),
                "Pride and Prejudice",
                1813,
                "A1-04",
                "Romance",
                "978-0-14-143951-8",
                "Jane Austen"
            ));

            _items.Add(new Book(
                Guid.NewGuid(),
                "The Catcher in the Rye",
                1951,
                "A1-05",
                "Classic Fiction",
                "978-0-316-76948-0",
                "J.D. Salinger"
            ));

            _items.Add(new Book(
                Guid.NewGuid(),
                "The Da Vinci Code",
                2003,
                "B1-01",
                "Thriller",
                "978-0-307-47427-7",
                "Dan Brown"
            ));

            _items.Add(new Book(
                Guid.NewGuid(),
                "The Hunger Games",
                2008,
                "B2-01",
                "Science Fiction",
                "978-0-439-02348-1",
                "Suzanne Collins"
            ));

            _items.Add(new Book(
                Guid.NewGuid(),
                "The Lord of the Rings",
                1954,
                "A2-03",
                "Fantasy",
                "978-0-618-64561-5",
                "J.R.R. Tolkien"
            ));

            _items.Add(new Book(
                Guid.NewGuid(),
                "Brave New World",
                1932,
                "A1-06",
                "Dystopian Fiction",
                "978-0-06-085052-4",
                "Aldous Huxley"
            ));

            _items.Add(new Book(
                Guid.NewGuid(),
                "The Chronicles of Narnia",
                1950,
                "A2-04",
                "Fantasy",
                "978-0-06-076489-1",
                "C.S. Lewis"
            ));

            _items.Add(new Book(
                Guid.NewGuid(),
                "Dune",
                1965,
                "B2-02",
                "Science Fiction",
                "978-0-441-17271-9",
                "Frank Herbert"
            ));

            _items.Add(new Book(
                Guid.NewGuid(),
                "The Alchemist",
                1988,
                "B1-02",
                "Adventure",
                "978-0-06-112241-5",
                "Paulo Coelho"
            ));

            _items.Add(new Book(
                Guid.NewGuid(),
                "The Shining",
                1977,
                "B1-03",
                "Horror",
                "978-0-307-74365-9",
                "Stephen King"
            ));

            _items.Add(new Game(
                Guid.NewGuid(),
                "The Legend of Zelda: Breath of the Wild",
                2017,
                "G1-01",
                "Action-Adventure",
                12,
                "Nintendo Switch"
            ));

            _items.Add(new Game(
                Guid.NewGuid(),
                "Red Dead Redemption 2",
                2018,
                "G1-02",
                "Action-Adventure",
                18,
                "PlayStation 4"
            ));

            _items.Add(new Game(
                Guid.NewGuid(),
                "The Witcher 3: Wild Hunt",
                2015,
                "G2-01",
                "RPG",
                18,
                "PC"
            ));

            _items.Add(new Game(
                Guid.NewGuid(),
                "Minecraft",
                2011,
                "G3-01",
                "Sandbox",
                7,
                "Multi-platform"
            ));

            _items.Add(new Game(
                Guid.NewGuid(),
                "God of War",
                2018,
                "G1-03",
                "Action-Adventure",
                18,
                "PlayStation 4"
            ));

            _items.Add(new Game(
                Guid.NewGuid(),
                "Super Mario Odyssey",
                2017,
                "G3-02",
                "Platformer",
                7,
                "Nintendo Switch"
            ));

            _items.Add(new Game(
                Guid.NewGuid(),
                "Elden Ring",
                2022,
                "G2-02",
                "Action RPG",
                16,
                "PlayStation 5"
            ));

            _items.Add(new Game(
                Guid.NewGuid(),
                "Halo Infinite",
                2021,
                "G4-01",
                "First-Person Shooter",
                16,
                "Xbox Series X"
            ));

            _items.Add(new Game(
                Guid.NewGuid(),
                "Animal Crossing: New Horizons",
                2020,
                "G3-03",
                "Simulation",
                3,
                "Nintendo Switch"
            ));

            _items.Add(new Game(
                Guid.NewGuid(),
                "Cyberpunk 2077",
                2020,
                "G2-03",
                "Action RPG",
                18,
                "PC"
            ));

            _items.Add(new Game(
                Guid.NewGuid(),
                "Horizon Forbidden West",
                2022,
                "G2-04",
                "Action RPG",
                16,
                "PlayStation 5"
            ));

            _items.Add(new Game(
                Guid.NewGuid(),
                "Ghost of Tsushima",
                2020,
                "G1-04",
                "Action-Adventure",
                18,
                "PlayStation 4"
            ));

            _items.Add(new Game(
                Guid.NewGuid(),
                "Stardew Valley",
                2016,
                "G3-04",
                "Simulation",
                7,
                "Multi-platform"
            ));

            _items.Add(new Game(
                Guid.NewGuid(),
                "Gran Turismo 7",
                2022,
                "G5-01",
                "Racing",
                3,
                "PlayStation 5"
            ));

            _items.Add(new Game(
                Guid.NewGuid(),
                "Forza Horizon 5",
                2021,
                "G5-02",
                "Racing",
                3,
                "Xbox Series X"
            ));

            _items.Add(new Magazine(
                Guid.NewGuid(),
                "National Geographic",
                2023,
                "M1-01",
                "Science & Nature",
                245
            ));

            _items.Add(new Magazine(
                Guid.NewGuid(),
                "Time Magazine",
                2023,
                "M1-02",
                "News & Politics",
                12
            ));

            _items.Add(new Magazine(
                Guid.NewGuid(),
                "Scientific American",
                2023,
                "M2-01",
                "Science",
                328
            ));

            _items.Add(new Magazine(
                Guid.NewGuid(),
                "Forbes",
                2023,
                "M3-01",
                "Business",
                156
            ));

            _items.Add(new Magazine(
                Guid.NewGuid(),
                "Wired",
                2023,
                "M2-02",
                "Technology",
                89
            ));

            _items.Add(new Magazine(
                Guid.NewGuid(),
                "The Economist",
                2023,
                "M3-02",
                "Economics & Politics",
                4521
            ));

            _items.Add(new Magazine(
                Guid.NewGuid(),
                "PC Gamer",
                2023,
                "M4-01",
                "Gaming",
                378
            ));

            _items.Add(new Magazine(
                Guid.NewGuid(),
                "Edge",
                2023,
                "M4-02",
                "Gaming",
                395
            ));

            _items.Add(new Magazine(
                Guid.NewGuid(),
                "Nature",
                2023,
                "M2-03",
                "Science",
                615
            ));

            _items.Add(new Magazine(
                Guid.NewGuid(),
                "Popular Science",
                2023,
                "M2-04",
                "Science & Technology",
                142
            ));

            _items.Add(new Magazine(
                Guid.NewGuid(),
                "Vogue",
                2023,
                "M5-01",
                "Fashion",
                1328
            ));

            _items.Add(new Magazine(
                Guid.NewGuid(),
                "Sports Illustrated",
                2023,
                "M6-01",
                "Sports",
                2847
            ));
        }
    }
}
