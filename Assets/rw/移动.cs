using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 移动 : MonoBehaviour
{
    public float runSpend;
    private Rigidbody2D myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }
    void Run()
    {
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playervei = new Vector2(moveDir * runSpend, myRigidbody.velocity.y);
        myRigidbody.velocity = playervei;
    }
}
