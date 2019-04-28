using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CausarDanoAoEncostar : MonoBehaviour
{
    public string filtroTag;
    public int dano;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (filtroTag == "" || (filtroTag != "" && col.CompareTag(filtroTag)))
        {
            var vida = col.GetComponent<Vida>();
            
            if (vida)
            {
                vida.CausarDano(dano);
                Destroy(gameObject);
            }
        }
    }
}
