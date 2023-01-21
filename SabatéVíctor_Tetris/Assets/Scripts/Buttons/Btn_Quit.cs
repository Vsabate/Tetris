using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_Quit : Btn_Parent
{
    public override void ButtonAction()
    {
        // Save MaxScore, then quit game.
        JsonFileSystem.instance.SaveToJson();
        Application.Quit();
    }
}
