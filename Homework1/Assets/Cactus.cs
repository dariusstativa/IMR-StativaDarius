using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator mAnimator;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mAnimator != null)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                mAnimator.SetTrigger("TrIdle");
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                mAnimator.SetTrigger("TrAttack");
            }
        }
    }
}
