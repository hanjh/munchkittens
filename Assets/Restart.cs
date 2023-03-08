using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

    public void RestartGame()
    {
        ComboEventManager.totalScore = 0;
        SceneManager.LoadScene("SampleScene");
    }

}
