using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
public GameObject ball;
public Rigidbody lero;
public GameManager gameMan;
    void Start()
    {
      gameMan = GameObject.Find("GameManager").GetComponent<GameManager>();
        lero = GetComponent<Rigidbody>();
      StartCoroutine("SpawnBall");
        
    }

    // Update is called once per frame
    void Update()
    {
        BallWatcher();
    }
    IEnumerator SpawnBall()
    {
      Vector3 spawnPos = new Vector3(0,0,0);
      Instantiate(ball, spawnPos, gameObject.transform.rotation);
      gameMan.ballOut = true;
      yield return null;
    }

    public void BallWatcher()
    {
      if(gameMan.ballOut == false)
      {
        StartCoroutine("SpawnBall");
      }
    }
}
