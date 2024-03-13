using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float rotationSpeed = 2f;
    public float minDistance = 5f;
    public AudioClip destroyAudio;

    private void Update()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 targetDir = player.position - gameObject.transform.position;
        float distance = targetDir.magnitude;
        if(distance > 5)
        {
            gameObject.transform.forward = Vector3.Slerp(gameObject.transform.forward, targetDir.normalized, rotationSpeed);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.position, minDistance * Time.deltaTime);
        }
        else
        {

        }
    }

    public void playDestroySound()
    {
        AudioSource audioSource = GameObject.FindGameObjectWithTag("globalSound").GetComponent<AudioSource>();
        audioSource.clip = destroyAudio;
        audioSource.loop = false;
        audioSource.volume = 1f;
        Debug.Log("Sound Played");
        audioSource.Play();
    }
}
