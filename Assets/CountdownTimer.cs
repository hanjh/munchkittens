using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{ 
   public float timeValue = 90;
   public static bool isTimerActive = false;
   public TextMeshProUGUI countdownText;

   private void Start() {
      isTimerActive = true;
   }

   // Update is called once per frame
   void Update()
   {
      if (isTimerActive) {
         if (timeValue > 0) {
            timeValue -= Time.deltaTime;
         } else {
            isTimerActive = false;
            timeValue = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
         }
         DisplayTime(timeValue);
      }
   }

   void DisplayTime(float timeToDisplay)
   {
      if (timeToDisplay < 0) {
            timeToDisplay = 0;
      }
      
      float minutes = Mathf.FloorToInt(timeToDisplay / 60);
      float seconds = Mathf.FloorToInt(timeToDisplay % 60); 
      
      countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
   }
}

