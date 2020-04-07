using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador_Ataque : MonoBehaviour
{
    //Generales
    public int porcentajeDañoBarreta = 25;
    public int porcentajeDañoArmaScientifica = 15;
    public int porcentajeDañoExplosivo = 50;
    public int armaActual = 0; // 1=Barreta || 2=ArmaScientifica || 3=Explosivo

    //Especificas a Armas Especificas
    private BoxCollider coliderA;

    private void Awake() 
    {
        coliderA = transform.Find("Ataque_Collider").gameObject.GetComponent<BoxCollider>();
          
    }
    private void Update() 
    {
        if(Input.GetButtonDown("CambiarArma"))
        {
            armaActual++;
            if(armaActual==4)
            armaActual = 1;
        }
        
        if(Input.GetButtonDown("Arma"))
        {
            if(armaActual == 2)
            {
                UsarArmaScientifica();
            }
            else if(armaActual == 3)
            {
                TirarExplosivo();
            }
        }
    }
    private void OnTriggerStay(Collider other) //Cuando el collider de ataque del jugador choca con otro GameObject
    {
        if(other.tag == "enemigo")              //El GameObject es un enemigo
        if(Input.GetButtonDown("Arma") && armaActual==1)         //USAR BARRETA
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
