using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaulMateriales
{
    List<string> listaObjetos;

    private void Awake() 
    {
        listaObjetos = new List<string>();
    }

    public void RecogerObjeto(string objeto)
    {
        listaObjetos.Add(objeto);
    }
    public string DevolverObjeto(string objeto)
    {
        string o = "";
        foreach (var obj in listaObjetos)
        {
            if(obj == objeto)
            o = obj;
        }
        return o;
    }

}
