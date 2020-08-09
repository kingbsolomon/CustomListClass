using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomListProject;

namespace CustomListClassTest
{
    [TestClass]
    public class UnitTestBubbleSort
    {
        [TestMethod]
        public void LastValueIsLargestValue()
        {
            // arrange
            CustomList<int> myCustomList = new CustomList<int>();
            int expectedElement = 8;

            //act
            myCustomList.Add(8);
            myCustomList.Add(1);
            myCustomList.Add(4);
            myCustomList.Add(7);

            CustomList<int> result = CustomList<int>.Sort(myCustomList);
            //assert
            Assert.AreEqual(expectedElement, result[3]);
        }

        [TestMethod]

        public void FirstValueIsSmallestValue()
        {
            // arrange
            CustomList<int> myCustomList = new CustomList<int>();
            int expectedElement = 1;

            //act
            myCustomList.Add(8);
            myCustomList.Add(1);
            myCustomList.Add(3);
            myCustomList.Add(4);
            myCustomList.Add(7);

            CustomList<int> result = CustomList<int>.Sort(myCustomList);
            //assert
            Assert.AreEqual(expectedElement, result[0]);
        }

        [TestMethod]
        public void SuccesfullySortsWithMultipleSameValues()
        {
            // arrange
            CustomList<int> myCustomList = new CustomList<int>();
            int expectedElement = 8;

            //act
            myCustomList.Add(8);
            myCustomList.Add(1);
            myCustomList.Add(1);
            myCustomList.Add(7);
            myCustomList.Add(8);
            myCustomList.Add(7);

            CustomList<int> result = CustomList<int>.Sort(myCustomList);
            //assert
            Assert.AreEqual(expectedElement, result[4]);
        }

        [TestMethod]
        public void ReturnsSameListIfAlreadySorted()
        {
            // arrange
            CustomList<int> myCustomList = new CustomList<int>();
            int expectedElement = 3;

            //act
            myCustomList.Add(1);
            myCustomList.Add(2);
            myCustomList.Add(3);
            myCustomList.Add(4);
            myCustomList.Add(5);

            CustomList<int> result = CustomList<int>.Sort(myCustomList);
            //assert
            Assert.AreEqual(expectedElement, result[2]);
        }

       [TestMethod]

        public void SuccessfullySortsListOfChars()
        {
            // arrange
            CustomList<char> myCustomList = new CustomList<char>();
            char expectedElement = 'f';

            //act
            myCustomList.Add('o');
            myCustomList.Add('z');
            myCustomList.Add('r');
            myCustomList.Add('f');

            CustomList<char> result = CustomList<char>.Sort(myCustomList);
            //assert
            Assert.AreEqual(expectedElement, result[0]);
        }
    }
}
