using CS_Project.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Project.Collection
{
    // --- interact with elements only by keys ---
    public class DictionaryCollection<T>: IEnumerable<KeyValuePair<int, T>> where T: IAirportObj
    {
        // Keys
        // Plane key     - is plane number
        // Passanger key - is passport number
        private Dictionary<int, T> collection;
        public T this[int key]
        {
            get { return collection[key]; }
            set { collection[key] = value; }
        }

        #region constructor

        public DictionaryCollection()
        {
            this.collection = new Dictionary<int, T>();
        }

        #endregion

        #region addDel

        public void Del(int key)
        {
            try
            {
                this.collection.Remove(key);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Incorect key!");
            }
        }

        public void Add(int key, T obj)
        {
            try
            {
                this.collection.Add(key, obj);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
            }
        }
        #endregion

        #region print

        #region printOneObj

        public void PrintOne(int key)
        {
            collection[key].Print(key);
        }

        #endregion
        
        public void PrintAll()
        {
            if(IsEmpy())
            {
                Console.Clear();
                Console.WriteLine("Collection is empty!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                return;
            }
            else
            {
                var i = 0;
                foreach (KeyValuePair<int, T> item in collection)
                {
                    i++;
                    Console.WriteLine("===============================");
                    Console.WriteLine("             #{0}                ", i);
                    Console.WriteLine("===============================");
                    item.Value.Print(item.Key);
                }
            }
        }

        #endregion

        #region checkMethod

        public bool IsEmpy()
        {
            if (collection.Count == 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public bool ContainsKey(int key)
        {
            return collection.ContainsKey(key);
        }
        public bool ContainsValue(T value)
        {
            return collection.ContainsValue(value);
        }

        #endregion

        #region IEnumerable

        public IEnumerator<KeyValuePair<int, T>> GetEnumerator()
        {
            return collection.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        #endregion IEnumerator

       
    }
}
