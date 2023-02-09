using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyesController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Text NameText = null;
    [SerializeField] private Text ClassText = null;
    [SerializeField] private Image ItemImage = null;
    private EyesDB.EyesRow EyeInfo = null;

    public SpriteRenderer EyesRenderer;

    public Sprite[] Eyes;

    bool isEyes = false;
    PlayerMove player;

    int playerIndex;

    EyesImage eyesImage;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMove>();
        EyeInfo = new EyesDB.EyesRow();
        eyesImage = FindObjectOfType<EyesImage>();
    }
    private void Update() //ddd
    {
        if (Input.GetKeyDown(KeyCode.F) && isEyes == true)
        {
            eyesImage.ChangePlayer(playerIndex);
            Destroy(gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.F) && isEyes == true)
        {
            Debug.Log("¾ÈµÅ");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            isEyes = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            isEyes = false;
        }
    }
    public static EyesController Create(int id)
    {        
        GameObject IT = Instantiate(Resources.Load("Eyes/eye")) as GameObject;

        EyesController Eye = IT.GetComponent<EyesController>();
        Eye.playerIndex = id;
        Eye.Init(id);

        return Eye;
    }
    public void Init(int id)
    {
        EyesDB gameDB = EyesDB.GetSingleton();
        List<EyesDB.EyesRow> result = gameDB.GetEyes(id);

        if (result != null)
        {
            EyeInfo = result[0];
            ItemImage.sprite = Eyes[id];
            EyesRenderer.sprite = Eyes[id];
            RefreshItemInfo();
        }
    }
    private void RefreshItemInfo()
    {

        NameText.text = " ¢Ã " + EyeInfo.Name + "ÀÇ ´«";
        ClassText.text = " ¼³¸í \n -" + EyeInfo.Class;
    }
}
