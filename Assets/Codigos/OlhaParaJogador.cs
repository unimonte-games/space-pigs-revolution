using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlhaParaJogador : MonoBehaviour
{
    Transform jogador, tr;

    public bool olharNoStart, olharNoUpdate, olharNoFixedUpdate;
    
    void Awake()
    {
        tr = GetComponent<Transform>();
    }

    void Start()
    {
        jogador = GameObject.FindWithTag("Player").transform;
        if (olharNoStart)
            Olhar();
    }

    
    void Update()
    {
        if (olharNoUpdate)
            Olhar();
    }

    void FixedUpdate()
    {
        if (olharNoFixedUpdate)
            Olhar();
    }

    void Olhar()
    {
        var diff = jogador.position - tr.position;
        diff.Normalize();

        var rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        tr.rotation = Quaternion.Euler(0f, 0f, rot_z - 90f);
    }
}
