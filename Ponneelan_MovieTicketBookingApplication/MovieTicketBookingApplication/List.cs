namespace MovieTicketBookingApplication
{
    public partial class List<Type>
    {
        private int _count;
        private int _capacity;
        private Type[] _array;
        public int  Count { get{return _count;}}
        public Type this [int i] { get{return _array[i];} set{_array[i] = value;} }
        
        

        public List()
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
            if (_capacity == _count)
            {
                GrowSize();
            }
            _array[_count] = data;
            _count++;
        }

        private void GrowSize()
        {
            _capacity *= 2;
            Type[] tempArray = new Type[_capacity];

            for (int i = 0 ; i < _count ; i++ )
            {
                tempArray[i] = _array[i];
            }
            _array = tempArray;
        }
        
        
    }
}