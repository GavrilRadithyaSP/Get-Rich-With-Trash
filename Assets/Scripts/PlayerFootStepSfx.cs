using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootStepSfx : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip grassStep;
    public AudioClip pavementStep;

    public float pitchMin = 0.9f;
    public float pitchMax = 1.1f;

    private string currentGround = "GrassGround";

    private void OnTriggerStay2D(Collider2D col)
    {
        // Pavement overrides grass if both are touching
        if (col.CompareTag("BetonGround"))
        {
            currentGround = "BetonGround";
            Debug.Log("Ground: Beton");
        }
        else if (col.CompareTag("GrassGround"))
        {    
            currentGround = "GrassGround";
            Debug.Log("Ground : Grass");
        }
    }

    // Called by Animation Event
    public void Footstep()
    {
        audioSource.pitch = Random.Range(pitchMin, pitchMax);

        switch(currentGround)
        {
            case "GrassGround":
                audioSource.PlayOneShot(grassStep);
                break;

            case "BetonGround":
                audioSource.PlayOneShot(pavementStep);
                break;
        }
    }
}
