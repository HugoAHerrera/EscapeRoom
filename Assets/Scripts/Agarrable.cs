using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Agarrable : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Llave"))
        {
            textMeshPro.text = "Pistas encontradas: 1/3";
        }
    }
}
