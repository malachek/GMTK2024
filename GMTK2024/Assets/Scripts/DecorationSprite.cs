using Cinemachine;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class DecorationSprite : MonoBehaviour
{

    public void SetSprite(Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }


    protected virtual void Update()
    {
        transform.parent.transform.LookAt(PlayerSwitch.GetLookLocation());
    }


}
