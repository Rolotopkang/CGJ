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
    public float shadowJumpStrenth;
    public float playerJumpStrenth;
    public int MaxJumpTimes;
    public bool isShadow;
    public bool isCurrentPlayer;
    public bool isInputTurn =false;

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

    private void Awake() {
        jumpstrenth = playerJumpStrenth;
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
            PhysicsCheck();
        }
        SwitchAnim();
    }

    private void Update() {
        Keydown();
        ChangeShadowAttribute();
    }

    private void Movement()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float jumpMove = Input.GetAxis("Jump");
        //人物左右移动
        if (isInputTurn) {
            horizontalMove = -horizontalMove;
        }
        rb2d.velocity = new Vector2(speed * horizontalMove * Time.fixedDeltaTime, rb2d.velocity.y);
        
        if (isGround)
        {
            JumpTimes = MaxJumpTimes;
            isJump = false;
            anim.SetBool("jumping",false);
        }

        if (jumpPresseed && isGround)
        {
            isJump = true;
            // jumping.Play();
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpstrenth * Time.fixedDeltaTime);
            JumpTimes--;
            jumpPresseed = false;
        }
        else if (jumpPresseed && JumpTimes > 0 && isJump)
        {
            // jumping.Play();
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpstrenth * Time.fixedDeltaTime);
            JumpTimes--;
            jumpPresseed = false;
        }
        else if (jumpPresseed && JumpTimes > 0 && !isGround && rb2d.velocity.y < 0)
        {
            // jumping.Play();
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpstrenth * Time.fixedDeltaTime);
            JumpTimes--;
            jumpPresseed = false;
        }
        
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
    
    void PhysicsCheck()
    {
        RaycastHit2D leftcheck = Raycast(new Vector2(-footOffset, 0f),
            Vector2.down, groundDistance, ground);
        RaycastHit2D rightcheck = Raycast(new Vector2(footOffset, 0f),
            Vector2.down, groundDistance, ground);
        if (leftcheck || rightcheck)
            isGround = true;
        else
            isGround = false;
    }
    
    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDiraction, float length, LayerMask layer)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDiraction, length, layer);
        Color color = hit ? Color.green : Color.red;
        Debug.DrawRay(pos+offset,rayDiraction*length,color);
        return hit;
    }

    private void Keydown() {
        if (Input.GetButtonDown("Jump") && JumpTimes > 0) {
            jumpPresseed = true;
        }
    }

    private void ChangeShadowAttribute() {
        if (isShadow && isInputTurn) {
            jumpstrenth = shadowJumpStrenth;
        } else {
            jumpstrenth = playerJumpStrenth;
        }
    }
    
    private void SwitchAnim()
    {
        anim.SetFloat("running", Mathf.Abs(rb2d.velocity.x));

        if (isShadow) 
        {
            if (isGround)
            {
                anim.SetBool("falling", false);
            }
            else if (!isGround && rb2d.velocity.y <= 0)
            {
                anim.SetBool("jumping", true);
                anim.SetBool("falling", false);
            }
            else if (!isGround && rb2d.velocity.y > 0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }
        else
        {
            if (isGround)
            {
                anim.SetBool("falling", false);
            }
            else if (!isGround && rb2d.velocity.y >= 0)
            {
                anim.SetBool("jumping", true);
                anim.SetBool("falling", false);
            }
            else if (!isGround && rb2d.velocity.y < 0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }
        
    }
}
