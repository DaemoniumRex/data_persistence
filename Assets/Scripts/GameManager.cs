using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int bounceCount;
    public bool ballOut;
    public int ballCount;
    public TextMeshProUGUI bounceText;
    public TextMeshProUGUI daTeamName;
    public GameObject ball3;
    public GameObject ball2;


    //mainamanref
    public MainManManager Instance;

    //bring the highscore table 
    
    void Start()
    {
        ballOut = false;
        ballCount = 3;

        //intentamos establecer el texto en el gui.
        //Debug.Log(MainManManager.Instance.teamName + "dude");
        daTeamName.text = "Team " + MainManManager.Instance.teamName;

       
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

            MainManManager.Instance.Tscore = bounceCount;
            Debug.Log(MainManManager.Instance.Tscore + "cuenta");
            SceneManager.LoadScene(2);

            
            
        }
    }
}
