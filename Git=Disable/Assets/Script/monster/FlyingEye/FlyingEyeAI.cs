using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FlyingEyeAI : MonoBehaviour
{
    [SerializeField] GameObject PosEmpty;
    [SerializeField] GameObject AttackPoint;  //공격 범위 소환을 위한 프리펩 받아오기
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
    }
    private void OnTriggerEnter2D(Collider2D collision) //만났을 때 애니메이션, 트리거 온
    {
        if (collision.gameObject.layer == 6)
        {
            IsPlayerTrigger = true;
            animator.SetBool("IsAttack_FlyEye", true);
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
                animator.SetBool("IsAttack_FlyEye", true);
                IsPlayerTrigger = true;
                TempTimeA = 0.0f;
                Attack = true;
            }
        }
    }
    public void FlyEye_Idle()
    {
        animator.SetBool("IsAttack_FlyEye", false);
    }
    void Update()
    {
        if (IsPlayerTrigger == true)
        {
            Vector2 rot = new Vector2(transform.position.x - EyesImage.PlayerPos.x, transform.position.y - EyesImage.PlayerPos.y);
            float Angle = Mathf.Atan2(rot.x, rot.y) * Mathf.Rad2Deg * -1;
            if (LR == false)
                Angle += -90;
            else
                Angle += 90;
            Quaternion angleAxis = Quaternion.AngleAxis(Angle, Vector3.forward);
            Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, RotateSpeed * Time.deltaTime);
            transform.rotation = rotation;

            //플레이어를 쳐다볼 수 있도록 플레이어와 자신으로 atan2연산, Slerp연산 후 나온 결과로 각도 변경

            if (EyesImage.PlayerPos.x < transform.position.x)
            {
                renderer.flipX = true;
                Vector3 newVelocity = new Vector3(-MoveSpeed, 0.0f, 0.0f);
                PosEmpty.GetComponent<Rigidbody2D>().velocity = newVelocity;
                LR = true;
            }
            if (EyesImage.PlayerPos.x > transform.position.x)
            {
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
                if (Btime > 1.4f)
                {
                    IsDelay = true;
                    Btime = 0.0f;
                    LR = LR = LR ? false : true;
                }
                else
                {
                    if (LR == true)
                    {
                        Vector3 newVelocity = new Vector3(MoveSpeed, 0, 0) * -1;
                        PosEmpty.GetComponent<Rigidbody2D>().velocity = newVelocity;

                    }
                    if (LR == false)
                    {
                        Vector3 newVelocity = new Vector3(MoveSpeed, 0, 0) * 1;
                        PosEmpty.GetComponent<Rigidbody2D>().velocity = newVelocity;
                    }
                }
            }
        }
        if (Attack == true)
        {
            Btime += Time.deltaTime;
            if (Btime >= 0.4f)
            {
                if (LR == true)
                {
                    Vector3 AttackPrePos = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z);
                    Destroy(Instantiate(AttackPoint, AttackPrePos, Quaternion.identity), 0.1f);
                    Attack = false;
                    Btime = 0.0f;
                }
                else if (LR == false)
                {
                    Vector3 AttackPrePos = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
                    Destroy(Instantiate(AttackPoint, AttackPrePos, Quaternion.identity), 0.1f);
                    Attack = false;
                    Btime = 0.0f;
                }
            }
        }
    }
}

