using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

public class PartidasControl : MonoBehaviour
{
    //General
    private static PartidasControl instance; //Singleton
    public static PartidasControl Instance 
    { 
        get 
        { 
        if(instance == null)
            Debug.LogError("PoolManager is NULL");
        return instance; 
        } 
    }
    public int maxNPartidas = 7; //maximo numero de partidas
    private static int nPartida; //numero de la partida
    private string nombreNivel1;
    //UI
    private GameObject PartidasGuardadas, PanelMensaje;
    public Button[] btnPartidas;
    private void Awake() 
    {
        instance = this;
        PartidasGuardadas = transform.Find("GrupoPartidas").gameObject;
        PanelMensaje =  transform.Find("PanelMensaje").gameObject;
        btnPartidas = PartidasGuardadas.GetComponentsInChildren<Button>();
    }
    private void Start() 
    {        
        PanelMensaje.SetActive(false);
        ActualizarTextoPartidas();
    }

    public void NuevaPartida(string nombreNivel1)
    {
        int nuevoN = BuscarPartidaVacia();
        if(nuevoN < maxNPartidas)
        {
            nPartida = nuevoN;
            btnPartidas[nPartida].gameObject.SetActive(true);
            SceneManager.LoadScene(nombreNivel1);
        }
        else
        {
            PanelMensaje.SetActive(true);
            TextMeshProUGUI txtMensaje = PanelMensaje.transform.Find("Mensaje").GetComponentInChildren<TextMeshProUGUI>();
            txtMensaje.text = "Todas las partidas estan usadas. Selecciona 'Cargar Partida'";
        }
    }
    public void OnClick_Ok_PanelMensaje()
    {
        PanelMensaje.SetActive(false);
    }
    public void RecibirNombreNivel(string nombre)
    {
        nombreNivel1 = nombre;
    }
    public void OnClick_CargarPartida(int n)
    {
        string path = Application.persistentDataPath + "/juego" + n + ".chernobyl";
        if(File.Exists(path) == false)
        {
            PanelMensaje.SetActive(true);
            TextMeshProUGUI txtMensaje = PanelMensaje.transform.Find("Mensaje").GetComponentInChildren<TextMeshProUGUI>();
            txtMensaje.text = "Partida vacia. Porfavor selecciona otra partida";
        }
        else
        {
            nPartida = n;
            SceneManager.LoadScene(nombreNivel1);
        }
    }

    private int BuscarPartidaVacia()
    {        
        for(int n = 0; n < maxNPartidas; n++)
        {
            string path = Application.persistentDataPath + "/juego" + n + ".chernobyl";
            if(File.Exists(path) == false)
            return n;
        }
        return maxNPartidas;
    }
    private void ActualizarTextoPartidas()
    {
        for(int n = 0; n < maxNPartidas; n++)
        {
            string path = Application.persistentDataPath + "/juego" + n + ".chernobyl";
            if(File.Exists(path))
                btnPartidas[n].gameObject.SetActive(true);
            else
                btnPartidas[n].gameObject.SetActive(false);
        }
    }
}
