using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomListProject
{
    public class CustomList<T> : IEnumerable
    {
        //member variables
        T[] customListArray;
        private int capacity;
        public int Capacity { get => capacity; set => capacity = value; }
        private int count;
        public int Count { get => count; }
        public T this[int index] { get => customListArray[index]; set => customListArray[index] = value; }

        //ctor
        public CustomList()
        {
            count = 0;
            capacity = 4;
            customListArray = new T[4];
        }
        //Will need to add specific overloads for eah type of array
        //0 for Int, Double, Float, 

        //member methods

        public void Add(T item)
        {
            if (count == capacity)
            {
                ChangeCapacity();
            }
            customListArray[count] = item;
            count++;

        }

        public T[] ZeroOrNullArray(T[] temp)
        {
            for (int i = 0; i < Capacity; i++)
            {
                temp[i] = default;
            }
            return temp;
        }
        public T[] CopyContents(T[] blank, T[] copy)
        {
            for (int i = 0; i < copy.Length; i++)
            {
                blank[i] = copy[i];
            }
            return blank;
        }
        public void ChangeCapacity()
        {
            Capacity *= 2;
            T[] tempArray = new T[Capacity];

            tempArray = ZeroOrNullArray(tempArray);
            tempArray = CopyContents(tempArray, customListArray);
            customListArray = tempArray;
        }


        public void Remove(T elementToRemove)
        {
            bool hasRemovedElement = false;
            //bool for if the element exists
            int j = 0;
            T[] customListArrayRemove = new T[capacity];

            for (int i = 0; i <= count; i++)
            {
                if (!customListArray[i].Equals(elementToRemove))
                {
                    customListArrayRemove[j] = customListArray[i];
                    j++;
                }
                else if ((customListArray[i].Equals(elementToRemove) && (!hasRemovedElement)))
                {
                    hasRemovedElement = true;
                    count--;
                }
                else if (customListArray[i].Equals(elementToRemove) && hasRemovedElement)
                {
                    customListArrayRemove[j] = customListArray[i];
                    j++;
                }

            }
            CopyContents(customListArray, customListArrayRemove);
        }

        public override string ToString()
        {
            string outputString = "";
            string toAdd = "";
            for (int i = 0; i <= Count-1; i++)
            {
                if (i == Count-1)
                {
                    toAdd = customListArray[i].ToString();
                    outputString += toAdd;
                }
                else
                {
                    toAdd = customListArray[i].ToString();
                    outputString += toAdd + ",";
                }
            }
            return outputString;
        }

        public static CustomList<T> operator +(CustomList<T> listOne, CustomList<T> listTwo)
        {
            CustomList<T> resultList = new CustomList<T>();
            for (int i = 0; i <= listOne.Count - 1; i++)
            {
                resultList.Add(listOne[i]);
            }
            for (int j = 0; j <= listTwo.Count - 1; j++)
            {
                resultList.Add(listTwo[j]);
            }
            return resultList;
        }

        public static CustomList<T> operator -(CustomList<T> listOne, CustomList<T> listTwo)
        {
            for (int i = 0; i < listTwo.Count; i++)
            {
                while(listOne.Contains(listTwo[i]))
                {
                    listOne.Remove(listTwo[i]);
                }
               
            }
            return listOne;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (customListArray[i].Equals(item))
                {
                    return true;
                } 
            }
            return false;
        }

        public IEnumerator GetEnumerator()
        {
            for(int index = 0; index < count; index++)
            {
                yield return customListArray[index];
            }
        }
       
        public static CustomList<T> Zip(CustomList<T> listOne, CustomList<T> listTwo)
        {
            CustomList<T> outputList = new CustomList<T>();
            int countOne = 0;
            int countTwo = 0;

            while (countOne != listOne.count || countTwo != listTwo.count)
            {
                if (countOne != listOne.count)
                {
                    outputList.Add(listOne[countOne]);
                    countOne++;
                }
                if (countTwo != listTwo.count)
                {
                    outputList.Add(listTwo[countTwo]);
                    countTwo++;
                }
            }
            return outputList;
        }

        public static CustomList<int> Sort(CustomList<int> myCustomList) 
        {
            int placeholder;
            for (int i = 0; i < myCustomList.count - 1; i++)
            {
                for (int j = 0; j < myCustomList.Count - 1; j++)
                {
                    if (myCustomList[j] > myCustomList[j + 1])
                    {
                        placeholder = myCustomList[j + 1];
                        myCustomList[j+1] = myCustomList[j];
                        myCustomList[j] = placeholder;
                    }
                }
            }
            return myCustomList;
        }
        public static CustomList<char> Sort(CustomList<char> myCustomList)
        {
            char placeholder;
            for (int i = 0; i < myCustomList.count - 1; i++)
            {
                for (int j = 0; j < myCustomList.Count - 1; j++)
                {
                    if (myCustomList[j] > myCustomList[j + 1])
                    {
                        placeholder = myCustomList[j + 1];
                        myCustomList[j + 1] = myCustomList[j];
                        myCustomList[j] = placeholder;
                    }
                }
            }
            return myCustomList;
        }
    }

}
//look into ICompare/IComparer interface
//sorting w/ C# using compare
