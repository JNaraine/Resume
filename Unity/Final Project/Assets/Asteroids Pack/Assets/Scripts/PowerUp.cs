using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Rigidbody rb;
    private Player player;
    public int pointvalue;
    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }
    void Update()
    {

    }
  
    //get score when player collided with powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Weakness"))
        {
            DontDestroyOnLoad(other.gameObject);
            Player.instance.UpdateScore();
        }
    }

}
