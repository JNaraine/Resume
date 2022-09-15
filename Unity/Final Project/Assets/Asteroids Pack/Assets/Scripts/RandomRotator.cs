using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    [SerializeField]
    private float tumble;

    void Start()
    { //Rotate object
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }
}