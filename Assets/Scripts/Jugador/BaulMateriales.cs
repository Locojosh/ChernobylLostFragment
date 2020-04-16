using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaulMateriales
{
    List<string> listaObjetos;
    public BaulMateriales()
    {
        listaObjetos = new List<string>();
        listaObjetos.Add("objetoejemplo1");
        listaObjetos.Add("objetoejemplo2");
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
    public string DevolverTodosLosObjetos()
    {
        string objetos = "";
        for (int i = 0; i < listaObjetos.Count; i++)
        {
            objetos += listaObjetos[i] + " | ";
        }
        return objetos;
    }

}
