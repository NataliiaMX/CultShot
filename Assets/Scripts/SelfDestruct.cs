using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float timeTillDEstroy = 3f;
    private void Start() 
    {
        Destroy(gameObject, timeTillDEstroy);
    }
}
