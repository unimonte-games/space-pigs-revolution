using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CausarDanoAoEncostar : MonoBehaviour
{
    public string filtroTag;
    public int dano;

    void OnCollisionEnter2D(Collision2D col)
    {
        print("aghhh");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        print("trig enter");
        if (filtroTag == "" || (filtroTag != "" && col.CompareTag(filtroTag)))
        {
            var vida = col.GetComponent<Vida>();
            if (vida)
            {
                vida.CausarDano(dano);
            }
        }
    }
}
