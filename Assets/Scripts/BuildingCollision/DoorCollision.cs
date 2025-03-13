using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Collections;

public class DoorCollision : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _prompt;
    [SerializeField] private Player_Controller _player;
    [SerializeField] private Scenes _insideScene;
    [SerializeField] private bool isInside;

    [SerializeField] private Player_Spawn_Controller _Spawn_Controller;

    private bool DoorInteract;

    private bool Colliding;

    private void Awake()
    {
        _prompt.enabled = false;

        

    }

    private void Update()
    {
        
        HandleBuildingEnter();

        if (Input.GetKeyDown(KeyCode.E))
        {
          HandleBuildingExit();
        }

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (isInside == false)
        {
          _Spawn_Controller.spawnPosition = _player.transform.position;
          _Spawn_Controller.lastSceneName = SceneManager.GetActiveScene().name;
        }

        Colliding = true;

        if (collision.CompareTag("Player"))
        {

            _prompt.enabled = true;


        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Colliding = false;

        _prompt.enabled = false;
    }

    private void HandleBuildingEnter()
    {

        DoorInteract = Input.GetKeyDown(KeyCode.E);

        if (Colliding == true && DoorInteract && isInside == false)
        {
            SceneManager.LoadScene(_insideScene.ToString());
        }

    }

    private void HandleBuildingExit()
    {

        DoorInteract = true; //Input.GetKeyDown(KeyCode.E);
        

        if(Colliding == true && DoorInteract && isInside == true)
        {
           _player.transform.position = _Spawn_Controller.spawnPosition;
            SceneManager.LoadScene(_Spawn_Controller.lastSceneName);

        }

        

    }

    


}




