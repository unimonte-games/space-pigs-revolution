using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAleatorio : MonoBehaviour
{
    public Sprite[] spritesPossiveis;

    void Awake()
    {
        var sprite_compo = GetComponent<SpriteRenderer>();
        if (sprite_compo)
            AplicaAleatorio(sprite_compo);
    }

    void AplicaAleatorio(SpriteRenderer spr)
    {
        spr.sprite = spritesPossiveis[Random.Range(0, spritesPossiveis.Length)];
    }

#if UNITY_EDITOR

    [ContextMenu("Aleatorizar em Cena")]
    void AleatoriarEmCena()
    {
        var inimigos = GameObject.FindGameObjectsWithTag("Inimigo");
        
        for (int i = 0; i < inimigos.Length; i++)
            AplicaAleatorio(inimigos[i].GetComponent<SpriteRenderer>());            
    }

#endif
}
