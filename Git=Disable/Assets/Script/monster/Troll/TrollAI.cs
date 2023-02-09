using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollAI : MonoBehaviour
{
    [SerializeField] GameObject PosEmpty;
    [SerializeField] GameObject AttackPoint1;  //공격 범위 소환을 위한 프리펩 받아오기
    [SerializeField] GameObject AttackPoint2;
    [SerializeField] GameObject AttackPoint3;
    new SpriteRenderer renderer;              //반짝이기 위해 렌더러 받아오기
    Animator animator;                        //애니메이터 설정
    public float MoveSpeed;                   //이동속도
    public float delaytime;                   //딜레이 타임
    static public bool IsPlayerTrigger;              //플레이어 닿았나 안닿았나
    public bool LR;                           //왼쪽 오른쪽
    float TempTimeA;                          //time 측정 TempA
    float Atime;                              //time 측정 A
    float Btime;                              //time 측정 B
    bool IsDelay;                             //딜레이가 걸리는지
    bool Attack;                              //공격소환을 할지 말지
    bool Attacking;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        MoveSpeed = 1.5f;
        delaytime = 1.5f;
        IsPlayerTrigger = false;
        LR = true;
        TempTimeA = 0.0f;
        Atime = 0.0f;
        Btime = 0.0f;
        IsDelay = false;
        Attack = false;
        Attacking = false;
    }
    private void OnTriggerEnter2D(Collider2D collision) //만났을 때 애니메이션, 트리거 온
    {
        if (collision.gameObject.layer == 6)
        {
            IsPlayerTrigger = true;
            animator.SetBool("IsSkeletonAttack", true);
            Attack = true;
        }
    }
    public void Attack1()
    {
        if (LR == true)
        {
            Vector3 AttackPrePos = new Vector3(transform.position.x - 4.1f, transform.position.y - 0.3f, transform.position.z);
            Destroy(Instantiate(AttackPoint1, AttackPrePos, Quaternion.identity), 0.3f);
            Attack = false;
            Attacking = true;
            Btime = 0.0f;
        }
        else if (LR == false)
        {
            Vector3 AttackPrePos = new Vector3(transform.position.x + 4.1f, transform.position.y - 0.3f, transform.position.z);
            Destroy(Instantiate(AttackPoint1, AttackPrePos, Quaternion.identity), 0.3f);
            Attack = false;
            Attacking = true;
            Btime = 0.0f;
        }
    }
    public void Attack2()
    {
        if (LR == true)
        {
            Vector3 AttackPrePos = new Vector3(transform.position.x - 3.1f, transform.position.y, transform.position.z);
            Destroy(Instantiate(AttackPoint2, AttackPrePos, Quaternion.identity), 0.3f);
            Attack = false;
            Attacking = false;
            Btime = 0.0f;
        }
        else if (LR == false)
        {
            Vector3 AttackPrePos = new Vector3(transform.position.x + 3.1f, transform.position.y, transform.position.z);
            Destroy(Instantiate(AttackPoint2, AttackPrePos, Quaternion.identity), 0.3f);
            Attack = false;
            Attacking = false;
            Btime = 0.0f;
        }
    }
    public void Attack3()
    {
        Vector3 AttackPrePos = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
        Destroy(Instantiate(AttackPoint3, AttackPrePos, Quaternion.identity), 0.3f);
        Attack = false;
    }
    private void OnTriggerStay2D(Collider2D collision) //쿨타임 때마다 애니메이션, 공격 및 어택 포인트 생성
    {
        if (collision.gameObject.layer == 6)
        {
            TempTimeA += Time.deltaTime;
            if (TempTimeA >= 2.3f)
            {
                animator.SetBool("IsAttack", true);
                IsPlayerTrigger = true;
                TempTimeA = 0.0f;
                Attack = true;
                Attacking= true;
            }
        }
    }
    public void IsSkeletonIdle()
    {
        animator.SetBool("IsAttack", false);
    }
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if (IsPlayerTrigger == true)
        {

            if (EyesImage.PlayerPos.x + 1 < transform.position.x)
            {
                animator.SetBool("IsRun", true);
                renderer.flipX = true;
                Vector3 newVelocity = new Vector3(-MoveSpeed, 0.0f, 0.0f);
                PosEmpty.GetComponent<Rigidbody2D>().velocity = newVelocity;
                LR = true;
            }
            if (EyesImage.PlayerPos.x - 1 > transform.position.x)
            {
                animator.SetBool("IsRun", true);
                renderer.flipX = false;
                Vector3 newVelocity = new Vector3(MoveSpeed, 0.0f, 0.0f);
                PosEmpty.GetComponent<Rigidbody2D>().velocity = newVelocity;
                LR = false;
            }
            //플레이어와 자신의 좌표 비교, 플레이어 방향으로 이동
        }
        else
        {
            if (IsDelay == true)
            {
                animator.SetBool("IsRun", false);
                Atime += Time.deltaTime;
                Vector3 newVelocity = new Vector3(MoveSpeed, 0, 0) * 0;
                PosEmpty.GetComponent<Rigidbody2D>().velocity = newVelocity;
                if (Atime >= 1)
                {
                    renderer.flipX = LR ? true : false;
                }
                if (Atime >= 2)
                {
                    IsDelay = false;
                    Atime = 0.0f;
                }
            }
            else if (IsDelay == false)
            {
                Btime += Time.deltaTime;
                if (Btime > 2.6f)
                {
                    IsDelay = true;
                    Btime = 0.0f;
                    LR = LR = LR ? false : true;
                }
                else
                {
                    if (LR == true)
                    {
                        animator.SetBool("IsRun", true);
                        Vector3 newVelocity = new Vector3(MoveSpeed, 0, 0) * -1;
                        PosEmpty.GetComponent<Rigidbody2D>().velocity = newVelocity;

                    }
                    if (LR == false)
                    {
                        animator.SetBool("IsRun", true);
                        Vector3 newVelocity = new Vector3(MoveSpeed, 0, 0) * 1;
                        PosEmpty.GetComponent<Rigidbody2D>().velocity = newVelocity;
                    }
                }
            }
        }
    }
}
