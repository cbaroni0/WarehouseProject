using System.Collections;
using System.Collections.Generic;
using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using WarehouseSimulator;

namespace Tests
{
    public class InputWHDimTest
    {
        int chosen_test;

        [Test]
        public void StartLoadedWarehouseTest()
        {
            //loading warehouse scenario
            List<Warehouse> wh_test = new List<Warehouse>();
            wh_test.Add(new Warehouse(10, 25, 15, 18));
            wh_test.Add(new Warehouse(101, 100, 10, 50));
            wh_test.Add(new Warehouse(6, 35, 20, 50));
            wh_test.Add(new Warehouse(1, 5, 7, 6));
            wh_test.Add(new Warehouse(60, 15, 12, 75));
            wh_test.Add(new Warehouse(99, 25, 33, 55));

            for (int i = 0; i < wh_test.Count; i++)
            {
                if (wh_test[i]._ID == 6)
                {
                    chosen_test = i;
                }
            }
            Assert.AreEqual(2, chosen_test);

            
            bool runAlg_test = false;
            bool fillTable_test = false;

            //no item
            wh_test[0].items.Add(new WarehouseItem(8, 12, 25, 2));
            wh_test[1].items.Add(new WarehouseItem(6, 16, 27, 7));
            if (wh_test[chosen_test].items.Count != 0)
            {
                runAlg_test = true;
                fillTable_test = true;
            }
            Assert.IsFalse(runAlg_test);
            Assert.IsFalse(fillTable_test);

            //has item
            wh_test[chosen_test].items.Add(new WarehouseItem(10, 15, 20, 6)); //loading items scenario
            if (wh_test[chosen_test].items.Count != 0)
            {
                runAlg_test = true;
                fillTable_test = true;
            }
            Assert.IsTrue(runAlg_test);
            Assert.IsTrue(fillTable_test);
        }

        [Test]
        public void IncrementAndDecrementTest()
        {
            int itemAt_test;
            List<Warehouse> wh_test = new List<Warehouse>();
            wh_test.Add(new Warehouse(10, 25, 15, 18));
            wh_test.Add(new Warehouse(101, 100, 10, 50));
            wh_test.Add(new Warehouse(6, 35, 20, 50));
            wh_test[0].items.Add(new WarehouseItem(8, 12, 25, 2));
            wh_test[1].items.Add(new WarehouseItem(6, 16, 27, 7));
            wh_test[1].items.Add(new WarehouseItem(6, 16, 27, 1));
            wh_test[2].items.Add(new WarehouseItem(10, 15, 20, 6));
            wh_test[2].items.Add(new WarehouseItem(10, 15, 20, 9));
            wh_test[2].items.Add(new WarehouseItem(10, 15, 20, 2));

            //increment
            itemAt_test = 1;
            chosen_test = 2;
            if (wh_test[chosen_test].items.Count > itemAt_test)
            {
                wh_test[chosen_test].items[itemAt_test]._Qty += 1;
            }
            Assert.AreEqual(9 + 1, wh_test[chosen_test].items[itemAt_test]._Qty);

            //decrement
            itemAt_test = 0;
            chosen_test = 1;
            if (wh_test[chosen_test].items.Count > itemAt_test)
            {
                wh_test[chosen_test].items[itemAt_test]._Qty -= 1;
            }
            Assert.AreEqual(7 - 1, wh_test[chosen_test].items[itemAt_test]._Qty);
        }

        [Test]
        public void AddAndDeleteItemTest()
        {
            int lengthInput_test = 5;
            int widthInput_test = 6;
            int heightInput_test = 7;
            int quantityInput_test = 8;
            int itemAt_test = 1;
            List<Warehouse> wh_test = new List<Warehouse>();
            wh_test.Add(new Warehouse(10, 25, 15, 18));
            wh_test.Add(new Warehouse(101, 100, 10, 50));
            wh_test.Add(new Warehouse(6, 35, 20, 50));
            chosen_test = 2;

            //add item
            if (!string.IsNullOrEmpty(lengthInput_test.ToString()) && !string.IsNullOrEmpty(widthInput_test.ToString()) &&
            !string.IsNullOrEmpty(heightInput_test.ToString()) && !string.IsNullOrEmpty(quantityInput_test.ToString()))
            {
                int len = Int32.Parse(lengthInput_test.ToString());
                int wid = Int32.Parse(widthInput_test.ToString());
                int hi = Int32.Parse(heightInput_test.ToString());
                int qty = Int32.Parse(quantityInput_test.ToString());
                wh_test[chosen_test].items.Add(new WarehouseItem(wid, hi, len, qty)); //items[0]
            }
            Assert.AreEqual(6, wh_test[chosen_test].items[0]._Dim1);
            Assert.AreEqual(7, wh_test[chosen_test].items[0]._Dim2);
            Assert.AreEqual(5, wh_test[chosen_test].items[0]._Dim3);
            Assert.AreEqual(8, wh_test[chosen_test].items[0]._Qty);

            //delete item
            wh_test[2].items.Add(new WarehouseItem(10, 15, 20, 6)); //items[1] -> removed later
            wh_test[2].items.Add(new WarehouseItem(11, 16, 21, 9)); //items[2]
            wh_test[2].items.Add(new WarehouseItem(12, 17, 22, 2)); //items[3]

            if (wh_test[chosen_test].items.Count > itemAt_test)
            {
                wh_test[chosen_test].items.RemoveAt(itemAt_test);
            }
            Assert.AreEqual(11, wh_test[chosen_test].items[itemAt_test]._Dim1);
            Assert.AreEqual(16, wh_test[chosen_test].items[itemAt_test]._Dim2);
            Assert.AreEqual(21, wh_test[chosen_test].items[itemAt_test]._Dim3);
            Assert.AreEqual(9, wh_test[chosen_test].items[itemAt_test]._Qty);
        }
    }
}