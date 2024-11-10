using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float lifeTime = 4.0f;

    void Start()
    {

        Destroy(gameObject, lifeTime);
    }
}