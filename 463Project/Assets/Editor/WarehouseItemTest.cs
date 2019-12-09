using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class WarehouseItemTest
    {
        [Test]
        public void WarehouseItemVariablesTest()
        {
            int test_dim1 = 16;
            int test_dim2 = 10;
            int test_dim3 = 12;
            int test_quantity = 6;
            var wh_item = new WarehouseSimulator.WarehouseItem(test_dim1, test_dim2, test_dim3, test_quantity);
            Assert.AreEqual(1920, wh_item.Volume);
            Assert.AreEqual(16, wh_item._Dim1);
            Assert.AreEqual(10, wh_item._Dim2);
            Assert.AreEqual(12, wh_item._Dim3);
            Assert.AreEqual(6, wh_item._Qty);
        }

    }
}