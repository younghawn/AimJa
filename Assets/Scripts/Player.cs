using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //movement speed in units per second
    private float movementSpeed = 5f;
    private Camera fpsCam;

    private void Start()
    {
        fpsCam = GetComponentInParent<Camera>();
    }

    void Update()
    {
        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        //update the position
        transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, 0, verticalInput * movementSpeed * Time.deltaTime);

        //output to log the position change
        Debug.Log(transform.position);

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("FIRE!");

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f));
            RaycastHit hit;

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, int.MaxValue))
            {
                Target target = hit.collider.GetComponent<Target>();
                target.Kill();
            }
        }
    }
}
