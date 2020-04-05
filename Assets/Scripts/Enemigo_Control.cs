using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_Control : MonoBehaviour
{
    public int vida = 100; //hacer private 
    public int Vida { get{ return vida;} }

#region Metodos Por Defecto
    public void QuitarVida(int valor)
    {
        vida -= valor;
    }

#endregion
}
