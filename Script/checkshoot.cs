using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class checkshoot : MonoBehaviour
{   
    
    float force;
    const float maxForce = 1.0f;  // 最大力量
    const float chargeRate = 0.2f;  // 蓄力速度
    Animator animator;
    float mouseDownTime;
    bool isCharging;
    public Slider Powerslider;

    public bool ready_to_shoot;

	


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponent<Animator>();
        ready_to_shoot = false;
        
    }
 
    void Update()
    {
        
        //按照鼠标按下的时间蓄力，每0.3秒蓄0.1的力（最多0.5)加到animator的power属性上，并用相应的力射箭
        if (Input.GetMouseButtonDown(1)) // 0表示鼠标左键
        {
            mouseDownTime = Time.time;  // 记录鼠标按下的时间
            isCharging = true;  // 开始蓄力
            Powerslider.gameObject.SetActive(true);
        }
 
        if (isCharging)
        {
            float holdTime = Time.time - mouseDownTime; // 计算鼠标按下的时间
            force = Mathf.Min(holdTime / 0.3f * chargeRate, maxForce); // 计算蓄力的量，最大为0.5
            animator.SetBool("Hold",true);
            Powerslider.value = force / maxForce; // 更新力量条的值
            animator.SetFloat("Force", force + 0.0f);
        }
 
        if (Input.GetMouseButtonUp(1) && isCharging)
        {
            isCharging = false;  // 停止蓄力
            animator.SetBool("Fire",false);
            float holdTime = Time.time - mouseDownTime;  // 计算鼠标按下的时间
            force = Mathf.Min(holdTime / 0.3f * chargeRate, maxForce);  // 计算蓄力的量，最大为0.5
            animator.SetFloat("Force", force );  // 将蓄力的量加到animator的power属性上
            
            animator.SetBool("Fire",false);
            
            
        }
         if(Input.GetMouseButtonDown(0)){
                if(uiscore.isinarea&&uiscore.shoot>0){
                fire(force);
                animator.SetBool("Fire",true);
                animator.SetBool("Hold",false);
                animator.SetFloat("Force",   0.0f); 
                animator.SetBool("Fire",false);
                Powerslider.value = 0;
                }
              
            }
    }

    public void fire(float f)
    {
        // Your existing fire code
        
        GameObject arrow = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Arrow"));
        // 使用Find方法通过子对象的名字获取子对象
        arrow.transform.position=this.transform.position;
        arrow.transform.rotation = Quaternion.LookRotation(this.transform.forward);
        Rigidbody arrow_db = arrow.GetComponent<Rigidbody>();
        Vector3 starting_point= transform.position;
        arrow_db.velocity = 100* f * this.transform.forward;

        uiscore.shoot--;       

       
    }
    void OnGUI()
    {
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 15; // Set the font size to 30
        GUI.Label(new Rect(0, 0, 100, 100), "Score："+uiscore.score, style);
        if (uiscore.isinarea)
        {
            // Create a new GUIStyle
            // Draw the message with the new GUIStyle
            GUI.Label(new Rect(10, 50, 500, 100), "在特定区域,射击次数："+uiscore.shoot, style);
            
        }
    }
}


