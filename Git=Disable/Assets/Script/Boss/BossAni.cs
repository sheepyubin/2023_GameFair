using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAni : MonoBehaviour
{
    public GameObject boss;
    public void Boss()
    {
        Instantiate(boss,gameObject.transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
