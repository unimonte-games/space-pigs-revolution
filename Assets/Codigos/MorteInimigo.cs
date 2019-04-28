using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorteInimigo : MonoBehaviour
{
    Vida vida;

    void Awake()
    {
        vida = GetComponent<Vida>();
    }

    void Update()
    {
        if (vida.vida == 0)
        {
            Destroy(gameObject);
        }
    }
}
