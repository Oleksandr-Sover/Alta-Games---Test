using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GameLogic
{
    public class EndGameHandler
    {
        GameObject player;
        PlayerData playerData;

        GameObject leftRay;
        GameObject rightRay;

        LayerMask layerMask;

        public delegate void OnEndShot();
        public event OnEndShot onEndShot;

        public delegate void OnWin();
        public event OnWin onWin;

        WaitForSeconds waitForSec = new WaitForSeconds(1);

        public void Initialization(GameObject player, PlayerData playerData, GameObject leftRay, GameObject rightRay, LayerMask layerMask)
        {
            this.player = player;
            this.playerData = playerData;
            this.leftRay = leftRay;
            this.rightRay = rightRay;
            this.layerMask = layerMask;
        }

        public IEnumerator ProcessEndGame()
        {
            yield return waitForSec;

            while (true)
            {
                if (player.transform.localScale.x <= playerData.MinPower)
                {
                    onEndShot?.Invoke();
                    yield break;
                }

                if (!CheckRaycast(leftRay.transform) && !CheckRaycast(rightRay.transform))
                {
                    onWin?.Invoke();
                    yield break;
                }

                yield return waitForSec;
            }
        }

        bool CheckRaycast(Transform origin)
        {
            if (Physics.Raycast(origin.position, origin.TransformDirection(Vector3.forward), out RaycastHit hit, 100, layerMask))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}