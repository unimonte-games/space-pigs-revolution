public struct Pergunta
{
    public string pergunta;
    public int resposta;

    public string[] alternativas;

    public Pergunta(string p, int r, string[] a)
    {
        pergunta = p;
        resposta = r;
        alternativas = a;        
    }
}
