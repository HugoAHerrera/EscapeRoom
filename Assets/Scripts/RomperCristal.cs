using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomperCristal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.activarAlarmas();
        Destroy(this.gameObject);
    }
}
