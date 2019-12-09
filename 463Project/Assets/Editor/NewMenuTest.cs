using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using WarehouseSimulator;
using System;
using System.IO;

namespace Tests
{
    public class NewMenuTest
    {
        private List<Warehouse> wh_test = new List<Warehouse>();
        public string path = "Assets/Files/data1.txt";

        [Test]
        public void SaveAndLoadTest()
        {
            toWarehouse(); //<- save() is called in this method
            load_warehouse();
            Assert.AreEqual(5, wh_test[0]._ID);
            Assert.AreEqual(8, wh_test[0]._Width);
            Assert.AreEqual(6, wh_test[0]._Height);
            Assert.AreEqual(7, wh_test[0]._Length);

        }

        public void toWarehouse()
        {
            var nm = new NewMenu();
            //test scenario
            string i = "5";
            string h = "6";
            string l = "7";
            string w = "8";
            Debug.Log(i + w + h + l);
            if (!string.IsNullOrEmpty(i) && !string.IsNullOrEmpty(l) &&
                !string.IsNullOrEmpty(w) && !string.IsNullOrEmpty(h))
            {
                wh_test.Add(new Warehouse(Int32.Parse(i), Int32.Parse(w),
                    Int32.Parse(h), Int32.Parse(l)));
                save();
            }
        }

        public void load_warehouse()
        {
            string line;
            StreamReader file1 = new StreamReader(path);
            while ((line = file1.ReadLine()) != "end")
            {
                Debug.Log(line);
                string[] words = line.Split(' ');
                wh_test.Add(new Warehouse(Int32.Parse(words[0]), Int32.Parse(words[1]), Int32.Parse(words[2]), Int32.Parse(words[3])));
            }

        }

        public void save()
        {
            StreamWriter outFile = new StreamWriter(path, false);
            //write warehouses
            for (int i = 0; i < wh_test.Count; i++)
            {
                string whStr = wh_test[i]._ID.ToString() + " " + wh_test[i]._Width.ToString() + " " + wh_test[i]._Height.ToString() + " " + wh_test[i]._Length.ToString();
                Debug.Log(whStr);
                outFile.WriteLine(whStr);
            }
            outFile.WriteLine("end");
            outFile.Close();
        }

    }
}