using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destoyable : MonoBehaviour
{

    
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "damageDealer")
        {
            particle.gameObject.SetActive(true);
            particle.Play();
            Destroy(gameObject);
        }
    }
}
