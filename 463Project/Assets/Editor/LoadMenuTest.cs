using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using WarehouseSimulator;
using System;
using System.IO;

namespace Tests
{
    public class LoadMenuTest
    {
        List<Warehouse> wh_testlist = new List<Warehouse>();

        [Test]
        public void WarehouseLoadingScenarioTest()
        {
            string test_line = "10 25 15 18";
            string[] words = test_line.Split(' ');
            var wh = new Warehouse(Int32.Parse(words[0]), Int32.Parse(words[1]), Int32.Parse(words[2]), Int32.Parse(words[3]));
            Assert.AreEqual(25 * 15 * 18, wh.Volume);
        }

        [Test]
        public void UserInputCheckTest()
        {
            wh_testlist.Add(new Warehouse(10, 25, 15, 18));
            wh_testlist.Add(new Warehouse(100, 100, 10, 50));
            string input = "10";
            Debug.Log(input);
            bool correct1 = false;
            bool correct2 = false;

            if (input == wh_testlist[0]._ID.ToString())
            {
                correct1 = true;
            }
            Assert.IsTrue(correct1);

            if (input == wh_testlist[1]._ID.ToString())
            {
                correct2 = true;
            }
            Assert.IsFalse(correct2);
        }

    }
}