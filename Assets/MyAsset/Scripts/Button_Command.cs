using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Command : MonoBehaviour
{

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);

        Debug.Log(name);
    }
}
