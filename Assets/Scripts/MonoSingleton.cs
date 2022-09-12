using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T: MonoSingleton<T>
{
    private static volatile T instance = null;
    //multiThread olmas� i�in "volatile" ekliyoruz ve veriyi bellekten almas�n� sa�l�yoruz

    public static  T Instance
    {

        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;
            }
            return instance;
        }
    }

}
