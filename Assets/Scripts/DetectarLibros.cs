using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DetectarLibros : MonoBehaviour
{
    // El nombre del objeto que representa la llave
    public string keyTag = "Libro";
    private int contador = 0;
    public TextMeshProUGUI textMeshPro;

    // Este método se llama cuando otro collider entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto tiene la etiqueta "Key"
        if (other.CompareTag(keyTag))
        {
            Destroy(other.gameObject);
            contador++;
            try
            {
                textMeshPro.text = "Pistas colocadas: " + contador + "/3";
            }
            catch (NullReferenceException ex)
            { }
                if (contador == 3) 
            {
                StartCoroutine(BajarObjeto());
            }
        }
    }

    private IEnumerator BajarObjeto()
    {
        float tiempoTotal = 1f; // Duración total de la animación (en segundos)
        float tiempoPasado = 0f;

        Vector3 posicionInicial = transform.position;
        Vector3 posicionFinal = new Vector3(posicionInicial.x, -6.65f, posicionInicial.z); 
        while (tiempoPasado < tiempoTotal)
        {
            tiempoPasado += Time.deltaTime;
            float t = Mathf.Clamp01(tiempoPasado / tiempoTotal);

            transform.position = Vector3.Lerp(posicionInicial, posicionFinal, t);

            yield return null;
        }
        transform.position = posicionFinal;
        Destroy(gameObject);
    }
}
