using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float y = Input.GetAxisRaw("Vertical");

        //è„â∫à⁄ìÆ
        if (y == 1)
        {
            transform.localPosition = new Vector2(0, 0.2311f);
            Debug.Log(y);
        }
        else if (y == -1)
        {
            transform.localPosition = new Vector2(0, -0.562f);
            Debug.Log(y);
        }
    }
}
