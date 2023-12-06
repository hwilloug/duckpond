using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public TMPro.TextMeshProUGUI playerMoneyText;

    float initialMoney = 50.00f;

    public float money { get { return money; }}
    float playerMoney;

    // Start is called before the first frame update
    void Start()
    {
        playerMoney = initialMoney;
        playerMoneyText.text = $"${playerMoney.ToString()}";
    }

    // Update is called once per frame
    void Update()
    {
        playerMoneyText.text = $"{playerMoney.ToString()}";
    }

    public bool SpendMoney(float amount)
    {
        if (amount <= playerMoney)
        {
            playerMoney -= amount;
            return true;
        } 
        else
        {
            Debug.Log("Not enough money");
            return false;
        }
    }
}
