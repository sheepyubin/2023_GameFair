using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArtemisMove : MonoBehaviour
{
    public float maxSpeed;// 속도
    public float jumpPower; // 점프
    public Vector2 Range;
    public LayerMask Monster;
    bool isground;
    [SerializeField] GameObject Skill;
    Collider2D[] hit;
    Vector3[] MonsterPos = new Vector3[20];
    [SerializeField]    Transform ArrowPos;
    [SerializeField]    GameObject Arrow;
    [SerializeField]    Transform pos;
    [SerializeField]    float radius;
    [SerializeField]    LayerMask layer;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    Transform trans;
    public int jumpcount;
    int Jumpcnt;
    int i = 0;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Jumpcnt = jumpcount;
        
    }
    public void ArtemisSkill()
    {
        hit = Physics2D.OverlapBoxAll(transform.position, Range, 0, Monster); //몬스터에 닿았는가?
        for (i = 0; i < hit.Length; i++)
        {
            MonsterPos[i] = hit[i].transform.position;
            //Debug.Log("X: " + MonsterPos[i].x + " Y: " + MonsterPos[i].y);
            //Instantiate(SkillPos, hit[i].transform.position, hit[i].transform.rotation);
            Destroy(Instantiate(Skill, MonsterPos[i], Quaternion.identity), 0.4f);
        }
    }

    void Update()
    {
        EyesImage.PlayerPos = transform.position;
        isground = Physics2D.OverlapCircle(pos.position, radius, layer); //땅에 닿았는가?

        if (isground == true && Input.GetKeyDown("c")&&Jumpcnt>0) //점프 1
        {
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        if (isground == false && Input.GetKeyDown("c") && Jumpcnt > 0) //점프 2
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            Jumpcnt--; //n단
        }
        if (isground)
        {
            Jumpcnt = jumpcount; //0이하로 내려가면 점프 불가
        }

        if (Input.GetKeyDown("z"))//공격모션
        {
            anim.SetBool("isAttack", true);
        }

        if (Input.GetKeyDown("x")) //스킬
        {
            anim.SetBool("isSkill", true);
        }

        if (Input.GetButtonUp("Horizontal")) //속도제한
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);

        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Range);
        Gizmos.DrawWireSphere(pos.position, radius);
    }
    public void flipx()
    {
        spriteRenderer.flipX = false;
    }

    public void IdleAnimation()
    {
        anim.SetBool("isAttack", false);
    }

    public void IdleAnimationSkill()
    {
        anim.SetBool("isSkill", false);
    }

    public void ShotArrow() //화살 프리팹 복제
    {
        Instantiate(Arrow, ArrowPos.position, transform.rotation);
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse); //이동


        if (rigid.velocity.x > maxSpeed)
        {  //오른쪽
            anim.SetBool("isLeft", false);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //spriteRenderer.flipX = false;
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1)) //왼쪽
        {
            anim.SetBool("isLeft", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }
    }
}

