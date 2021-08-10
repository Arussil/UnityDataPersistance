using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MainSceneUIHandler : MonoBehaviour
{
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
      string highestScorePlayerName = DataManager.Instance.highestScorePlayerName;
      int highestScore = DataManager.Instance.highestScore;
      if (highestScorePlayerName != null && highestScore != 0)
      {
        score.text = $"Best Score: {highestScorePlayerName}: {highestScore}";
        score.gameObject.SetActive(true);
      }
    }
}
