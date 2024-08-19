using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private List<ItemStockSO> itemStockSOList;

    public event EventHandler OnSuccessfulPurchase;
    public event EventHandler OnFailedPurchase;
    public event EventHandler OnNotOnStock;

    private void Start(){
        //Subscribe to an event that will call BuyItem when the player wants to buy an item.
    }


    // Should also have a player parameter or at least inventory
    public void BuyItem(StoreItemSO itemSO, PlayerInventory playerInventory){

        bool foundItem = false;

        foreach (ItemStockSO itemStockSO in itemStockSOList){
            if (itemStockSO.itemSO.baseDataSO == itemSO.baseDataSO){
                if(itemStockSO.inStock > 0){

                    foundItem = true;

                    if(Transaction(itemSO, playerInventory)){
                        //Transaction was completed Successfuly 

                        OnSuccessfulPurchase?.Invoke(this, EventArgs.Empty);

                        itemStockSO.itemSold++;
                        itemStockSO.inStock--;

                        if(itemStockSO.inStock != itemStockSO.stockLimit){
                            StartCoroutine(Restock(itemStockSO));
                        }

                        break;
                    }

                    OnFailedPurchase?.Invoke(this, EventArgs.Empty);
                } 
            }
        }

        if(!foundItem){
            OnNotOnStock?.Invoke(this, EventArgs.Empty);
        }
    }

    // should take a payer script as parameter
    private bool Transaction(StoreItemSO itemSO, PlayerInventory playerInventory){

        bool isTransactionSuccessful = false;
        
        //Check for money and do transaction
        
        if(playerInventory.Money >= itemSO.basePrice){
            playerInventory.RemoveMoney(itemSO.basePrice);
            switch (itemSO.storeItemType){
                case StoreItemSO.StoreItemType.Seed: 
                    playerInventory.AddItemToInventory(itemSO.baseDataSO, playerInventory.SeedsInventory);
                    break;
                case StoreItemSO.StoreItemType.Fertilizer:
                    playerInventory.AddItemToInventory(itemSO.baseDataSO, playerInventory.FertilizerInventory);
                    break;
            } 
            isTransactionSuccessful = true;
        }
        
        return isTransactionSuccessful;
    }

    //Runs a timer in the background and increases the stock
    private IEnumerator Restock(ItemStockSO itemStockSO){
        for (int i = 0; i < 10; i++){
            if(itemStockSO.inStock == itemStockSO.stockLimit) break;
            yield return new WaitForSeconds(itemStockSO.restockTime);
            itemStockSO.inStock++;
        }
    }
}
