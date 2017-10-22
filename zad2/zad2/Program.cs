using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    class Program
    {
        public static void ListOfExamples(IGenericList <double>  listOfIntegers)
        {
            listOfIntegers.Add(1.3); // [1]
            listOfIntegers.Add(2.2); // [1 ,2]
            listOfIntegers.Add(3.4); // [1 ,2 ,3]
            listOfIntegers.Add(4.5); // [1 ,2 ,3 ,4]
            listOfIntegers.Add(5.2); // [1 ,2 ,3 ,4 ,5]
            listOfIntegers.RemoveAt(0); // [2 ,3 ,4 ,5]
            listOfIntegers.Remove(5.2);
            Console.WriteLine(listOfIntegers.Count); // 3
            Console.WriteLine(listOfIntegers.Remove(100)); // false
            Console.WriteLine(listOfIntegers.RemoveAt(5)); // false
            listOfIntegers.Clear(); // []
            Console.WriteLine(listOfIntegers.Count); // 0
            Console.ReadLine();
        }

        static void Main(String[] args)
        {
            int i = 5;
            IGenericList <double> lista = new GenericList<double>(i);
            ListOfExamples(lista);
        }
    }
}
