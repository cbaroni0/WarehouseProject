using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using WarehouseSimulator;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CromulentBisgetti.ContainerPacking;
using CromulentBisgetti.ContainerPacking.Entities;
using CromulentBisgetti.ContainerPacking.Algorithms;

public class InputWHDim : MonoBehaviour
{
    public GameObject prefab;
    public Text itemIDInput;
    public Text lengthInput;
    public Text widthInput;
    public Text heightInput;
    public Text quantityInput;

    private int chosen;
    private string path = "Assets/Files/data.txt";

    public GameObject loadScrollView; //Content item from LoadScrollView

    private List<Warehouse> wh = new List<Warehouse>();
    private void Start()
    {
        load_warehouse();
        runAlg();
        fillTable();
    }
    public void backToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void toWarehouse()
    {
        SceneManager.LoadScene(4);
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
    }
    public void runAlg()
    {
        //finding location of loaded warehouse in warehouse list
        bool temp = true;
        int count = 0;
        while (temp)
        {
            if (wh[count]._ID == PlayerPrefs.GetInt("loadWH"))
            {
                temp = false;
                chosen = count;
            }
            else
            {
                count++;
            }
        }

        List<Container> containers = new List<Container>();
        List<Item> itemsToPack = new List<Item>();
        List<int> algorithms = new List<int>();

        //containers.Add(new Container(id, length, width, height));
        containers.Add(new Container(wh[count]._ID, wh[count]._Length, wh[count]._Width, wh[count]._Height));

        //itemsToPack.Add(new Item(id, dim1, dim2, dim3, quantity));
        for(int i = 0; i < wh[count].items.Count; i++)
        {
            itemsToPack.Add(new Item(i, wh[count].items[i]._Dim1, wh[count].items[i]._Dim2, wh[count].items[i]._Dim3, wh[count].items[i]._Qty));
        }

        //DON'T CHANGE THIS
        algorithms.Add((int)AlgorithmType.EB_AFIT);

        //Results
        List<ContainerPackingResult> result = PackingService.Pack(containers, itemsToPack, algorithms);

        //Writing Packed File
        StreamWriter outFile = new StreamWriter("Assets/Files/pack.txt", false);
        //write warehouse
        string whStr = wh[chosen]._ID.ToString() + " " + wh[chosen]._Length.ToString() + " " + wh[chosen]._Width.ToString() + " " + wh[chosen]._Height.ToString();
        Debug.Log(whStr);
        outFile.WriteLine(whStr);

        //write items
        //Dim1 Dim2 Dim3 CoordX CoordY CoordZ HighlightBool
        int resCount = 0;
        for (int i = 0; i < wh[chosen].items.Count; i++)
        {
            for (int j = 0; j < wh[chosen].items[i]._Qty; j++)
            {
                string itemStr = wh[chosen].items[i]._Dim1.ToString() + " " + wh[chosen].items[i]._Dim2.ToString() + " " + 
                    wh[chosen].items[i]._Dim3.ToString() + " " + result[0].AlgorithmPackingResults[0].PackedItems[resCount + j].CoordX + " " + 
                    result[0].AlgorithmPackingResults[0].PackedItems[resCount + j].CoordY + " " +
                    result[0].AlgorithmPackingResults[0].PackedItems[resCount + j].CoordZ + " " + "false";
                Debug.Log(itemStr);
                outFile.WriteLine(itemStr);
                
            }
            resCount += wh[chosen].items[i]._Qty;
        }
        outFile.WriteLine("end");

        outFile.Close();
    }
    public void fillTable()
    {
        //empty table if not empty
        if( loadScrollView.transform.childCount > 0)
        {
            foreach( Transform child in loadScrollView.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
        //finding location of loaded warehouse in warehouse list
        bool temp = true;
        int count = chosen;


        for (int j = 0; j < wh[count].items.Count; j++) 
        {
            GameObject newItem = Instantiate(prefab) as GameObject;
            newItem.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = j.ToString();
            string text = wh[count].items[j]._Dim1.ToString() + "x" + wh[count].items[j]._Dim2.ToString() + "x" + wh[count].items[j]._Dim3.ToString();
            Debug.Log(text);
            newItem.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = text;
            newItem.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = wh[count].items[j]._Qty.ToString();
            newItem.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = wh[count].items[j]._IsPacked.ToString();
            newItem.transform.SetParent(loadScrollView.transform, false);
        }
    }

    public void increment()
    {
        int itemAt = Int32.Parse(itemIDInput.text.ToString());
        wh[chosen].items[itemAt]._Qty += 1;

        runAlg();
        fillTable();
    }

    public void decrement()
    {
        int itemAt = Int32.Parse(itemIDInput.text.ToString());
        wh[chosen].items[itemAt]._Qty -= 1;

        runAlg();
        fillTable();
    }

    public void deleteItem()
    {
        int itemAt = Int32.Parse(itemIDInput.text.ToString());
        wh[chosen].items.RemoveAt(itemAt);

        runAlg();
        fillTable();
    }

    public void addItem()
    {
        int len = Int32.Parse(lengthInput.text.ToString());
        int wid = Int32.Parse(widthInput.text.ToString());
        int hi = Int32.Parse(heightInput.text.ToString());
        int qty = Int32.Parse(quantityInput.text.ToString());
        wh[chosen].items.Add(new WarehouseItem(len, wid, hi, qty));

        runAlg();
        fillTable();
    }

    public void save()
    {
        StreamWriter outFile = new StreamWriter(path, false);
        //write warehouses
        for (int i = 0; i < wh.Count; i++)
        {
            string whStr = wh[i]._ID.ToString() + " " + wh[i]._Length.ToString() + " " + wh[i]._Width.ToString() + " " + wh[i]._Height.ToString();
            Debug.Log(whStr);
            outFile.WriteLine(whStr);
        }
        outFile.WriteLine("end");

        //write items
        for(int i = 0; i < wh.Count; i ++)
        {
            for(int j = 0; j < wh[i].items.Count; j++)
            {
                string itemStr = wh[i].items[j]._Dim1.ToString() + " " + wh[i].items[j]._Dim2.ToString() + " " + wh[i].items[j]._Dim3.ToString() + " " + wh[i].items[j]._Qty.ToString();
                outFile.WriteLine(itemStr);
            }
            outFile.WriteLine("end");
        }
        outFile.Close();
    }
}
