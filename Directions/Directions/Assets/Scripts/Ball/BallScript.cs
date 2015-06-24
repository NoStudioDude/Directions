using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public float speed = 5f;

    Vector3 targetPosition = Vector3.zero;
    Vector3 currentPosition = Vector3.zero;

    void Start()
    {
        currentPosition = transform.position;
    }


    void Update()
    {
        if (targetPosition != Vector3.zero && currentPosition != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        }

        currentPosition = transform.position;
    }

    public void SendTo(Transform to)
    {
        currentPosition = to.position;
    }
}
