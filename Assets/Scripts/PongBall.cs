using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
public class PongBall : MonoBehaviour
{
    private Rigidbody spirit;

    public Vector3 dir;
    public float randomiaX; 
    public float randomiaY; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        spirit = GetComponent<Rigidbody>();
        StarDir();
       
    }

    // Update is called once per frame
    void Update()
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
        velocity += velocity.normalized * 0.5f;
        Debug.Log("velocity: " + velocity + " paddle");

        }
        spirit.velocity = velocity;
    }
}
