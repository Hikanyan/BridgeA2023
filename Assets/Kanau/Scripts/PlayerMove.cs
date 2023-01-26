using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector2 scale = transform.localScale;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //ã‰ºˆÚ“®
        if (y == 1)
        {
            transform.localPosition = new Vector2(0, 3);
        }
        else if (y == -1)
        {
            transform.localPosition = new Vector2(0, 0);
        }

        if (x == 1)
        {
            scale.x = 1;//‰E•ûŒü‚ÉŒü‚­
        }
        else if (x == -1)
        {
            scale.x = -1;//¶•ûŒü‚ÉŒü‚­
        }
        transform.localScale = scale;
    }
}
