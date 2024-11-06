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
                // ���� ���� ������Ʈ�� ���� ��ġ�� �����ϴ� �۾��� ���⼭ ȣ�� ����
                Vector3 randomPosition = keyPositionManager.GetRandomKeyPosition();
                // ���� ���� �Լ� ȣ�� (��: Instantiate(keyPrefab, randomPosition, Quaternion.identity));
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
