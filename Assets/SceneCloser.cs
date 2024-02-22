using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneCloser : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    private void OnEnable()
    {
        _closeButton.onClick.AddListener(CloseScene);
        //SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void CloseScene()
    {
        SceneManager.UnloadSceneAsync("Cube").completed += operation =>
        {
            Debug.Log("Scene unloaded successfully.");
        };
    }
}
