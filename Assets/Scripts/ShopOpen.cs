using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ShopOpen : MonoBehaviour
{
    ObjectPool<GameObject> objectPool;

    public GameObject shop;

    bool open = false;

    void OnMouseDown()
    {
        if (!open)
        {
            open = true;
            shop.SetActive(true);
        }
        else
        {
            open = false;
            shop.SetActive(false);
        }
    }
}
