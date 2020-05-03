using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{

    public new Rigidbody rigidbody;
    private Transform defaultPosition;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        defaultPosition = rigidbody.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if((rigidbody.transform.position.x - defaultPosition.position.x) < 5)
        {
            
            rigidbody.AddForce(rigidbody.transform.up * 10, ForceMode.Acceleration);
        }
        
    }
}
