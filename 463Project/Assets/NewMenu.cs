// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;
using WarehouseSimulator;
using UnityEngine.SceneManagement;

public class NewMenu : MonoBehaviour
{
    private List<Warehouse> wh = new List<Warehouse>();
    private string path = "Assets/Files/data.txt";
    public Text id;
    public Text height;
    public Text length;
    public Text width;

    public void Start()
    {
        load_warehouse();
    }

    public void toWarehouse()
    {
        string i = id.text.ToString();
        string h = height.text.ToString();
        string l = length.text.ToString();
        string w = width.text.ToString();
        Debug.Log(i + w + h + l);
        if (!string.IsNullOrEmpty(i) && !string.IsNullOrEmpty(l) &&
            !string.IsNullOrEmpty(w) && !string.IsNullOrEmpty(h))
        {
            wh.Add(new Warehouse(Int32.Parse(id.text.ToString()), Int32.Parse(width.text.ToString()),
                Int32.Parse(height.text.ToString()), Int32.Parse(length.text.ToString())));

            save();
            
            PlayerPrefs.SetInt("loadWH", Int32.Parse(i));
            SceneManager.LoadScene(3);
        }
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void load_warehouse()
    {
        string line;

        //loading warehouses into list
        StreamReader file = new StreamReader(path);
        while ((line = file.ReadLine()) != "end")
        {
            Debug.Log(line);
            string[] words = line.Split(' ');
            wh.Add(new Warehouse(Int32.Parse(words[0]), Int32.Parse(words[1]), Int32.Parse(words[2]), Int32.Parse(words[3])));
        }
        //loading items into warehouses
        for (int i = 0; i < wh.Count; i++)
        {
            while ((line = file.ReadLine()) != "end")
            {
                Debug.Log(line);
                string[] words = line.Split(' ');
                wh[i].items.Add(new WarehouseItem(Int32.Parse(words[0]), Int32.Parse(words[1]), Int32.Parse(words[2]), Int32.Parse(words[3])));
            }

        }
        file.Close();
    }

    public void save()
    {
        StreamWriter outFile = new StreamWriter(path, false);
        //write warehouses
        for (int i = 0; i < wh.Count; i++)
        {
            string whStr = wh[i]._ID.ToString() + " " + wh[i]._Width.ToString() + " " + wh[i]._Height.ToString() + " " + wh[i]._Length.ToString();
            Debug.Log(whStr);
            outFile.WriteLine(whStr);
        }
        outFile.WriteLine("end");

        //write items
        for (int i = 0; i < wh.Count; i++)
        {
            for (int j = 0; j < wh[i].items.Count; j++)
            {
                string itemStr = wh[i].items[j]._Dim1.ToString() + " " + wh[i].items[j]._Dim2.ToString() + " " + wh[i].items[j]._Dim3.ToString() + " " + wh[i].items[j]._Qty.ToString();
                outFile.WriteLine(itemStr);
            }
            outFile.WriteLine("end");
        }
        outFile.Close();
    }

}
