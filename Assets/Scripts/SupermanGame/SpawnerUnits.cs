using System.Collections.Generic;
using UnityEngine;

public class SpawnerUnits
{
    private GameObject[] units;
    private int numberOfUnits;
    private GameObject leftWall;
    private GameObject rightWall;
    private GameObject upWall;
    private GameObject downWall;
    public List<GameObject> unitsList;

    public SpawnerUnits(GameObject[] objects,int numberOfObjects,GameObject lW,GameObject rW,GameObject uW,GameObject dW)
    {
        units =objects;
        numberOfUnits = numberOfObjects;
        leftWall = lW;
        rightWall = rW;
        upWall = uW;
        downWall = dW;
    }

    public void Spawn()
    {
        unitsList = new List<GameObject>();
        for (int i = 0; i < numberOfUnits; i++)
        {
            int randomUnit = Random.Range(0, units.Length);
            float randomX = Random.Range(leftWall.transform.position.x, rightWall.transform.position.x);
            float randomZ = Random.Range(downWall.transform.position.z, upWall.transform.position.z);
            Vector3 randomPosition = new Vector3(randomX,0.5f,randomZ);
            unitsList.Add(Object.Instantiate(units[randomUnit],randomPosition,Quaternion.identity));
        }
    }
}
