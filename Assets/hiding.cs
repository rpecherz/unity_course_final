using UnityEngine;

public class Hiding : MonoBehaviour
{
    private Transform co_chcemy;
    private MeshRenderer houdini;
    private MeshCollider zas;
    private bool inside = false;
    private static Vector3 powrotnaPozycja;
    private Quaternion powrotnaRotacja;

    [SerializeField] private Transform playerek;

    void Start()
    {
        co_chcemy = transform; 
        houdini = GetComponent<MeshRenderer>();
        zas = GetComponent<MeshCollider>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player")) 
        {
            inside = true;
            Debug.Log("thunder");
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            inside = false;

        }
    }

    void FixedUpdate()
    {
        if (inside && !PlayerMovement.isHiding && Input.GetKeyDown(KeyCode.E))
        {
            inside = false;
            houdini.material.color = new Color(houdini.material.color.r, houdini.material.color.g, houdini.material.color.b, 0); 
            zas.enabled = false;

            powrotnaPozycja = playerek.position;
            Debug.Log(powrotnaPozycja);
            powrotnaRotacja = playerek.rotation;

            playerek.position = co_chcemy.position;
            playerek.rotation = co_chcemy.rotation;
            PlayerMovement.isHiding = true;

        }
        else if (PlayerMovement.isHiding && Input.GetKeyDown(KeyCode.R))
        {
            playerek.position = powrotnaPozycja;
            Debug.Log(playerek.position);
            playerek.rotation = powrotnaRotacja;

            houdini.material.color = new Color(houdini.material.color.r, houdini.material.color.g, houdini.material.color.b, 1); 
            zas.enabled = true;
            Debug.Log(zas.enabled);

            PlayerMovement.isHiding = false;
        }
    }
}
