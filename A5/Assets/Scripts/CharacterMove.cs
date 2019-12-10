using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class CharacterMove : MonoBehaviour
{
    NavMeshAgent agent;
    public ParticleSystem clickParticle;
    public ParticleSystem enemyParticle;

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
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                agent.destination = hit.point;
                anim.SetBool("isWalking", true);

                if (hit.collider.tag == "Range")
                {
                    Instantiate(enemyParticle, hit.point, Quaternion.identity);
                }
                else
                {
                    Instantiate(clickParticle, hit.point, Quaternion.identity);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Click")
        {
            anim.SetBool("isWalking", false);
        }

        else if (other.transform.tag == "Range")
        {
            anim.SetBool("isWalking", false);
            agent.destination = transform.position;
            StartCoroutine(Wait());
            anim.SetBool("Attacking", false);
        }
    }

    IEnumerator Wait()
    {
        anim.SetBool("Attacking", true);
        yield return new WaitForSeconds(1);
    }
}