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
        public Key key = null;
       


        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        void Start()
        {
            // 게임 시작 시 저장된 진행 상황을 불러와 게임 상태를 업데이트합니다.
            UpdateGameState();
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
        private void UpdateGameState()
        {
            // 획득한 아이템들을 확인하고 이미 획득한 아이템은 파괴합니다
            foreach (ItemObject item in FindObjectsOfType<ItemObject>())
            {
                if (SaveManager.Instance.IsItemAcquired(item.data.name))
                {
                    Destroy(item.gameObject);
                }
            }

            // 열린 문들을 확인하고 이미 열린 문은 애니메이션을 실행합니다
            foreach (Door door in FindObjectsOfType<Door>())
            {
                if (SaveManager.Instance.IsDoorOpened(door.gameObject.name))
                {
                    door.doorAnimator.SetTrigger("Open");
                }
            }

            // 해결된 퍼즐들을 확인하고 이미 해결된 퍼즐의 UI는 숨깁니다
            foreach (Safe safe in FindObjectsOfType<Safe>())
            {
                if (SaveManager.Instance.IsPuzzleSolved(safe.gameObject.name))
                {
                    PopupManager.Instance.HidePopup(safe.safeUI);
                }
            }
        }
    }


}
