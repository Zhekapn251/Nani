using DTT.MinigameBase.LevelSelect;
using DTT.MinigameMemory.Demo;
using Naninovel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameAdapter : MonoBehaviour
{
    public static event System.Action ResumeGame;
    [SerializeField] private MemoryGameLevelSelectHandler memoryGameLevelSelectHandler;
    MemoryGameLevelSelectHandler levelSelectHandler;

    private void OnEnable()
    {
        memoryGameLevelSelectHandler.LevelSelectOpened += UnloadScenes;
    }

    private void OnDisable()
    {
        memoryGameLevelSelectHandler.LevelSelectOpened -= UnloadScenes;
    }

    public async UniTaskVoid UnloadScenesAsync()
    {
        ResumeGame?.Invoke();
        if (SceneManager.GetSceneByName("DDT Level Select").isLoaded)
        {
            await SceneManager.UnloadSceneAsync("DDT Level Select");
        }

        if (SceneManager.GetSceneByName("Demo").isLoaded)
        {
            await SceneManager.UnloadSceneAsync("Demo");
        }

        Debug.Log("Scenes Unloaded. Resume game");
        
    }

    public void UnloadScenes()
    {
        UnloadScenesAsync().Forget();
    }
}