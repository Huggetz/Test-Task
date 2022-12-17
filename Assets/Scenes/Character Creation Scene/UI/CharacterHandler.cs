using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    public float xFreeze, yFreeze;
    public ClothesOptions _headGear;
    public ClothesOptions _chestPiece;
    public ClothesOptions _legPiece;
    public ClothesOptions _shoePiece;

    public static CharacterHandler _sceneHandler;

    private void Awake()
    {
        _sceneHandler = this;
    }
    private void Start()
    {
        if (MovingScript._activeMovingScript.enabled == true)
            MovingScript._activeMovingScript.enabled = false;
        MovingScript._activeMovingScript.transform.position = new Vector3(xFreeze, yFreeze, 0);

        foreach (Animator animator in MovingScript._activeMovingScript._playerAnimators)
        {
            animator.SetFloat("xMovement", 0);
            animator.SetFloat("yMovement", -1);
        }
    }
}
