using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotSeeds : MonoBehaviour{

    [SerializeField] private EItemType eItemType;
    [SerializeField] private InventoryType inventoryType;
    [SerializeField] private Transform transformPackage, spawnLocation;
    [SerializeField] private Button button;
    [SerializeField] private Image image;
    [SerializeField] private Sprite sprite;
    [SerializeField] private TextMeshProUGUI count;

    private InventoryStackSO inventoryStackSO;

    public enum InventoryType{
        Seed,
        Fertilizer,
        Decoration
    }

    private void Start(){

        button.onClick.AddListener(OnInteract);

        switch (inventoryType){
            case InventoryType.Seed:
                inventoryStackSO = PlayerInventory.Instance.GetInventoryStackSO(eItemType, PlayerInventory.Instance.SeedsInventory);
                break;
            case InventoryType.Fertilizer:
                inventoryStackSO = PlayerInventory.Instance.GetInventoryStackSO(eItemType, PlayerInventory.Instance.FertilizerInventory);
                break;
            case InventoryType.Decoration:
                inventoryStackSO = PlayerInventory.Instance.GetInventoryStackSO(eItemType, PlayerInventory.Instance.DecorationsInventory);
                break;
        }

        ShopManager.Instance.OnSuccessfulPurchase += UpdateVisuals;

        image.sprite = sprite; 
        count.text = inventoryStackSO.itemsInStack.ToString();
    }

    private void UpdateVisuals(object sender, EventArgs e)
    {
        count.text = inventoryStackSO.itemsInStack.ToString();
    }

    public void OnInteract()
    {
        if(inventoryStackSO.itemsInStack >= 1){
            inventoryStackSO.baseDataSOArray[inventoryStackSO.itemsInStack-1] = null;
            inventoryStackSO.itemsInStack--;
            Debug.Log(Instantiate(transform, spawnLocation.position, Quaternion.identity));
            Instantiate(transformPackage, spawnLocation.position, Quaternion.identity);
            count.text = inventoryStackSO.itemsInStack.ToString();
        }
    }
}
