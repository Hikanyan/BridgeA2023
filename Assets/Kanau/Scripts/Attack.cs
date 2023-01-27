using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] GameObject _attackRight;
    [SerializeField] GameObject _attackLeft;
    Animator _attackRightAnim;
    Animator _attackLeftAnim;
    private bool _triger = true;

    void Start()
    {
        _attackRightAnim = _attackRight.GetComponent<Animator>();
        _attackLeftAnim = _attackLeft.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (_triger)
            {
                _attackRightAnim.SetBool("attackRight", true);
                _attackLeftAnim.SetBool("attackLeft", true);
                _triger = false;
            }
            
        }
        if (!Input.GetKey(KeyCode.A))
        {
            _attackRightAnim.SetBool("attackRight", false);
            _attackLeftAnim.SetBool("attackLeft", false);
            _triger = true;
        }
    }
}
