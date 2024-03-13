using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{

    public Transform BulletSpawnPoint;
    public Transform orientation;
    public GameObject bulletPreFab;
    public float bulletSpeed;
    public AudioClip fireSound;
    public AudioSource fireSoundSource;

    private void Start()
    {
        fireSoundSource.clip = fireSound;
        fireSoundSource.loop = false;
        fireSoundSource.volume = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        bool fireInput = Input.GetMouseButtonDown(0);
        if(fireInput)
        {
            fireSoundSource.Play();
            var bullet = Instantiate(bulletPreFab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = orientation.forward * bulletSpeed;
        }
    }
}
