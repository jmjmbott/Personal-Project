using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatGround : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatLength;
    
    void Start()
    {
        startPos = transform.position;
        repeatLength = GetComponent<BoxCollider>().size.z * 3;
    }

    // Get Ground Position and repeat
    void Update()
    {
        if (transform.position.z < startPos.z - repeatLength)
        {
            transform.position = startPos;
        }
    }
}
