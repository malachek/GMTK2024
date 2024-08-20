using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour{

    [SerializeField] private StoreItemSO storeItemSO;
    [SerializeField] private Button buyButton;

    void Start(){
        buyButton.onClick.AddListener(OnBuyItem);
    }

    private void OnBuyItem()
    {
        ShopManager.Instance.BuyItem(storeItemSO, PlayerInventory.Instance);
    }
}
