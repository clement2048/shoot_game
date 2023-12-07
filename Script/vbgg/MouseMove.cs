using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousemove : MonoBehaviour
{
     public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        // 锁定鼠标并隐藏
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        moveSpeed = 100f; //移动速度
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 angle = Vector3.zero;

        angle.x = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * moveSpeed * Time.deltaTime;
        angle.y = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * moveSpeed * Time.deltaTime;

        transform.localEulerAngles = angle;

      

    }
}