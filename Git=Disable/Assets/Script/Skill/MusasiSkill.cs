using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusasiSkill : MonoBehaviour
{
    public float speed;
    void Start()
    {
        Invoke("DestroyArrow", 0.4f);
    }

    void Update()
    {
        if (transform.rotation.y == 0)
            transform.Translate(transform.right * speed * Time.deltaTime); //------->
        else
            transform.Translate(transform.right * -1 * speed * Time.deltaTime); //------->


    }

    void DestroyArrow()
    {
        Destroy(gameObject);
    }
}
