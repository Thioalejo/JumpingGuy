using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState { Ready, Playing };

public class GameManager : MonoBehaviour
{
    public GameState gameState = GameState.Ready;
    public RawImage background, platform;
    public float parallaxSpeed = 0.02f;
    public GameObject uiReady;
    public GameObject player;

    void Update()
    {
        bool action = Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0);
        HandleJump(action);
        UpdateParallax();
        UpdateGameState(action);
    }

    private void HandleJump(bool action)
    {
        if (gameState == GameState.Playing && action)
        {
            PlayerManager.Instance.SetAnimation("PlayerJumpAnimation");
        }
    }

    #region Metodos
    //Para activar el juego al precionar espape o boton derecho del mouse
    void UpdateGameState(bool action)
    {
        if (gameState == GameState.Ready && action)
        {
            gameState = GameState.Playing;
            uiReady.SetActive(false);

            // player.GetComponent<PlayerManager>().SetAnimation("PlayerRunAnimation");
            PlayerManager.Instance.SetAnimation("PlayerRunAnimation");
            SpawnManager.Instance.StartSpawn();
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
    #endregion
}
