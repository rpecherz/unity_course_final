using UnityEngine;

public class Szaffa : MonoBehaviour
{
    private Vector3 closedPosition;   
    private Vector3 openPosition;
    private bool isOpen = false;

    private void Start()
    {
        closedPosition = transform.localPosition;
        openPosition = closedPosition + new Vector3(0f, 0f, 0.01f);
    }

    public void Toggle(float openDistance, float openingSpeed, AudioSource audioSource)
    {
        isOpen = !isOpen;

        openPosition = closedPosition + new Vector3(0f, 0f, openDistance);

        StopAllCoroutines();
        StartCoroutine(MoveDrawer(openingSpeed));

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    private System.Collections.IEnumerator MoveDrawer(float openingSpeed)
    {
        Vector3 targetPosition = isOpen ? openPosition : closedPosition;

        while (Vector3.Distance(transform.localPosition, targetPosition) > 0.01f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * openingSpeed);
            yield return null;
        }

        transform.localPosition = targetPosition;
    }
}
