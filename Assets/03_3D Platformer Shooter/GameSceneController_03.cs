using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController_03 : MonoBehaviour
{
    public PlayerController_03 player;

    public Camera gameCamera;

    public float cameraSmoothness = 0.05f;

    public Text gameText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        player.onHitObstacle = () =>
        {
            OnGameOver(false);
        };

        player.onHitOrb = () =>
        {
            OnGameOver(true);
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (player != null)
        {
            gameCamera.transform.position = new Vector3(
                Mathf.Lerp(gameCamera.transform.position.x, player.transform.position.x, cameraSmoothness),
                player.transform.position.y,
                gameCamera.transform.position.z
            );
        }
    }

    void OnGameOver(bool win)
    {
        if (win)
        {
            Time.timeScale = 0;
            gameText.text = "You Won the Game Press R to Reload the Game";
        }
        else
        {
            gameText.text = "You Lost the Game Press R to Reload the Game";
        }
    }
}
