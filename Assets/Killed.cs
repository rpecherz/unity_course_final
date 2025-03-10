using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Killed : MonoBehaviour
{
    private Transform potworek;
    public AudioSource a1;
    [SerializeField] private Transform ending;
    [SerializeField] private Light swiatlo; 
    [SerializeField] private PlayerMovement p;

    private Animator animate; 
    void Start()
    {
        animate = GetComponent<Animator>();
        potworek = GetComponent<Transform>();
    }
    void LateUpdate()
    {
        if (follow.isDead)
        {
            StartCoroutine(HandleDeath());
        }
    }

    private IEnumerator HandleDeath()
    {
        follow.isDead = false;
        follow.agent.enabled = false;
        potworek.LookAt(follow.pl);
        potworek.position = new Vector3(potworek.position.x, potworek.position.y, potworek.position.z);
        p.enabled = false;
        ending.LookAt(potworek);
        animate.Play("jumpscare");
        a1.Play();
        yield return new WaitForSeconds(1.4f); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

}
