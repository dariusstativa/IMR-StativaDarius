using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AnimationManager : MonoBehaviour
{
    public ImageTargetBehaviour cactusA;
    public ImageTargetBehaviour cactusB;
    public float distance = 0.25f;
    public Animator animA;
    public Animator animB;
    private int frameTrig = 0;
    // Update is called once per frame
    void Update()
    {
       
        if (!cactusA || !cactusB || !animA || !animB) return;

        if (isVisible(cactusA) && isVisible(cactusB))
        {
            float dis = Vector3.Distance(cactusA.transform.position, cactusB.transform.position);

            if (distance >= dis && frameTrig == 0)
            {
                frameTrig = 1;
                animA.SetTrigger("TrAttack");
                animB.SetTrigger("TrAttack");
            }
            else if (distance <= dis && frameTrig == 1)
            {
                frameTrig = 0;
                animA.SetTrigger("TrIdle");
                animB.SetTrigger("TrIdle");
            }
        }
        else
        {
            if (frameTrig != 0)
            {
                frameTrig = 0;
                animA.SetTrigger("TrIdle");
                animB.SetTrigger("TrIdle");
            }
        }
    }

    bool isVisible(ImageTargetBehaviour obj)
    {
        var s = obj.TargetStatus.Status;
        return s == Status.TRACKED || s == Status.EXTENDED_TRACKED;
    }
}
