using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camremove : MonoBehaviour
{
    public Camera Cam1;
    public Camera Cam2;
    public Camera Cam3;
    public Camera Cam4;

    public AudioSource audio;
    public AudioClip[] clip;

    int a = 0,b = 0,c = 0, d = 0;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        transform.position = EyesImage.PlayerPos;
    }
    void OnTriggerEnter2D(Collider2D collision) //카메라 전환 (스테이지 넘어 갈 때)
    {
        if (collision.gameObject.tag == "Stage1")
        {
            if(a == 0)
            {
                audio.clip = clip[0];
                audio.Play();
            }
            a++;
            ShowCam1View();
            MonsterSpawn.State = 1;
            Debug.Log(MonsterSpawn.State);
        }
        if (collision.gameObject.tag == "Stage2")
        {
            if (b == 0)
            {
                audio.clip = clip[1];
                audio.Play();
            }
            b++;
            ShowCam2View();
            MonsterSpawn.State = 2;
        }
        if (collision.gameObject.tag == "Stage3")
        {
            if (c == 0)
            {
                audio.clip = clip[2];
                audio.Play();
            }
            c++;
            ShowCam3View();
            MonsterSpawn.State = 3;
        }
        if (collision.gameObject.tag == "BossStage")
        {
            if (d == 0)
            {
                audio.clip = clip[3];
                audio.Play();
            }
            d++;
            ShowCamBossView();
            MonsterSpawn.State = 4;
        }
    }
    public void ShowCam1View()
    {
        Cam1.enabled = true;
        Cam2.enabled = false;
        Cam3.enabled= false;
        Cam4.enabled= false;
        Debug.Log("1");
    }
    public void ShowCam2View()
    {
        Cam1.enabled = false;
        Cam2.enabled = true;
        Cam3.enabled = false;
        Cam4.enabled = false;
        Debug.Log("2");
    }
    public void ShowCam3View()
    {
        Cam1.enabled = false;
        Cam2.enabled = false;
        Cam3.enabled = true;
        Cam4.enabled = false;
        Debug.Log("3");
    }
    public void ShowCamBossView()
    {
        Cam1.enabled = false;
        Cam2.enabled = false;
        Cam3.enabled = false;
        Cam4.enabled = true;
        Debug.Log("4");
    }
}
