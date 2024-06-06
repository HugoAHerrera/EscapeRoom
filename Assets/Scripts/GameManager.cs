using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager: Singleton<GameManager>
{
    //Animaciones de la sala medieval
    Animator libreria_mov;
    Animator vela_mov;
    Animator puertaFinal_mov;

    //Animaciones de la sala garaje
    Animator puertaGaraje_mov;
    Animator panelControl_mov;

    public GameObject[] alarmasIncencios;

    public Text[] tiempoCrono;
    //6 minutos de reloj
    //private float timer = 365;

    private float timer = 365;


    private bool recargarScene = true;

    private float minutos;
    private float segundos;

    public GameObject[] pistasGaraje;
    public Transform[] positionsToSpawnPistasGaraje;

    public GameObject[] pistasMedieval;
    public Transform[] positionsToSpawnPistasMedieval;

    private void Start()
    {
        //Ajustes generales
        minutos = (int)timer/60;
        segundos = (int)timer%60;
        StartCoroutine(SpawnPistas());
        DontDestroyOnLoad(this);

        //Ajustes para la sala garaje
        GameObject puertaGaraje = GameObject.Find("PuertaGaraje");
        GameObject panelControl = GameObject.Find("PanelControl");

        puertaGaraje_mov = puertaGaraje.GetComponent<Animator>();
        puertaGaraje_mov.enabled = false;
        panelControl_mov = panelControl.GetComponent<Animator>();
        panelControl_mov.enabled = false;
        for(int i = 0; i < alarmasIncencios.Length; i++){
            alarmasIncencios[i].SetActive(false);
        }
        
        //Ajustes para la sala medieval
        GameObject vela = GameObject.Find("VelaPared");
        GameObject libreria = GameObject.Find("Libreria");
        GameObject puertaFinal = GameObject.Find("Puerta");

        libreria_mov = libreria.GetComponent<Animator>();
        libreria_mov.enabled = false;

        vela_mov = vela.GetComponent<Animator>();
        vela_mov.enabled = false;

        puertaFinal_mov = puertaFinal.GetComponent<Animator>();
        puertaFinal_mov.enabled = false;
        
    }

    void Update()
    {
        //Añadir luego la opción de al completar las salas terminar
        if(minutos <= 0 && segundos <= 0 && recargarScene == true)
        {
            recargarScene = false;
            RestartGame();
            Destroy(this.gameObject);
        }else{
            if (SceneManager.GetSceneByBuildIndex(1).isLoaded)
            {
                timer -= Time.deltaTime;
                minutos = (int)timer / 60;
                segundos = (int)timer % 60;
                try
                {
                    tiempoCrono[0].text = minutos.ToString() + ":" + segundos.ToString();
                    tiempoCrono[1].text = minutos.ToString() + ":" + segundos.ToString();
                }
                catch (NullReferenceException ex)
                {}
            }
        }
    }

    public IEnumerator SpawnPistas()
    {
        
        int i = 0;

        yield return new WaitForSeconds(UnityEngine.Random.Range(3, 8));
        //En la sala del garaje solo es aleatoria la posición del martillo:
        Instantiate(pistasGaraje[0], positionsToSpawnPistasGaraje[UnityEngine.Random.Range(0,positionsToSpawnPistasGaraje.Length-1)]);

        while(i<pistasMedieval.Length){
            //En la sala medieval es aleatoria la pista que hay en cada posición
            yield return new WaitForSeconds(UnityEngine.Random.Range(3, 8));
            //Instantiate(pistasMedieval[Random.Range(0,pistasGaraje.Length-1)], positionsToSpawnPistasMedieval[i]);
            Instantiate(pistasMedieval[i], positionsToSpawnPistasMedieval[i]);
            //
            i++;
        }
        


        StopSpawningPistasCoroutine();
    }

    private void StopSpawningPistasCoroutine()
    {
        StopCoroutine(SpawnPistas());
    }

    //Reinicia el juego y carga la misma escena
    public void RestartGame()
    {
        //vida = 0;
        //caminoCorrecto = 0;
        timer = 365;
        StopCoroutine(SpawnPistas());
        SceneManager.LoadScene(0);
    }

    public void actualizarMarcador()
    {
        if(minutos > PlayerPrefs.GetInt("minutos"))
        {
            PlayerPrefs.SetInt("mintos", (int) minutos);
            PlayerPrefs.SetInt("segundos", (int) segundos);
        }else if(minutos == PlayerPrefs.GetInt("minutos"))
        {
            if(segundos > PlayerPrefs.GetInt("segundos"))
            {
                PlayerPrefs.SetInt("segundos", (int) segundos);
            }
        }
    }

    public void activarAlarmas(){   
        for(int i = 0; i < alarmasIncencios.Length; i++){
            alarmasIncencios[i].SetActive(true);
        }
    }

    public void activarPanel(){
        panelControl_mov.enabled = true;
    }
}
