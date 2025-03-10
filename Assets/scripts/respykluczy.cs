using UnityEngine;

public class respykluczy : MonoBehaviour
{
    public static AudioSource bling,szafkha;
    public AudioSource jakistam,jakistam2;
    private Vector3[] pozycje = new Vector3[]
    {
        new Vector3(-17.268f, 11.85f, -8.677f),
        new Vector3(-17.268f, 11.941f, -6f),
        new Vector3(-17.30f, 11.941f, -3.57f),
        new Vector3(-14.763f, 12.745f, 5.5f),
        new Vector3(2.782f, 12.745f, 4.2f),
        new Vector3(4.27f, 12.745f, 4.21f),
        new Vector3(4.27f, 10.5f, 4.3f),
        new Vector3(2.87f, 10.5f, 4.35f),
        new Vector3(2.87f, 11.63f, 4.34f),
        new Vector3(3f, 12.7f, 4.34f),
        new Vector3(5.67f, 13.5f, -16.25f),
        new Vector3(7.8f, 13.5f, -16.25f),
        new Vector3(7.8f, 12.6f, -16.25f),
        new Vector3(21.58f, 10.143f, -12.8f),
        new Vector3(22.278f, 11.977f, -7.1f),
        new Vector3(22.297f, 12f, -6f),
        new Vector3(22.297f, 12f, -5.09f),
        new Vector3(22.297f, 12.67f, 4f),
        new Vector3(22.297f, 12.677f, 5.56f),
        new Vector3(22.297f, 11.85f, 3.72f),
        new Vector3(22.29f, 11.85f, 5.19f),
        new Vector3(20.45f, 5.745f, -2.7f),
        new Vector3(-33.302f, 4.9f, 17.9f),
        new Vector3(-33.302f, 3.37f, 17.176f),
        new Vector3(-31.812f, 3.395f, 17.176f),
        new Vector3(-24f, 3.347f, 2.48f),
        new Vector3(-32.616f, 2.426f, 17.374f),
        new Vector3(-22.615f, 3.347f, 2.5f),
        new Vector3(-22.615f, 2.341f, 2.5f)
    };

    [SerializeField] private Transform klucz1;
    [SerializeField] private Transform klucz2;
    [SerializeField] private MeshRenderer kluczyk1;
    [SerializeField] private MeshRenderer kluczyk2;

    void Start()
    {
        bling=jakistam;
        szafkha = jakistam2;
        int index1 = Random.Range(0, pozycje.Length);
        int index2 = Random.Range(0, pozycje.Length);
        while(index2==index1)
            index2= Random.Range(0, pozycje.Length);
        klucz1.position = pozycje[index1];
        klucz2.position = pozycje[index2];
    }
    void Update()
    {
        if(DoorInteraction.open_front)
            kluczyk1.enabled = false; 
        if(DoorInteraction.open_padlock)
            kluczyk2.enabled = false;
    }

}
