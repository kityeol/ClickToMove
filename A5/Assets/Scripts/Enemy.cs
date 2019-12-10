using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Death()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
