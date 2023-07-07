using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform hedef;
    public Vector3 hedefMesafe;
    public float hassasiyet ;

    float fareX, fareY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, hedef.position + hedefMesafe, Time.deltaTime * 10);
        fareX += Input.GetAxis("Mouse X") * hassasiyet;
        fareY += Input.GetAxis("Mouse Y") * hassasiyet;
        //fareY = Mathf.Clamp(fareY, -25f, 25f);
        if (fareY>=25)
        {
            fareY = 25;
        }

        if (fareY<=-25)
        {
            fareY =-25;
        }

        this.transform.eulerAngles = new Vector3(fareY, fareX, 0);
        hedef.transform.eulerAngles = new Vector3(0, fareX, 0);
    }
}
