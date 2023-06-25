using UnityEngine;

public class CarControllerArcade : MonoBehaviour
{
    private const string HORIZONTAl = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float _moveInput;
    private float _turnInput;
    private bool _isGrounded;

    [SerializeField] private float forwardSpeed;
    [SerializeField] private float reverseSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float airDrag;
    [SerializeField] private float groundDrag;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Rigidbody sphereRb;

    private void Start()
    {
        sphereRb.transform.parent = null;
    }

    private void Update()
    {
        _moveInput = Input.GetAxisRaw(VERTICAL);
        _turnInput = Input.GetAxisRaw(HORIZONTAl);
        _moveInput *= _moveInput > 0 ? forwardSpeed : reverseSpeed;

        transform.position = sphereRb.transform.position;

        _isGrounded = Physics.Raycast(transform.position, -transform.up, out var hit,1f, groundLayer);
        
        transform.rotation = Quaternion.FromToRotation(transform.up,hit.normal) * transform.rotation;

        if (_isGrounded)
        {
            var newRotation = _turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw(VERTICAL);
            transform.Rotate(0,newRotation,0,Space.World);
            sphereRb.drag = groundDrag;
        }
        else
        {
            sphereRb.drag = airDrag;
        }
    }

    private void FixedUpdate()
    {
        if (_isGrounded)
        {
            sphereRb.AddForce(transform.forward * _moveInput,ForceMode.Acceleration);
        }
        else
        {
            sphereRb.AddForce(transform.up * -20f);
        }
    }
}
