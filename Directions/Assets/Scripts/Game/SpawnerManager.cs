using UnityEngine;
using System.Collections;

public class SpawnerManager : MonoBehaviour {

    [SerializeField]GameObject[] BallsToSpawn;
    [SerializeField]Transform centerPoint;

    public Transform forwardObj;

    GameObject currentBall;

    float timeToMove = 1f;
    float timeToSpawn = 2f;

	void Start () {
	    
	}
	
	void Update () {
        if (currentBall == null)
        {
            timeToSpawn -= Time.deltaTime;
            if (timeToSpawn <= 0)
            {
                timeToSpawn = 2f;
                SpawnBallAtCurrentLocation();
            }
        }
        else
        {
            timeToMove -= Time.deltaTime;
            if (timeToMove <= 0)
            {
                timeToMove = 1f;
                MoveCurrentForward();
            }
        }

	}

    void SpawnBallAtCurrentLocation()
    { 
        
    }

    void MoveCurrentForward()
    {
        currentBall.GetComponent<BallScript>().SendTo(forwardObj);
        currentBall = null;
    }
}
