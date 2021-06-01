using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CS_Project;
using CS_Project.Collection;
using CS_Project.AditionalMethods;



namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddToCollectionPlane()
        {
            // arrange 
            int key = 123;
            Plane newVal = new Plane(key);
            DictionaryCollection < Plane > collection = new DictionaryCollection<Plane>();


            // act
            collection.Add(key, newVal);

            // assert
            Assert.AreEqual<Plane>(newVal, collection[key]);
        }



    }
}
