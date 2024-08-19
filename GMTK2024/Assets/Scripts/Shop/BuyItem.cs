using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour{

    [SerializeField] private StoreItemSO storeItemSO;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private ShopManager shopManager;
    [SerializeField] private Button buyButton;
    [SerializeField] private GameObject statusUI;
    [SerializeField] private TextMeshProUGUI statusText;

    void Start(){
        buyButton.onClick.AddListener(OnBuyItem);
        shopManager.OnFailedPurchase += ShopManager_OnFailedPurchase;
        shopManager.OnSuccessfulPurchase += ShopManager_OnSuccessfulPurchase;
        shopManager.OnNotOnStock += ShopManager_OnNotOnStock;
    }

    private void ShopManager_OnNotOnStock(object sender, EventArgs e)
    {
        statusUI.SetActive(true);
        statusText.text = "Not Available";
        StartCoroutine(Timer());
    }

    private void ShopManager_OnSuccessfulPurchase(object sender, EventArgs e)
    {
        statusUI.SetActive(true);
        statusText.text = "Successful Purchase";
        StartCoroutine(Timer());
    }

    private void ShopManager_OnFailedPurchase(object sender, EventArgs e)
    {
        statusUI.SetActive(true);
        statusText.text = "Not Enough Money";
        StartCoroutine(Timer());
    }

    private void OnBuyItem()
    {
        shopManager.BuyItem(storeItemSO, playerInventory);
    }

    IEnumerator Timer(){
        yield return new WaitForSeconds(3);
        statusUI.SetActive(false);
    }
}
