using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoCercano_Control : MonoBehaviour
{
    [SerializeField] float velocidad = 10f;
    [SerializeField] int fuerzaDaño = 15;
    [SerializeField] float distanciaPerseguir = 10f, distanciaAtacando = 1f;
    [SerializeField] float frecuenciaAtaque = 1f; //Cada cuantos segundos ataca
    private float timerAtaque = 0f;
    private bool bAtacando = false;
    //Jugador
    private GameObject player; 
    private Jugador sPlayer;
    //Animacion
    private Animator animator; 
    [SerializeField] string nombreTriggerAnimacionAtaque; //Trigger que activa la animacion de ataque del animator

    private void Awake() 
    {
        animator = gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player");
        sPlayer = player.GetComponent<Jugador>();
    }
    private void Update() 
    {
        if(Vector3.Distance(transform.position, player.transform.position) < distanciaPerseguir && Vector3.Distance(transform.position, player.transform.position) > distanciaAtacando) //Si cerca, entonces perseguir
        {
            
            transform.LookAt(player.transform); //Mirar al jugador
            Vector3 eulerPos = transform.localEulerAngles; eulerPos.x = 0; //No mirar en eje x
            transform.rotation = Quaternion.Euler(eulerPos);    
            
            transform.position += transform.forward * velocidad * Time.deltaTime; //Acercarse
        }
        if(Vector3.Distance(transform.position, player.transform.position) <= distanciaAtacando)
        {            
            timerAtaque -= Time.deltaTime;

            if(timerAtaque <= 0)
            {
                Atacar();
                timerAtaque = frecuenciaAtaque;
            }
        } 
        else
        {
            timerAtaque = 0f;            
        } 
        
    }

    private void Atacar()
    { 
        PlayAnimacionAtaque();
        sPlayer.RecibirDaño(fuerzaDaño);
    }
    private void PlayAnimacionAtaque()
    {
        animator.SetTrigger(nombreTriggerAnimacionAtaque);     //La animacion de ataque del enemigo 
    }  
}
