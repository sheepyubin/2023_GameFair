using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Image FullHP;

    public Attackted attack;
    // Start is called before the first frame update
    void Start()
    {
        attack = GetComponent<Attackted>();
    }

    // Update is called once per frame
    void Update()
    {
        if(attack == null)
        {
            attack = FindObjectOfType<Attackted>();
        }
        FullHP.fillAmount = attack.HP / 40;
    }
}
