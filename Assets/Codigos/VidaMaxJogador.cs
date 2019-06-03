using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaMaxJogador : MonoBehaviour
{
    public const int VIDA_MAX_INICIAL = 8;
    public static int vidaMax = VIDA_MAX_INICIAL;


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
