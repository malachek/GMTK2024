using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractGodMode : MonoBehaviour{

    private BaseDataSO baseDataSO;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Camera mainCamera;

    void Update(){

        if (Input.GetMouseButtonDown(0)){

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask)){

                if(baseDataSO != null){
                    if (hit.collider.gameObject.GetComponent<Soil>() != null){
                        InsertFertilizer(hit.collider.gameObject.GetComponent<Soil>());
                    }
                }
                else{
                    hit.collider.gameObject.GetComponent<InventorySlot>()?.OnInteract(this);
                    hit.collider.gameObject.GetComponent<Ducky>()?.OnInteract(this);
                    hit.collider.gameObject.GetComponent<SunScript>()?.OnInteract(this);

                }
            }
        }
    }

    public void SetBaseDataSO(BaseDataSO baseDataSO){
        if(this.baseDataSO == null){
            Debug.Log(baseDataSO);
            this.baseDataSO = baseDataSO;
        }
    }

    private void InsertFertilizer(Soil soil){
        FertilizerSO fertilizerSO = baseDataSO as FertilizerSO;
        soil.HealSoil(fertilizerSO.healthBooster * 100);
        baseDataSO = null;
    }
}
