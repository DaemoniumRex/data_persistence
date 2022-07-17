using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//for the UI, neede to use the INPUTFIELD
using UnityEngine.UI;
using TMPro;

//this is the code that allows unity to discern between editor and build code.
#if UNITY_EDITOR
using UnityEditor;
#endif
 
public class MenuUIHandler : MonoBehaviour
{
    public MainManManager MainManMan;
    
    //took out both start and update methods, dont plan to use them in this script.
    //vars for the team name input 

    public TMP_InputField teamNameInput;
    public string userName;

    // public void  Start() {
    //     teamNameInput.text =  "Tim";
    // }
    public void StartGame()
    { 
        
        
        SceneManager.LoadScene(1);    
        
        
        
    }
     public void ReStartGame()
    { 
        
         SceneManager.LoadScene(1);  
        
    }
    // public void named()
    // {
        
    // }

    public void Exit()
     {
        
        //Application.Quit();
        //update to the exit method to accomodate for the use in unity editor.
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();//this is the original exit method.

        #endif
    }
    //here we are going to set up the code to save the input name

    public void SaveTeamName()
    {
        if(teamNameInput.text.Equals(""))
        {
            teamNameInput.text =  "Tim";
            
        }
         userName = teamNameInput.text;
        //teamNameInput.text = userName;
        //  MainManMan.nameDrop(userName);
        // MainManManager.Instance.nameDrop(userName);
        MainManManager.Instance.teamName = userName;
        Debug.Log(userName + "hey due");
        Debug.Log(MainManManager.Instance.teamName + "hey");



            
    }

    public void LogCall()
    {
        Debug.Log(userName + " usernamelog");
    }



}
