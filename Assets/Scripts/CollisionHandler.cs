using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] float finishLoadDelay = 3f;
    [SerializeField] ParticleSystem crashVFX;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Finish")
        {
            Invoke("ReloadLevel", finishLoadDelay);
        }
        else 
        {
            StartCrashSequence(); 
        }
    }

    private void StartCrashSequence()
    {
        crashVFX.Play();
        GetComponent<Controller>().enabled = false;
        Invoke("ReloadLevel", loadDelay);

    }

    private void ReloadLevel ()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
