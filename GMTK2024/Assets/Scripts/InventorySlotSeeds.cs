using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour{

    [SerializeField] private TextMeshProUGUI count;
    [SerializeField] private int startingNum;

    private InventoryStackSO inventoryStackSO;

    private void Start(){
        ShopManager.Instance.OnSuccessfulPurchase += ShopManager_OnSuccessfulPurchase;
        UpdateVisuals(startingNum);
    }

    public void SetInventoryStackSO(InventoryStackSO inventoryStackSO){
        this.inventoryStackSO = inventoryStackSO;
    }

    private void ShopManager_OnSuccessfulPurchase(object sender, EventArgs e)
    {
        UpdateVisuals(inventoryStackSO.itemsInStack);
    }

    public void UpdateVisuals(int inventoryNum){
        count.text = inventoryNum.ToString();
    }
}
