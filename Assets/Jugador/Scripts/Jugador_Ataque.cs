using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador_Ataque : MonoBehaviour
{
    //Generales 
    public string nombreBotonCambiarArma = "", nombreBotonDispararArma = "";
    public string nombreTagEnemigo;
    public int porcentajeDañoBarreta = 25;
    public int porcentajeDañoArmaScientifica = 15;
    public int porcentajeDañoExplosivo = 50;
    public int armaActual = 0; // 1=Barreta || 2=ArmaScientifica || 3=Explosivo
    public SonidosBiblioteca sSonidos;
    
    //Especificas a Armas Especificas
    //Barreta
    public Animator animator;
    private BoxCollider coliderA;
    public string nombreAnimacionBarreta = "barreta"; //Nombre de la animacion de la barreta atacando
    public string nombreAnimacionExplosivo = "explosivo";
    //Armas
    private GameObject balaPuntoSalida;
    //Arma scientifica
    public GameObject balaPrefab;
    //Explosivo a lanzar
    public GameObject explosivoPrefab; 

    private void Awake() 
    {
        //Barreta
        coliderA = transform.Find("Ataque_Collider").gameObject.GetComponent<BoxCollider>();
        //Arma Scientifica
        balaPuntoSalida = GameObject.Find("BalaPuntoSalida").gameObject;
    }
    private void Update() 
    {
        if(Input.GetButtonDown(nombreBotonCambiarArma))
        {
            armaActual++;
            if(armaActual==4)
            armaActual = 1;
        }
        
        if(Input.GetButtonDown(nombreBotonDispararArma))
        {//DispararArmaScientifica();
            if(armaActual == 2)
            {
                DispararArma(2);
            }
            else if(armaActual == 3)
            {
                DispararArma(3);
            }
        }
    }
    //ATAQUE BARRETA
    private void OnTriggerStay(Collider other) //Cuando el collider de ataque del jugador choca con otro GameObject
    {
        if(other.tag == nombreTagEnemigo)              //El GameObject es un enemigo
        if(Input.GetButtonDown(nombreBotonDispararArma) && armaActual==1)         //USAR BARRETA
        {
            other.gameObject.GetComponent<Enemigo_Control>().QuitarVida(porcentajeDañoBarreta);
            PlayAnimacionBarreta();
        }         
    }
    private void DispararArma(int arma)
    {
        ActualizarBalaPuntoSalida();
        switch (arma)
        {
            case 2: //ARMA SCIENTIFICA
            GameObject clon = Instantiate(balaPrefab, balaPuntoSalida.transform) as GameObject; //Instancear bala
            sSonidos.Play(gameObject.GetComponent<AudioSource>(), sSonidos.Disparo);
            break;
            case 3: //ARMA QUIMICA
            GameObject clonQ = Instantiate(explosivoPrefab, balaPuntoSalida.transform) as GameObject; //Instancear bala
            sSonidos.Play(gameObject.GetComponent<AudioSource>(), sSonidos.Explosion);
            PlayAnimacionExplosivo();
            break;
        }        
    }
    private void ActualizarBalaPuntoSalida()
    {
        balaPuntoSalida.transform.rotation = transform.rotation;

        balaPuntoSalida.transform.position = transform.position;
        balaPuntoSalida.transform.position += transform.forward;        
        //balaPuntoSalida.transform.position += new Vector3(0.5f, 0f, 1.5f);
    }
    private void PlayAnimacionBarreta()
    {
        animator.SetTrigger(nombreAnimacionBarreta);     //La animacion de ataque de barreta  del jugador 
    }    
    private void PlayAnimacionExplosivo()
    {
        animator.SetTrigger(nombreAnimacionExplosivo);     //La animacion de ataque de barreta  del jugador 
    }                                          
}
