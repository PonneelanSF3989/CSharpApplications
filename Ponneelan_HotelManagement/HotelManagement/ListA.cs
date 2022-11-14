using System;
using System.Collections;

namespace HotelManagement
{
    public partial class List<Type> : IEnumerable, IEnumerator
    {
        int i ;

        public object Current {get {return _array[i];}}
        public IEnumerator GetEnumerator()
        {
            i = -1;
            return (IEnumerator) this;
        }

        public bool MoveNext()
        {
            if (i < _count -1)
            {
                ++i;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            i = -1;
        }
    }
}