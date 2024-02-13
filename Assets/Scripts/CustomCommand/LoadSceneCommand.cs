using System.Collections;
using System.Collections.Generic;
using DTT.MinigameMemory.Demo;
using Naninovel;
using UnityEngine;
using UnityEngine.SceneManagement;


[CommandAlias("loadScene")]
public class LoadSceneCommand : Command
{
    private StringParameter SceneName = "Demo";
    private MemoryGameLevelSelectHandler levelSelectHandler;
    public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        Debug.Log($"Loading scene {SceneName}...");
        if (!Assigned(SceneName) || string.IsNullOrWhiteSpace(SceneName)) {
            Debug.LogError("Scene name is not specified.");
            return;
        }
        await SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
        Debug.Log($"Scene {SceneName} loaded.");
    }
}
