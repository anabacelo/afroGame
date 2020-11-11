using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anime;
    private Rigidbody rigid;
    private float horizontal;
    private float vertical;
    public float speed= 10f;
    //iniciando timer com um valor padrão
    public float timer = 0f;


    void Start()
    {
        anime = GetComponentInParent<Animator>();
        rigid = GetComponentInParent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //contando os segundos através do timer
        timer += Time.deltaTime;
    }

    void FixedUpdate() {
        
        //Horizontal
        if (Input.GetAxis("Horizontal") == 0)
        {
            anime.SetBool("isSideWalking", false);
        }
        else if (Input.GetAxis("Horizontal") < 0) {
            anime.SetBool("isSideWalking", true);
            transform.localScale = new Vector3(1, 1, 1);
            rigid.velocity = new Vector3(horizontal * speed,rigid.velocity.y, vertical*speed);
            //se houver qualquer movimentação o timer zera;
            timer = 0;
        }

        else if (Input.GetAxis("Horizontal") > 0)
        {
            anime.SetBool("isSideWalking", true);
            transform.localScale = new Vector3(-1, 1, 1);
            rigid.velocity = new Vector3(horizontal * speed, rigid.velocity.y, vertical * speed);
            //se houver qualquer movimentação o timer zera;
            timer = 0;
        }


        //Vertical

        if (Input.GetAxis("Vertical") == 0)
        {
            anime.SetBool("isFrontWalking", false);
            anime.SetBool("isBackWalking", false);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            anime.SetBool("isFrontWalking", true);
            rigid.velocity = new Vector3(horizontal * speed, rigid.velocity.y, vertical * speed);
            anime.SetBool("isBackWalking", false);
            //se houver qualquer movimentação o timer zera;
            timer = 0;
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            anime.SetBool("isBackWalking", true);            
            rigid.velocity = new Vector3(horizontal * speed, rigid.velocity.y, vertical * speed);
            anime.SetBool("isFrontWalking", false);
            //se houver qualquer movimentação o timer zera;
            timer = 0;
        }
        if(timer >= 30){
            //ativa a variavel para fazer a transição
            anime.SetBool("isSuperIdle",true);
            //zera o timer
            timer = 0;
            //para não pular direto da transição idle2 para idle3 fiz ele esperar...
            StartCoroutine(countDown());
        }
    }

    IEnumerator countDown(){
        //ele espera 1.6 segundos
        yield return new WaitForSeconds(1.6f);
        //desativa a variavel idle, assim fazendo ele ficar no idle2 até pegar os 30 segundos dnv...
        anime.SetBool("isSuperIdle", false);
    }
}
