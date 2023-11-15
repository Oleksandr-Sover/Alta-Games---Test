using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameLogic
{
    public class SceneHandler
    {
        public void LoadNewScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}