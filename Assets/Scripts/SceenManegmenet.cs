using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceenManegmenet : MonoBehaviour
{
    public void LoadScenn(string sceneName)
    {
        Debug.Log("Loading_Scene"+ sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
