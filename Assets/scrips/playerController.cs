using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerController : MonoBehaviour
{
    [Header("动态参数")] 
    //actor参数
    //private @ [SerializeField]
    [SerializeField] private bool jumpPresseed;
    [SerializeField] private int JumpTimes;
    [SerializeField] private bool isGround;
    [SerializeField] private bool isJump;
    [SerializeField] private bool isThroughPlatForms;

    //可调整参数
    //public 
    [Header("可调整参数")] 
    public float speed;
    public float jumpstrenth;
    public int MaxJumpTimes;
    public bool isShadow;
    public bool isCurrentPlayer;
    public bool isFollow;

    //定位辅助
    [Header("环境检测")] 
    public float footOffset = 0.4f;
    public float headClearance = 0.5f;
    public float groundDistance = 1.2f;
    
    public LayerMask ground;

    //组件
    [Header("组件")]
    private SpriteRenderer sprd;
    private Rigidbody2D rb2d;
    private Animator anim;
    private CapsuleCollider2D CapCl2d;

    private void Awake()
    {
        sprd = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        CapCl2d = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (isCurrentPlayer)
        {
            Movement();
        }
        SwitchAnim();
    }

    private void Movement()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float jumpMove = Input.GetAxis("Jump");
        //人物左右移动
        rb2d.velocity = new Vector2(speed * horizontalMove * Time.fixedDeltaTime, rb2d.velocity.y);
        //改变人物朝向
        
        if (rb2d.velocity.x < 0)
        {
            if (isShadow)
            {
                sprd.flipX = true;
            }
            else
            {
                sprd.flipX = false;
            }
        }
        else if(rb2d.velocity.x > 0)
        {
            if (isShadow)
            {
                sprd.flipX = false;
            }
            else
            {
                sprd.flipX = true;
            }
        }
    }
    
    private void SwitchAnim()
    {
        anim.SetFloat("running", Mathf.Abs(rb2d.velocity.x));
        // if (isGround)
        // {
        //     anim.SetBool("falling", false);
        // }
        // else if (!isGround && rb2d.velocity.y >= 0)
        // {
        //     anim.SetBool("jumping", true);
        //     anim.SetBool("falling", false);
        // }
        // else if (!isGround && rb2d.velocity.y < 0)
        // {
        //     anim.SetBool("jumping", false);
        //     anim.SetBool("falling", true);
        // }
    }
}
