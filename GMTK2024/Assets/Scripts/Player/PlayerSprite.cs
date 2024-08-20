using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField]
    List<Sprite> sprites;

    SpriteRenderer sr;

    [SerializeField]
    Transform cameraPos;

    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprites[4];
    }

    private void Update()
    {
        transform.rotation = Quaternion.identity;

        Vector3 dir = cameraPos.position - transform.position;
        dir.y = 0f;

        transform.rotation = Quaternion.LookRotation(dir);

        //transform.LookAt(new Vector3(cameraPos.position.x, 0f, cameraPos.position.z));
    }

    public void UpdateSprite(Vector2 moveDir)
    {
        //Debug.Log(moveDir);
        switch ((int)moveDir.x, (int)moveDir.y)
        {
            case (0, -1):
                sr.sprite = sprites[0];
                break;

            case (1, - 1):
                sr.sprite = sprites[7];
                break;

            case (1, 0):
                sr.sprite = sprites[6];
                break;

            case (1, 1):
                sr.sprite = sprites[5];
                break;

            case (0, 1):
                sr.sprite = sprites[4];
                break;

            case (-1, 1):
                sr.sprite = sprites[3];
                break;

            case (-1, 0):
                sr.sprite = sprites[2];
                break;

            case (-1, -1):
                sr.sprite = sprites[1];
                break;
        }
    }
}
