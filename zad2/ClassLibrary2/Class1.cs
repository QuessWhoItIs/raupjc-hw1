using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    public interface IGenericList <X>
    {
        /// <summary >
        /// Adds an item to the collection .
        /// </ summary >
        void Add(X item);
        /// <summary >
        /// Removes the first occurrence of an item from the collection .
        /// If the item was not found , method does nothing .
        /// </ summary >
        bool Remove(X item);
        /// <summary >
        /// Removes the item at the given index in the collection .
        /// </ summary >
        bool RemoveAt(int index);
        X GetElement(int index);
        /// <summary >
        /// Returns the index of the item in the collection .
        /// If item is not found in the collection , method returns -1.
        /// </ summary >
        int IndexOf(X item);
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
        bool Contains(X item);
    }
    public class GenericList <X> : IGenericList <X>
    {
        private X[] _internalstorage;
        private int brojac = 0;

        public GenericList()
        {
            _internalstorage = new X[4];
        }
        public GenericList(int Size)
        {
            if (Size <= 0)
            {
                Console.WriteLine("Nemogu kreirati listu negativne veličine");
                Console.ReadLine();
            }
            else
            {
                _internalstorage = new X[Size];

            }
        }

        public void Add(X item)
        {
            if (brojac >= _internalstorage.Length)
            {
                var temp = new X[(_internalstorage.Length) * 2];
                Array.Copy(_internalstorage, temp, _internalstorage.Length);
                _internalstorage = temp;
            }

            _internalstorage[brojac] = item;
            brojac++;
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
            _internalstorage[_internalstorage.Length - 1] = default(X);
            brojac--;
            return true;
        }
        public bool Remove(X item)
        {
            for (int i =0; i < _internalstorage.Length; i++)
            {
                if (_internalstorage[i].Equals(item))
                {
                    return RemoveAt(i);
                }
            }
            return false;
        }



        public X GetElement(int index)
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

        public int IndexOf(X item)
        {
            for (int i = 0; i < _internalstorage.Length; i++)
            {
                if (_internalstorage[i].Equals(item))
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

        public bool Contains(X item)
        {
            if (IndexOf(item) >= 0)
                return true;

            return false;
        }
    }
}
