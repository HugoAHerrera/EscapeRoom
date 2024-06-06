using UnityEngine;
using System.Collections;
using TMPro;

public class ControlPuertaGareja : MonoBehaviour
{
    public Transform puertaTransform;
    public float alturaSubida = 2f;
    public float alturaMaxima = 3.25f;
    public float duracionSubida = 1f;
    public Transform objetivoDestino;
    public TextMeshProUGUI textMeshPro;

    public void SubirBarrera()
    {
        StartCoroutine(SubirPuertaGradualmente());
    }

    IEnumerator SubirPuertaGradualmente()
    {
        Vector3 posicionInicial = puertaTransform.position;
        Vector3 posicionFinal = posicionInicial + Vector3.up * alturaSubida;

        float tiempoPasado = 0f;

        while (tiempoPasado < duracionSubida)
        {
            tiempoPasado += Time.deltaTime;

            float t = tiempoPasado / duracionSubida;
            t = Mathf.Clamp01(t); 

            Vector3 nuevaPosicion = Vector3.Lerp(posicionInicial, posicionFinal, t);

            nuevaPosicion.y = Mathf.Min(nuevaPosicion.y, alturaMaxima);

            puertaTransform.position = nuevaPosicion;

            yield return null; 
        }

        puertaTransform.position = posicionFinal;
        GameObject xrOriginObject = GameObject.Find("XR Origin");

        if (xrOriginObject != null)
        {
            Transform xrOrigin = xrOriginObject.transform;

            xrOrigin.position = objetivoDestino.position;
            textMeshPro.text = "Pistas colocadas: 0/3";
        }
        Destroy(this.gameObject);

    }
}
