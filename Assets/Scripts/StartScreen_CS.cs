using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen_CS : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) == true)
        {
            SceneManager.LoadScene("Level_S");
        }
    }
}
