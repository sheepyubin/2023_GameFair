using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skeleton_Attackted_Monster : MonoBehaviour
{
    [SerializeField] GameObject DieMark;
    public Image HPBar;
    Animator animator;
    GameObject Mark;
    bool IsDie;
    public bool skill4;
    public float HP;
    float MaxHP;
    float Atime;
    float Btime;
    bool Spawn;

    public void FlyingEye_Idle()
    {
        animator.SetBool("IsSkeletonTakeHit", false);
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        HPBar.type = Image.Type.Filled;
        skill4 = false;
        IsDie = false;
        Atime = 0.0f;
        Btime = 0.0f;
        Spawn = false;
        MaxHP = HP;
    }

    void MonsterAtteackted(float damage)
    {
        HP -= damage;
        animator.SetBool("IsSkeletonTakeHit", true);
        if (HP <= 0)
        {
            IsDie = true;
        }
    }
    public void SkeletonTakeHit()
    {
        animator.SetBool("IsSkeletonTakeHit", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("skill4"))
        {
            skill4 = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "skill1":
                MonsterAtteackted(Random.Range(9, 12));
                break;
            case "skill2":
                MonsterAtteackted(Random.Range(30, 38));
                break;
            case "skill3":
                MonsterAtteackted(Random.Range(9, 13));
                break;
            case "skill5":
                MonsterAtteackted(Random.Range(10, 15));
                break;
            case "skill6":
                MonsterAtteackted(Random.Range(10, 15));
                break;
            case "skill7":
                MonsterAtteackted(Random.Range(30, 40));
                break;
            case "skill8":
                MonsterAtteackted(Random.Range(10, 15));
                break;
            case "attack5":
                MonsterAtteackted(5);
                break;
            case "attack7":
                MonsterAtteackted(7);
                break;
            case "attack9":
                MonsterAtteackted(9);
                break;
        }
    }
    void Update()
    {
        HPBar.fillAmount = HP / MaxHP;
        if (skill4 == true)
        {
            if (IsDie == false)
            {
                if (Spawn == false)
                {
                    Spawn = true;
                    InstantDie.IsDieMark = true;
                    Mark = Instantiate(DieMark) as GameObject;
                }
                if (InstantDie.IsDieMark == true)
                    Mark.transform.localPosition = new Vector3(transform.position.x, transform.position.y, transform.position.y);
                Atime += Time.deltaTime;
                if (Atime >= 1.1f)
                {
                    Atime = 0.0f;
                    skill4 = false;
                    Spawn = false;
                    IsDie = true;
                }
            }
        }
        if (IsDie == true)
        {
            HP = 0.0f;
            animator.SetBool("IsSkeletonDeath", true);
            Btime += Time.deltaTime;
            if (Btime >= 1.0f)
            {
                MonsterSpawn.SpawnCount--;
                Destroy(transform.parent.gameObject);
                Destroy(gameObject);
            }
        }
    }
}