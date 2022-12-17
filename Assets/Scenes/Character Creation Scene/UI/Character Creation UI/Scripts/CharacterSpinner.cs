using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpinner : MonoBehaviour
{
    
    public void SpinLeft()
    {
        foreach (Animator animator in MovingScript._activeMovingScript._playerAnimators)
        {
            float xPos = animator.GetFloat("xMovement");
            float yPos = animator.GetFloat("yMovement");
            // animator.SetFloat("xMovement", );
            //animator.SetFloat("yMovement", );
            if (xPos == 0 & yPos == -1)
            {
                animator.SetFloat("xMovement", -1);
                animator.SetFloat("yMovement", 0);
            }
            else if (xPos == -1 && yPos == 0)
            {
                animator.SetFloat("xMovement", 0);
                animator.SetFloat("yMovement", 1);
            }
            else if (xPos == 0 && yPos == 1)
            {
                animator.SetFloat("xMovement", 1);
                animator.SetFloat("yMovement", 0);
            }
            else if (xPos == 1 && yPos == 0)
            {
                animator.SetFloat("xMovement", 0);
                animator.SetFloat("yMovement", -1);
            }
        }
        
    }
    public void SpinRight()
    {
        foreach (Animator animator in MovingScript._activeMovingScript._playerAnimators)
        {
            float xPos = animator.GetFloat("xMovement");
            float yPos = animator.GetFloat("yMovement");
            
            if (xPos == 0 & yPos == -1)
            {
                animator.SetFloat("xMovement", 1);
                animator.SetFloat("yMovement", 0);
            }
            else if (xPos == 1 && yPos == 0)
            {
                animator.SetFloat("xMovement", 0);
                animator.SetFloat("yMovement", 1);
            }
            else if (xPos == 0 && yPos == 1)
            {
                animator.SetFloat("xMovement", -1);
                animator.SetFloat("yMovement", 0);
            }
            else if (xPos == -1 && yPos == 0)
            {
                animator.SetFloat("xMovement", 0);
                animator.SetFloat("yMovement", -1);
            }
        }
    }
}
