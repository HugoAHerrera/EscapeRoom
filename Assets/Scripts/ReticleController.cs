using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticleController : MonoBehaviour
{
    public float timeCompleted = 3f;
    public float currentTime;
    public Image radial;
    public bool move = false;

    private void OnEnable()
    {
        currentTime = 0;
        move = false;
        radial.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        currentTime = 0;
        move = false;
        radial.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > timeCompleted)
        {
            move = true;
            radial.fillAmount = 0;
            radial.gameObject.SetActive(false);
        }
        else
        {
            radial.fillAmount = currentTime / timeCompleted;
        }
        
    }
}
