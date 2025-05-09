using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private RunnersSystem runnersSystem;
    [SerializeField] private PlayerAnimator playerAnimator;

    [Header(" Settings ")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float roadWidth;
    
    private bool canMove;

    [Header(" Control ")]
    [SerializeField] private float slideSpeed;

    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;

    private void Start()
    {
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }

    void Update()
    {
        if (canMove)
        {
        MoveForward();
        ManageControl();
        }
    }

    private void GameStateChangedCallback(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.Game)
        {
            StartMoving();
        }
        else
        {
            StopMoving();
        }
    }

    private void StartMoving()
    {
        canMove = true;
        playerAnimator.Run();
    }

    private void StopMoving()
    {
        canMove = false;
        playerAnimator.Idle();
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }

    private void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;

            xScreenDifference /= Screen.width;
            xScreenDifference *= slideSpeed;

            Vector3 position = transform.position;
            position.x = clickedPlayerPosition.x + xScreenDifference;
            transform.position = position;
        }
    }

}