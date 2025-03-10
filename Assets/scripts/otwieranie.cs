using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    private bool isOpen = false;
    public static bool open_padlock = false,open_front = false,padlockoff = false;
    public float rotationSpeed = 2f; 
    public static float wynik = 0f;


    [SerializeField] private Quaternion closedRotation; 
    [SerializeField] private Quaternion openRotation;
    [SerializeField] private AudioSource a1;

    
    void Update()
    {

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 3.5f))
        {
            if (Input.GetKeyDown(KeyCode.E) && hit.collider != null)
            {
                switch (hit.collider.tag)
                {
                    case "Door":
                        isOpen = !isOpen;
                        a1.Play();
                        break;
                    case "coin":
                        wynik += 1000;
                        respykluczy.bling.Play();
                        hit.collider.gameObject.SetActive(false);
                        break;
                    case "rzezba":
                        wynik += 10000;
                        respykluczy.bling.Play();
                        hit.collider.gameObject.SetActive(false);
                        break;
                    case "gold":
                        wynik += 5000;
                        respykluczy.bling.Play();
                        hit.collider.gameObject.SetActive(false);
                        break;
                    case "frontkey":
                        open_front = true;
                        break;
                        
                    case "padlockkey":
                        open_padlock = true;
                         Debug.Log("padlockkey");
                        break;
                    case "padlock":
                        if (open_padlock && hit.rigidbody != null)
                        {
                            hit.rigidbody.isKinematic = false;

                            padlockoff = true;
                            Debug.Log("padlock klikniety");
                        }
                        break;
                    case "door_main":
                        if(padlockoff && open_front)
                            SceneManager.LoadScene("koncowawygrana");
                        break;
                    default:
                        break;
                }
            }

        }
        if (isOpen)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, openRotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, closedRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
