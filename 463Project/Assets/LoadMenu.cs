using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;
using WarehouseSimulator;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    private List<Warehouse> wh = new List<Warehouse>();
    public void Start()
    {
        string path = "Assets/Files/data.txt";
        string line;

        //loading warehouses into list
        StreamReader file = new StreamReader(path);
        while ((line = file.ReadLine()) != "end")
        {
            string[] words = line.Split(' ');
            wh.Add(new Warehouse(Int32.Parse(words[0]), Int32.Parse(words[1]), Int32.Parse(words[2]), Int32.Parse(words[3])));
        }
    }
    public void backToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public Text infield;
    public void toWarehouse()
    {
        string input = infield.text.ToString();
        Debug.Log(input);
        bool correct = false;
        //checks if user input is correct
        for(int i = 0; i < wh.Count; i++)
        {
            if( input == wh[i]._ID.ToString())
            {
                correct = true;
            }
        }

        if(correct)
        {
            PlayerPrefs.SetInt("loadWH", Int32.Parse(input));
            SceneManager.LoadScene(3);
        }
    }

    public void loadWarehouse()
    {
        SceneManager.LoadScene(4);
    }
}
