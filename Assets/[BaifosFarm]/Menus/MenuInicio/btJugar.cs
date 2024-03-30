using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btJugar : MonoBehaviour
{
    public void onClickHandler() {
        SceneManager.LoadScene("Juego");
    }
}
