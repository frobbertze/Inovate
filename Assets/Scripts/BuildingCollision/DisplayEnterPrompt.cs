using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DisplayEnterPrompt : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _prompt;
    [SerializeField] private Player_Controller _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            _prompt.enabled = true;


        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

            _prompt.enabled = false;



    }

    private void UpdateTMPPosition()
    {

        _prompt.transform.position = _player.transform.position;

    }

}
