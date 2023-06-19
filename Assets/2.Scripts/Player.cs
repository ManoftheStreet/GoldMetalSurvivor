using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed;
    public Vector2 inputVec;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        //1. ���� �ش�
        //rigid.AddForce(inputVec)
        //2. �ӵ�����
        //rigid.velocity = inputVec;
        //3. ��ġ �̵�
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }
    private void LateUpdate()
    {
        anim.SetFloat("Speed",inputVec.magnitude);
        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
    }
    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
