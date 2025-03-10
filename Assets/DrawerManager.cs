using UnityEngine;

public class DrawerManager : MonoBehaviour
{
    [SerializeField] private float openingSpeed = 2f; 
    [SerializeField] private float openDistance = 0.01f; 
    [SerializeField] private float interactionRange = 2.2f; 
    [SerializeField] private AudioSource audioSource; 

    private void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, interactionRange))
        {
            Debug.Log("nachodzi");
            if (Input.GetKeyDown(KeyCode.E) && hit.collider.CompareTag("Szuflada"))
            {
                Debug.Log("powinno dzialac");
                Szaffa drawer = hit.collider.GetComponent<Szaffa>();
                if (drawer != null)
                {
                    drawer.Toggle(openDistance, openingSpeed, audioSource);
                }
            }
        }
    }
}
