using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador_Ataque : MonoBehaviour
{
    public int porcentajeDañoBarreta = 25;
    public int porcentajeDañoArmaScientifica = 15;
    public int porcentajeDañoExplosivo = 50;

    public GameObject cuboCerca;
    private BoxCollider coliderA;

    private void Awake() 
    {
        coliderA = transform.Find("Ataque_Collider").gameObject.GetComponent<BoxCollider>();
        
    }
    private void OnTriggerStay(Collider other) //BARRETA
    {
        if(other.tag == "enemigo")
        if(Input.GetButtonDown("Arma"))
        {
            DañarEnemigo(other.gameObject, porcentajeDañoBarreta); 
        }         
    }
    private void UsarArmaScientifica()
    {

    }
    private void TirarExplosivo()
    {

    }

    private void DañarEnemigo(GameObject enemigo, int daño)
    {
        enemigo.GetComponent<Enemigo_Control>().QuitarVida(daño);
        //Animacion     
        Animator anim = enemigo.GetComponent<Animator>();  
        if()
    }
}
