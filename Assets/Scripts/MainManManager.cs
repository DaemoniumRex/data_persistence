using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManManager : MonoBehaviour
{

    //variables to save.
    public string teamName;

    public int Tscore;


    // got rid of the start and the update method 
    // this script will hold the the values for the data persistance along scenes

    //class member declaration, note the keyword static
    //this means that the values stored in this class will be shared by all the instances of itself.
    public static MainManManager Instance;

    private void Awake()
    //awake method is called as soon as the object is created.
    {
        // here we are going to implement a singleton pattern that ensures that only one instance of this object is inside the scene.
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }//singleton patter complete

        Instance = this;
        //"this" stored in the class member instance, the currente inst of MMM, we can now call the instance from any other script, and get a link to that specific instance of it.
        //no need to reference it.
        DontDestroyOnLoad(gameObject);
        //this line protects the gameObject to be deleted when changing scenes.
    }

    public void nameDrop(string team)
    {
        team = teamName;
    }
}
