using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class ObstacleSetter : MonoBehaviour, IObstacleSetter
    {
        public void SetObstacles(ObjectPoolFactory obstacleFactory, ObstacleData obstacleData)
        {
            GameObject obstacle;
            float halfFieldWidth = obstacleData.FieldWidth / 2;
            float halfFieldHeight = obstacleData.FieldHeight / 2;
            float x;
            float z;
            int quantity;

            float randValue = Random.value;

            if (randValue < obstacleData.MinFillingProbability)
            {
                quantity = obstacleData.MinQuantity;
            }
            else
            {
                quantity = obstacleData.MaxQuantity;
            }

            for (int i = 0; i < quantity; i++)
            {
                z = Random.Range(-halfFieldWidth, halfFieldWidth) + obstacleData.FieldCenter.z;
                x = Random.Range(-halfFieldHeight, halfFieldHeight) + obstacleData.FieldCenter.x;

                obstacle = obstacleFactory.Create();
                obstacle.transform.position = new Vector3(x, obstacleData.FieldCenter.y, z);
            }
        }
    }
}