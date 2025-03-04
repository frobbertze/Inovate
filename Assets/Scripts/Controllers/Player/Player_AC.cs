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

    public void SetAnimationForAction(PlayerActionStatus playerActionStatus)
    {
        switch (playerActionStatus)
        {
            case PlayerActionStatus.IDLE:
                _animator.SetBool("Moving", false);
                _animator.SetBool("Running", false);
                break;
            case PlayerActionStatus.WALK:
                _animator.SetBool("Moving", true);
                _animator.SetBool("Running", false);
                break;
            case PlayerActionStatus.JUMP:
                break;
            case PlayerActionStatus.WALL_JUMP:
                break;
            case PlayerActionStatus.FALL:
                break;
            case PlayerActionStatus.LAND:
                break;
            case PlayerActionStatus.DASH:
                break;
            case PlayerActionStatus.ATTACK:
                break;
            case PlayerActionStatus.HURT:
                break;
            case PlayerActionStatus.DEAD:
                break;
            case PlayerActionStatus.CROUCH:
                break;
            case PlayerActionStatus.CRAWL:
                break;
            case PlayerActionStatus.ROLL:
                break;
            case PlayerActionStatus.CLIMB:
                break;
            case PlayerActionStatus.LEDGE_GRAB:
                break;
            case PlayerActionStatus.RUN:
                _animator.SetBool("Moving", false);
                _animator.SetBool("Running", true);
                break;
            default:
                break;
        }
    }

}
