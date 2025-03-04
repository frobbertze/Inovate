using UnityEngine;

public class Player_Animations : MonoBehaviour
{

    private readonly int moving = Animator.StringToHash("Moving"); //Gets "Moving" bool from player animator parameters
    private readonly int dead = Animator.StringToHash("Dead"); //Gets "Dead" trigger from player animator parameters

    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetWalkingAnimation()
    {

        animator.SetBool(moving, true);  //Sets player animator parameter "Moving" to true

    }

}
