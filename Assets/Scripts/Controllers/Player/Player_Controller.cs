using Assets.Scripts.Enums;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    [SerializeField] PlayerActionStatus currentActionStatus = PlayerActionStatus.IDLE;
    [SerializeField] FacingDirection _facingDirection = FacingDirection.RIGHT;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
