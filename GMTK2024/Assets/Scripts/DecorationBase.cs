using Cinemachine;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class DecorationBase : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;

    [SerializeField] 
    SO_Decoration decorData;

    CinemachineBrain brain;

    [SerializeField]
    Transform godLook;
    //rotation?????
  
    [SerializeField]
    Transform playerLocation;

    protected bool isGodMode;

    delegate void OnOrientationUpdate();
    OnOrientationUpdate onOrientationUpdate;


    protected virtual void Awake()
    {
        //PlayerSwitch.OnSwitchPlayer += HandleSwitchPlayer;

        PlayerSwitch.OnSwitchToGod += HandleSwitchToGod;
        PlayerSwitch.OnSwitchToSmall += HandleSwitchToSmall;

        brain = Camera.main.GetComponent<CinemachineBrain>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = decorData.Sprite;
    }

    protected virtual void Start()
    {

    }

    protected void HandleSwitchToGod()
    {
        isGodMode = true;
    }

    protected void HandleSwitchToSmall()
    {
        isGodMode = false;
    }

    public void HandleSwitchPlayer(string PlayerMode)
    {
        SwitchLookLocation(PlayerMode.Equals("GOD"));
    }



    protected virtual void Update()
    {
        LookUpdate;

        transform.LookAt(CurrentLook);

        /* if (brain == null) return;
        
        CinemachineVirtualCamera activeVirtualCamera = brain.ActiveVirtualCamera as CinemachineVirtualCamera;

        Vector3 cameraPosition = activeVirtualCamera.transform.position;

        transform.LookAt(Vector3.Scale(cameraPosition, new Vector3(1f, 0f, 1f)), Vector3.up);*/
    }

    public void SwitchLookLocation(bool isGod)
    {
        Debug.Log($"Plant: {name} is switching look location now");
        smallLook = isGod ? godLook : smallLook;


       
        /*brain = Camera.main.GetComponent<CinemachineBrain>();*/
    }
}
