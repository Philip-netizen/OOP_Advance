using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace chatgpt
{
    // ========= Abstraction (Base Class) ========
    public abstract class LibraryItem
    {
        public string Title { get; private set; } // encapsulated
        public int Id { get; private set; } // encapsulated
        public bool IsBorrowed { get; private set; } // encapsulated

        protected LibraryItem(int id, string title) // protected constructor
        {
            Id = id;
            Title = title;
        }
        public abstract void DisplayInfo(); // abstract method has no body but it is required to have to its child class. this is also to support polymorphism
        public virtual void Borrow() // virtual method has a body whic is required to implement on its child class
        {
            IsBorrowed = true;
        }
        public virtual void Return() // virtual method has a body whic is required to implement on its child class
        {
            IsBorrowed = false;
        }
    }
}
