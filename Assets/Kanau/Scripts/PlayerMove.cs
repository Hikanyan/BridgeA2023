using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    //AudioSource _step;
    //public AudioClip _stepSe;
    // Start is called before the first frame update
    private void Start()
    {
         //_step = GetComponent<AudioSource>();
        
    }
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector2 scale = transform.localScale;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //�㉺�ړ�
        if (y == 1)
        {
            transform.localPosition = new Vector2(0, 0.2311f);
            Debug.Log(y);
        }
        else if (y == -1)
        {
            transform.localPosition = new Vector2(0, -0.562f);
            //_step.PlayOneShot(_stepSe);
            Debug.Log(y);
        }

        //if (x == 1)
        //{
        //    scale.x = 1;//�E�����Ɍ���
        //    Debug.Log(x);
        //}
        //else if (x == -1)
        //{
        //    scale.x = -1;//�������Ɍ���
        //    Debug.Log(x);
        //}
        //transform.localScale = scale;
    }
}
