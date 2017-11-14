using UnityEngine;

public class Level : MonoBehaviour {

    public static bool GameIsOver;

    public GameObject gameOverUI;

    void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update () {
        if (GameIsOver)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
            EndGame();

        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
	}

    void EndGame()
    {
        GameIsOver = true;

        gameOverUI.SetActive(true);
    }

}
