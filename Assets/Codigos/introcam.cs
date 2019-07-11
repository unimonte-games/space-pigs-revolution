using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introcam : MonoBehaviour
{
    public Color cor1, cor2;
    public UnityEngine.Video.VideoPlayer vid;
    public Camera cam;
    public int quadroInicio, quadroFim;
    int tamQuadro;

    void Start()
    {
        tamQuadro = quadroFim - quadroInicio;
    }

    void Update()
    {
        var quadro = (int)vid.frame;

        if (quadro > quadroInicio && quadro <= quadroFim)
        {
            var difQuadro = quadro - quadroInicio;
            float t = Mathf.Clamp01((float)difQuadro/(float)tamQuadro);
            Color corRes = Color.Lerp(cor1, cor2, t);
            cam.backgroundColor = corRes;
        }
        else if (quadro > quadroFim)
            Menu();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
