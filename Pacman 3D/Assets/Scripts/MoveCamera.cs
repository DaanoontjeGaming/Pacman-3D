using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    void Update()
    {
        //Deze code past de camera positie aan zodat hij altijd de player volgt.
        // transform.position = cameraPosition.position;
    }
}
