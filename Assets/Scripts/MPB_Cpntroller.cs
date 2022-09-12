using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPB_Cpntroller : MonoBehaviour
{
    [SerializeField] Color color = Color.white;

    Renderer _rend;
    MaterialPropertyBlock _materialProperty;
    
    void Start()
    {
        _rend = GetComponent<Renderer>();
        _materialProperty = new MaterialPropertyBlock();
        _materialProperty.SetColor("Color_d0e1f6e285744aba81ec2e77fe42ea48", color);
        _rend.SetPropertyBlock(_materialProperty);
    }



}
