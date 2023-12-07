using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.05f; // 物体的移动速度
    public float width = 2f; // 矩形的宽度
    public float height = 2f; // 矩形的高度

    private Vector3 startPosition; // 初始位置
    private float x;
    private float y;
  

    void Start()
    {
        startPosition = transform.position; // 获取初始位置
    }

    void Update()
    {
         x = Mathf.Sin(Time.time * speed) * width; // 按照时间和速度计算x坐标
         y = Mathf.Cos(Time.time * speed) * height; // 按照时间和速度计算y坐标

        transform.position = startPosition + new Vector3(x, y, 0); // 更新物体的位置
}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("arrow")) // 检查碰撞对象的标签是否为"Target"
        {
            Debug.Log("Arrow hit the target!");
            
   
            uiscore.score++;
            // 获取碰撞对象的 Rigidbody 组件
            Destroy(collision.gameObject.GetComponent<Rigidbody>());
            Transform targetRigidbody=collision.gameObject.GetComponent<Transform>();
           
            targetRigidbody.transform.SetParent(transform, true);

            // 创建 FixedJoint 组件并将其连接到箭和靶子上
                    
    }
    }
}