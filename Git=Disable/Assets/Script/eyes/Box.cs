using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public bool isbox;
    public bool isboxing = false;

    public SpriteRenderer boximage;
    public Sprite boxopen;

    private int ran;
    public EyesController Eyes;
    private EyesDB eyesDB = null;

    public GameObject GameEyes;
    private void Awake()
    {
        eyesDB = new EyesDB();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            isbox = true;
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isboxing == false && isbox)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            isboxing = true;
            ran = Random.Range(1, 8);
            boximage.sprite = boxopen;
            Eyes = EyesController.Create(ran);
            GameEyes = GameObject.FindGameObjectWithTag("eyes");
            GameEyes.transform.position = transform.position;

            Invoke("delete", 1.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            isbox = false;
        }
    }
    public void delete()
    {
        Destroy(gameObject);
    }
}
