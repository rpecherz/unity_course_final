using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private TextMeshProUGUI text;
    private Vector3 originalScale;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = originalScale * 1.2f; 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale; 
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (CompareTag("play"))
        {
            SceneManager.LoadScene("poziom"); 
        }
        else if (CompareTag("quit"))
        {
            Application.Quit(); 
            Debug.Log("Zamknięcie gry"); 
        }
    }
}
