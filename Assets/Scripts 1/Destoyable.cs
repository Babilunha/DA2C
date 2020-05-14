using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destoyable : MonoBehaviour
{

    public float cubeSize = 5f;
    public int cubesInRow = 5;

    public float expolisionRodius = 5f;
    public float explosionForce = 50f;
    public float explosionUpward = 0.4f;


    float cubesPivotDistance;
    Vector3 cubesPivot;
    private ContactPoint contactPoint;

    private void Start()
    {
        

        cubesPivotDistance = cubeSize * cubesInRow / 2;

        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("damageDealer"))
        {
            contactPoint = collision.contacts[0];
            
            Explode(contactPoint.point);


        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.CompareTag("damageDealer"))
    //    {
    //        Explode();
    //    }
    //}

    private void Explode(Vector3 position)
    {
        gameObject.SetActive(false);

        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    createPieces(x, y, z);
                }
            }
        }

        //Vector3 expolisionPos = position;

        //Collider[] colliders = Physics.OverlapSphere(expolisionPos, expolisionRodius);

        //foreach (Collider hit in colliders)
        //{
        //    Rigidbody rb = hit.GetComponent<Rigidbody>();
        //    if (rb != null)
        //    {
        //        rb.AddExplosionForce(explosionForce, transform.position, expolisionRodius, explosionUpward);
        //    }
        //}
    }

    private void createPieces(int x, int y, int z)
    {
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;

        Destroy(piece, 5.0f);
    }
}
