using System.Collections;
using System.Collections.Generic;
using DTT.MinigameMemory.Demo;
using Naninovel;
using UnityEngine;
using UnityEngine.SceneManagement;


[CommandAlias("resumeGame")]
    public class ResumeGame : Command
    {
        private StringParameter SceneName = "Demo";
        private MemoryGameLevelSelectHandler levelSelectHandler;
        public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            var scriptPlayer = Engine.GetService<IInputManager>();
            scriptPlayer.ProcessInput = true;
        }
    }

