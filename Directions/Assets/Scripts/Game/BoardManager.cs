using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }


    public int columns = 8;
    public int rows = 8;
    int[] randomRotations = new int[4];
    [HideInInspector]public Count wallCount = new Count(5, 9);
    [HideInInspector]public Count foodCount = new Count(1, 5);

    public GameObject arrowTiles;
    public GameObject[] pointsTiles;
    public TouchHandler touchHandler;

    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    void InitialiseList()
    {
        gridPositions.Clear();

        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }


    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        boardHolder.gameObject.AddComponent<TouchHandler>();

        var step = 1.5f;

        for (float x = -1.5f; x < columns + 1; x+=step)
        {
            for (float y = 1.5f; y <= rows + 1; y+=step)
            {
                if ((x == -1 && y == rows + 1) || (x == columns + 1 && y == rows + 1))
                    continue;
                else
                {
                    GameObject toInstantiate;
                    Quaternion rot;

                    if (x == -1.5f || y == rows + 1 )
                    {
                        if (y == rows + 1 & x == -1.5f)
                            continue;
                        else
                        {
                            toInstantiate = pointsTiles[Random.Range(0, pointsTiles.Length)];
                            rot = Quaternion.identity;
                        }
                    }
                    else
                    {
                        toInstantiate = arrowTiles;
                        rot = RandomRotation();
                    }

                    
                    GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), RandomRotation()) as GameObject;
                    instance.name = instance.tag + " [x:" + x + ";y:" + y + "]";
                    if (instance.tag == "Arrow")
                        instance.GetComponent<ArrowScript>().currentRotation = (int)rot.eulerAngles.z;

                    instance.transform.SetParent(boardHolder);
                }
            }
        }
    }


    Quaternion RandomRotation()
    {
        int intRotation = Random.Range(0, 4);

        return Quaternion.Euler(new Vector3(0, 0, randomRotations[intRotation]));
    }


    /*void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }*/



    public void SetupScene()
    {
        randomRotations[0] = 0;
        randomRotations[1] = 90;
        randomRotations[2] = 180;
        randomRotations[3] = 270;

        BoardSetup();
        InitialiseList();

    }

    void Start()
    {
        SetupScene();
    }

}

