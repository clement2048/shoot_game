using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifshootTarget : MonoBehaviour
{
    // Start is called before the first frame update

   
    private FixedJoint fixedJoint;
    
   
    void Start()
    {
      
    }

   private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("arrow")) // 检查碰撞对象的标签是否为"Target"
        {
            Debug.Log("Arrow hit the target!");
            
   
            uiscore.score++;
           
             // 获取碰撞对象的 Rigidbody 组件
           

            // 创建 FixedJoint 组件并将其连接到箭和靶子上
            
            Destroy(collision.gameObject.GetComponent<Rigidbody>());
            
    }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
