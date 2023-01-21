using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_Quit : Btn_Parent
{
    protected override void ButtonAction()
    {
        // FIRST SAVE MAX SCORE, THEN QUIT

        Application.Quit();
    }
}
