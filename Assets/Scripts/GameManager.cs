using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PainelCompleto;
    public bool isPause = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //metodo responsavel para pausar o jogo
    public void Pause()
    {
        if(isPause)
        {
            PainelCompleto.SetActive(false);
            isPause = false;
            Time.timeScale = 1;
        }else
        {
            PainelCompleto.SetActive(true);
            isPause = true;
            Time.timeScale = 0;
        }
    }
}
