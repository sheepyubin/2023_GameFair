using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    void Start()
    {
        Invoke("DestroyArrow", 2); //3ÃÊ ÈÄ ÆÄ±«
    }
    void Update()
    {
        if (transform.rotation.y == 0)
            transform.Translate(transform.right * speed * Time.deltaTime); //------->
        else
            transform.Translate(transform.right * -1*speed * Time.deltaTime); //------->


    }

    void DestroyArrow()
    {
        Destroy(gameObject);
    }
}
