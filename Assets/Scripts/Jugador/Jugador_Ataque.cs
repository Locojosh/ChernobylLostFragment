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
    private int armaActual = 0; // 1=Barreta || 2=ArmaScientifica || 3=Explosivo
    
    //Especificas a Armas Especificas
    //Barreta
    private BoxCollider coliderA;
    public string nombreAnimacionBarreta = "barreta"; //Nombre de la animacion de la barreta atacando
    //Arma scientifica
    public Rigidbody balaPrefabRB;
    private GameObject balaPuntoSalida;
    public int velocidadBala = 50;
    //Explosivo a lanzar
    public Rigidbody explosivoPrefabRB; 
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
        if(other.tag == "enemigo")              //El GameObject es un enemigo
        if(Input.GetButtonDown("Arma") && armaActual==1)         //USAR BARRETA
        {
            other.gameObject.GetComponent<Enemigo_Control>().QuitarVida(porcentajeDañoBarreta);
            PlayAnimacionBarreta();
        }         
    }
    private void DispararArmaScientifica()
    {
        Rigidbody balaRB = Instantiate(balaPrefabRB, balaPuntoSalida.transform.position, balaPuntoSalida.transform.rotation); //Instancear bala
        balaRB.velocity = transform.TransformDirection(Vector3.forward * velocidadBala); //Velocidad de la bala
    }
    private void TirarExplosivo()
    {
        Rigidbody explosivoRB = Instantiate(explosivoPrefabRB, explosivoPuntoSalida.transform.position, explosivoPuntoSalida.transform.rotation); //Instancear explosivo a lanzar
        Vector3 dirExplosivo = new Vector3(0, 0.5f, 1); //Direccion que el explosivo es lanzado
        explosivoRB.velocity = transform.TransformDirection(dirExplosivo * velocidadExplosivo); //Velocidad del explosivo
    }
    private void PlayAnimacionBarreta()
    {
        Animator anim = this.GetComponent<Animator>();  //***NOTA*** El jugador debe tener un componente Animator
        anim.SetTrigger(nombreAnimacionBarreta);     //La animacion de ataque de barreta  del jugador 
    }                                              
}
