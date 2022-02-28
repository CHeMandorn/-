using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerController : MonoBehaviour
{
    public float movingSpeed =1.0f;
    public float jumpHeight = 20.0f;
    private Animator anim;
    public GameObject MyMouse { get; set; }
    private Rigidbody2D MouseRgb;
    public bool CanMove = true;//�ƶ��Ƿ�����
    public bool isGround = true;//�Ƿ��ڵ���
    public int jumpCount;//����Ծ����
    public int jumpNum;//�������ÿ���Ծ����
    public bool isjump;//������Ծ����
    private bool jumpPressed;
    private bool SkillJ=false;
    private GameObject Circle;
    private int Groundtest=0;
    public float SkillJRange = 3.0f;
    private float Yspeed;

    
    public static bool isAlive=true;
   
    public GameObject Dialogpanel;


    private void Awake()
    {
        MyMouse = this.transform.Find("First").gameObject;
    }
    private void Start()
    {
        anim = MyMouse.GetComponent<Animator>();
        MouseRgb = MyMouse.GetComponent<Rigidbody2D>();
        MyMouse.GetComponent<CollisionControl>().enabled = true;
    }

    private void Update()
    {
        

        if (isAlive)
        {
            Yspeed = MouseRgb.velocity.y;

            //�����л������жϺ��л������Ķ���״̬������ײ��
            if (MyMouse.name != MouseRgb.name)
            {
                MouseRgb = MyMouse.GetComponent<Rigidbody2D>();
                anim = MyMouse.GetComponent<Animator>();
                MyMouse.GetComponent<CollisionControl>().enabled = true;
            }

            //����״̬������
            SwitchAnimation();
            if (CanMove)
                GroundMovement();

            if (Input.GetButtonDown("Jump") && jumpCount > 0)
            {
                jumpPressed = true;
            }

            SkillChange();

            Isground();
        }
        else
        {
            //TODO:��������

            //TODO:��������״̬
            MyMouse.SetActive(false);
        }
        
    }

    private void FixedUpdate()
    {
        jump();
      //  isGround = Physics2D.OverlapCircle(MyMouse.transform.Find("GorundCheck").position, 0.2f, ground);
    }


    //����״̬���л�
    private void SwitchAnimation()
    {
        anim.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        anim.SetBool("isjump", isjump);
    }

   

    private void GroundMovement()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        MouseRgb.velocity = new Vector2(horizontalMove * movingSpeed, MouseRgb.velocity.y);
        if(horizontalMove != 0)
        {
            MyMouse.transform.localScale = new Vector3(horizontalMove, 1, 1);
        }
    }
    private void SkillChange()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            Circle = MyMouse.transform.Find("Circle").gameObject;
            Circle.SetActive(true);
            SkillJ = true;
        }
        if(SkillJ  && Circle.transform.localScale.x<SkillJRange)
        {
            float t = Circle.transform.localScale.x+0.01f;
            
            Circle.transform.localScale = new Vector3(t,t,1);
        }
        if(SkillJ  && Circle.transform.localScale.x >=SkillJRange)
        {
            Circle.transform.localScale = new Vector3(0, 0, 1);
            Circle.SetActive(false);
            SkillJ = false;
        }
    }

    //��Ծ
   private void jump()
    {
        if(isGround)
        {
            jumpCount = jumpNum;
            isjump = false;
        }
        if(jumpPressed && isGround)
        {
            isjump = true;
            MouseRgb.velocity = new Vector2(MouseRgb.velocity.x, jumpHeight);
            jumpCount--;
            jumpPressed = false;
        }
        else if(jumpPressed && jumpCount >0 && isjump)
        {
            MouseRgb.velocity = new Vector2(MouseRgb.velocity.x, jumpHeight);
            jumpCount--;
            jumpPressed = false;
        }    
    }


    private void Isground()
    {
        if(MouseRgb.velocity.y > 0.01f|| MouseRgb.velocity.y < -0.01f)
        {
            isGround = false;
        }
        if(MouseRgb.velocity.y < 0.01f && MouseRgb.velocity.y > -0.01f)
        {
            Groundtest++;
        }
        if(Groundtest>=5)
        {
            Groundtest = 0;
            isGround = true;
        }
    }

    public void Dialog(Collider2D Collider,bool isIn)//����ColliderĿ������
    {
        if(isIn)
        {
            Dialogpanel.SetActive(true);
            DiaLogPanel x = Dialogpanel.GetComponent<DiaLogPanel>();
            x.target = Collider;
        }
        else
        {
            Dialogpanel.SetActive(false);
        }
    }
    
}
