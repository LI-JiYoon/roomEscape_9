using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RoomEscape.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public float gameSpeed = 1.0f;
        public bool isGamePaused;
        public Canvas gameUICanvas;  // Reference to the UI Canvas
        public PlayerController playerController;
        public KeyPositionManager keyPositionManager;


        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        private void Start()
        {
            if (keyPositionManager != null)
            {
                keyPositionManager.PopulateKeyPositions();
                // 이후 열쇠 오브젝트를 랜덤 위치에 생성하는 작업도 여기서 호출 가능
                Vector3 randomPosition = keyPositionManager.GetRandomKeyPosition();
                // 열쇠 생성 함수 호출 (예: Instantiate(keyPrefab, randomPosition, Quaternion.identity));
            }
            else
            {
                Debug.LogError("KeyPositionManager is not assigned in GameManager.");
            }
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                TogglePause();
            }
        }

        public void StartGame()
        {
            isGamePaused = false;
            Time.timeScale = gameSpeed;
            EnableUI(true);
        }

        public void PauseGame()
        {
            isGamePaused = true;
            Time.timeScale = 0;
            EnableUI(true);
        }

        public void TogglePause()
        {
            if (isGamePaused)
            {
                StartGame();
            }
            else
            {
                PauseGame();
            }
        }

        void EnableUI(bool enabled)
        {
            if (gameUICanvas != null)
            {
                gameUICanvas.enabled = enabled;
            }
        }

        public void GameOver()
        {
            // Handle Game Over Logic
        }

        public void GameClear()
        {
            // Handle Game Clear Logic
        }

        public void EndBranching()
        {
            // Handle Ending Branch Logic
        }
    }


}
