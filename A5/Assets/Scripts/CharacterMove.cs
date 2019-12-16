using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class CharacterMove : MonoBehaviour
{
    public NavMeshAgent agent;
    public ParticleSystem clickParticle;
    public ParticleSystem enemyParticle;
    public float range = 10.0f;

    public Animator anim;
    //public enum CharacterState { Walking, Attacking }
    //public static CharacterState currentState;
    private bool Walking = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Vector3.Distance(agent.destination, transform.position) > range)
        {
            agent.isStopped = false;
            Vector3 lookAt = new Vector3(agent.destination.x, agent.transform.position.y, agent.destination.z);
            agent.transform.LookAt(lookAt);
            anim.SetBool("isWalking", true);
        }
        else
        {
            StartCoroutine(Wait());
            agent.isStopped = true;
        }
        if (Vector3.Magnitude(agent.velocity) == 0)
        {
            anim.SetBool("isWalking", false);
        }
    }

    public void Walk(RaycastHit hit)
    {
        agent.destination = hit.point;

        if (hit.collider.tag == "Enemy")
        {
            Instantiate(enemyParticle, hit.point, Quaternion.identity);
        }
        else
        {
            Instantiate(clickParticle, hit.point, Quaternion.identity);
        }
        

    }

    public void Attack(RaycastHit hit)
    {
        if (hit.transform.gameObject.CompareTag("Enemy") && Vector3.Distance(hit.transform.position, transform.position) <= range)
        {
            anim.SetBool("isWalking", false);
            agent.destination = transform.position;
            StartCoroutine(Wait());
            agent.isStopped = true;
        }
    }
    
    IEnumerator Wait()
    {
        anim.SetBool("Attacking", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("Attacking", false);
    }
}