using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    public GameOver_Control sGameOver; //Arrastrar desde UI
    int vida = 50;
    public int Vida { get { return vida; } }
    public string hablar = "Hola";
    public BaulMateriales baulMateriales;
    public Sprite caraActual;
    public Sprite[] listaCarasUI; 
    int nivelRadiacion = 77; //Radiacion del lugar en que se encuentra
    public int NivelRadiacion { get { return nivelRadiacion; } set { nivelRadiacion = value; } }
    
    private void Awake() 
    {
        baulMateriales = GameObject.Find("Baul_Materiales").GetComponent<BaulMateriales>();
    }
    public void RecibirDaño(int daño)
    {
        vida -= daño;
    }
    public void HablarMensaje(string mensaje)
    {
        hablar = mensaje;
    }
    public void AgregarObjetoAlBaul(string objeto)
    {
        baulMateriales.RecogerObjeto(objeto);
    }
    public string RetirarObjetoDelBaul(string objeto)
    {
        return baulMateriales.DevolverObjeto(objeto);
    }
    public void CambiarCara(int indiceListaCaras)
    {
        caraActual = listaCarasUI[indiceListaCaras]; 
    }
    public void Morir()
    {
        sGameOver.GameOver();
    }
}
