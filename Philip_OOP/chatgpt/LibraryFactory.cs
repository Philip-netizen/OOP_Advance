using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace chatgpt
{
    //======== Factory Pattern =========
    public class LibraryFactory
    {
        public LibraryItem CrateLibararyItem(string type, int id, string title, string issueNumber = "", string author = "")
        {
            return type.ToLower() switch
            {
                "book" => new Book(id, title, author),
                "magazine" => new Magazine(id, title, issueNumber),
                _ => throw new Exception("Invalid item type!")
            };
        }
    }
}
