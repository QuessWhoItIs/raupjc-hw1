using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    public interface IIntegerList
    {
        /// <summary >
        /// Adds an item to the collection .
        /// </ summary >
        void Add(int item);
        /// <summary >
        /// Removes the first occurrence of an item from the collection .
        /// If the item was not found , method does nothing and returns false .
        /// </ summary >
        bool Remove(int item);
        /// <summary >
        /// Removes the item at the given index in the collection .
        /// Throws IndexOutOfRange exception if index out of range .
        /// </ summary >
        bool RemoveAt(int index);
        /// <summary >
        /// Returns the item at the given index in the collection .
        /// Throws IndexOutOfRange exception if index out of range .
        /// </ summary >
        int GetElement(int index);
        /// <summary >
        /// Returns the index of the item in the collection .
        /// If item is not found in the collection , method returns -1.
        /// </ summary >
        int IndexOf(int item);
        /// <summary >
        /// Readonly property . Gets the number of items contained in the
        /// </ summary >
        int Count { get; }
        /// <summary >
        /// Removes all items from the collection .
        /// </ summary >
        void Clear();
        /// <summary >
        /// Determines whether the collection contains a specific value .
        /// </ summary >
        bool Contains(int item);
    }
     public class IntegerList : IIntegerList
    {
        private int[] _internalstorage;
        private int brojac = 0;

        public IntegerList()
        {
            _internalstorage = new int[4];
        }
        public IntegerList(int Size)
        {
            if (Size <= 0)
            {
                Console.WriteLine("Nemogu kreirati listu negativne veličine");
                Console.ReadLine();
            }
            else
            {
                _internalstorage = new int[Size];
  
            }
        }

        public void Add(int item)
        {
            if (brojac == _internalstorage.Length)
            {
                int[] temp = _internalstorage;
                _internalstorage = new int[temp.Length * 2];
                Array.Copy(temp, _internalstorage, temp.Length);
            }
                    _internalstorage[brojac] = item;
                    brojac += 1;
        }

        public bool RemoveAt(int index)
        {
            if (index >= brojac)
            {
                return false;
            }
            if (index > _internalstorage.Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = index; i < _internalstorage.Length - 1; i++)
            {
                _internalstorage[i] = _internalstorage[i + 1];
            }
            _internalstorage[_internalstorage.Length - 1] = 0;
            brojac--;
            return true;
        }
        public bool Remove(int item)
        {
            for (int i = 0; i < _internalstorage.Length; i++)
            {
                if (_internalstorage[i] == item)
                {
                    return RemoveAt(i);
                }
            }
            return false;
        }



        public int GetElement(int index)
        {
            if (index < _internalstorage.Length && index >= 0)
            {
                return _internalstorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < _internalstorage.Length; i++)
            {
                if (_internalstorage[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }
        public int Count => brojac;

        public void Clear()
        {
            Array.Clear(_internalstorage, 0, _internalstorage.Length);
            brojac = 0;
        }

        public bool Contains(int item)
        {
            if (IndexOf(item) >= 0)
                return true;

            return false;
        }
    }
}
