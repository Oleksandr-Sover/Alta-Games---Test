using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] PlayerController playerController;
        [SerializeField] PlayerData playerData;
        [SerializeField] DoorController doorController;
        [SerializeField] GameObject leftRay;
        [SerializeField] GameObject rightRay;
        [SerializeField] TriggerDetector winTriggerDetector;

        [SerializeField] LayerMask obstacleLayer;

        EndGameHandler endGameHandler = new();
        SceneHandler sceneHandler = new();

        int sceneIndex = 0;

        void Awake()
        {
            endGameHandler.Initialization(playerController.gameObject, playerData, leftRay, rightRay, obstacleLayer);
            endGameHandler.onEndShot += SetGameEnding;
            endGameHandler.onWin += SetWinningMovement;
            winTriggerDetector.onTrigger += ReloadScene;
        }

        void Start()
        {
            StartCoroutine(endGameHandler.ProcessEndShot());
            StartCoroutine(endGameHandler.ProcessWin());
        }

        void SetGameEnding() => playerController.SetEndShotState();

        void SetWinningMovement()
        {
            doorController.OpenDoor();
            playerController.SetMoveState();
        }

        public void ReloadScene() => sceneHandler.LoadNewScene(sceneIndex);
    }
}