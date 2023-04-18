using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;

public class ColisonDetect : MonoBehaviour
{
    [SerializeField] float BoostValue=2f;
    [SerializeField] [Required] GameObject ui;
    [SerializeField] string nextScene;
    Movement movement;
    string CurrentScene;
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                SceneManager.LoadScene(CurrentScene);
                break;
            case "SpeedUp":
                movement.speed += BoostValue;
                Destroy(collision.gameObject);
                break;
            case "SpeedDown":
                movement.speed -= BoostValue;
                Destroy(collision.gameObject);
                break;
            case "Colectable":
                Debug.Log("MARCO");
                Destroy(collision.gameObject);
                break;
            case "Point":
                ui.GetComponent<PointCount>().score += 5;
                Destroy(collision.gameObject);
                ui.GetComponent<PointCount>().ScoreUpdate();
                break;
            case "LevelEnd":
                SceneManager.LoadScene(nextScene);
                break;
            default:
                break;
        }
    }
    private void Awake()
    {
        movement = gameObject.GetComponent<Movement>();
        CurrentScene = SceneManager.GetActiveScene().name;
    }
}


