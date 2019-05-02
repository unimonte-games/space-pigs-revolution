using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstanciadorPerguntas : MonoBehaviour
{
    readonly char[] letrasAlternativas = {'A', 'B', 'C', 'D'};

    public GameObject alternativaPrefab;

    Text perguntaTxt;
    Text[] alternativasTxts = new Text[BancoDePerguntas.QTD_ALTERNATIVAS];

    Transform tr;
    RectTransform rtr;

    bool visivel;
    float t;
    const float velT = 0.22f;

    public AnimationCurve curva;

    void Awake()
    {
        tr = GetComponent<Transform>();
        rtr = GetComponent<RectTransform>();

        perguntaTxt = tr.Find("Pn Pergunta").Find("Txt Pergunta").GetComponent<Text>();

        var tr_alternativas = tr.Find("Pn Txts Alternativas");
        for (byte i = 0; i < BancoDePerguntas.QTD_ALTERNATIVAS; i++)
        {
            var alternativaNome = string.Concat("Txt Alternativa ", letrasAlternativas[i]);
            alternativasTxts[i] = tr_alternativas.Find(alternativaNome).GetComponent<Text>();
        }
    }

    void Start()
    {
        Pergunta pergunta = BancoDePerguntas.ObterPergunta();
        perguntaTxt.text = pergunta.pergunta;

        for (byte i = 0; i < BancoDePerguntas.QTD_ALTERNATIVAS; i++)
            alternativasTxts[i].text = pergunta.alternativas[i];

        GetComponent<SistemaPerguntas>().DefinirPerguntaEmUso(pergunta);
    }

    void Update()
    {
        if (visivel && t < 1)
        {
            t += Time.deltaTime * velT;

            if (t > 1)
                t = 1;

            float ancoraCima   = curva.Evaluate(t) + 1;
            float anchoraBaixo = curva.Evaluate(t);

            var anc_max = rtr.anchorMax;
            var anc_min = rtr.anchorMin;
            anc_max.y = ancoraCima;
            anc_min.y = anchoraBaixo;
            rtr.anchorMax = anc_max;
            rtr.anchorMin = anc_min;
        }
    }

    public void TornarSeVisivel()
    {
        visivel = true;
    }
}
