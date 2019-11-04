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
