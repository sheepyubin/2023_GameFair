using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RobinSkill : MonoBehaviour
{
    public float Arrowspeed; //È­»ì
    void Start()
    {
        Invoke("DestroySkill", 1f);
    }
    void Update()
    {
        if (RobinMove.MonsterPos != null)
        {
            if (RobinMove.MonsterPos.x < transform.position.x)
                transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.position = Vector2.MoveTowards(transform.position, RobinMove.MonsterPos, Arrowspeed * Time.deltaTime);
        }
        }

        void DestroySkill()
    {
       Destroy(gameObject);
    }
}
