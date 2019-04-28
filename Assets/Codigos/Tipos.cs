public struct Pergunta
{
    public string pergunta;
    public int resposta;

    public string[] alternativas;
    public bool jaRespondida;

    public Pergunta(string p, int r, string[] a)
    {
        pergunta = p;
        resposta = r;
        alternativas = a;
        jaRespondida = false;
    }
}


[System.Serializable]
public struct ComparadorDistancia
{
    public enum Comparacao
    {
        Circular,
        Quadrado,
        DiferencaAltura,
        DiferencaLargura,
    }

    public float distancia;
    public UnityEngine.Vector2 deslocamento;
    public Comparacao metodo;


    public bool DentroDaDistancia(UnityEngine.Vector2 pos1, UnityEngine.Vector2 pos2)
    {
        UnityEngine.Vector2 pos1_desl = pos1 + deslocamento;

        switch (metodo)
        {
            case Comparacao.Circular:
                return UnityEngine.Vector3.Distance(pos1_desl, pos2) < distancia;

            case Comparacao.DiferencaAltura:
                return UnityEngine.Mathf.Abs(pos2.y - pos1_desl.y) < distancia;

            case Comparacao.DiferencaLargura:
                return UnityEngine.Mathf.Abs(pos2.x - pos1_desl.x) < distancia;

            case Comparacao.Quadrado:
                return UnityEngine.Mathf.Abs(pos2.y - pos1_desl.y) < distancia
                    && UnityEngine.Mathf.Abs(pos2.x - pos1_desl.x) < distancia;

            default: return false;
        }
    }

    public UnityEngine.Vector2[] ObterPontosPraGizmos()
    {
        const int qtd_circulo = 32;
        const int qtd_quad = 4;

        int qtd = metodo == Comparacao.Circular ? qtd_circulo : qtd_quad;
        UnityEngine.Vector2[] posicoes = new UnityEngine.Vector2[qtd];

        switch (metodo)
        {
            case Comparacao.Circular:
                const float pi2_parte = UnityEngine.Mathf.PI * 2f / qtd_circulo;

                for (int i = 0; i < qtd; i++)
                {
                    posicoes[i].x = UnityEngine.Mathf.Cos(pi2_parte * i) * distancia + deslocamento.x;
                    posicoes[i].y = UnityEngine.Mathf.Sin(pi2_parte * i) * distancia + deslocamento.y;
                }

                break;
            case Comparacao.DiferencaAltura:
                posicoes[0].x = distancia*2 + deslocamento.x;
                posicoes[0].y = distancia + deslocamento.y;
                posicoes[1].x = distancia*2 + deslocamento.x;
                posicoes[1].y = -distancia + deslocamento.y;
                posicoes[2].x = -distancia*2 + deslocamento.x;
                posicoes[2].y = -distancia + deslocamento.y;
                posicoes[3].x = -distancia*2 + deslocamento.x;
                posicoes[3].y = distancia + deslocamento.y;
                break;
            case Comparacao.DiferencaLargura:
                posicoes[0].x = distancia + deslocamento.x;
                posicoes[0].y = distancia*2 + deslocamento.y;
                posicoes[1].x = distancia + deslocamento.x;
                posicoes[1].y = -distancia*2 + deslocamento.y;
                posicoes[2].x = -distancia + deslocamento.x;
                posicoes[2].y = -distancia*2 + deslocamento.y;
                posicoes[3].x = -distancia + deslocamento.x;
                posicoes[3].y = distancia*2 + deslocamento.y;
                break;
            case Comparacao.Quadrado:
                posicoes[0].x = distancia + deslocamento.x;
                posicoes[0].y = distancia + deslocamento.y;
                posicoes[1].x = distancia + deslocamento.x;
                posicoes[1].y = -distancia + deslocamento.y;
                posicoes[2].x = -distancia + deslocamento.x;
                posicoes[2].y = -distancia + deslocamento.y;
                posicoes[3].x = -distancia + deslocamento.x;
                posicoes[3].y = distancia + deslocamento.y;
                break;
        }

        return posicoes;
    }
}