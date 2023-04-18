using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float lookSpeed = 2.0f;
    [SerializeField] private float lookXLimit = 45.0f;
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private AudioSource walkSfxSource;
    [SerializeField] private bool sfxPlaying;
    [SerializeField] private bool canMove = true;
    [SerializeField] private bool canLook = true;
    [SerializeField] private Rigidbody rigidbody;
    private float _rotationX;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (canMove && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || 
                        Input.GetKey(KeyCode.W) ||Input.GetKey(KeyCode.D)))
        {
            Move();
            if (!sfxPlaying)
            {
                walkSfxSource.Play();
                sfxPlaying = true;
            }
        }
        else
        {
            if (sfxPlaying)
            {
                walkSfxSource.Stop();
                sfxPlaying = false;
            }
        }

        if (canLook) Look();
    }

    private void Move()
    {
        var curSpeedX = Input.GetAxis("Horizontal");
        var curSpeedY = Input.GetAxis("Vertical");
        var moveDirection = new Vector3(curSpeedX, 0, curSpeedY);
        rigidbody.AddRelativeForce ((moveDirection * moveSpeed));
    }
    private void Look()
    {
        _rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        _rotationX = Mathf.Clamp(_rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}