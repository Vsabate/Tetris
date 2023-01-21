using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_DeleteData : Btn_Parent
{
    public override void ButtonAction()
    {
        // DELETE SAVE FILE THAT CONTAINS MAX SCORE DATA
        JsonFileSystem.instance.DeletePossibleSaveFile();
    }
}
