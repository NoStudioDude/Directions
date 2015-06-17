using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {

    [HideInInspector]public Transform neighbourArrow;
    [HideInInspector]public Transform myCenterPoint;

    int rotationDirection = -1; // -1 for clockwise :: 1 for anti-clockwise
    int rotationStep = 5;
    bool doingRotation;

    private Vector3 currentRotation, targetRotation;

    public void rotateObject()
    {
        if (!doingRotation)
        {
            doingRotation = true;
            currentRotation = transform.eulerAngles;
            targetRotation.z = (currentRotation.z + (90 * rotationDirection));
            StartCoroutine("objectRotation");
        }
    }

    IEnumerator objectRotation()
    {
        while (((int)currentRotation.z > (int)targetRotation.z && rotationDirection < 0) || ((int)currentRotation.z < (int)targetRotation.z && rotationDirection > 0))
        {
            currentRotation.z += (rotationStep * rotationDirection);
            transform.eulerAngles = currentRotation;

            yield return new WaitForSeconds(0);
        }

        doingRotation = false;
        yield return null;

    }
}
