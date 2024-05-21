using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text tiempoRestante;

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void SalirJuego()
    {
        Application.Quit();
    }

    public void actualizarMarcador()
    {
        tiempoRestante.text = PlayerPrefs.GetInt("minutos").ToString() + ":" + PlayerPrefs.GetInt("segundos").ToString();
    }

    void Start()
    {
        actualizarMarcador();
    }
    
}