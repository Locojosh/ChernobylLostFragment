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
    //Arma scientifica
    public GameObject balaPrefab;
    private GameObject balaPuntoSalida;
    public GameObject balas;
    public int velocidadBala = 100;
    //Explosivo a lanzar
    public GameObject explosivoPrefab; 
    private GameObject explosivoPuntoSalida;
    public int velocidadExplosivo = 10;

    private void Awake() 
    {
        //Barreta
        coliderA = transform.Find("Ataque_Collider").gameObject.GetComponent<BoxCollider>();
        //Arma Scientifica
        balaPuntoSalida = GameObject.Find("BalaPuntoSalida").gameObject;
        //Explosivo a lanzar
        explosivoPuntoSalida = transform.Find("ExplosivoPuntoSalida").gameObject;
        balas = GameObject.Find("Balas");
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
        Vector3 posSalida = new Vector3(transform.position.x + 0.5f, balaPuntoSalida.transform.position.y, transform.position.z + 0.75f);
        switch (arma)
        {
            case 2: //ARMA SCIENTIFICA
            GameObject clon = Instantiate(balaPrefab, posSalida, Quaternion.identity) as GameObject; //Instancear bala
            sSonidos.Play(gameObject.GetComponent<AudioSource>(), sSonidos.Disparo);
            break;
            case 3: //ARMA QUIMICA
            //
            PlayAnimacionExplosivo();
            break;
        }        
    }
    private void ActualizarBalaPuntoSalida()
    {
        Vector3 newPos = new Vector3(transform.position.x + 0.5f, balaPuntoSalida.transform.position.y, transform.position.z + 0.75f);
        balaPuntoSalida.transform.position = newPos;
        balaPuntoSalida.transform.rotation = transform.rotation;
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
