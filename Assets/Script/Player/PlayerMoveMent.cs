using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{
    #region var
    
    [Header("config")]
    [SerializeField]private float moveSpeed;

    private PlayerActions _actions;
    private Rigidbody2D rb2D;
    private Vector2 moveDirection;
    
    #endregion
    
    #region Mono
    private void Awake()
    {
        _actions = new PlayerActions(); 
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReadMovement();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnEnable()
    {
        _actions.Enable();
    }

    private void OnDisable()
    {
        _actions.Disable();
    }
    

    #endregion

    #region private
    /// <summary>
    /// 获取移动输入值
    /// </summary>
    private void ReadMovement()
    {
        moveDirection = _actions.Movement.Move.ReadValue<Vector2>().normalized;
    }
    /// <summary>
    /// 根据移动输入值进行移动
    /// </summary>
    private void Move()
    {
        Flip();
        rb2D.MovePosition(rb2D.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
    /// <summary>
    /// 根据移动输入值的x值大于小于0来对Player进行翻转
    /// </summary>
    private void Flip()
    {
        if (moveDirection.x > 0) transform.eulerAngles = new Vector3(0, 0, 0);
        if (moveDirection.x < 0) transform.eulerAngles = new Vector3(0, 180, 0); 
    }
    #endregion
    
}
