using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f;
    public Transform particle;
    // Start is called before the first frame update
    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //
        if(collision.gameObject.CompareTag("Enemy"))
        {
            LogicScript gameLogic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
            gameLogic.scoreUpdate(1);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Transform p = Instantiate(particle, collision.transform.position, collision.transform.rotation);
            Destroy(p.gameObject, 5f);
            
        }

    }
}
