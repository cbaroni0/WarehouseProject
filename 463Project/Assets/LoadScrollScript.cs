using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WarehouseSimulator;
using System.IO;
using UnityEngine.UI;
using System;

public class LoadScrollScript : MonoBehaviour
{
    public GameObject prefab;

    public GameObject parent; //Content item from LoadScrollView
    private void Start()
    {
        string path = "Assets/Files/data.txt";
        string line;
        List<Warehouse> wh = new List<Warehouse>();

        //loading warehouses into list
        StreamReader file = new StreamReader(path);
        while ((line = file.ReadLine()) != "end")
        {
            string[] words = line.Split(' ');
            wh.Add(new Warehouse(Int32.Parse(words[0]), Int32.Parse(words[1]), Int32.Parse(words[2]), Int32.Parse(words[3])));
        }

        for (int i = 0; i < wh.Count; i++)
        {
            GameObject newItem = Instantiate(prefab) as GameObject;
            newItem.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = wh[i]._ID.ToString();
            string text = wh[i]._Width.ToString() + "x" + wh[i]._Height.ToString() + "x" + wh[i]._Length.ToString();
            Debug.Log(text);
            newItem.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = text;
            newItem.transform.SetParent(parent.transform, false);
        }

    }
}
