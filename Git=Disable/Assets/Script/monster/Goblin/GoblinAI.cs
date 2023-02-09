using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GoblinAI : MonoBehaviour
{
    [SerializeField] GameObject PosEmpty;
    [SerializeField] GameObject AttackPoint;  //공격 범위 소환을 위한 프리펩 받아오기
    private Rigidbody2D monsterRigidbody;     //이동을 위한 리지드바디 받아오기
    new SpriteRenderer renderer;              //반짝이기 위해 렌더러 받아오기
    Animator animator;                        //애니메이터 설정
    public float MoveSpeed;                   //이동속도
    public float RotateSpeed;                 //회전속도
    public float delaytime;                   //딜레이 타임
    public bool IsPlayerTrigger;              //플레이어 닿았나 안닿았나
    public bool LR;                           //왼쪽 오른쪽
    float TempTimeA;                          //time 측정 TempA
    float Atime;                              //time 측정 A
    float Btime;                              //time 측정 B
    bool IsDelay;                             //딜레이가 걸리는지
    bool Attack;                              //공격소환을 할지 말지
    private void Start()
    {
        monsterRigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        MoveSpeed = 1.5f;
        RotateSpeed = 0.6f;
        delaytime = 1.5f;
        IsPlayerTrigger = false;
        LR = true;
        TempTimeA = 0.0f;
        Atime = 0.0f;
        Btime = 0.0f;
        IsDelay = false;
        Attack = false;
    }
    private void OnTriggerEnter2D(Collider2D collision) //만났을 때 애니메이션, 트리거 온
    {
        if (collision.gameObject.layer == 6)
        {
            IsPlayerTrigger = true;
            animator.SetBool("IsAttack_Goblin", true);
            Attack = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision) //쿨타임 때마다 애니메이션, 공격 및 어택 포인트 생성
    {
        if (collision.gameObject.layer == 6)
        {
            TempTimeA += Time.deltaTime;
            if (TempTimeA >= 0.6f)
            {
                animator.SetBool("IsAttack_Goblin", true);
                IsPlayerTrigger = true;
                TempTimeA = 0.0f;
                Attack = true;
            }
        }
    }
    public void GoblinIdle()
    {
        animator.SetBool("IsAttack_Goblin", false);
    }
    void Update()
    {
        transform.rotation = Quaternion.Euler(0,0,0);
        if (IsPlayerTrigger == true)
        {

            if (EyesImage.PlayerPos.x + 1 < transform.position.x)
            {
                animator.SetBool("IsRun_Goblin", true); 
                renderer.flipX = true;
                Vector3 newVelocity = new Vector3(-MoveSpeed, 0.0f, 0.0f);
                PosEmpty.GetComponent<Rigidbody2D>().velocity = newVelocity;
                LR = true;
            }
            if (EyesImage.PlayerPos.x - 1 > transform.position.x)
            {
                animator.SetBool("IsRun_Goblin", true);
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
                animator.SetBool("IsRun_Goblin", false);
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
                if (Btime > 1.5f)
                {
                    IsDelay = true;
                    Btime = 0.0f;
                    LR = LR = LR ? false : true;
                }
                else
                {
                    if (LR == true)
                    {
                        animator.SetBool("IsRun_Goblin", true);
                        Vector3 newVelocity = new Vector3(MoveSpeed, 0, 0) * -1;
                        PosEmpty.GetComponent<Rigidbody2D>().velocity = newVelocity;

                    }
                    if (LR == false)
                    {
                        animator.SetBool("IsRun_Goblin", true);
                        Vector3 newVelocity = new Vector3(MoveSpeed, 0, 0) * 1;
                        PosEmpty.GetComponent<Rigidbody2D>().velocity = newVelocity;
                    }
                }
            }
        }
        if (Attack == true)
        {
            Btime += Time.deltaTime;
            if (Btime >= 0.48f)
            {
                if (LR == true)
                {
                    Vector3 AttackPrePos = new Vector3(transform.position.x - 1.7f, transform.position.y - 0.3f, transform.position.z);
                    Destroy(Instantiate(AttackPoint, AttackPrePos, Quaternion.identity), 0.3f);
                    Attack = false;
                    Btime = 0.0f;
                }
                else if (LR == false)
                {
                    Vector3 AttackPrePos = new Vector3(transform.position.x + 1.7f, transform.position.y - 0.3f, transform.position.z);
                    Destroy(Instantiate(AttackPoint, AttackPrePos, Quaternion.identity), 0.3f);
                    Attack = false;
                    Btime = 0.0f;
                }
            }
        }
    }
}