using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yidong : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private Transform target;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("1");
        if (collision.tag == "Player")
        {
            Destroy(this.gameObject,0.2f);
        }
    }
}
