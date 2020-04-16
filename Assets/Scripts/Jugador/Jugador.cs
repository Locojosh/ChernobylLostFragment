using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public GameOver_Control sGameOver; //Arrastrar desde UI
    int vida = 100;
    string hablar = "Hola";
    BaulMateriales baulMateriales;
    Sprite caraActual;
    public Sprite[] listaCarasUI; 
    int nivelRadiacion; //Radiacion del lugar en que se encuentra
    public int NivelRadiacion { get { return nivelRadiacion; } set { nivelRadiacion = value; } }
    
    private void Awake() 
    {
        baulMateriales = new BaulMateriales();
    }
    public void RecibirDaño(int daño)
    {
        vida -= daño;
    }
    public void Hablar(string mensaje)
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
