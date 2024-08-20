using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ItemStock")]
public class ItemStockSO : ScriptableObject{

    public StoreItemSO itemSO;
    public int stockLimit;
    public int inStock;
    public float restockTime;
    public int itemSold;
}
