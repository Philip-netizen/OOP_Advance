using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatgpt
{
    //======== Service Layer (SOLID)========
    public class LibraryService
    {
        private readonly ILibrary _libraryRepository;
        public LibraryService(ILibrary libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }
        public void AddLibraryItem(LibraryItem item)
        {
            _libraryRepository.AddItem(item);
        }
        public void GetAllItems()
        {
            var libraryItems = _libraryRepository.GetAllItems();
            if (libraryItems.Count == 0)
            {
                Console.WriteLine("No items in the library.");
                return;
            }
            foreach (var item in libraryItems)
            {
                item.DisplayInfo();
            }
        }
        public void GetItemById(int id)
        {
            var item = _libraryRepository.GetItemById(id);
            if (item == null)
            {
                Console.WriteLine("Item not found.");
                return;
            }
            item.DisplayInfo();
        }
        public void BorrowItem(int id)
        {
            var item = _libraryRepository.BorrowItem(id);
            if (item == null)
            {
                Console.WriteLine("Item not found or already borrowed.");
                return;
            }
            item.DisplayInfo();
        }
        public void ReturnItem(int id)
        {
            var item = _libraryRepository.ReturnItem(id);
            if (item == null)
            {
                Console.WriteLine("Item not found or not currently borrowed.");
                return;
            }
            item.DisplayInfo();
        }
    }
}
