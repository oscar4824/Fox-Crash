using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Salir()
    {
        Application.Quit();
    }

    public void ShowRules()
    {
        // Activa el objeto "rulesPanel" para mostrar las reglas.
        SceneManager.LoadScene("Reglas");
    }

    public void HideRules()
    {
        // Desactiva el objeto "rulesPanel" para ocultar las reglas.
        //rulesPanel.SetActive(false);
    }
}
