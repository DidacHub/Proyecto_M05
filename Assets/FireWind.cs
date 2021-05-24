using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWind : MonoBehaviour
{
    public Transform firePoint;
    public GameObject WindProjectile;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            Shoot();
    }

    void Shoot()
    {
        Instantiate(WindProjectile, firePoint.position, firePoint.rotation);
    }
}
