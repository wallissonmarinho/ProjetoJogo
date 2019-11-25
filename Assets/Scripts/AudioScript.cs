using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip Jump;
    public AudioClip Teste;
    public AudioSource MusicSourc;
    // Start is called before the first frame update
    void Start()
    {
        MusicManager();
    }

    // Update is called once per frame
    void Update()
    {
        MusicManager();
        MusicList();
        
    }
    //Controla quail efeito vai ser tocada
    void MusicManager()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            MusicSourc.clip = Jump;
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            MusicSourc.clip = Teste;
        }
    }
    //Função que executa a reprodução dos efeitos
    void MusicList()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            MusicSourc.Play();
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            MusicSourc.Play();
        }
    }
}
