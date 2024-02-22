//using System.Threading;

using Naninovel;
using UnityEngine;
using UnityEngine.SceneManagement;

[CommandAlias("LoadGameScene")]
public class LoadGameSceneCommand : Command
{
    public StringParameter SceneName;  

    public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        await SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
        await WaitForSceneToClose(SceneName, asyncToken);
        //Debug.Log("Scene closed");
    }

    private async UniTask WaitForSceneToClose(string sceneName, AsyncToken asyncToken)
    {
        while (SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            await UniTask.Yield(PlayerLoopTiming.Update, asyncToken);
            //Debug.Log("Waiting for scene to close...");
        }
    }
}