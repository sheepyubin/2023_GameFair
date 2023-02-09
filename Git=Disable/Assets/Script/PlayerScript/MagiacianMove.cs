using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagiacianMove : MonoBehaviour
{
    public float maxSpeed;// �ӵ�
    public float jumpPower; // ����
    bool isground;
    public Vector2 Range;
    public LayerMask Monster;
    [SerializeField] GameObject Skill;
    Collider2D hit;
    Vector3 temp;
    [SerializeField] Transform pos;
    [SerializeField] float radius;
    [SerializeField] LayerMask layer;
    [SerializeField] GameObject Magic;
    [SerializeField] Transform skillPos;
    [SerializeField] Transform MagicPos;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    public int jumpcount;
    int Jumpcnt;
    public static Vector2 MonsterPos;
    public static Vector3 PlayerPos;

    public void MagicianSkill()
    {
        hit = Physics2D.OverlapBox(transform.position, Range, 0, Monster); //���Ϳ� ��Ҵ°�?
        if (hit != null)
        {
            MonsterPos = hit.transform.position;
            Instantiate(Skill, skillPos.position, Quaternion.identity);
        }
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Jumpcnt = jumpcount;
    }

    void Update()
    {
        EyesImage.PlayerPos = transform.position;
        PlayerPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        isground = Physics2D.OverlapCircle(pos.position, radius, layer); //���� ��Ҵ°�?

        if (isground == true && Input.GetKeyDown("c") && Jumpcnt > 0) //���� 1
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        if (isground == false && Input.GetKeyDown("c") && Jumpcnt > 0) //���� 2
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            Jumpcnt--; //n��
        }
        if (isground)
        {
            Jumpcnt = jumpcount; //0���Ϸ� �������� ���� �Ұ�
        }

        if (Input.GetKeyDown("z"))//���ݸ��
        {
            anim.SetBool("isAttack", true);
        }

        if (Input.GetKeyDown("x")) //��ų
        {
            anim.SetBool("isSkill", true);
        }

        if (Input.GetButtonUp("Horizontal")) //�ӵ�����
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);

        }

        if (Mathf.Abs(rigid.velocity.x) < 0.01) //Idle or walk
            anim.SetBool("isWalk", false);
        else
            anim.SetBool("isWalk", true);
    }

    public void ShotMagic() //ȭ�� ������ ����
    {
        Instantiate(Magic, MagicPos.position, transform.rotation);
    }
    public void IdleAnimation()
    {
        anim.SetBool("isAttack", false);
    }
    public void IdleAnimationSkill()
    {
        anim.SetBool("isSkill", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Range);
        Gizmos.DrawWireSphere(pos.position, radius);
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse); //�̵�


        if (rigid.velocity.x >= maxSpeed)
        {  //������
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x <= maxSpeed * (-1)) //����
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }
    }
}