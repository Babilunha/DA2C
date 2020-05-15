using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{
    public float lookRadius = 10f;


    //rigidbody of the enemy to perform physics on
    private new Rigidbody rigidbody;



    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();


    }

    private void Update()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
