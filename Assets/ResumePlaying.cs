using System;
using System.Collections;
using System.Collections.Generic;
using Naninovel;
using UnityEngine;

public class ResumePlaying : MonoBehaviour
{
    private void Start()
    {
        MiniGameAdapter.ResumeGame += Resume;
    }

    public void Resume()
    {
        Debug.Log("Resuming game...");
        var scriptPlayer = Engine.GetService<IScriptPlayer>();
        scriptPlayer.Play();
    }
}
