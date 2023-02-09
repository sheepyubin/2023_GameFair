using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//카메라, 포탈 테스트용 
public class move_test : MonoBehaviour
{
    public Camera Cam1;
    public Camera Cam2;

    public float maxSpeed;
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);


        if (rigid.velocity.x > maxSpeed)
        { 
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1))
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) //카메라 전환 (스테이지 넘어 갈 때)
    {
        if (collision.gameObject.tag == "Stage1")
        {
            ShowCam1View();
        }
        if (collision.gameObject.tag == "Stage2")
        {
            ShowCam2View();
        }
    }
    public void ShowCam1View()
    {
        Cam1.enabled = true;
        Cam2.enabled = false;
    }

    public void ShowCam2View()
    {
        Cam1.enabled = false;
        Cam2.enabled = true;
    }
}
