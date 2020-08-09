using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomListProject;

namespace CustomListClassTest
{
    [TestClass]
    public class UnitTestZip
    {
        [TestMethod]
        public void OutputIsOfCorrectCount()
        {
            // arrange
            CustomList<int> myCustomList1 = new CustomList<int>();
            CustomList<int> myCustomList2 = new CustomList<int>();
            int expectedCount = 6;

            //act
            myCustomList1.Add(10);
            myCustomList1.Add(5);
            myCustomList1.Add(8);
            myCustomList2.Add(3);
            myCustomList2.Add(2);
            myCustomList2.Add(9);

            CustomList<int> result = CustomList<int>.Zip(myCustomList1, myCustomList2);
            //assert
            Assert.AreEqual(expectedCount, result.Count);
        }

        [TestMethod]
        public void AlternatesElementsFromEachArray()
        {
            // arrange
            CustomList<int> myCustomList1 = new CustomList<int>();
            CustomList<int> myCustomList2 = new CustomList<int>();
            int expectedElement = 4;

            //act
            myCustomList1.Add(1);
            myCustomList1.Add(3);
            myCustomList1.Add(5);

            myCustomList2.Add(2);
            myCustomList2.Add(4);
            myCustomList2.Add(6);

            CustomList<int> result = CustomList<int>.Zip(myCustomList1, myCustomList2);
            //assert
            Assert.AreEqual(expectedElement, result[3]);
        }

        [TestMethod]
        public void SuccesfullyZipsTwoListsOfDifferentLengthCountCheck()
        {
            // arrange
            CustomList<int> myCustomList1 = new CustomList<int>();
            CustomList<int> myCustomList2 = new CustomList<int>();
            int expectedCount = 8;

            //act
            myCustomList1.Add(10);
            myCustomList1.Add(5);
            myCustomList1.Add(8);

            myCustomList2.Add(3);
            myCustomList2.Add(5);
            myCustomList2.Add(1);
            myCustomList2.Add(2);
            myCustomList2.Add(9);

            CustomList<int> result = CustomList<int>.Zip(myCustomList1, myCustomList2);
            //assert
            Assert.AreEqual(expectedCount, result.Count);
        }

        [TestMethod]
        public void CapacityExpandsWhenExceededDuringZip()
        {
            // arrange
            CustomList<int> myCustomList1 = new CustomList<int>();
            CustomList<int> myCustomList2 = new CustomList<int>();
            int expectedCapacity = 8;

            //act
            myCustomList1.Add(10);
            myCustomList1.Add(5);
            myCustomList1.Add(3);

            myCustomList2.Add(3);
            myCustomList2.Add(2);
            myCustomList2.Add(9);

            CustomList<int> result = CustomList<int>.Zip(myCustomList1, myCustomList2);
            //assert
            Assert.AreEqual(expectedCapacity, result.Capacity);
        }

        [TestMethod]
        public void ReturnsListIdenticalToInputIfOneInputListIsEmpty()
        {
            // arrange
            CustomList<int> myCustomList1 = new CustomList<int>();
            CustomList<int> myCustomList2 = new CustomList<int>();
            int expectedElement = 8;

            //act
            myCustomList1.Add(10);
            myCustomList1.Add(5);
            myCustomList1.Add(8);
            myCustomList1.Add(6);

            CustomList<int> result = CustomList<int>.Zip(myCustomList1, myCustomList2);
            //assert
            Assert.AreEqual(expectedElement, result[2]);
        }
    }
}
