using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform gun;
    public Transform bulletSpawnPosition;
    public float projectileSpeed = 100f;
    public ParticleSystem muzzleFlash;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        muzzleFlash.Play();
        //bulletSpawnPosition.rotation = gun.rotation;
        //GameObject _isntanceOfBullet = Instantiate(bullet, bulletSpawnPosition.position, Quaternion.identity) as GameObject;
        GameObject _isntanceOfBullet = Instantiate(bullet, bulletSpawnPosition.position, gun.rotation) as GameObject;
        Rigidbody _instanceOfBulletRigidbody = _isntanceOfBullet.GetComponent<Rigidbody>();
        //_instanceOfBulletRigidbody.rotation = gun.rotation;
        _instanceOfBulletRigidbody.AddForce(gun.forward * projectileSpeed, ForceMode.Impulse);
    }
}
