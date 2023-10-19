using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;
    void Start()
    {
        // Dit stuk code zorgt ervoor dat de cursor in het midden van het scherm blijft en niet zichtbaar is.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //Deze code haalt alle nodige inputs op zodat we hiermee kunnen draaien
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // De code link zorgt ervoor dat de camera maximaal maar 90 graden omhoog en omlaag kan kijken. (totaal 180 graden)

        // Deze code zorgt ervoor dat je camera en player daadwerkelijk draaien
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
