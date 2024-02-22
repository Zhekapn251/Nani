using System;
using System.Collections;
using System.Collections.Generic;
using Naninovel;
using TMPro;
using UnityEngine;

public class TextEvent : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private string _variableName;
    
    public void StrikeThroughInt(int mode)
    {
        var manager = Engine.GetService<ICustomVariableManager>();
        var result = manager.GetVariableValue(_variableName);
        mode = Int32.Parse(result);

        switch (mode) 
        {
           case 0:
               _textMeshProUGUI.enabled = false;
               _textMeshProUGUI.fontStyle = FontStyles.Normal;
               break; 
           case 1:
               _textMeshProUGUI.enabled = true;
                break;
           case 2:
                _textMeshProUGUI.fontStyle = FontStyles.Strikethrough;
               break;
        }
            
    }
}