using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectCollision : MonoBehaviour
{
    
    public ParticleSystem astExplosion;
    private Player player;
    
    public bool shouldExplode = false;
    private AudioSource EnemyAudio;
    public AudioClip Explision;

   
    public int pointValue;
    // Start is called before the first frame update
    void Start()
    {
        EnemyAudio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
     void OnTriggerEnter(Collider other)
    {

        //When the laser and the asteroids collides they destroy each other
            if (other.gameObject.tag.Equals("Enemy"))
            {


                Instantiate(astExplosion, transform.position, astExplosion.transform.rotation);

                //EnemyAudio.Play();
                EnemyAudio.PlayOneShot(Explision, 1.0f);
                Destroy(other.gameObject);

                Player.instance.UpdateScore();

            }

            if (other.gameObject.tag.Equals("Laser"))
            {

                Destroy(other.gameObject);

            } //Laser won't destroy the ring
            else if (other.gameObject.tag.Equals("Weakness"))
            {
                DontDestroyOnLoad(other.gameObject);
            }
            //the PowerUp Indicator won't destroy the ring
        if (other.gameObject.tag.Equals("Strength"))
        {
            DontDestroyOnLoad(other.gameObject);
        }
        
       
        
        
    }
 

}
