using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreScript : MonoBehaviour
{
   private Transform entryContainer;
   private Transform entryTemplate;
   //private List<HighscoreEntry> highscoreEntryList;
   private List<Transform> highscoreEntryTransformList;
   public MainManManager Instance;
   private void Awake() 
   {
   
    entryContainer = transform.Find("Highscore Entry Cont");
    entryTemplate = entryContainer.Find("Highscore Entry Temp");

    entryTemplate.gameObject.SetActive(false);
   //test
   AddHighscoreEntry(MainManManager.Instance.Tscore, MainManManager.Instance.teamName);
//Debug.Log(PlayerPrefs.GetString("highscoreTable"));

   //  highscoreEntryList = new List<HighscoreEntry>()
   //  {
   //    new HighscoreEntry{ score = 1984, name = "MarO"},
   //    new HighscoreEntry{ score = 194, name = "MgaO"},
   //    new HighscoreEntry{ score = 1284, name = "naO"},
   //    new HighscoreEntry{ score = 3484, name = "yaO"},
   //    new HighscoreEntry{ score = 1856, name = "MtaO"},
      
   //  };

   //changing the coure of the hs list to get it from the json one

   
     string jsonString = PlayerPrefs.GetString("highscoreTable");
   Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);


    
    
      //keep the list at ten
      if (highscores.highscoreEntryList.Count > 10)
 {
            for (int h = highscores.highscoreEntryList.Count; h>10; h--)
 {

                highscores.highscoreEntryList.RemoveAt(10);

            }

        }


      //sorting algorythm by score
      for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
      {
         for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
         {
            if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
            {
               //and here we swap
               HighscoreEntry tmp = highscores.highscoreEntryList[i];
               highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
               highscores.highscoreEntryList[j] = tmp;

            }
         }
      }
      

      highscoreEntryTransformList = new List<Transform>(); 
      foreach(HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
    {
      CreateHighscoreEntryTansform(highscoreEntry, entryContainer, highscoreEntryTransformList);
    }





    //lets implement playerprefs to establish data persistance between sessions.



    
   //  Highscores highscores = new Highscores {
   //    highscoreEntryList = highscoreEntryList
   //  };

   //  string json = JsonUtility.ToJson(highscores);
   //  PlayerPrefs.SetString("highscoreTable", json);
   //  PlayerPrefs.Save();
   //  Debug.Log(PlayerPrefs.GetString("highscoreTable"));
   
    
   }


//method to create a new entry in the transform

private void CreateHighscoreEntryTansform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
{
      float templateHeight = 66f;
      Transform entryTransform = Instantiate(entryTemplate, container);
      RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
      entryRectTransform.anchoredPosition = new Vector2(0, - templateHeight * transformList.Count);
      entryTransform.gameObject.SetActive(true);


      int rank = transformList.Count + 1;
      string rankString;
      switch (rank)
      {
         default:
            rankString = rank + "TH";
            break;
         case 1: 
            rankString = "1ST";
            break;
         case 2: 
            rankString = "2ND";
            break;
         case 3:
            rankString = "3RD";
            break;
      }

      entryTransform.Find("Pos").GetComponent<TextMeshProUGUI>().text = rankString;

      //test score value
      int score = highscoreEntry.score;
      entryTransform.Find("Score").GetComponent<TextMeshProUGUI>().text = score.ToString();

      //test name
      string name = highscoreEntry.name;

      entryTransform.Find("TeamName").GetComponent<TextMeshProUGUI>().text = name;

      entryTransform.Find("TBackground").gameObject.SetActive(rank % 2 == 1);

      transformList.Add(entryTransform);
}

   private void AddHighscoreEntry(int score, string name)
   {
      //create highscore entry
      HighscoreEntry highscoreEntry = new HighscoreEntry {score = score, name = name};
      
      //load saved highscores

      string jsonString = PlayerPrefs.GetString("highscoreTable");
   Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

   //add new entry to highscores
   highscores.highscoreEntryList.Add(highscoreEntry);

   //keep list to ten code
   if (highscores.highscoreEntryList.Count > 10)
 {
            for (int h = highscores.highscoreEntryList.Count; h>10; h--)
 {

                highscores.highscoreEntryList.RemoveAt(10);

            }

        }

   //save updated highscores
   string json = JsonUtility.ToJson(highscores);
   PlayerPrefs.SetString("highscoreTable", json);
   PlayerPrefs.Save();

   }
   private class Highscores {
      public List<HighscoreEntry> highscoreEntryList;
   }
   //hacemos una nueva clase para guardar the new hs entry
   // for the player prefs to work we have to serialize
   [System.Serializable]
   private class HighscoreEntry
   {
      public int score;
      public string name;
   }
}
