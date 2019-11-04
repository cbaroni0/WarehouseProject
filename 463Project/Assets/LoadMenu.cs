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
    public void backToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public Text infield;
    public void toWarehouse()
    {
        string input = infield.text.ToString();
        Debug.Log(input);
        PlayerPrefs.SetInt("loadWH", Int32.Parse(input));
        SceneManager.LoadScene(3);
    }

    public void loadWarehouse()
    {
        SceneManager.LoadScene(4);
    }
}
