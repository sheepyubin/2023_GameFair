using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCanvas : MonoBehaviour
{
    public Canvas canvas;
    public Camera[] cam;

    public GameObject ESC;

    private void Start()
    {
        cam[1].enabled = false;
        cam[2].enabled = false;
        cam[3].enabled = false;
    }
    private void Update()
    {
        if (cam[1].enabled == true)
        {
            CamChange(1);

        }
        if (cam[2].enabled == true)
        {
            CamChange(2);

        }
        if (cam[3].enabled == true)
        {
            CamChange(3);

        }
        if(Input.GetKeyDown(KeyCode.Escape))
            ESC.SetActive(true);
    }
    public void CamChange(int camnum)
    {
        canvas.worldCamera = cam[camnum];
    }
}
