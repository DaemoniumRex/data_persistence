using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int bounceCount;
    public bool ballOut;
    public int ballCount;
    public TextMeshProUGUI bounceText;
    public GameObject ball3;
    public GameObject ball2;
    void Start()
    {
        ballOut = false;
        ballCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //BallWatch();
    }

     public void UpdateBounce(int ToAdd)
    {
        bounceCount += ToAdd;
        bounceText.text =  "" + bounceCount;
    }

    public void BallWatch()
    {
        if (ballCount == 2)
        {
            ball3 = GameObject.Find("Cube3");
            ball3.SetActive(false);
        }
        else if (ballCount == 1)
        {
            ball2 = GameObject.Find("Cube2");
            ball2.SetActive(false);
        }
        else if (ballCount == 0)
        {
            
        }
    }
}
