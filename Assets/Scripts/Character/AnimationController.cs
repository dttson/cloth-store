using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterController = ClothStore.Character.CharacterController;

public class AnimationController : MonoBehaviour
{
    private static readonly int s_Vertical = Animator.StringToHash("Vertical");
    private static readonly int s_Horizontal = Animator.StringToHash("Horizontal");
    
    [SerializeField] private CharacterController _character;
    [SerializeField] private Animator _animator;

    void Awake()
    {
    }
    
    void Update()
    {
        checkWalkAnimation();
    }

    private void checkWalkAnimation()
    {
        int verticalValue = _character.MoveDirection.y > 0.001f ? 1 : _character.MoveDirection.y < -0.001f ? -1 : 0;
        int horizontalValue = _character.MoveDirection.x > 0.001f ? 1 : _character.MoveDirection.x < -0.001f ? -1 : 0;
        _animator.SetInteger(s_Vertical, verticalValue);
        _animator.SetInteger(s_Horizontal, horizontalValue);
        
        //TODO: Should check x direction for horizontal moving, but for now temporarily use same animation for all move directions
        if (verticalValue == 0)
        {
            _animator.SetInteger(s_Vertical, -Mathf.Abs(horizontalValue));    
        }
    }
}
