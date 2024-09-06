using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour{

    [SerializeField] private TextMeshProUGUI count;
    [SerializeField] private int startingNum;

    private int inventoryNum;

    private void Start(){
        ShopManager.Instance.OnSuccessfulPurchase += ShopManager_OnSuccessfulPurchase;
        UpdateVisuals(startingNum);
    }

    private void ShopManager_OnSuccessfulPurchase(object sender, EventArgs e)
    {
        UpdateVisuals(inventoryNum++);
    }

    public void UpdateVisuals(int inventoryNum){
        count.text = inventoryNum.ToString();
        this.inventoryNum = inventoryNum;
    }
}
