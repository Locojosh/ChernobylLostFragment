﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    public GameOver_Control sGameOver; //Arrastrar desde UI
    public int vida = 100;
    public string hablar = "Hola";
    public string mensajeDefault = "Tengo que salir de Chernobyl...";
    public BaulMateriales baulMateriales;
    public Sprite caraActual;
    public Sprite[] listaCarasUI; 
    int nivelRadiacion = 77; //Radiacion del lugar en que se encuentra
    public int NivelRadiacion { get { return nivelRadiacion; } set { nivelRadiacion = value; } }
    
    private void Awake() 
    {
        baulMateriales = GameObject.Find("Baul_Materiales").GetComponent<BaulMateriales>();
    }
    private void Start() 
    {
        Load();
    }
    public void RecibirDaño(int daño)
    {
        vida -= daño;
        if(vida <= 0)
        {
            Morir();
        }
    }
    public void HablarMensaje(string mensaje)
    {
        hablar = mensaje;
        Invoke("HablarDefault", 3);
    }
    private void HablarDefault()
    {
        hablar = mensajeDefault;
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
    public void Load()
    {
        GameData data = GameSaveLoad.Load(PartidasControl.Instance.NPartida);

        vida = data.vida;
        baulMateriales.listaObjetos = data.baulObjetos;
        Vector3 pos = new Vector3();
        pos.x = data.playerPos[0];
        pos.y = data.playerPos[1];
        pos.z = data.playerPos[2];
        transform.SetPositionAndRotation(pos, Quaternion.identity);
    }
}
