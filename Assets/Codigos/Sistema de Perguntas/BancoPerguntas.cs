public static class BancoDePerguntas
{
    public const int QTD_ALTERNATIVAS = 4;

    static readonly Pergunta[] perguntas = {
        new Pergunta(
            "Qual é o menor planeta do sistema solar?",
            0, new string [QTD_ALTERNATIVAS] {
                "Mercúrio",
                "Plutão",
                "Júpiter",
                "Saturno"
        }),

        new Pergunta(
            "Qual é o maior Planeta do sistema solar?",
            2, new string [QTD_ALTERNATIVAS] {
            "Mercúrio",
            "Plutão",
            "Júpiter",
            "Saturno"
        }),

        new Pergunta(
            "Qual o planeta mais longe do sol?",
            2, new string [QTD_ALTERNATIVAS] {
            "Mercúrio",
            "Vênus",
            "Netuno",
            "Saturno"
        }),

        new Pergunta(
            "O que é o sol?",
            3, new string [QTD_ALTERNATIVAS] {
            "Planeta",
            "Meteoro",
            "Satélite Natural",
            "Estrela"
        }),

        new Pergunta(
            "Qual o planeta mais frio do sistema solar?",
            1, new string [QTD_ALTERNATIVAS] {
            "Mercúrio",
            "Netuno",
            "Vênus",
            "Saturno"
        }),

        new Pergunta(
            "Qual o planeta mais quente do sistema solar?",
            2, new string [QTD_ALTERNATIVAS] {
            "Mercúrio",
            "Plutão",
            "Vênus",
            "Saturno"
        }),

        new Pergunta(
            "Quantos satélites naturais a Terra possui?",
            2, new string [QTD_ALTERNATIVAS] {
            "Zero",
            "Cinco",
            "Um",
            "Dois"
        }),

        new Pergunta(
            "O que é a Lua?",
            0, new string [QTD_ALTERNATIVAS] {
            "Satélite Natural",
            "Estrela",
            "Planeta",
            "Cometa"
        }),

        new Pergunta(
            "Qual(is) planeta(s) possuí(em) anéis?",
            0, new string [QTD_ALTERNATIVAS] {
            "Júpiter, Urano, Saturno e Netuno",
            "Júpiter, lua e Netuno",
            "Júpiter e Saturno",
            "Saturno"
         }),

        new Pergunta(
            "Qual o planeta mais próximo da Terra?",
            3, new string [QTD_ALTERNATIVAS] {
            "Mercúrio",
            "Plutão",
            "Terra",
            "Marte"
        }),

        new Pergunta(
            "Quantos planetas existem?",
            1, new string [QTD_ALTERNATIVAS] {
            "Dez",
            "Oito",
            "Cinco",
            "Onze"
        }),

        new Pergunta(
            "Quanto tempo a Terra leva para fazer a translação (Girar em torno do sol)?",
            3, new string [QTD_ALTERNATIVAS] {
            "Um hora",
            "Trezentos dias",
            "quatrocentos dias",
            "Trezentos e sessenta e cinco dias"
        }),

        new Pergunta(
            "Quanto tempo a Terra leva para fazer a rotação (Girar)?",
            2, new string [QTD_ALTERNATIVAS] {
            "Cinco horas",
            "Vinte horas",
            "Vinte e quatro horas",
            "Dez horas"
        }),

        new Pergunta(
            "75% da Terra é composta de?",
            0, new string [QTD_ALTERNATIVAS] {
            "Água",
            "Terra",
            "Ar",
            "Areia"
        }),

        new Pergunta(
            "Qual planeta é conhecido pelos seus anéis?",
            3, new string [QTD_ALTERNATIVAS] {
            "Mercúrio",
            "Plutão",
            "Júpiter",
            "Saturno"
        }),

        new Pergunta(
            "Qual é o planeta conhecido como vermelho?",
            3, new string [QTD_ALTERNATIVAS] {
            "Mercúrio",
            "Plutão",
            "Júpiter",
            "Marte"
        }),

        new Pergunta(
            "Qual o único planeta que gira de lado?",
            2, new string [QTD_ALTERNATIVAS] {
            "Lua",
            "Terra",
            "Urano",
            "Júpiter"
        }),

        new Pergunta(
            "Vênus é composto de?",
            2, new string [QTD_ALTERNATIVAS] {
            "Pedras",
            "Água",
            "Gases",
            "Ar"
        }),

        new Pergunta(
            "Marte possui quantos satélites naturais?",
            0, new string [QTD_ALTERNATIVAS] {
            "Dois",
            "Cinco",
            "Dez",
            "Um"
        }),

        new Pergunta(
            "Qual o planeta mais próximo ao sol?",
            0, new string [QTD_ALTERNATIVAS] {
            "Mercúrio",
            "Plutão",
            "Júpiter",
            "Saturno"
        }),
    };

    public static int perguntasRespondidas = 0;

    public static Pergunta ObterPergunta()
    {
        bool jaRespondida = true;
        int p_bit_i = 0;
        int i = 0;

        while (jaRespondida)
        {
            i = UnityEngine.Random.Range(0, perguntas.Length);
            p_bit_i = 1 << i;
            jaRespondida = (perguntasRespondidas & p_bit_i) == p_bit_i;
        }

        perguntasRespondidas = perguntasRespondidas | p_bit_i;
        return perguntas[i];
    }

    public static void ZerarPerguntasRespondidas()
    {
        perguntasRespondidas = 0;
    }
}
