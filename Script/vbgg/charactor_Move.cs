using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMove : MonoBehaviour
{
     CharacterController playerController;

    Vector3 direction;

    public float speed = 10;
    public float jumpPower = 5;
    public float gravity = 7f;
    public float Rotatespeed;
    public float mousespeed = 0.0001f;
    public float minmouseY = -45f;
    public float maxmouseY = 45f;

    public Transform agretctCamera;

    private Quaternion m_CharacterTargetRot;
    // Use this for initialization
    void Start(){
        playerController = this.GetComponent<CharacterController>();
    }
    
    void Update()
    {
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");

        // 只有在有输入的情况下才更新移动方向
        if (_horizontal != 0 || _vertical != 0)
        {
            direction = new Vector3(_horizontal, 0, _vertical);
            direction.y -= gravity * Time.deltaTime;
            playerController.Move(playerController.transform.TransformDirection(direction * Time.deltaTime * speed));
        }

        float translationY = Input.GetAxis("Vertical") * 6.0f;
        float translationX = Input.GetAxis("Horizontal") * 6.0f;
        translationY *= Time.deltaTime;
        translationX *= Time.deltaTime;
    }

}






