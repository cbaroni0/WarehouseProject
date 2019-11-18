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

    public Material mainMat;
    public Material specMat;

    // Start is called before the first frame update
    void Start()
    {
        string line;

        //loading warehouse
        StreamReader file = new StreamReader("Assets/Files/pack.txt");
        line = file.ReadLine();
        Debug.Log(line);
        string[] words = line.Split(' ');
        //width height length added to x y z
        whX = float.Parse(words[1]);
        whY = float.Parse(words[2]);
        whZ = float.Parse(words[3]);
        //set scale/size of warehouse
        warehouse = GetComponent<Transform>();
        warehouse.localScale = new Vector3(whX, whY, whZ);
        //set position of warehouse
        warehouse.localPosition = new Vector3(whX / 2, whY / 2, whZ / 2);

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
            //cube.transform.position = new Vector3(float.Parse(words2[3]) + (cube.transform.localScale.x * 0.5f) - (whX * 0.5f), float.Parse(words2[4]) + (cube.transform.localScale.y * 0.5f) - (whY * 0.5f), float.Parse(words2[5]) + (cube.transform.localScale.z * 0.5f) - (whZ * 0.5f));
            float x = float.Parse(words2[3]) + cube.transform.localScale.x / 2;
            float y = float.Parse(words2[4]) + cube.transform.localScale.y / 2;
            float z = float.Parse(words2[5]) + cube.transform.localScale.z / 2;
            cube.transform.position = new Vector3(x, y, z);

            //cube.transform.position = new Vector3(float.Parse(words2[3]) - (cube.transform.localScale.x) + (whX * 0.5f), float.Parse(words2[4]) - (cube.transform.localScale.y) + (whY * 0.5f), float.Parse(words2[5]) - (cube.transform.localScale.z) + (whZ * 0.5f));
            cubes.Add(cube);
            if (words2[6] == "false")
            {
                cubes[cubes.Count - 1].GetComponent<MeshRenderer>().material = mainMat;
            }
            else
            {
                cubes[cubes.Count - 1].GetComponent<MeshRenderer>().material = specMat;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
