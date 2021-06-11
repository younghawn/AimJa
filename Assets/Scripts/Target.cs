using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public void Kill()
    {
        transform.position = new Vector3(Random.Range(-8, 8), Random.Range(2, 8), 8);
        Debug.Log("hit!");
    }
}
