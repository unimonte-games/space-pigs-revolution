using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoJogador : MonoBehaviour
{
    Transform tr;
    public float velY;
    public bool movimentarSeVertical = true;
    DiarioPn diario;

    float ObtemPosicaoX(float antes)
    {
        if (Input.GetMouseButton(0))
            return Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        else
            return antes;

        // var toques = Input.touches;

        // if (toques.Length == 0)
        //     return antes;

        // return toques[0].position.x;
    }

    void Awake()
    {
        tr = GetComponent<Transform>();
        diario = FindObjectOfType<DiarioPn>();
    }

    void Update()
    {
        if (diario.aberto)
            return;

        var pos = tr.position;

        pos.x = ObtemPosicaoX(pos.x);

        if (movimentarSeVertical)
            pos.y += velY * Time.deltaTime;

        tr.position = pos;
    }

    public void DefinirMovimentarSeVertical(bool def)
    {
        movimentarSeVertical = def;
    }
}
