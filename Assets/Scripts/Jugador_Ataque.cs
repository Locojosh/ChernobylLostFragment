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
    private void OnTriggerStay(Collider other) //Cuando el collider de ataque del jugador choca con otro GameObject
    {
        if(other.tag == "enemigo")              //El GameObject es un enemigo
        if(Input.GetButtonDown("Arma"))         //USAR BARRETA
        {
            other.gameObject.GetComponent<Enemigo_Control>().QuitarVida(porcentajeDañoBarreta);
            PlayAnimacionBarreta();
        }         
    }
    private void UsarArmaScientifica()
    {

    }
    private void TirarExplosivo()
    {

    }

    private void PlayAnimacionBarreta()
    {
        Animator anim = this.GetComponent<Animator>();  //***NOTA*** El jugador debe tener un componente Animator
        anim.SetTrigger("barreta");                 //***NOTA*** La animacion de ataque de barreta  del jugador 
    }                                               //debe tener un trigger llamado "barreta"
}
