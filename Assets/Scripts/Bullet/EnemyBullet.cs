using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Vector2 targetDirection;
    private float speed;
    private bool isAlive = true;
    void Start()
    {
        speed = 2.0f;
        targetDirection = (FindObjectOfType<PlayerControl>().transform.position - transform.position).normalized;
    }
    
    void Update()
    {
        if (isAlive) {
            transform.Translate(targetDirection * Time.deltaTime * speed);
        } else {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag.Equals("Ground"))
            isAlive = false;
    }
}
