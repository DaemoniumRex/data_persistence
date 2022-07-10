using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < -12 || gameObject.transform.position.x > 12 || gameObject.transform.position.y < -6 || gameObject.transform.position.y > 8)
        {
            Destroy(gameObject);
        }
    }
}
