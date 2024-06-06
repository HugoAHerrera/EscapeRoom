using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CuboFinal : InteractableObject
{
    void Start()
    {
        ConfigureListeners();
    }

    void ConfigureListeners()
    {
        rr.doInteraction.AddListener(ActionInteractable);
    }

    public override void ActionInteractable()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Consiguió escapar");
    }
}
