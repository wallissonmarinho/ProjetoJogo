using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public GameObject JumpAudio;
    public int lives;
    public Text TextLives;
    public float forcaPulo;
    public float vMaxima;
    private float movimento;
    public bool isGrounded;
    

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
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody.AddForce(new Vector2(0, forcaPulo));
            
        }
        //Jump controller se ele estiver no chão animação jumping desativado
        if(isGrounded)
        {
            GetComponent<Animator>().SetBool("jumping", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("jumping", true);
        }
    }
    //Metodo para saber se o player esta em contato com objetos
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        //Metodo para saber se estar no chão e se não, o player não pode pular
        if(collision2D.gameObject.CompareTag("Plataforma") || collision2D.gameObject.CompareTag("Fogo") || collision2D.gameObject.CompareTag("ArmarioBig"))
        {
           isGrounded = true;
           Debug.Log("NO CHÃO"+collision2D.gameObject.tag);
        }
        //Metodo para perder vida quando entrar em contato com inimigos
        if(collision2D.gameObject.CompareTag("Fogo"))
        {
           lives--;
           TextLives.text = lives.ToString();
           if(lives==0)
           {
               //logica para morrer
           }
        }
        
    }
    void OnCollisionExit2D(Collision2D collision2D)
    {
        isGrounded = false;
        Debug.Log("NO AR"+collision2D.gameObject.tag);

        if(collision2D.gameObject.CompareTag("ArmarioBig") || collision2D.gameObject.CompareTag("Fogo"))
        {
        isGrounded = true;
           Debug.Log("NO CHÃO"+collision2D.gameObject.tag);
        }
    }

}
