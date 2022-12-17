using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    public float _playerSpeed;
    private Vector3 moveDirection;
    public Animator[] _playerAnimators;
    public static MovingScript _activeMovingScript;

    private void Awake()
    {
        _activeMovingScript = this;
        _playerAnimators = GetComponentsInChildren<Animator>();
        DirectionReset();
    }

    public void DirectionReset()
    {
        foreach (Animator animator in _playerAnimators)
        {
            animator.SetFloat("xMovement", 0);
            animator.SetFloat("yMovement", -1);

        }
    }
   


    private void Update()
    {
       
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            Mover();
            foreach (Animator animator in _playerAnimators)
            {
                if (animator.GetBool("Moving") == false)
                    animator.SetBool("Moving", true);
            }
        }
        else
        {
            foreach (Animator animator in _playerAnimators)
            {
                if (animator.GetBool("Moving") == true)
                    animator.SetBool("Moving", false);
            }
        }
    }

    public void Mover()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        float yMovement = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector3(xMovement, yMovement, 0).normalized;

        transform.position += moveDirection * _playerSpeed * Time.deltaTime;

        foreach(Animator animator in _playerAnimators)
        {
            animator.SetFloat("xMovement", xMovement);
            animator.SetFloat("yMovement", yMovement);
            
        }
    }

    private void Disabler()
    {
       this.enabled = false;
    }
}
