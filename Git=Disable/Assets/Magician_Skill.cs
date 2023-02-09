using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician_Skill : MonoBehaviour
{
    public float Arrowspeed; //È­»ì
    void Start()
    {
        Invoke("DestroySkill", 0.5f);
    }
    void Update()
    {
        if (MagiacianMove.MonsterPos != null)
        {
            if (MagiacianMove.MonsterPos.x < transform.position.x)
                transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.position = Vector2.MoveTowards(transform.position, MagiacianMove.MonsterPos, Arrowspeed * Time.deltaTime);
        }
    }

    void DestroySkill()
    {
        Destroy(gameObject);
    }
}
