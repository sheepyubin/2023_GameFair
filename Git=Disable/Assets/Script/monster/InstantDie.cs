using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDie : MonoBehaviour
{
    new SpriteRenderer renderer;
    float Atime;
    int i;
    public float delay;
    bool IsTansparency;
    public static bool IsDieMark = false;
    void Start()
    {
        i = 0;
        IsTansparency = false;
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        Atime += Time.deltaTime;
        if (Atime > delay)
        {
            if (IsTansparency == true)
            {
                renderer.color = new Color(1, 1, 1, 0.1f);
                Atime = 0.0f;
                IsTansparency = !IsTansparency;
                i++;
            }
            else
            {
                renderer.color = new Color(1, 1, 1, 1);
                Atime = 0.0f;
                IsTansparency = !IsTansparency;
                i++;
            }
            if(i == 6)
            {
                i = 0;
                Destroy(gameObject);
                IsDieMark = false;
            }
        }
    }
}
