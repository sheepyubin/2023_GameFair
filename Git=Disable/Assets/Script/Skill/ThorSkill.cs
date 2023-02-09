using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThorSkill : MonoBehaviour
{
    [SerializeField] Transform SkillPos;

    private void Update()
    {
        gameObject.transform.position = new Vector3(SkillPos.position.x, SkillPos.position.y, SkillPos.position.z);
        Invoke("DestroySkill", 1);
    }

    void DestroySkill()
    {
        Destroy(gameObject);
    }
}
