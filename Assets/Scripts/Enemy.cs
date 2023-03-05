using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyCrashVfxSfx;
    [SerializeField] int amountToUpdateScore = 1;
    [SerializeField] int hitPoints = 3;

    ScoreBoard scoreBoard;
    GameObject parentGameObject;


    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();

        AddRigidbody();

        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
    }

    private void AddRigidbody()
    {
        Rigidbody rigidBody = gameObject.AddComponent<Rigidbody>();
        rigidBody.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (hitPoints > 0)
        {
            scoreBoard.IncreaseScore(amountToUpdateScore);
            hitPoints--;
        }
        else 
        {
            scoreBoard.IncreaseScore(amountToUpdateScore);

            GameObject fx = Instantiate(enemyCrashVfxSfx, transform.position, Quaternion.identity);
            fx.transform.parent = parentGameObject.transform;
    
            Destroy(gameObject);
        }
    }
}
