using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class LevelManager : MonoBehaviour
{

    public void changeToScene(string scene)
    {
        if (PlayerPrefs.GetString(ConstantType._level + scene.Substring(5)).Equals(ConstantType._unblock))
        {
            PlayerPrefs.SetString(ConstantType._currentLevel, scene.Substring(5));
            Application.LoadLevel(scene);
        }
    }

}
