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
    
    //Barreta
    public Animator animator;
    private BoxCollider coliderA;
    public string nombreAnimacionBarreta = "barreta"; //Nombre de la animacion de la barreta atacando
    public string nombreAnimacionExplosivo = "explosivo";
    //Armas
    public Transform balaPuntoSalida;
    //Arma scientifica
    public GameObject balaPrefab;
    //Explosivo a lanzar
    public GameObject explosivoPrefab;
    public int balas = 20, explosivos = 5; //cuantas municiones tiene

    private void Awake() 
    {
        //Barreta
        coliderA = transform.Find("Ataque_Collider").gameObject.GetComponent<BoxCollider>();
        //Arma Scientifica
        balaPuntoSalida = GameObject.Find("BalaPuntoSalida").gameObject.transform;
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
                if(balas > 0)
                DispararArma(2);
            }
            else if(armaActual == 3)
            {
                if(explosivos > 0) //Probar que tenga municiones
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
            GameObject clon = Instantiate<GameObject>(balaPrefab, balaPuntoSalida.position, balaPuntoSalida.rotation, balaPuntoSalida); //Instancear bala
            sSonidos.Play(gameObject.GetComponent<AudioSource>(), sSonidos.Disparo);
            balas--;
            break;
            case 3: //ARMA QUIMICA
            GameObject clonQ = Instantiate<GameObject>(explosivoPrefab, balaPuntoSalida.position, balaPuntoSalida.rotation, balaPuntoSalida); //Instancear bala
            sSonidos.Play(gameObject.GetComponent<AudioSource>(), sSonidos.Explosion);
            PlayAnimacionExplosivo();
            explosivos--;
            break;
        }        
    }
    private void ActualizarBalaPuntoSalida()
    {
        Vector3 newPos = new Vector3(transform.position.x, 0.5f, transform.position.z);
        balaPuntoSalida.SetPositionAndRotation(newPos, transform.rotation);
        balaPuntoSalida.transform.position += transform.forward * 1.5f;   
        balaPuntoSalida.transform.position += transform.right * 0.5f; 
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
