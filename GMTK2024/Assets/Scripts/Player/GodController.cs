using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class GodController : MonoBehaviour
{



#if ENABLE_INPUT_SYSTEM
    private StarterAssetsInputs _input;
#endif

    private PlayerSwitch _playerSwitch;
    [SerializeField] CinemachineVirtualCamera myCamera;


    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _playerSwitch = FindObjectOfType<PlayerSwitch>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateAndZoom();
        SwitchPlayer();
    }

    private void RotateAndZoom()
    {
        if (_input.move != Vector2.zero)
        {
            Debug.Log($"X: {_input.move.x} | Y: {_input.move.y}");
            transform.Rotate(0f, _input.move.x * -2f * myCamera.m_Lens.FieldOfView * Time.deltaTime, 0f);
            myCamera.m_Lens.FieldOfView -= _input.move.y * .25f;
        }
    }

    private void SwitchPlayer()
    {
        if (_input.switchPlayer)
        {
            _input.switchPlayer = false;
            _playerSwitch.SwitchPlayer();
        }
    }
}
