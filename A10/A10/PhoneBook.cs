using System;
using System.Linq;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class Contact
    {
        public string Name;
        public int Number;

        public Contact(string name, int number)
        {
            Name = name;
            Number = number;
        }
    }

    public class PhoneBook : Processor
    {
        public PhoneBook(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string[], string[]>)Solve);

        public string[] Solve(string [] commands)
        {
            string[] book = new string[10000000];
            List<string> result = new List<string>();
            foreach(var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var args = toks.Skip(1).ToArray();
                int number = int.Parse(args[0]);
                switch (cmdType)
                {
                    case "add":
                        Add(args[1], number,book);
                        break;
                    case "del":
                        Delete(number,book);
                        break;
                    case "find":
                        result.Add(Find(number,book));
                        break;
                }
            }
            return result.ToArray();
        }

        public void Add(string name, int number,string[] book)
        {
            book[number-1] = name;
        }

        public string Find(int number, string[] book)
        {
            if (book[number-1] != null)
                return book[number-1];
            return "not found";
        }

        public void Delete(int number, string[] book)
        {
            book[number-1] = null;
        }
    }
}
