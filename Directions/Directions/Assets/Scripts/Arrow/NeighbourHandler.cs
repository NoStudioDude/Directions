using UnityEngine;
using System.Collections;

public class NeighbourHandler : MonoBehaviour
{
    public ArrowScript parentArrow;
    Transform neighbourSpawner;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Spawner" && neighbourSpawner == null)
        {
            neighbourSpawner = col.transform;
            col.GetComponent<SpawnerManager>().isSpawner = false;

        }else if (col.tag == "Arrow" && !parentArrow.Equals(col.GetComponent<ArrowScript>()))
        {
            parentArrow.neighbourArrow = col.transform;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        parentArrow.neighbourArrow = null;
    }
}
