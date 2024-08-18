using Cinemachine;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class DecorationSprite : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;

    [SerializeField] 
    SO_Decoration decorData;

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = decorData.Sprite;
    }


    protected virtual void Update()
    {
        transform.parent.transform.LookAt(PlayerSwitch.GetLookLocation());
    }


}
