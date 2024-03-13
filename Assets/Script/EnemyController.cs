using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float rotationSpeed = 2f;
    public float minDistance = 5f;
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
}
