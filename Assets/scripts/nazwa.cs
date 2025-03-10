using UnityEngine;
using TMPro;

public class nazwa : MonoBehaviour
{
    TMP_Text t1;
    void Start()
    {
        t1 = GetComponent<TMP_Text>();
    }
    void Update()
    {
        if (t1 != null)
        {
            t1.text = DoorInteraction.wynik.ToString();
        }
    }
}
