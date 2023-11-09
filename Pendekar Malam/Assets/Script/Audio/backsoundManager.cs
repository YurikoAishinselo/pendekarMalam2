using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backsoundManager : MonoBehaviour
{
    public AudioSource GameFightBacksound;
    public AudioSource lightningBacksound;
    public float interval = 10f; // Time interval for playing the second audio

    private float timer = 0f;

    private void Awake()
    {
        if (GameFightBacksound != null)
        {
            //GameFightBacksound.Play(); // Play the audio when the scene starts
        }
    }
    private void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Check if it's time to play the second audio
        if (timer >= interval)
        {
            // Play the second audio
            //lightningBacksound.Play();

            // Reset the timer
            timer = 0f;
        }
    }

}
