﻿// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void newWarehouse()
    {
        SceneManager.LoadScene(1);
    }

    public void loadWarehouse()
    {
        SceneManager.LoadScene(2);
    }
    
}
