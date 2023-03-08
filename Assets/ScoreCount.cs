using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = string.Format("{0}", 0);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = string.Format("{0}", ComboEventManager.totalScore);
    }
}