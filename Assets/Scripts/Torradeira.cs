using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torradeira : MonoBehaviour
{
	public GameObject PainelCompleto;
	public Text TextLives;
	public int lives;
	public bool Tiro;
	public GameObject VerificaInimigo;
    public bool isGround;
	public GameObject prefabTiro;

	private float contadorTiros = 0;
	public float tempoTiro = 1;

	public float forcaTiro;
    private Rigidbody2D rb2dTorradeira;
    private Animator Torrad;

    // Start is called before the first frame update
    void Start()
    {
        rb2dTorradeira = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
		isGround = VerificaInimigo.GetComponent<VerificaFaca>().isGroundedEnemy;
        Animacao();  
        Atirar();  
		Vida();    
    }
	void Vida()
	{
		if(lives <= 0)
           {
            	Destroy(gameObject);
				PainelCompleto.SetActive(true);
            	Time.timeScale = 0;
           }
	}
	
    void Animacao()
    {
		if(isGround)
		{
			Torrad = GetComponent<Animator>();
     		Torrad.SetBool("Presenca",true);
			 Tiro = true;
		}
		else
		{
			Torrad = GetComponent<Animator>();
     		Torrad.SetBool("Presenca",false);
			 Tiro = false;
		}
        
    }
    public void Atirar()
	{
		if (contadorTiros >= tempoTiro) { 
			if (Tiro)
			{
				GameObject tempTiro = Instantiate(prefabTiro,
					transform.position + new Vector3(-0.8f, -0.2f, 0),
					transform.rotation);

				tempTiro.GetComponent<Rigidbody2D>().AddForce(new Vector2(forcaTiro, 0));
				
				contadorTiros = 0;
			}
		}

		contadorTiros += Time.deltaTime;
		//print(contadorTiros);
	}
	void OnCollisionEnter2D(Collision2D collision2D)
    {
        //Metodo para perder vida quando entrar em contato com inimigos
        if(collision2D.gameObject.CompareTag("Player"))
        {
           lives--;
           TextLives.text = lives.ToString();
           
        }
        
    }

}
