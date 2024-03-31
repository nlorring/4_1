using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class OneDimArray<T> : IEnumerable
        where T : IComparable<T>
    {
        T[] array;
        int capacity;
        int size;


        public OneDimArray(int n = 0, Func<T>? valueprovider = null)
        {
            if (valueprovider == null && size > 0)
            {
                throw new ArgumentNullException(nameof(valueprovider));
            }

            capacity = 7;
            size = n;
            while (capacity < size)
            {
                capacity = capacity * 2 + 1;
            }

            array = new T[capacity];

            for (int i = 0; i < size; i++)
            {
                array[i] = valueprovider();
            }

        }

        public T this[int index]
        {
            get
            {
                if(index > size)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                return array[index];
            }
            set 
            {
                if (index > size)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                array[index] = value;
            }
        }

        public void Add(T value)
        {
            if (capacity <= size)
            {
                capacity = capacity * 2 + 1;
                T[] newArray = new T[capacity];
                array.CopyTo(newArray, 0);
                array = newArray;
            }
            array[size] = value;
            size++;
        }

        public void Pop()
        {
            size--;
            if (capacity > size * 2 + 1)
            {
                capacity = (capacity - 1) / 2;
                Array.Resize(ref array, capacity);
            }
        }
        public void Sort()
        {
            Array.Sort(array, 0, size);
        }
        public int Length
        { get { return size; } }

        public int NormCount(Func<T, bool> condition)
        {
            int count = 0;
            for (int i = 0; i < size; ++i)
            {
                if (condition(array[i]))
                {
                    count++;
                }
            }
            return count;
        }
        public bool OneCount(Func<T, bool> condition)
        {
            for (int i = 0; i < size; ++i)
            {
                if (condition(array[i]))
                {
                    return true;
                }
            }
            return false;
        }
        public bool AllCount(Func<T, bool> condition)
        {
            for (int i = 0; i < size; ++i)
            {
                if (!condition(array[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public bool Inside(T elem)
        {
            for (int i = 0; i < size; ++i)
            {
                if (elem.Equals(array[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsInside(T elem)
        {
            for (int i = 0; i < size; ++i)
            {
                if (elem.Equals(array[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public void SuitableValue(Func<T, bool> condition)
        {
            for (int i = 0; i < size; ++i)
            {
                if (condition(array[i]))
                {
                    Console.WriteLine(array[i]);
                    return;
                }
            }
            Console.WriteLine("Нет ни одного подходящего значения");
            return;
        }

        public void DoSmth(Action<T> smth)
        {
            for (int i = 0; i < size; i++)
            {
                smth(array[i]);
            }
        }

        public T[] AllSuitableValues(Func<T, bool> condition)
        {
            int new_size = 0;
            for (int i = 0; i < size; ++i)
            {
                if (condition(array[i]))
                {
                    new_size++;
                }
            }
            T[] newArray = new T[new_size];
            int s = 0;
            for (int i = 0; i < size; ++i)
            {
                if (condition(array[i]))
                {
                    s++;
                    newArray[s] = array[i];
                }
            }
            return newArray;
        }

        public T[] BackFlip()
        {
            T[] newArr = new T[size];
            int s = 0;
            for (int i = size - 1; i >= 0; --i)
            {
                newArr[s] = array[i];
                s++;
            }
            return newArr;
        }

        public T MinValue()
        {
            T min = array[0];
            for (int i = 0; i < size; i++)
            {
                if (min.CompareTo(array[i]) > 0)
                {
                    min = array[i];
                }
            }
            return min;
        }

        public T MaxValue()
        {
            T max = array[0];
            for (int i = 0; i < size; i++)
            {
                if (max.CompareTo(array[i]) < 0)
                {
                    max = array[i];
                }
            }
            return max;
        }

        public Tprojection ProjectionMax<Tprojection>(Func<T, Tprojection> projector)
            where Tprojection : IComparable<Tprojection>
        {
            Tprojection max = projector(array[0]);
            for (int i = 0; i < size; i++)
            {
                if (max.CompareTo(projector(array[i])) < 0)
                {
                    max = projector(array[i]);
                }
            }
            return max;
        }
        public Tprojection ProjectionMin<Tprojection>(Func<T, Tprojection> projector)
            where Tprojection : IComparable<Tprojection>
        {
            Tprojection min = projector(array[0]);
            for (int i = 0; i < size; i++)
            {
                if (min.CompareTo(projector(array[i])) > 0)
                {
                    min = projector(array[i]);
                }
            }
            return min;
        }

        public OneDimArray<TProj> Project<TProj>(Func<T, TProj> choicer)
            where TProj : IComparable<TProj>
        {
            int i = -1;
            TProj GetProjectValue()
            {
                i++;
                return choicer(this[i]);
            }
            return new OneDimArray<TProj>(size, GetProjectValue);
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public OneDEnum<T> GetEnumerator()
        {
            return new OneDEnum<T>(this);
        }

        public class OneDEnum<Tenum> : IEnumerator
            where Tenum : IComparable<Tenum> 
        {
        public OneDimArray<Tenum> _arr = new OneDimArray<Tenum>();

        int position = -1;

        public OneDEnum(OneDimArray<Tenum> _arr)
        {
            this._arr = _arr;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _arr.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Tenum Current
        {
            get
            {
                try
                {
                    return _arr[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

}
}
