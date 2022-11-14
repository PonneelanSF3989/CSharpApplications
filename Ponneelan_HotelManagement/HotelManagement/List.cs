using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public partial class List<Type>
    {
        private int _count;
        private int _capacity;
        private Type[] _array;
        public int Count { get{return _count;} }
        public Type this[int i]{get{return _array[i];} set {_array[i] = value;}}

        public  List()
        {
            _count = 0;
            _capacity = 4;
            _array = new Type[_capacity];
        }
        public List(int size)
        {
            _count = 0;
            _capacity = size;
            _array = new Type[_capacity];
        }

        public void Add(Type data)
        {
            if(_count == _capacity)
            {
                GrowSize();
            }
            _array[_count] = data;
            _count++;
        }
        public void GrowSize()
        {
            _capacity *= 2;
            Type[] tempArray = new Type[_capacity];
            
            for (int i = 0 ; i < _count ; i++)
            {
                tempArray[i] = _array[i];
            }
            _array = tempArray;


        }

        public void AddRange(List<Type> data)
        {
            Type [] tempArray = new Type[_count + data.Count];
            for (int i = 0 ; i < data.Count ; i++)
            {
                tempArray [i] = _array[i];
            }
            for(int i = 0 ; i < data.Count ; i++)
            {
                tempArray [_count + i] = data[i];
            }
            _array = tempArray;
            _count += data.Count;
        }
        
        
    }
}