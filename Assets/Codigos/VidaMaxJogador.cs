using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaMaxJogador : MonoBehaviour
{
    public static int vidaMax = 8;


    void Awake()
    {
        GetComponent<Vida>().vida = vidaMax;
    }

#if UNITY_EDITOR
    [Header("Apenas para inspecionar")]
    [Tooltip("Só pra fazer aparecer o valor no inspector")]
    public int _vidaMax;

    void Update()
    {
        _vidaMax = vidaMax;
    }
#endif

}
