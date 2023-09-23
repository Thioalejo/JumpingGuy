using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState { Ready, Playing, Ended};

public class GameManager : MonoBehaviour
{
    public GameState gameState = GameState.Ready;
    public RawImage background, platform;
    public float parallaxSpeed = 0.02f;
    public GameObject uiReady;
    public GameObject player, UiScore;

    void Update()
    {
        bool action = Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0);

        HandleJump(action);
        HandleCollisions();
        UpdateParallax();
        UpdateGameState(action);
        HandleExit();
    }

    #region Metodos
    private void HandleJump(bool action)
    {
        if (gameState == GameState.Playing && action && PlayerManager.Instance.grounded)
        {
            PlayerManager.Instance.SetAnimation("PlayerJumpAnimation");
            AudioManager.Instance.PlaySound("Jump");
        }
    }

    void HandleCollisions()
    {
        if (gameState==GameState.Playing && PlayerManager.Instance.enemyCollision)
        {
            gameState = GameState.Ended;
            PlayerManager.Instance.SetAnimation("PlayerDieAnimation");
            SpawnManager.Instance.StopSpawn();
            SpeedManager.Instance.ResetSpeed();
        }
    }

   
    //Para activar el juego al precionar espape o boton derecho del mouse
    void UpdateGameState(bool action)
    {
        if (gameState == GameState.Ready && action)
        {
            gameState = GameState.Playing;
            uiReady.SetActive(false);
            UiScore.SetActive(true);

            // player.GetComponent<PlayerManager>().SetAnimation("PlayerRunAnimation");
            PlayerManager.Instance.SetAnimation("PlayerRunAnimation");
            SpawnManager.Instance.StartSpawn();
            SpeedManager.Instance.StartSpeedIncrease();
        }
        else if(gameState ==GameState.Ended && action)
        {
            HandleRestar();
        }
    }
    //Para activar el desplazamiento/Movimiento del fondo y la plataforma
    void UpdateParallax()
    {
        if (gameState == GameState.Playing)
        {
            float finalSpeed = parallaxSpeed * Time.deltaTime;
            background.uvRect = new Rect(background.uvRect.x + finalSpeed, 0f, 1f, 1f);
            platform.uvRect = new Rect(platform.uvRect.x + finalSpeed * 4, 0f, 1f, 1f);
        }
    }

    void HandleRestar()
    {
        SceneManager.LoadScene("Main");
    }

    void HandleExit()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }


    #endregion
}
