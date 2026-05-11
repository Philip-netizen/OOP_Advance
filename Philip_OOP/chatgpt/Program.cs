using chatgpt;

class Program
{
    static void Main(string[] args)
    {
        ILibrary repo = new LibraryRepository();
        LibraryService service = new LibraryService(repo);

        while (true)
        {
            Console.WriteLine("\n==== LIBRARY MANAGEMENT SYSTEM ====");
            Console.WriteLine("1. Add Library Item");
            Console.WriteLine("2. Borrow Library Item");
            Console.WriteLine("3. Return Library Item");
            Console.WriteLine("4. View All Library Items");
            Console.WriteLine("5. View Library Item By ID");
            Console.WriteLine("6. Exit");
            Console.Write("Choose option: ");

            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        AddLibraryItem(service);
                        break;

                    case "2":
                        BorrowLibraryItem(service);
                        break;

                    case "3":
                        ReturnLibraryItem(service);
                        break;

                    case "4":
                        service.GetAllItems();
                        break;

                    case "5":
                        DisplayLibraryItemById(service);
                        break;

                    case "6":
                        Console.WriteLine("Exiting system...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }
    }

    static void AddLibraryItem(LibraryService service)
    {
        Console.Write("Enter Library Item ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Title: ");
        string name = Console.ReadLine();

        Console.Write("Magazine or Book: ");
        string type = Console.ReadLine();

        if (type.ToLower() == "magazine")
        {
            Console.Write("Enter Issue Number: ");
            string issueNumber = Console.ReadLine();
            LibraryItem lib = LibraryFactory.CrateLibararyItem("magazine", id, name, issueNumber);
            service.AddLibraryItem(lib);
        }
        else
        {
            Console.Write("Enter Author Name: ");
            string author = Console.ReadLine();
            LibraryItem lib = LibraryFactory.CrateLibararyItem("book", id, name, author);
            service.AddLibraryItem(lib);
        }
        Console.WriteLine("Library item added successfully!");
        return;
    }

    static void BorrowLibraryItem(LibraryService service)
    {
        Console.Write("Enter Library Item ID: ");
        int id = int.Parse(Console.ReadLine());

        service.BorrowItem(id);
    }
    static void ReturnLibraryItem(LibraryService service)
    {
        Console.Write("Enter Library Item ID: ");
        int id = int.Parse(Console.ReadLine());

        service.ReturnItem(id);
    }
    static void DisplayLibraryItemById(LibraryService service)
    {
        Console.Write("Enter Library Item ID: ");
        int id = int.Parse(Console.ReadLine());

        service.GetItemById(id);
    }
}