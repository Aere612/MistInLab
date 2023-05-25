using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    
    [SerializeField] private Camera playerCamera;
    
    [SerializeField] private float lookSpeed = 2.0f;
    [SerializeField] private float lookXLimit = 45.0f;
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float gravity = 5.0f;
    
    [SerializeField] private AudioSource walkSfxSource;
    [SerializeField] private bool sfxPlaying;
    
    private float _rotationX;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(!characterController.isGrounded) characterController.Move(Vector3.down * (gravity * Time.deltaTime));
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            Move();
            if (!sfxPlaying)
            {
                sfxPlaying = true;
                walkSfxSource.Play();
            }
        }
        else
        {
            if (sfxPlaying)
            {
                sfxPlaying = false;
                walkSfxSource.Stop();
            }
        }
        Look();
    }

    private void Move()
    {
        var forward = transform.TransformDirection(Vector3.forward);
        var right = transform.TransformDirection(Vector3.right);
        var curSpeedX = moveSpeed * Input.GetAxis("Vertical");
        var curSpeedY = moveSpeed * Input.GetAxis("Horizontal");
        var moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void Look()
    {
        _rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        _rotationX = Mathf.Clamp(_rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
        
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}