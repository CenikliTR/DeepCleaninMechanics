using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CheeseDestroy : MonoBehaviour
{
    public void DestroyCheese()
    {
        transform.DOScale(0.4f, 0.4f);
        transform.DOMove(Vector3.back, 0.5f).OnComplete(
        () => NewParent());
    }
    void NewParent()
    {
        GameObject pool= GameObject.Find("ObjectPool");
        this.transform.parent = pool.transform;
        this.gameObject.SetActive(false);
    }
}
