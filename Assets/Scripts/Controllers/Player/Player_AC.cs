using UnityEngine;

public class Player_AC : MonoBehaviour
{

    private readonly int moving = Animator.StringToHash("Moving"); //Gets "Moving" bool from player animator parameters
    private readonly int dead = Animator.StringToHash("Dead"); //Gets "Dead" trigger from player animator parameters

    private Animator _animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetAnimationForAction(PlayerMovementState playerMovementState)
    {

        _animator.SetFloat("MovementAction", (float)playerMovementState);
        
    }

}
