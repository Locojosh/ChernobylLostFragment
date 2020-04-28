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
    public int velocidadBala = 50;
    //Explosivo a lanzar
    public GameObject explosivoPrefab; 
    private GameObject explosivoPuntoSalida;
    public int velocidadExplosivo = 10;

    private void Awake() 
    {
        //Barreta
        coliderA = transform.Find("Ataque_Collider").gameObject.GetComponent<BoxCollider>();
        //Arma Scientifica
        balaPuntoSalida = transform.Find("BalaPuntoSalida").gameObject;
        //Explosivo a lanzar
        explosivoPuntoSalida = transform.Find("ExplosivoPuntoSalida").gameObject;
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
        {
            if(armaActual == 2)
            {
                DispararArmaScientifica();
            }
            else if(armaActual == 3)
            {
                TirarExplosivo();
            }
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
        GameObject clon = Instantiate(balaPrefab, balaPuntoSalida.transform.position, balaPuntoSalida.transform.rotation, balaPuntoSalida.transform) as GameObject; //Instancear bala
        Rigidbody balaRB = clon.GetComponent<Rigidbody>();
        balaRB.velocity = transform.TransformDirection(transform.forward * velocidadBala); //Velocidad de la bala
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
