using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyItemUI : MonoBehaviour{

    [SerializeField] private StoreItemSO storeItemSO;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemsName, itemsPrice;

    void Start(){
        itemIcon.sprite = storeItemSO.baseDataSO.Sprite;
        itemsName.text = storeItemSO.baseDataSO.objectsName;
        itemsPrice.text = storeItemSO.basePrice.ToString();
    }
}
