﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public int lives;
    public Text TextLives;
    public float forcaPulo;
    public float vMaxima;
    private float movimento;
    

    void Start()
    {
        TextLives.text = lives.ToString();
    }


    void Update()
    {
        Movimentos();
    }

    void Movimentos()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        movimento = Input.GetAxis("Horizontal");

        //Função para movimentar para esquerda e para direita
        rigidbody.velocity = new Vector2(movimento*vMaxima, rigidbody.velocity.y);

        //Função para flipar a imagem
        if(movimento < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }else if(movimento > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        //Transição de Idle para Run
        if(movimento > 0 || movimento <0)
        {
            GetComponent<Animator>().SetBool("Walking", true);
        }else
        {
            GetComponent<Animator>().SetBool("Walking", false);
        }
        //Função para pular
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(new Vector2(0, forcaPulo));
            
        }
    }

}
