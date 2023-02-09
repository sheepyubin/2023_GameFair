using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobinMove : MonoBehaviour
{
    public float maxSpeed;// 속도
    public float jumpPower; // 점프
    bool isground;
    public Vector2 Range;
    public LayerMask Monster;
    [SerializeField] GameObject Skill;
    [SerializeField] Transform Skillpos;
    [SerializeField]Transform ArrowPos;
    [SerializeField]GameObject Arrow;
    [SerializeField]Transform pos;
    [SerializeField]float radius;
    [SerializeField]LayerMask layer;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    Transform trans;
    public int jumpcount;
    int Jumpcnt;
    int i = 0;
    Collider2D hit;
    public static Vector2 MonsterPos;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Jumpcnt = jumpcount;
    }

    public void RobinSkill()
    {
        hit = Physics2D.OverlapBox(transform.position, Range, 0, Monster); //몬스터에 닿았는가?
        if(hit!=null) 
        { 
            MonsterPos = hit.transform.position;
            Instantiate(Skill, Skillpos.position, Quaternion.identity);
        }
        //Skill.transform.position = Vector3.MoveTowards(Skill.transform.position, MonsterPos, 0);
        //Instantiate(SkillPos, hit[i].transform.position, hit[i].transform.rotation);
        //Destroy(Instantiate(Skill, MonsterPos, Quaternion.identity), 0.4f);
    }
    void Update()
    {
        isground = Physics2D.OverlapCircle(pos.position, radius, layer); //땅에 닿았는가?

        if (isground == true && Input.GetKeyDown("c") && Jumpcnt > 0) //점프 1
        {
            Jumpcnt--; //n단
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
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

        if (Mathf.Abs(rigid.velocity.x) < 0.01) //Idle or walk
            anim.SetBool("isWalk", false);
        else
            anim.SetBool("isWalk", true);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Range);
        Gizmos.DrawWireSphere(pos.position, radius);
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


        if (rigid.velocity.x >= maxSpeed)
        {  //오른쪽
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x <= maxSpeed * (-1)) //왼쪽
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }
    }
}
