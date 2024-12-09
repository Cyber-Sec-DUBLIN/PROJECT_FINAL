using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
public void StartGame() {
SceneManager.LoadScene(1);
}


public void PlayGame() {
SceneManager.LoadScene(2);
}

public void GitHub() {
    Application.OpenURL("https://github.com/Cyber-Sec-DUBLIN/PROJECT_FINAL");
}
}
 