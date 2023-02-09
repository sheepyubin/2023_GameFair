using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public Image BossHp;

    public GameObject[] BossHitBox;
    public GameObject[] BossAttackBox;
    public GameObject BossSkill;

    public Animator anime;
    int ran = 0;

    public int HP = 0;
    private int nowHP = 0;
    // Start is called before the first frame update

    void Start()
    {
        nowHP = HP;
        anime = GetComponent<Animator>();
        BossHp.fillAmount = 1;
        InvokeRepeating("UseSkill", 5,7);
    }

    // Update is called once per frame
    void Update()
    {
        BossHp.fillAmount = nowHP / HP;
        ran = Random.Range(1, 5);
        if(nowHP <= 0)
        {
            CancelInvoke("UseSkill");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {

        }
    }
    public void UseSkill()
    {
        anime.SetInteger("count", ran);
    }

    public void ShowBossHitBox(int hit)
    {
        BossHitBox[hit].SetActive(true);
    }
    public void ShowBossAttackBox(int attack)
    {
        BossHitBox[attack].SetActive(false);
        BossAttackBox[attack].SetActive(true);
    }
    public void notBossAttackBox(int attack)
    {
        BossAttackBox[attack].SetActive(false);
    }

    public void BossSkillProduce(float y)
    {
        Instantiate(BossSkill, new Vector3(gameObject.transform.position.x + y, 6f, 0), Quaternion.identity);
    }
    public void chIdle()
    {
        anime.SetInteger("count", 0);
    }
}
