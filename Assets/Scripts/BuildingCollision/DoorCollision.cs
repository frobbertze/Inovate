using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DisplayEnterPrompt : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _prompt;
    [SerializeField] private Player_Controller _player;
    
    private bool EnterBuilding;

    private string BuildingName;

    private bool Colliding;

    private void Awake()
    {
        _prompt.enabled = false;
       

    }

    private void Update()
    {

        HandleBuildingEnter();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Player_SpawnController.spawnPosition = _player.transform.position;
        //Player_SpawnController.lastScene = SceneMana

        BuildingName = collision.gameObject.name;

        Debug.Log(BuildingName);

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

        EnterBuilding = Input.GetKeyDown(KeyCode.E);

        if (Colliding == true && EnterBuilding)
        {
            Scenes_Controller.LoadScene(Scenes.Building_01_Inside);
        }


    }

    private void HandleBuildingExit()
    {



    }
          
}




