using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public float speed = 2f;
    public float force = 300;
    public GameManager gm;
    
    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            thisAnimation.Play();
            GetComponent<Rigidbody>().AddForce(Vector3.up * force);
        }
        
       
      
           
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            gm.GameOver();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "score")
        {
            gm.UpdateScore(1);
        }
            
    }
}
