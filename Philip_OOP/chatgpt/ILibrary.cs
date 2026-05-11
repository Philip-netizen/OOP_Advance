using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatgpt
{
    //========= Interface ========
    public interface ILibrary
    {
        public void AddItem(LibraryItem libraryItem);
        public List<LibraryItem> GetAllItems();
        public LibraryItem GetItemById(int id);
        public LibraryItem BorrowItem(int id);
        public LibraryItem ReturnItem(int id);
    }
}
