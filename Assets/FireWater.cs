using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWater : MonoBehaviour
{
    public Transform firePoint;
    public GameObject WaterProjectile;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            Shoot();
    }

    void Shoot()
    {
        Instantiate(WaterProjectile, firePoint.position, firePoint.rotation);
    }
}

