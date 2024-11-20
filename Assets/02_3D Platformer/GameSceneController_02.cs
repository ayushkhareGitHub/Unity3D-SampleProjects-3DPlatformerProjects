using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController_02 : MonoBehaviour
{
    public Camera gameCamera;

    public PlayerController_02 player;

    public Text gameText;

    // Start is called before the first frame update
    void Start()
    {
        player.onHitObstacle = () =>
        {
            OnGameOver(false);
        };

        player.onHitOrb = () =>
        {
            OnGameOver(true);
        };

        Time.timeScale = 1;
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
                Mathf.Lerp(gameCamera.transform.position.x, player.transform.position.x, 0.03f),
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
