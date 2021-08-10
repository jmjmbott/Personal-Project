using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    private float speed = 5;
 
    // Translate position and Scrolls Object
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
