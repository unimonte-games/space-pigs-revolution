using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CausarDanoAoEncostar : MonoBehaviour
{
    public string[] filtroTag;
    public int dano;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (DentroDaTag(col.tag))
        {
            var vida = col.GetComponent<Vida>();

            if (vida)
            {
                vida.CausarDano(dano);
                Destroy(gameObject);
            }
        }
    }

    bool DentroDaTag(string inimigo_tag)
    {
        for (int i = 0; i < filtroTag.Length; i++)
        {
            if (inimigo_tag == filtroTag[i])
                return true;
        }

        return false;
    }
}
