using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEffect : MonoBehaviour
{

    private ContactPoint contactPoint;

    public GameObject BoomEffectParticle;

    public GameObject bomb;



    public float expolisionRodius = 50f;
    public float explosionForce = 100f;
    public float explosionUpward = 10f;

    private void Start()
    {
     
    }


    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.tag == "Environment")
        //{
        //    contactPoint = collision.contacts[0];

        //    GameObject _instanceOfBulletMark = Instantiate(BulletMark, contactPoint.point, Quaternion.LookRotation(contactPoint.normal)) as GameObject;

        //    _instanceOfBulletMark.transform.Rotate(Vector3.right * 90);

        //    _instanceOfBulletMark.transform.Translate(Vector3.up * 0.005f);

        //    Destroy(_instanceOfBulletMark, 3.0f);

        //    Destroy(this.gameObject);
        //}

        if (collision.gameObject.tag != "Player")
        {
            contactPoint = collision.contacts[0];

            GameObject _instanceOfBoomEffectParticle = Instantiate(BoomEffectParticle, contactPoint.point, Quaternion.LookRotation(contactPoint.normal)) as GameObject;

            Destroy(_instanceOfBoomEffectParticle, 2.0f);

            simulateExplosionAround();

            Destroy(this.gameObject);
        }

           

    }

    private void simulateExplosionAround()
    {
        Vector3 expolisionPos = bomb.transform.position;

        Collider[] colliders = Physics.OverlapSphere(expolisionPos, expolisionRodius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, expolisionPos, expolisionRodius, explosionUpward, ForceMode.Impulse);
            }
        }
    }




    //public ParticleSystem boom;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.gameObject.layer == 8)
    //    {
    //        ParticleSystem _isntanceOfBullet = Instantiate(boom, collision.transform.position, Quaternion.identity) as ParticleSystem;
    //    }

    //}
}
