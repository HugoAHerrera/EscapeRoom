using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboInteractivo : InteractableObject
{
    
    void Start()
    {
        rr.doInteraction.AddListener(ActionInteractable);
        //base.ActionInteractable();
    }
    
    protected override void ActionInteractable()
    {
        base.ActionInteractable();
        Debug.Log("Estas interactuando con este cubo");
    }

}
