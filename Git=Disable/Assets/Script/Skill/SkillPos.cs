using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPos : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        Invoke("DestroyPos", 0.5f);
    }

    void DestroyPos()
    {
        Destroy(gameObject);
    }
}
