using System.Collections;
using System.Collections.Generic;
using Naninovel;
using UnityEngine;

[CommandAlias("loadMiniGame")]
public class LoadMiniGame : Command
{
    const string PrefabName = "Canvas";

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var prefab = Resources.Load<GameObject>(PrefabName);
        if (prefab != null) UnityEngine.Object.Instantiate(prefab);
        else Debug.LogError($"Prefab '{PrefabName}' could not be loaded.");
        return UniTask.CompletedTask;
    }
}