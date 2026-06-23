using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadCanvas_Manager : MonoBehaviour
{
    public Text currentScore;
    public Text bestScore;

    public void SetScoreValues(int currentSc, int bestSc)
    {
        if (currentScore != null)
            currentScore.text = currentSc.ToString();
        if (bestScore != null)
            bestScore.text = bestSc.ToString();
    }
}
