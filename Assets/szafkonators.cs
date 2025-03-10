using UnityEngine;

public class szafkonators : MonoBehaviour
{
    private bool isOpen = false,canToggle = true;
    private float rotationSpeed = 3f; 
    private float toggleCooldown = 0.7f;

    [SerializeField] private Quaternion closedRotation;
    [SerializeField] private Quaternion openRotation;
    [SerializeField] private float length = 3.5f;

    void LateUpdate()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, length))
        {
            Debug.Log(hit.collider.tag);
            if (Input.GetKeyUp(KeyCode.E) && hit.collider.CompareTag("szafka"))
            {
                if (canToggle) 
                {
                    canToggle = false;
                    toggleCooldown = 0.7f;
                    szafkonators szafa = hit.collider.GetComponent<szafkonators>();
                    if (szafa != null)
                        szafa.togyl();
                }
            }
        }
        if(toggleCooldown <= 0f)
            canToggle = true;
    }

    void FixedUpdate()
    {
        toggleCooldown -= Time.deltaTime;
        if (isOpen)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, openRotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, closedRotation, Time.deltaTime * rotationSpeed);
        }
    }

    public void togyl()
    {
        isOpen = !isOpen;
        Debug.Log("Cabinet is now " + (isOpen ? "open" : "closed"));
    }
}
