using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectarLlavePanel : MonoBehaviour
{
    public string keyTag = "Llave";
    public TextMeshProUGUI textMeshPro;

    // Este método se llama cuando otro collider entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        textMeshPro.text = "Pistas encontradas: 2/3";
        if (other.CompareTag(keyTag))
        {
            
            Destroy(gameObject);
        }
    }
}
