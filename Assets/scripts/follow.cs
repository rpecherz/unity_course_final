using UnityEngine;
using UnityEngine.AI; 

public class follow : MonoBehaviour
{
    private Vector3[] pozycje = new Vector3[]
    {
        new Vector3(-34.96f, 0.71f, -8.41f),
        new Vector3(-30.98f, 9.82f, 8.21f),
        new Vector3(-30.03f, 9.82f, 4f),
        new Vector3(-14.763f, 12.745f, 5.5f),
        new Vector3(-14.29f, 9.82f,-16f),
        new Vector3(-4.64f, 9.82f, 0.7f),
        new Vector3(3.13f, 9.82f, 14.16f),
        new Vector3(28f, 9.82f, -4f),
        new Vector3(30.5f, 1.08f, 0.35f),
        new Vector3(11.65f,1.08f,11.24f)
    };
    public static bool isDead=false;
    public Transform player;
    public static Transform pl;
    private Transform poz; 
    public static NavMeshAgent agent; 
    [SerializeField] private SkinnedMeshRenderer meshek;
    [SerializeField] private float sightRange = 30f;
    [SerializeField] private float fieldOfViewAngle = 150f;
    private Animator animate;
    private float huntCD,huntDuration; 
    private bool isMeshOn = false,turnMuzyka = true,isHunting = false;
    [SerializeField] private AudioSource a1,a2;
    private float RandCD = 0f,angleToPlayer;
    private Vector3 directionToPlayer,dokad;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        poz = GetComponent<Transform>();
        animate = GetComponent<Animator>();
        huntDuration = Random.Range(15f,20f);
        huntCD = Random.Range(10f,12f);
        a1.Play();
    }
    void OnTriggerEnter(Collider collider)
    {
        if(huntCD<=0 && collider.gameObject.CompareTag("Player"))
        {
            
            isDead = true;
        }
    }

    void Update()
    {
        pl = player;
        RandCD -= Time.deltaTime;
        meshek.enabled = isMeshOn;
        if(huntCD>0)
        {
            agent.isStopped = true;
            huntCD -= Time.deltaTime;
            isMeshOn = false;
        }
        else
        {
            directionToPlayer = player.position - transform.position;
            angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);
            if(huntDuration<=0)
            {
                a2.Stop();
                a1.Play();
                turnMuzyka = true;
                huntCD = Random.Range(20f,22f);
                huntDuration = Random.Range(25f,35f);
                isMeshOn = false;
                poz.position = pozycje[Random.Range(0,pozycje.Length)];
                return;
            }
            agent.isStopped = false;
            isMeshOn = true;
            if(turnMuzyka)
            {
                turnMuzyka = false;
                a1.Stop();
                a2.Play();
            }
            huntDuration -= Time.deltaTime;
            // jezeli go widzi to goni go
            if (!PlayerMovement.isHiding && directionToPlayer.magnitude < sightRange && angleToPlayer < fieldOfViewAngle / 2)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position + Vector3.up, directionToPlayer.normalized, out hit, sightRange))
                {
                    if (hit.transform == player && hit.collider.CompareTag("Player"))
                    {
                        animate.Play("crawl");
                        agent.SetDestination(player.position);
                        agent.speed = 8f;
                        RandCD = Mathf.Max(RandCD,7f);
                    }
                }
            }
            // w przeciwnym biega po chacie??
            else
            {
                if(!(animate.GetCurrentAnimatorStateInfo(0).IsName("norm")))
                    animate.Play("norm");
                if(RandCD<=0 || (RandCD>0 && poz.position == dokad))
                {
                    RandCD = Random.Range(3f,10f);
                    dokad = pozycje[Random.Range(0,pozycje.Length)];
                    agent.SetDestination(dokad);
                    agent.speed = 25f;
                    Debug.Log(dokad.x);
                    Debug.Log(dokad.y);
                }
            }
        }
    }
}
