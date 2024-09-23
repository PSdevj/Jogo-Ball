using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ControleDoJogo : MonoBehaviour
{

    public bool gameLigado = false;
   
    [SerializeField] private GameObject Menuprincipal;
    
    
    


    // Start is called before the first frame update
    void Start()
    {
        gameLigado = false;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool EstadoDoJogo()
    {
        return gameLigado;
    }

    public void LigaJogo()
    {
        Time.timeScale = 1;
        gameLigado = true;
        Menuprincipal.SetActive(false);
    }

    public void PersonagemMorreu()
    {
        
        Time.timeScale = 0;
        gameLigado = false;

    }

    public void JogadorVenceu()
    {
      
        Time.timeScale = 0;
        gameLigado = false;
 
    }

    public void SaiDoJogo()
    {
        Application.Quit();
    }


}
