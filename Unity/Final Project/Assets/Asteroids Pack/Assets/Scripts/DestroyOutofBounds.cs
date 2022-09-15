using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    private float lowerBound = -35;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //the laser is cut off at a certain distance
        if (transform.position.z < lowerBound)
        {

            Destroy(gameObject);
        }
    }
}
