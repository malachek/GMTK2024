using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ItemsSO")]
public class StoreItemSO : ScriptableObject{

    public enum StoreItemType{
        Seed,
        Fertilizer,
        Decoration
    }

    public BaseDataSO baseDataSO;
    public float basePrice;
    public int bundleNum;
    public StoreItemType storeItemType;
    public float priceMultiplier;
    public float priceMultiplierModifier; // once player buy more than the supplyLimiter this will be added to the 
                                          // pricemultiplier to increase prices even more.
    public int supplyLimiter;

}
