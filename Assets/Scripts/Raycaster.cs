using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycaster : MonoBehaviour
{
    public Material basic;
    public Material highlighted;
    public ReticleController target;
    Vector3 posicionDestino;
    Renderer renderer;


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 30))
        {
            //Si choco con algo interactivo
            if (hit.transform.tag == "InteractiveBox") {

                //Habilito el "script", es decir, la clase Reticle Controller, y con ello, el comportamiento de la reticula
                target.enabled = true;
                renderer = hit.transform.GetComponent<Renderer>();
                renderer.material = highlighted;

                //Adapto la reticula a la distancia y superficie de choque
                HitAdapter(hit.distance, hit.normal);
            }
            else //Si choco con algo pero no es interactivo
            {
                //Adapto la reticula a la distancia y superficie
                HitAdapter(hit.distance, hit.normal);

                //Detengo el comportamiento de la reticula deshabilitando la clase Reticle Controller
                target.enabled = false;
                if (renderer != null)
                { 
                    renderer.material = basic;
                }
            }
        }
        else //Si no choco con nada
        {
            HitAdapter(30, -transform.forward);
            //Detengo el comportamiento de la reticula deshabilitando la clase Reticle Controller
            target.enabled = false;
            if (renderer != null)
            {
                renderer.material = basic;
            }
        } 
        
        //Si mi reticula ha finalizado su cuenta atrás y me da la señal para iniciar el desplazamiento
        //Y si mi renderer existe, me muevo hasta la posición en la que está dicho renderer
        if(target.move == true)
        {
            if (renderer != null) {
                //Teleport();
                Sliding();
                transform.position = Vector3.Lerp(transform.position, posicionDestino, Time.deltaTime*3);
            }
        }
    }


    void HitAdapter(float distancia, Vector3 normal)
    {
        Vector3 posReticula = target.transform.localPosition;
        posReticula.z = distancia-0.01f;

        //Asigno a mi retícula una nueva posición (sobre el objeto intercativo)
        target.transform.localPosition = posReticula;
        //Asigno a mi retícula una nueva rotación (mirando en la dirección de las normales de la sup. del objeto interactivo)
        target.transform.rotation = Quaternion.LookRotation(normal);
    }

    void Sliding()
    {
        posicionDestino = renderer.transform.localPosition;
    }
    void Teleport()
    {
        //Traslado todo mi Raycaster (cámara) hasta la posición destino
        posicionDestino = renderer.transform.localPosition;
        transform.position = posicionDestino;
    }

}
