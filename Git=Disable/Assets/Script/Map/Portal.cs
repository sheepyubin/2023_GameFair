using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//포탈 스크립트
public class Portal : MonoBehaviour
{
    public GameObject target;
    public GameObject to;
    private void OnTriggerEnter2D(Collider2D collision) //플레이어에게 닿았다면
    {
        if (collision.CompareTag("Player"))
        {
            target = collision.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(TeleportRoutine());
        }
    }
    IEnumerator TeleportRoutine()
    {
        yield return null;
        target.transform.position = to.transform.position; //텔레포트
    }
}
