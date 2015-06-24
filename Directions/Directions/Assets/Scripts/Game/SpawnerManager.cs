using UnityEngine;
using System.Collections;

public class SpawnerManager : MonoBehaviour {

    [SerializeField]GameObject[] BallsToSpawn;
    [SerializeField]Transform centerPoint;

    GameObject currentBall;
    [HideInInspector]public SpawnerManager neighbourSpawner;
    [HideInInspector]public bool isSpawner = true;
    bool isRequestingBall;

    float timeToSpawn = 2f;

	void Update () {
        if (isSpawner)
        {
            if (currentBall == null)
            {
                timeToSpawn -= Time.deltaTime;
                if (timeToSpawn <= 0)
                {
                    timeToSpawn = 2f;
                    SpawnBall();
                }
            }
        }
	}

    IEnumerator RequestingBall()
    {
        neighbourSpawner.SendBallTo(transform);

        while (isRequestingBall)
        {
            yield return new WaitForSeconds(1f);
            
        }

        isRequestingBall = false;
        yield return null;
    }

    void SpawnBall()
    {
        int index = Random.Range(0, BallsToSpawn.Length);
        currentBall = Instantiate(BallsToSpawn[index], centerPoint.position, Quaternion.identity) as GameObject;
    }

    public void SendBallTo(Transform target)
    {
        currentBall.GetComponent<BallScript>().SendTo(target);
        currentBall = null;
    }
}