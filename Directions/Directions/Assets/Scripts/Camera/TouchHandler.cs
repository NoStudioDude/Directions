using UnityEngine;
using System.Collections;

public class TouchHandler : MonoBehaviour {

    void Update()
    {
#if !UNITY_STANDALONE || !UNITY_EDITOR

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            
        }
#endif

        ProcessTouch();
    }



    void ProcessTouch() //Vector2 touchPosition
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Arrow")
                {
                    ArrowScript arrowScript = hit.collider.GetComponent<ArrowScript>();
                    arrowScript.rotateObject();
                }
            }else
                Debug.Log("NO HIT");
        }
    }

}