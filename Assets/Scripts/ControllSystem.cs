using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;



public class ControllSystem : MonoSingleton<ControllSystem>
{

    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask objectLayer;
    public bool isClicked = false;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButton(0) && GameManager.Instance.ýsPlay)
        {
            GameManager.Instance.playObject.transform.position = Cast();
            isClicked = true;

        }
        else
        {
           isClicked =false;
        }
    }


    void MoveTarget() 
    {
        transform.position = Cast();
    }
    public float ofset;
    public Vector3 Cast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, objectLayer))
            if (hit.collider != null)
                return new Vector3(hit.point.x-0.4f, hit.point.y +ofset , hit.point.z);
         return new Vector3(-0.4f, 2.4f, -0.8f);
    }
}
