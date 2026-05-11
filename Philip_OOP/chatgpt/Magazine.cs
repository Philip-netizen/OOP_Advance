using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatgpt
{
    public class Magazine : LibraryItem
    {
        public string IssueNumber { get; private set; }

        public Magazine(int id, string title, string issueNumber) : base(id, title)
        { 
            IssueNumber = issueNumber;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"THIS ITEM IS A MAGAZINE | Id: {Id} | Title: {Title} | IssueNumber: {IssueNumber}");
        }
    }
}
