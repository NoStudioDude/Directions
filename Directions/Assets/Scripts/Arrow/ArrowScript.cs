using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {

    [HideInInspector]public int currentRotation;
    [HideInInspector]public Transform neighbourArrow;

	void Start () {
	
	}
	
    void Update () {
	
	}

    public void Rotate()
    {
        Debug.Log("ArrowScript:Rotate()");
        int zRot = 0;
        switch (currentRotation)
        { 
            case 0:
                zRot = 90;
                break;
            case 90:
                zRot = 180;
                break;
            case 180:
                zRot = 270;
                break;
            case 270:
                zRot = 0;
                break;
        }
        currentRotation = zRot;
        //transform.rotation.eulerAngles.z =  zRot;
    }

}
