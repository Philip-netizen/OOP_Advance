using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatgpt
{
    //======== Inheritance ========
    public class Book : LibraryItem // inherited from LibraryItem
    {
        public string Author { get; private set; } // encapsulation
        public Book(int id, string title, string author) : base(id, title) // constructor the base properties (id, title) should also be passed to child class
                                                                           // because it is own by the parent class
        {
            Author = author;
        }
        public override void DisplayInfo() // Polymorphism..inherited from base class LibraryItem
        {
            Console.WriteLine($"THIS ITEM IS A BOOK | Id: {Id} | Title: {Title} | Author: {Author}");
        }
    }
}
