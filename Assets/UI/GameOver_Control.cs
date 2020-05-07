using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_Control : MonoBehaviour
{
    public GameObject Jugador;
    private PlayerLook sJugadorLook;
    private GameObject BotonesInferior;
    public GameObject InterfazPartida;
    private int menuOSalir; //1>>Menu 2>>Salir
    public string nombreSceneMenu;
    private GameObject GuardarCambios, PartidasGuardadas;
    private void Awake() 
    {
        BotonesInferior = transform.Find("Botones").gameObject;
        GuardarCambios = transform.Find("GuardarCambios").gameObject;
        PartidasGuardadas = transform.Find("Partidas_Guardadas").gameObject;  
        sJugadorLook = Jugador.transform.Find("PlayerCamera").GetComponent<PlayerLook>(); 
    }
    private void Start() 
    {
        gameObject.SetActive(false);
        GuardarCambios.SetActive(false);
        PartidasGuardadas.SetActive(false);
    }
    public void GameOver()
    {
        sJugadorLook.UnlockCursor();
        Jugador.SetActive(false);
        InterfazPartida.SetActive(false);
        gameObject.SetActive(true);
    }
    public void OnClick_Menu()
    {
        menuOSalir = 1;
        GuardarCambios.SetActive(true);
    }
    
    public void OnClick_Salir()
    {
        menuOSalir = 2;
        GuardarCambios.SetActive(true);
    }
    public void OnClick_SiGuardarCambios()
    {
        PartidasGuardadas.SetActive(true);
        BotonesInferior.SetActive(false);
    }
    public void OnClick_NoGuardarCambios()
    {
        if(menuOSalir == 1) //Menu >> Salir
        {
            SceneManager.LoadScene(nombreSceneMenu);
        }
        else
        {
            if(menuOSalir == 2) //Salir>>Salir
            {
                Application.Quit();
            }
        }
    }
    private void GuardarPartida()
    {
        //Guardar PlayerPrefs

        //Continuar con..
        if(menuOSalir == 1) //Menu >> Guardar
        {
            SceneManager.LoadScene(nombreSceneMenu);
        }
        else
        {
            if(menuOSalir == 2) //Salir >> Guardar
            {
                Application.Quit();
            }
        }
    }
}
