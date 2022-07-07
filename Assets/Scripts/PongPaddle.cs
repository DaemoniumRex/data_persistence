using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPaddle : MonoBehaviour
{
     public float Speed = 2.0f;
    public float MaxMovement = 5.9f;
    public float MinMovement = -3.66f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }



    public void Move()
    {

        if(gameObject.name == "P1")
    
       {
        float input = Input.GetAxis("V2");

         Vector3 pos = transform.position;

         
        pos.y += input * Speed * Time.deltaTime;

        if (pos.y > MaxMovement)
            pos.y = MaxMovement;
        else if (pos.y < MinMovement)
            pos.y = MinMovement;

         transform.position = pos;
         }
         else 
         {
            float input = Input.GetAxis("V1");

         Vector3 pos = transform.position;

         
        pos.y += input * Speed * Time.deltaTime;

        if (pos.y > MaxMovement)
            pos.y = MaxMovement;
        else if (pos.y < MinMovement)
            pos.y = MinMovement;

         transform.position = pos;
         }
    }
}
