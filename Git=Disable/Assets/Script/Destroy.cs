using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyAttack",1f);
    }
    void Update()
    {
        
    }

    public void DestroyAttack()
    {
        Destroy(gameObject);
    }
}
