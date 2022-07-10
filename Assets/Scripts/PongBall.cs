using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
public class PongBall : MonoBehaviour
{
    private Rigidbody spirit;
    public GameManager gameMan;

    public Vector3 dir;
    public float randomiaX; 
    public float randomiaY; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        gameMan = GameObject.Find("GameManager").GetComponent<GameManager>();
        spirit = GetComponent<Rigidbody>();
        StarDir();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void StarDir()
    {
       randomiaX = Random.Range(-5f, 5f);
     randomiaY = Random.Range(-5f, 5f);
     spirit.AddForce(new Vector3(randomiaX, randomiaY, 0)  , ForceMode.Impulse);
      Debug.Log("velocity: " + spirit.velocity);
    }

    private void OnCollisionExit(Collision other)
    {
        var velocity = spirit.velocity;
        //velocity += velocity.normalized * 5000f;
       // Debug.Log("velocity: " + velocity);

        if (other.gameObject.CompareTag("Paddle"))
       { 
        velocity += velocity.normalized * 0.9f;
        Debug.Log("velocity: " + velocity + " paddle");

        }
        spirit.velocity = velocity;


    }
     void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.CompareTag("Sides"))
         {
            Destroy(gameObject);
            gameMan.ballOut = false;
            gameMan.ballCount--;
            Debug.Log(gameMan.ballCount);
            gameMan.BallWatch();
         }
     }
}
