using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coreografia : MonoBehaviour
{
    [Header("Parâmetros gerais")]
    [Tooltip("Local (Self) ou global (World), em resumo, define se a rotação interfere")]
    public Space relativoAo;

    [Tooltip("Espera-se esse tempo antes de aplicar os parâmetros descritos")]
    public float tempoDeEspera;

    [Header("Movimento e rotação")]
    [Tooltip("movimento no eixo X")]
    public float movimentoX;

    [Tooltip("movimento no eixo Y")]
    public float movimentoY;

    [Tooltip("Rotação (eixo Z)")]
    public float rotacao;

    [Header("Efeito")]
    [Tooltip("Por enquanto apenas senoide, talvez hajam outros efeitos no futuro, senão vou tirar isso aqui")]
    public EfeitoMov efeito = EfeitoMov.Senoide;

    [Tooltip("Frequência do efeito")]
    public float frequenciaEfeito;

    [Tooltip("Intensidade do efeito")]
    public Vector2 intensidadeEfeito;

    [Header("Aceleração")]

    [Tooltip("Aceleração do movimento no eixo X")]
    public float aceleracaoMovimentoX;

    [Tooltip("Aceleração do movimento no eixo Y")]
    public float aceleracaoMovimentoY;

    [Tooltip("Aceleração da rotação (eixo Z)")]
    public float aceleracaoRotacao;

    [Space(10)]

    [Tooltip("Aceleração da frequência do efeito")]
    public float aceleracaoFrequenciaEfeito;

    [Tooltip("Aceleração da intensidade do efeito")]
    public Vector2 aceleracaoIntensidadeEfeito;

    public enum EfeitoMov
    {
        Nenhum,
        Senoide
    }

    GerenciadorJogo gerenJogo;

#if UNITY_EDITOR

    [Header("Pré-Visualização")]
    public uint prever_Tamanho = 60;
    public float prever_CirculoRaio = 0.3f;
    public uint prever_Intervalo = 3;
    public Color prever_Cor = Color.red;
    Vector2 prever_posTr;
    float prever_rotTr;

    public bool usarOnValidate = true;

    float init_movimentoX;
    float init_movimentoY;
    float init_rotacao   ;
    float init_frequenciaEfeito ;
    Vector2 init_intensidadeEfeito;

#endif

    Transform tr;
    Transform jogador_tr;
    float efeitoFator = 0f;
    float dirTempo = -1;

    void Awake()
    {
        gerenJogo = FindObjectOfType<GerenciadorJogo>();
        tr = GetComponent<Transform>();
        jogador_tr = GameObject
            .FindWithTag("Player")
            .GetComponent<Transform>();

#if UNITY_EDITOR
        DEBUG_AtualizaPreverTr();
#endif
    }

    void Update()
    {
        if (gerenJogo.pausado)
            return;

        if (dirTempo < 0)
            dirTempo = Time.time;
        else
        {
            if (Time.time - dirTempo > tempoDeEspera)
            {
                efeitoFator += Time.deltaTime * frequenciaEfeito;
                efeitoFator = efeitoFator > 2*Mathf.PI ? 0f : efeitoFator;

                Vector3 ang = tr.eulerAngles;
                ang.z += rotacao * Time.deltaTime;
                tr.eulerAngles = ang;

                Vector2 pos = tr.localPosition;

                Vector2 pos_delta = (CalculaDelta(movimentoX, movimentoY) + CalculaEfeito(efeitoFator, intensidadeEfeito)) * Time.deltaTime;
                pos_delta = relativoAo == Space.Self
                    ? RotacionaPonto(pos_delta, ang.z)
                    : pos_delta;

                pos += pos_delta;

                tr.localPosition = pos;

                AceleraTudo();
            }
        }
    }

    Vector2 CalculaDelta(float movX, float movY)
    {
        Vector2 res = new Vector2();

        res.x += movX;
        res.y += movY;

        return res;
    }

    Vector2 CalculaEfeito(float fator, Vector2 intensidade)
    {
        Vector2 res = new Vector2();

        switch (efeito)
        {
            case EfeitoMov.Senoide:
                res.x = Mathf.Cos(fator);
                res.y = Mathf.Sin(fator);
                res *= intensidade;
                break;
        }


        return res;
    }

    Vector2 RotacionaPonto(Vector2 ponto, float angulo)
    {
        Vector2 res = new Vector2();

        float rad = angulo * (Mathf.PI / 180);
        float cos = Mathf.Cos(rad);
        float sin = Mathf.Sin(rad);

        float x = ponto.x;
        float y = ponto.y;

        res.x = x * cos - y * sin;
        res.y = x * sin + y * cos;

        return res;
    }

    void AceleraTudo()
    {
        movimentoX += aceleracaoMovimentoX * Time.deltaTime;
        movimentoY += aceleracaoMovimentoY * Time.deltaTime;
        rotacao    += aceleracaoRotacao * Time.deltaTime;

        frequenciaEfeito  += aceleracaoFrequenciaEfeito * Time.deltaTime;
        intensidadeEfeito += Vector2.one * aceleracaoIntensidadeEfeito * Time.deltaTime;
    }

#if UNITY_EDITOR

    void DEBUG_AtualizaPreverTr()
    {
        prever_posTr = transform.position;
        prever_rotTr = transform.eulerAngles.z;

        init_movimentoX = movimentoX;
        init_movimentoY = movimentoY;
        init_rotacao    = rotacao   ;
        init_frequenciaEfeito  = frequenciaEfeito ;
        init_intensidadeEfeito = intensidadeEfeito;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = prever_Cor;

        Vector2 posAnterior = new Vector2();

        float efeito = 0f;

        float dt = 0.1f;
        int contador = 0;

        float angZ = prever_rotTr;

        float _movimentoX = init_movimentoX;
        float _movimentoY = init_movimentoY;
        float _rotacao    = init_rotacao   ;
        float _frequenciaEfeito  = init_frequenciaEfeito ;
        Vector2 _intensidadeEfeito = init_intensidadeEfeito;


        for (int i = 0; i < prever_Tamanho; i++)
        {
            contador++;

            efeito += dt * _frequenciaEfeito;
            efeito = efeito > 2*Mathf.PI ? 0f : efeito;

            angZ += _rotacao * dt;

            Vector2 posPrev = posAnterior;

            Vector2 posPrev_delta = (CalculaDelta(_movimentoX, _movimentoY) + CalculaEfeito(efeito, _intensidadeEfeito)) * dt;

            posPrev_delta = relativoAo == Space.Self ? RotacionaPonto(posPrev_delta, angZ) : posPrev_delta;

            posPrev += posPrev_delta;

            Vector2 posPrevFinal     = posPrev + prever_posTr;
            Vector2 posAnteriorFinal = posAnterior + prever_posTr;


            Gizmos.DrawLine(posAnteriorFinal, posPrevFinal);

            if (contador == prever_Intervalo)
            {
                contador = 0;
                Gizmos.DrawWireSphere(posPrevFinal, prever_CirculoRaio/2);
            }


            posAnterior = posPrev;


            _movimentoX += aceleracaoMovimentoX * dt;
            _movimentoY += aceleracaoMovimentoY * dt;
            _rotacao    += aceleracaoRotacao * dt;
            _frequenciaEfeito  += aceleracaoFrequenciaEfeito * dt;
            _intensidadeEfeito += Vector2.one * aceleracaoIntensidadeEfeito * dt;
        }
    }

#endif
}























