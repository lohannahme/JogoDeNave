using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetBool("lefts", true);
            anim.SetBool("rights", false);
        }
        
        if(Input.GetKeyUp(KeyCode.A)|| Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetBool("lefts", false);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("rights", true);
            anim.SetBool("lefts", false);
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("rights", false);
        }


    }
}
