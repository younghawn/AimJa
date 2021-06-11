using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{

    //camera public values
    public float XMinRotation;
    public float XMaxRotation;
    public float YMinRotation;
    public float YMaxRotation;
    [Range(1.0f, 10.0f)]
    public float Xsensitivity;
    [Range(1.0f, 10.0f)]
    public float Ysensitivity;
    private float rotAroundX, rotAroundY;

    // Use this for initialization
    void Start()
    {
        rotAroundX = transform.eulerAngles.x;
        rotAroundY = transform.eulerAngles.y;
    }

    private void Update()
    {
        rotAroundX += Input.GetAxis("Mouse Y") * Xsensitivity;
        rotAroundY += Input.GetAxis("Mouse X") * Ysensitivity;

        // Clamp rotation values
        rotAroundX = Mathf.Clamp(rotAroundX, XMinRotation, XMaxRotation);
        rotAroundY = Mathf.Clamp(rotAroundY, YMinRotation, YMaxRotation);

        // Apply rotation
        transform.rotation = Quaternion.Euler(-1 * rotAroundX, rotAroundY, 0);
        transform.parent.rotation = Quaternion.Euler(-1 * rotAroundX, rotAroundY, 0);
    }
}
