using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoJogador : MonoBehaviour
{
    Transform tr;
    public float velY;
    GerenciadorJogo gerenJogo;
    DiarioBt diarioBt;

    float posDest_x, posDest_y;

    bool numaPergunta;

    float tween;

    float ObtemPosicaoX()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
    }

    float ObtemPosicaoY()
    {
        //return Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        var camPos = Camera.main.transform.position;
        var ponteiroPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var diffPos = ponteiroPos - camPos;

        return camPos.y + diffPos.y;
    }

    void Awake()
    {
        tr = GetComponent<Transform>();
        gerenJogo = FindObjectOfType<GerenciadorJogo>();
        diarioBt = FindObjectOfType<DiarioBt>();
    }

    void Update()
    {
        if (gerenJogo.pausado)
            return;

        if (Input.GetMouseButtonDown(0))
            tween = 0;

        tween = Mathf.Clamp01(tween + Time.deltaTime*4f);

        if (!numaPergunta && !diarioBt.mouseEmCima && Input.GetMouseButton(0))
        {
            posDest_x = ObtemPosicaoX();
            posDest_y = ObtemPosicaoY();
        }
    }

    void FixedUpdate()
    {
        if (gerenJogo.pausado)
            return;

        var pos = tr.position;
        posDest_y += velY * Time.deltaTime;

        pos.x = Mathf.Lerp(pos.x, posDest_x, tween);
        pos.y = Mathf.Lerp(pos.y, posDest_y, tween);
        pos.z = 0;

        tr.position = pos;
    }

    public void EntrarEmPergunta()
    {
        numaPergunta = true;
    }
}
