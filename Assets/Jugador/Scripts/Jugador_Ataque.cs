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
    private int armaActual = 0; // 1=Barreta || 2=ArmaScientifica || 3=Explosivo
    
    //Especificas a Armas Especificas
    //Barreta
    public Animator animator;
    private BoxCollider coliderA;
    public string nombreAnimacionBarreta = "barreta"; //Nombre de la animacion de la barreta atacando
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
        {DispararArmaScientifica();
            /*if(armaActual == 2)
            {
                DispararArmaScientifica();
            }
            else if(armaActual == 3)
            {
                TirarExplosivo();
            }*/
        }
    }
    private void OnTriggerStay(Collider other) //Cuando el collider de ataque del jugador choca con otro GameObject
    {
        if(other.tag == nombreTagEnemigo)              //El GameObject es un enemigo
        if(Input.GetButtonDown(nombreBotonDispararArma) && armaActual==1)         //USAR BARRETA
        {
            other.gameObject.GetComponent<Enemigo_Control>().QuitarVida(porcentajeDañoBarreta);
            PlayAnimacionBarreta();
        }         
    }
    private void DispararArmaScientifica()
    {
        ActualizarBalaPuntoSalida();
        Vector3 posSalida = new Vector3(transform.position.x + 0.5f, balaPuntoSalida.transform.position.y, transform.position.z + 0.75f);
        GameObject clon = Instantiate(balaPrefab, posSalida, Quaternion.identity) as GameObject; //Instancear bala
        //Rigidbody balaRB = clon.GetComponent<Rigidbody>();
        //balaRB.AddRelativeForce(0, velocidadBala, 0); //Velocidad de la bala
        
    }
    private void ActualizarBalaPuntoSalida()
    {
        Vector3 newPos = new Vector3(transform.position.x + 0.5f, balaPuntoSalida.transform.position.y, transform.position.z + 0.75f);
        balaPuntoSalida.transform.position = newPos;
        balaPuntoSalida.transform.rotation = transform.rotation;
    }

    private void TirarExplosivo()
    {
        GameObject clon = Instantiate<GameObject>(explosivoPrefab, explosivoPuntoSalida.transform.position, explosivoPuntoSalida.transform.rotation, explosivoPuntoSalida.transform); //Instancear explosivo a lanzar
        Rigidbody explosivoRB = clon.GetComponent<Rigidbody>();
        //Vector3 dirExplosivo = new Vector3(0, 0.5f, 1); //Direccion que el explosivo es lanzado
        explosivoRB.velocity = transform.rotation.eulerAngles * velocidadExplosivo; //Velocidad del explosivo
    }
    private void PlayAnimacionBarreta()
    {
        animator.SetTrigger(nombreAnimacionBarreta);     //La animacion de ataque de barreta  del jugador 
    }                                              
}
