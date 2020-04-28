using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveControl : MonoBehaviour
{
    public string color;
    public BaulMateriales baul;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.name == "Player")
        {
            baul.RecogerObjeto("Llave" + color);
            Destroy(gameObject);
        }    
    }
}
