using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSfx : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip organicSFX;
    public AudioClip inorganicSFX;
    public AudioClip hazardSFX;

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Organic Trash
        if (col.CompareTag("Organik"))
        {
            audioSource.PlayOneShot(organicSFX);
            Destroy(col.gameObject);
        }

        // Inorganic Trash
        else if (col.CompareTag("Inorganik"))
        {
            audioSource.PlayOneShot(inorganicSFX);
            Destroy(col.gameObject);
        }

        // Hazard Trash
        else if (col.CompareTag("Bahaya"))
        {
            audioSource.PlayOneShot(hazardSFX);
            Destroy(col.gameObject);
        }
    }
}
