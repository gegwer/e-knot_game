using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnCollisionEnter : MonoBehaviour
{
    public AudioSource source;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && source != null)
        {
            FlappyBirdController controller = collision.gameObject.GetComponent<FlappyBirdController>();
            if (controller != null && !controller.IsDead)
                source.Play();
        }
    }
}
