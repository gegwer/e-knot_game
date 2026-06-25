using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple score trigger for pipes
/// Attach this to the middle of pipe prefab with trigger collider
/// </summary>
public class ScoreTrigger : MonoBehaviour
{
    private bool hasScored = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasScored && other.gameObject.tag == "Player")
        {
            FlappyBirdController bird = other.GetComponent<FlappyBirdController>();
            
            if (bird != null && !bird.IsDead && FlappyBirdController.isGameStarted)
            {
                hasScored = true;
                
                if (Game_Manager.instance != null)
                    Game_Manager.instance.AddScorePoint();
            }
        }
    }
}
