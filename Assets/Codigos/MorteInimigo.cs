using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MorteInimigo : MonoBehaviour
{
    Vida vida;
    public UnityEvent aoMorrer;

    void Awake()
    {
        vida = GetComponent<Vida>();
    }

    void Update()
    {
        if (vida.vida == 0)
        {
            aoMorrer.Invoke();
            Destroy(gameObject);
        }
    }
}
