using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float normalSpeed = 5.0f;
    public float sprintSpeed = 10.0f;
    public float sprintDuration = 5.0f;
    public float sprintCooldown = 10.0f;
    public float jumpHeight = 3.0f;
    public float gravity = -9.81f;
    public float mouseSensitivity = 500.0f;
    public AudioSource ad;

    private CharacterController controller;
    private float currentSpeed;
    private float sprintTimeRemaining;
    private bool isSprinting;
    private float cooldownTimeRemaining;
    private float verticalRotation = 0f;
    private Vector3 velocity;
    private bool canJump;
    public static bool isHiding = false;

    public Transform cameraTransform;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = normalSpeed;
        cooldownTimeRemaining = 0f;
        canJump = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if (cooldownTimeRemaining > 0f)
        {
            cooldownTimeRemaining -= Time.deltaTime;
        }
        if(isHiding)
        {
            velocity = Vector3.zero;
            return;
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * horizontal + transform.forward * vertical;
        controller.Move(direction * currentSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift) && sprintTimeRemaining <= 0f && cooldownTimeRemaining <= 0f)
        {
            isSprinting = true;
            sprintTimeRemaining = sprintDuration;
            cooldownTimeRemaining = sprintCooldown;
        }

        if (isSprinting)
        {
            currentSpeed = sprintSpeed;
            sprintTimeRemaining -= Time.deltaTime;

            if (sprintTimeRemaining <= 0f)
            {
                isSprinting = false;
                currentSpeed = normalSpeed;
            }
        }


        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            canJump = false;
        }
        velocity.y = Mathf.Max(-9.81f,velocity.y + gravity * 1.4f * Time.deltaTime);

        controller.Move(velocity*Time.deltaTime);

        HandleCamera();
    }
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("drank drank ");
        if(!collision.gameObject.CompareTag("Player"))
        {
            canJump = true;
            if(velocity != Vector3.zero)
            {
                float helper = Random.Range(1, 100);
                if(helper == 2)   
                    ad.Play();
            }
        }
    }
    void HandleCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
