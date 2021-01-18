using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndlessMov : MonoBehaviour
{
    public Slider runSlider;
    public float atualDistance = 0f;
    //2687 == 2m:17s
    public float winDistance = 2687f;
    public float speed = 10f;
    public float lineSpeed = 10f;
    public Rigidbody rb;
    private float currentLine = 0f;
    Vector3 verticalTargetPosition;
    public int maxLife = 3;
    private int currentLife;
    private Animator anim;

    public float minSpeed = 10f;
    public float maxSpeed = 30f;
    private bool invicible = false;
    static int blinkingValue;
    public float invicibleTime = 3f;
    public GameObject model;
    private EndlessUIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        atualDistance = transform.position.z;
        uiManager = FindObjectOfType<EndlessUIManager>();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponentInChildren<Rigidbody>();
        verticalTargetPosition  = new Vector3(transform.position.x, 2, transform.position.z);
        currentLife = maxLife;
        speed = minSpeed;
        blinkingValue = Shader.PropertyToID("_BlinkingValue");

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            changeLine(-2f);
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            changeLine(2f);
        }

        Vector3 targetPosition = new Vector3(verticalTargetPosition.x, verticalTargetPosition.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, lineSpeed * Time.deltaTime);
    }

    private void FixedUpdate() {
        rb.velocity = new Vector3(0,2, 1 * speed);
        runSlider.value = atualDistance / winDistance;
        atualDistance = transform.position.z;
        if(speed < maxSpeed){
            speed += 0.1f;
        }
        if(runSlider.value == 1){
            Debug.Log("You Win!!!");
        }
    }


    void changeLine(float direction){
        float targetLine = currentLine + direction;
        if(targetLine < -10f || targetLine > 10f){
            return;
        }
        currentLine = targetLine;
        verticalTargetPosition = new Vector3((currentLine),2, 0);
    }

    private void OnTriggerEnter(Collider other) {
        if(invicible){
            return;
        }
        if(other.CompareTag("Obstacle")){
            currentLife--;
            uiManager.UpdateLifes(currentLife);
            speed = 0;
            if(currentLife <= 0){
                //gameOver
                //youLoseScreen
                //reloadLevel
                gameOver();
            } else{
                StartCoroutine(Blinking(invicibleTime));
            }
        }
    }
    IEnumerator Blinking(float time){
        invicible = true;
        float timer = 0;
        float currentBlink = 1f;
        float lastBlink = 0;
        float blinkPeriod = 0.1f;
        bool enabled = false;
        yield return new WaitForSeconds(1f);
        float newMinSpeed = minSpeed - 10f;
        if(newMinSpeed >= minSpeed){
            minSpeed = newMinSpeed;
        }
        speed = minSpeed;
        while(timer < time && invicible){
            //Shader.SetGlobalFloat(blinkingValue, currentBlink);
            model.SetActive(enabled);
            yield return null;
            timer += Time.deltaTime;
            lastBlink += Time.deltaTime;
            if(blinkPeriod < lastBlink){
                lastBlink = 0;
                currentBlink = 1f - currentBlink;
                enabled = !enabled;
            }
        }
        model.SetActive(true);
        enabled = false;
        //Shader.SetGlobalFloat(blinkingValue, 0);
        invicible = false;

    }

    public void gameOver(){
        Debug.Log("You Lose");
        Debug.Log("Reloading...");
        SceneManager.LoadScene("EndlessRunne");
    }
}
