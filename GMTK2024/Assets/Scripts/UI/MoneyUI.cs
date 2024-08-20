using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI text;

    void Start(){
        text.text = "$" + PlayerInventory.Instance.Money.ToString();

        ShopManager.Instance.OnSuccessfulPurchase += UpdateVisuals;
    }

    private void UpdateVisuals(object sender, EventArgs e)
    {
        text.text = "$" + PlayerInventory.Instance.Money.ToString();
    }
}
