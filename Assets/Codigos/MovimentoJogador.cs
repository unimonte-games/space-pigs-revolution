using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoJogador : MonoBehaviour
{
    Transform tr;
    public float velY;
    GerenciadorJogo gerenJogo;
    DiarioBt diarioBt;

    bool numaPergunta;

    float ObtemPosicaoX(float antes)
    {
        if (Input.GetMouseButton(0))
            return Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        else
            return antes;
    }

    Vector3 ObtemPosicaoVertical(Vector3 antes)
    {
        if (Input.GetMouseButton(0))
        {
            //return Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            var camPos = Camera.main.transform.position;
            var ponteiroPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var diffPos = ponteiroPos - camPos;

            return camPos + diffPos;
        }
        else
            return antes;
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

        var pos = tr.position;


        if (!numaPergunta && !diarioBt.mouseEmCima)
        {
          pos.x = ObtemPosicaoX(pos.x);
            pos = ObtemPosicaoVertical(pos);
        }

        pos.y += velY * Time.deltaTime;

        pos.z = 0;

        tr.position = pos;
    }

    public void EntrarEmPergunta()
    {
      numaPergunta = true;
    }
}
