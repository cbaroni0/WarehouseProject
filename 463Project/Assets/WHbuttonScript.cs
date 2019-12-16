// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WHbuttonScript : MonoBehaviour
{
    public void ReturnButton()
    {
        SceneManager.LoadScene(3);
    }
}
