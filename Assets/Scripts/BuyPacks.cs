using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPacks : MonoBehaviour
{
    public string oneOrMax;
    public GameObject pack;

    Player player;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    
    void OnMouseDown()
    {
        if (oneOrMax == "one")
        {
            bool purchased = player.SpendMoney(10.00f);
            if (purchased) {
                Instantiate(pack);
            }
        }
        else if (oneOrMax == "max")
        {

        }
    }
}
