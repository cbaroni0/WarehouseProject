using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class WarehouseTest
    {
        [Test]
        public void WarehouseVariablesTest()
        {
            int test_ID = 10;
            int test_width = 12;
            int test_height = 18;
            int test_length = 15;
            var wh = new WarehouseSimulator.Warehouse(test_ID, test_width, test_height, test_length);
            Assert.AreEqual(3240, wh.Volume);
            Assert.AreEqual(12, wh._Width);
            Assert.AreEqual(18, wh._Height);
            Assert.AreEqual(15, wh._Length);
        }
    }
}