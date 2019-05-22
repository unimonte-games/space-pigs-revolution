using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvtPorTempo : MonoBehaviour
{
    public float segs;
    public bool rodarEmStart;
    public UnityEngine.Events.UnityEvent evento;

    float tempo;

    void Start()
    {
        if (rodarEmStart)
            Iniciar();
    }

    public void Iniciar()
    {
        StartCoroutine(Cronometrar());
    }

    IEnumerator Cronometrar()
    {
        yield return new WaitForSeconds(segs);
        evento.Invoke();
    }
}

