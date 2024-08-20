using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodController : MonoBehaviour
{
    [Header("Jar")]
    [SerializeField] Transform JarTransform;


    [Header("Cinemachine")]
    [Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
    public GameObject CinemachineCameraTarget;

    [Tooltip("Default FOV")]
    [SerializeField] float OriginalGodCameraFOV;


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


    private PlayerSwitch _playerSwitch;
    [SerializeField] CinemachineVirtualCamera myCamera;

    [SerializeField] Transform CameraPivot;



    private const float _threshold = 0.01f;


    public delegate void RotateJar();
    public static event RotateJar OnRotateJar;

    private void Awake()
    {
        PlayerSwitch.OnSwitchToGod += HandleSwitchToGod;
    }
    // Start is called before the first frame update
    void Start()
    {
        _playerSwitch = FindObjectOfType<PlayerSwitch>();
        myCamera.m_Lens.FieldOfView = OriginalGodCameraFOV;

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
        float hor = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        if (hor != 0f)
        {
            OnRotateJar?.Invoke();
            JarTransform.Rotate(0f, hor * -2f * myCamera.m_Lens.FieldOfView * Time.deltaTime, 0f);
        }

        if (vert != 0f)
        {
            float newFOV = myCamera.m_Lens.FieldOfView - vert * .25f;

            if (newFOV >= 70f)
            {
                myCamera.m_Lens.FieldOfView = 70f;
            }
            else if (newFOV <= 20f)
            {
                myCamera.m_Lens.FieldOfView = 20f;
            }
            else
            {
                myCamera.m_Lens.FieldOfView = newFOV;
            }
        }
    }

    void HandleSwitchToGod()
    {
        ResetCameraPosition();
    }

    void ResetCameraPosition()
    {
        Debug.Log("Resetting Camera Position");
        myCamera.m_Lens.FieldOfView = OriginalGodCameraFOV;
    }


    private void SwitchPlayer()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            /*_input.sprint = false;
            _input.jump = false;
            _input.move = Vector2.zero;
            _input.look = Vector2.zero;
            _input.switchPlayer = false;*/
            _playerSwitch.SwitchPlayer();
        }
    }



    private void CameraRotation()
    {

        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Calculate squared magnitude of the input
        float sqrMagnitude = Mathf.Pow(mouseX, 2) + Mathf.Pow(mouseY, 2);

        bool isMouseInput = Mathf.Abs(mouseX) > 0.01f || Mathf.Abs(mouseY) > 0.01f;

        // if there is an input and camera position is not fixed
        if (sqrMagnitude >= _threshold && !LockCameraPosition)
        {
            // Don't multiply mouse input by Time.deltaTime for mouse input
            float deltaTimeMultiplier = isMouseInput ? 1.0f : Time.deltaTime;

            _cinemachineTargetYaw += mouseX * deltaTimeMultiplier;
            _cinemachineTargetPitch += mouseY * deltaTimeMultiplier;
        }

        // Clamp our rotations so our values are limited to 360 degrees
        _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, -45f, 45f);
        _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

        // Rotate the camera pivot
        CameraPivot.Rotate(0f, 50f * mouseX * Time.deltaTime, 0f);

        // Cinemachine will follow this target
        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride, _cinemachineTargetYaw, 0.0f);

    }

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }
}