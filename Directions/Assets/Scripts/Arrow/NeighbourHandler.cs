using UnityEngine;
using System.Collections;

public class NeighbourHandler : MonoBehaviour
{

    public ArrowScript parentArrow;
    Transform neighbourArrow;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Arrow" && !parentArrow.Equals(col.GetComponent<ArrowScript>()))
        {
            Transform m_Neighbour = col.GetComponent<Transform>();
            if (m_Neighbour != neighbourArrow)
                neighbourArrow = m_Neighbour;

            parentArrow.neighbourArrow = neighbourArrow;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        neighbourArrow = null;
        parentArrow.neighbourArrow = null;
    }
}
