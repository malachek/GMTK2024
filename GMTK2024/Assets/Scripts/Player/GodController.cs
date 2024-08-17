using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class GodController : MonoBehaviour
{
    [Header("Cinemachine")]
    [Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
    public GameObject CinemachineCameraTarget;

    [Tooltip("How far in degrees can you move the camera up")]
    public float TopClamp = 70.0f;

    [Tooltip("How far in degrees can you move the camera down")]
    public float BottomClamp = -30.0f;

    [Tooltip("Additional degress to override the camera. Useful for fine tuning camera position when locked")]
    public float CameraAngleOverride = 0.0f;

    [Tooltip("For locking the camera position on all axis")]
    public bool LockCameraPosition = false;

    private float _cinemachineTargetYaw;
    private float _cinemachineTargetPitch;


#if ENABLE_INPUT_SYSTEM
    private PlayerInput _playerInput;
#endif

    private StarterAssetsInputs _input;

    private PlayerSwitch _playerSwitch;
    [SerializeField] CinemachineVirtualCamera myCamera;

    [SerializeField] Transform CameraPivot;



    private const float _threshold = 0.01f;

    private bool IsCurrentDeviceMouse
    {
        get
        {
#if ENABLE_INPUT_SYSTEM
            return _playerInput.currentControlScheme == "KeyboardMouse";
#else
				return false;
#endif
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _playerInput = GetComponent<PlayerInput>();
        _playerSwitch = FindObjectOfType<PlayerSwitch>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateAndZoom();
        SwitchPlayer();
    }

    private void LateUpdate()
    {
        //CameraRotation();
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



    private void CameraRotation()
    {

        // if there is an input and camera position is not fixed
        if (_input.look.sqrMagnitude >= _threshold && !LockCameraPosition)
        {
            //Don't multiply mouse input by Time.deltaTime;
            float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;

            _cinemachineTargetYaw += _input.look.x * deltaTimeMultiplier;
            _cinemachineTargetPitch += _input.look.y * deltaTimeMultiplier;
        }

        // clamp our rotations so our values are limited 360 degrees
        _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, -45f, 45f);
        _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

        CameraPivot.Rotate(0f, 50f * _input.look.x * Time.deltaTime, 0f);

        return;
        // Cinemachine will follow this target
        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride,
            _cinemachineTargetYaw, 0.0f);
    }

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }
}
