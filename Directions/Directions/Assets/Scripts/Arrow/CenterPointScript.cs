using UnityEngine;
using System.Collections;

public class CenterPointScript: MonoBehaviour
{
    public ArrowScript parentArrow;
    GameObject objBall;
    bool isSendingBall;

    void Start()
    {
        if (parentArrow != null)
            parentArrow.myCenterPoint = transform;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ball")
        {
            objBall = col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Ball")
        {
            objBall = null;
        }
    }

    void Update()
    {
        if (objBall != null & !isSendingBall)
        {
            isSendingBall = true;
        }
    }

    IEnumerable SendBall()
    {
        BallScript ballScript = objBall.GetComponent<BallScript>();
        if (ballScript != null)
        {
            ballScript.SendTo(parentArrow.neighbourArrow);
        }
        yield return new WaitForSeconds(1f);

        isSendingBall = false;
        yield return null;
    }
}