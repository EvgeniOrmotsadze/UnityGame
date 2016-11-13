using UnityEngine;
using System.Collections;
using Assets;
public class ChangeScene : MonoBehaviour {


    public void changeToScene(string scene)
    {
        if (PlayerPrefs.GetString("Level" + scene.Substring(5)).Equals(ConstantType._unblock))
        {
            PlayerPrefs.SetString("CurrentScene", scene.Substring(5));
            Application.LoadLevel(scene);
        }
    }

}
