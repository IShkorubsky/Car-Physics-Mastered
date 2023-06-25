using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAl = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float _horizontalInput;
    private float _verticalInput;
    private float _currentSteerAngle;
    private float _currentBreakForce;
    private bool _isBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;
    
    [SerializeField] private MeshRenderer frontLeftWheelTransform;
    [SerializeField] private MeshRenderer frontRightWheelTransform;
    [SerializeField] private MeshRenderer rearLeftWheelTransform;
    [SerializeField] private MeshRenderer rearRightWheelTransform;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        _horizontalInput = Input.GetAxis(HORIZONTAl);
        _verticalInput = Input.GetAxis(VERTICAL);

        if (_verticalInput == 0 || Input.GetKey(KeyCode.Space))
        {
            _isBreaking = true;
        }
        else
        {
            _isBreaking = false;
        }
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = _verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = _verticalInput * motorForce;
        rearLeftWheelCollider.motorTorque = _verticalInput * motorForce;
        rearRightWheelCollider.motorTorque = _verticalInput * motorForce;
        _currentBreakForce = _isBreaking ? breakForce : 0f;
        ApplyBreaking();

    }

    private void ApplyBreaking()
    {
        frontLeftWheelCollider.brakeTorque = _currentBreakForce;
        frontRightWheelCollider.brakeTorque = _currentBreakForce;
        rearLeftWheelCollider.brakeTorque = _currentBreakForce;
        rearRightWheelCollider.brakeTorque = _currentBreakForce;
    }

    private void HandleSteering()
    {
        _currentSteerAngle = maxSteerAngle * _horizontalInput;
        frontLeftWheelCollider.steerAngle = _currentSteerAngle;
        frontRightWheelCollider.steerAngle = _currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, MeshRenderer wheelMeshRenderer)
    {
        wheelCollider.GetWorldPose(out var position,out var rotation);
        wheelMeshRenderer.transform.position = position;
        wheelMeshRenderer.transform.rotation = rotation;
    }
}
