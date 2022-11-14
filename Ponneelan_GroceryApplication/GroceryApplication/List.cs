using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryApplication
{
    public partial class ListA <Type>
    {
        private  int _count ;
        private  int _capacity ;
        public int  Count { get{return _count;} }
        public int Capacity { get{return _capacity;}}
        
        
        private Type[] _array; 
        public Type this[int i] { get{return _array[i];} set{_array[i] = value;} }

        public ListA()
        {
            _count = 0;
            _capacity = 4;
            _array = new Type [_capacity];
        }

        public ListA (int size)
        {
            _count = 0;
            _capacity = size;
            _array = new Type [_capacity];
        }

        public void Add(Type data)
        {
            if (_capacity == _count)
            {
               GrowSize();
            }
            _array[_count] = data;
            _count++;

        }

        void GrowSize()
        {
            _capacity *= 2;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            _array = temp; 
        }

        public void AddRange(ListA<Type> data)
        {
            Type[] temp = new Type[_capacity];
            for (int i = 0 ; i<_count ; i++ )
            {
                temp[i] = _array[i];
            }
            for (int j = _count ; j < data.Count ; j++)
            {
                temp [j] = data[j];
            }
            _count += data.Count;
            _array = temp;

        }
        
             




        
           
    }
}