using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class Attackted : MonoBehaviour
{
    new SpriteRenderer renderer;
    new Rigidbody2D rigidbody2D;
    public float HP = 40f;
    public float damage = 0.0f;
    public float delay = 0.3f;
    const short temp = 4;
    int i = 0;
    float Btime;
    bool IsTansparency;
    bool IsAttackted = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "monster1":
                IsAttackted = true;
                damage = 1.0f;
                attackted(damage);
                break;
            case "monster2":
                IsAttackted = true;
                damage = 2.0f;
                attackted(damage);
                break;
            case "monster3":
                IsAttackted = true;
                damage = 3.0f;
                attackted(damage);
                break;
            case "monster4":
                IsAttackted = true;
                damage = 4.0f;
                attackted(damage);
                break;
            case "monster5":
                IsAttackted = true;
                damage = 9.0f;
                attackted(damage);
                break;
            case "monster6":
                IsAttackted = true;
                damage = 13.0f;
                attackted(damage);
                break;
            case "monster7":
                IsAttackted = true;
                damage = 14.0f;
                attackted(damage);
                break;
        }
    }
    void Die()
    {

    }
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        IsTansparency = false;
        IsAttackted = false;
    }
    void attackted(float damage)
    {
        if (IsAttackted == false)
        {
            IsAttackted = true;
            HP -= damage;
        }
        if (HP < 0)
        {
            Die();
        }
        IsAttackted = true;
    }
    void Update()
    {
        if (IsAttackted == true)
        {
            Physics2D.IgnoreLayerCollision(6, 12, true);
            Btime += Time.deltaTime;
            if (Btime >= delay)
            {
                IsTansparency = !IsTansparency;
                if (IsTansparency)
                {
                    i++;
                    renderer.color = new Color(1, 1, 1, 0.2f);
                    Btime = 0.0f;
                }
                else
                {
                    i++;
                    renderer.color = new Color(1, 1, 1, 1.0f);
                    Btime = 0.0f;
                }
                
            }
            if (i >= temp)
            {
                i = 0;
                IsAttackted = false;
                Btime= 0.0f;
                Physics2D.IgnoreLayerCollision(6, 12, false);
            }
        }
        else
        {
            Debug.Log(HP);
            
        }
    }
}