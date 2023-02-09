using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCoolTimer : MonoBehaviour
{
    public Image skillFilter;

    public float coolTime;

    private float currentCoolTime;

    private bool canUseSkill = true;
    [Header("UI")]
    [SerializeField]
    private Button[] actionButtons;
    public KeyCode[] action;
    Animator anim;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(action[0]))
        {
            ActionButtonOnClick(0);
        }
    }
    private void ActionButtonOnClick(int btnIndex)
    {
        actionButtons[btnIndex].onClick.Invoke();
    }
    public void UseThorSkill()
    {
        if (canUseSkill)
        {
            if (Input.GetKeyDown("x")) //스킬
            {
                anim.SetBool("isSkill", true);
            }
            Debug.Log("Use Skill");
            skillFilter.fillAmount = 1;
            StartCoroutine("Cooltime");

            currentCoolTime = coolTime;

            StartCoroutine("CoolTimeCounter");

            canUseSkill = false;
        }
        else
        {
            Debug.Log("아직 스킬을 사용할 수 없습니다.");
        }
    }

    public void UseMusasiSkill()
    {
        if (canUseSkill)
        {
            if (Input.GetKeyDown("x")) //스킬
            {
                anim.SetBool("isSkill", true);
            }
            Debug.Log("Use Skill");
            skillFilter.fillAmount = 1;
            StartCoroutine("Cooltime");

            currentCoolTime = coolTime;

            StartCoroutine("CoolTimeCounter");

            canUseSkill = false;
        }
        else
        {
            Debug.Log("아직 스킬을 사용할 수 없습니다.");
        }
    }

    IEnumerator Cooltime()
    {
        while (skillFilter.fillAmount > 0)
        {
            skillFilter.fillAmount -= 1 * Time.smoothDeltaTime / coolTime;

            yield return null;
        }
        canUseSkill = true;

        yield break;
    }
    IEnumerator CoolTimeCounter()
    {
        while (currentCoolTime > 0)
        {
            yield return new WaitForSeconds(1f);

            currentCoolTime -= 1f;
        }
        yield break;
    }
}
