using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Options : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
