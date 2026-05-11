using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatgpt
{
    //======== Repository Pattern ========
    public class LibraryRepository : ILibrary
    {
        private List<LibraryItem> items = new List<LibraryItem>();

        public void AddItem(LibraryItem libraryItem)
        {
            if (items.Any(e => e.Id == libraryItem.Id))
                throw new Exception("Item with the same ID already exists.");
            items.Add(libraryItem);
        }

        public List<LibraryItem> GetAllItems()
        {
            return items;
        }

        public LibraryItem GetItemById(int id)
        {
            return items.FirstOrDefault(item => item.Id == id);
        }

        public LibraryItem BorrowItem(int id)
        {
            var item = GetItemById(id);
            if (item != null && !item.IsBorrowed)
            {
                item.Borrow();
                return item;
            }
            return null;
        }

        public LibraryItem ReturnItem(int id)
        {
            var item = GetItemById(id);
            if (item != null && item.IsBorrowed)
            {
                item.Return();
                return item;
            }
            return null;
        }
    }
}