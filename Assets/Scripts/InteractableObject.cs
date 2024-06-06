using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public RaycastReticula rr;
    
    // Start is called before the first frame update
    void Start()
    {
        rr = FindObjectOfType<RaycastReticula>();
        rr.doInteraction.AddListener(ActionInteractable);
        rr.endInteraction.AddListener(StopActionInteractable);
    }

    public virtual void ActionInteractable()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

    public virtual void StopActionInteractable()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.white;
    }



}
