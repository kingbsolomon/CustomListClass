using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListProject
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<char> newList = new CustomList<char>() { 'f', 'c', 'l', 's', 'b', 'p' };
            CustomList<char>.Sort(newList);
        }
    }
}
