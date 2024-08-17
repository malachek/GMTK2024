using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class DecorationBase : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;

    [SerializeField] 
    SO_Decoration decorData;

    CinemachineBrain brain;



    protected virtual void Awake()
    {
        PlayerSwitch.OnSwitchPlayer += SwitchLookLocation;

        brain = Camera.main.GetComponent<CinemachineBrain>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = decorData.Sprite;

    }

    protected virtual void Update()
    {
        if (brain == null) return;
        
        CinemachineVirtualCamera activeVirtualCamera = brain.ActiveVirtualCamera as CinemachineVirtualCamera;

        Vector3 cameraPosition = activeVirtualCamera.transform.position;

        transform.LookAt(Vector3.Scale(cameraPosition, new Vector3(1f, 0f, 1f)), Vector3.up);
    }

    public void SwitchLookLocation()
    {
        Debug.Log($"Plant: {name} is switching look location now");
        brain = Camera.main.GetComponent<CinemachineBrain>();
    }
}
