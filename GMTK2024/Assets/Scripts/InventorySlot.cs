using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour {

    [SerializeField] private EItemType eItemType;
    [SerializeField] private InventoryType inventoryType;

    private InventoryStackSO inventoryStackSO;

    public enum InventoryType{
        Seed,
        Fertilizer,
        Decoration
    }

    private void Start(){
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
    }

    public void OnInteract(InteractGodMode interactGodMode)
    {
        if(inventoryStackSO.itemsInStack >= 1){
            BaseDataSO baseDataSO = inventoryStackSO.baseDataSOArray[inventoryStackSO.itemsInStack-1];
            interactGodMode.SetBaseDataSO(baseDataSO);
            inventoryStackSO.baseDataSOArray[inventoryStackSO.itemsInStack-1] = null;
            inventoryStackSO.itemsInStack--;
        }
    }
}
