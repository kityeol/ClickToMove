using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deathEffect;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Death()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        StartCoroutine(Wait());
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        health -= 25;
    }
}
