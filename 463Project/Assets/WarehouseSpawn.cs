using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using WarehouseSimulator;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WarehouseSpawn : MonoBehaviour
{
    private Transform warehouse;
    private float whX, whY, whZ;

    // Start is called before the first frame update
    void Start()
    {
        string line;

        //loading warehouse
        StreamReader file = new StreamReader("Assets/Files/pack.txt");
        line = file.ReadLine();
        Debug.Log(line);
        string[] words = line.Split(' ');
        whX = float.Parse(words[1]);
        whY = float.Parse(words[2]);
        whZ = float.Parse(words[3]);

        warehouse = GetComponent<Transform>();
        warehouse.localScale = new Vector3(whX, whY, whZ);
        List<GameObject> cubes = new List<GameObject>();
        
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.transform.position = new Vector3(0, whY*-0.5f, 0);

        //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //cube.transform.position = new Vector3(0f, 0f, 0f);
        //cube.transform.localScale = new Vector3(10f, 10f, 10f);

        //Material newMat = new Material(Shader.Find("warehouse"));
        //cube.GetComponent<Renderer>().material = newMat;

        GameObject cube;
        //loading items into warehouses
        while ((line = file.ReadLine()) != "end")
        {
            Debug.Log(line);
            string[] words2 = line.Split(' ');

            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(float.Parse(words2[0]), float.Parse(words2[1]), float.Parse(words2[2]));
            cube.transform.position = new Vector3(float.Parse(words2[3]) + (cube.transform.localScale.x * 0.5f) - (whX * 0.5f), float.Parse(words2[4]) + (cube.transform.localScale.y * 0.5f) - (whY * 0.5f), float.Parse(words2[5]) + (cube.transform.localScale.z * 0.5f) - (whZ * 0.5f));
            //cube.transform.position = new Vector3(float.Parse(words2[3]) - (cube.transform.localScale.x) + (whX * 0.5f), float.Parse(words2[4]) - (cube.transform.localScale.y) + (whY * 0.5f), float.Parse(words2[5]) - (cube.transform.localScale.z) + (whZ * 0.5f));
            cubes.Add(cube);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
