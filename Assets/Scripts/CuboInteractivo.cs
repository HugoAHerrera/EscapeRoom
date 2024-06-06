using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboInteractivo : InteractableObject
{
    public Transform objetivoDestino;

    void Start()
    {
        ConfigureListeners();
    }

    void ConfigureListeners()
    {
        rr.doInteraction.RemoveListener(FindObjectOfType<CuboFinal>().ActionInteractable);
        rr.doInteraction.AddListener(ActionInteractable);
    }

    public override void ActionInteractable()
    {
        base.ActionInteractable();
        GameObject xrOriginObject = GameObject.Find("XR Origin");

        if (xrOriginObject != null)
        {
            Transform xrOrigin = xrOriginObject.transform;

            xrOrigin.position = objetivoDestino.position;
        }
    }
}
