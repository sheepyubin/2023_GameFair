using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyesImage : MonoBehaviour
{
    [Header("Player")]
    public GameObject NowPlayer;
    public GameObject[] Players;
    public GameObject Effect;
    [Header("UI")]
    public Image EyeRenderer;
    public Image SkillRenderer;
    public Sprite[] Eyes;
    public Sprite[] SkillIcon;

    static public Vector3 PlayerPos;
    private void Start()
    {
        NowPlayer = GameObject.Find("Yubin");
    }
    public void Update()
    {

    }
    public void ChangePlayer(int eye)
    {
        EyeRenderer.sprite = Eyes[eye];
        SkillRenderer.sprite = SkillIcon[eye];
        Instantiate(Players[eye], PlayerPos, Quaternion.identity);
        Instantiate(Effect, PlayerPos, Quaternion.identity);
        Destroy(NowPlayer);
        NowPlayer = Players[eye];
    }
}
