using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiseQndInvisivel : MonoBehaviour
{
    public float distanciaCamera;
    public bool destrutivel;
    Transform cam, tr;
    
    void Start()
    {
        cam = Camera.main.GetComponent<Transform>();
        tr  = GetComponent<Transform>();
        StartCoroutine(Co_Update());
    }

    IEnumerator Co_Update()
    {
        while (true)
        {
            if (cam != null && tr != null)
            {
                if (!DentroDaDistancia(cam, tr) && destrutivel)
                {
                    Destroy(gameObject);
                    break;
                }
            }
            yield return new WaitForSeconds(0.25f);
        }
    }

    bool DentroDaDistancia(Transform _cam, Transform _tr)
    {
        return Vector3.Distance(_cam.position, _tr.position) <= distanciaCamera;
    }

    public void DefinirDestrutivel(bool def)
    {
        destrutivel = def;
    }

    #if UNITY_EDITOR

    public bool previsualizar;

    void OnDrawGizmos()
    {
        Transform _cam = Camera.main.GetComponent<Transform>();

        if (_cam == null || !previsualizar)
            return;

        Gizmos.color = 
            DentroDaDistancia(_cam, transform)
                ? new Color(0, 1, 1)
                : new Color(1, 0, 1)
        ;

        Gizmos.DrawWireSphere(transform.position, distanciaCamera);
    }

#endif
}
