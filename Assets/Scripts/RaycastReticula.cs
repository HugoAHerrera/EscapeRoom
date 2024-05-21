using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RaycastReticula : MonoBehaviour
{

    public UnityEvent doInteraction;
    public UnityEvent endInteraction;
    
    public GameObject corona; 
    public GameObject reticula;
    
    private float amount = 3;
    private float timer = 0;

    RaycastHit hit;
    
    void FixedUpdate()
    {
        
        if(Physics.Raycast(transform.position, transform.forward, out hit, 20))
        {
            //Debug.DrawRay(transform.position, transform.forward, Color.blue);
            if(hit.transform.gameObject.tag == "Interactables")
            {

                corona.SetActive(true);
                Image _sprite = corona.GetComponent<Image>();
                ReticulaAdaptacion(hit.distance, hit.normal);
                timer += Time.deltaTime;
                _sprite.fillAmount = timer / amount;
                if(timer > 3)
                {
                    //Llamar al evento o al comportamiento deseado
                    timer = 0;
                    corona.SetActive(false);
                    doInteraction.Invoke();
                }
            }else
            {
                timer = 0;
                corona.SetActive(false);
                ReticulaAdaptacion(hit.distance, hit.normal);
                endInteraction.Invoke();
            }
        }else
        {
            timer = 0;
            corona.SetActive(false);
            ReticulaAdaptacion(20, -transform.forward);
            endInteraction.Invoke();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       corona.SetActive(false); 
       reticula.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void ReticulaAdaptacion(float distancia, Vector3 normal)
    {
        Vector3 posicionReticula = reticula.transform.localPosition;
        posicionReticula.z = distancia - 0.04f; //El valor que resto es la distancia que hay del canvas a la cámara. En este caso 0.3/10 + 0.01
        
        reticula.transform.localPosition = posicionReticula;
        reticula.transform.rotation = Quaternion.LookRotation(normal);
    

    }
}
