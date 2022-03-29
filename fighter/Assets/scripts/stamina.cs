using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class stamina : MonoBehaviour
{
    public Slider staminaBar;
    private int maxStamina = 100;
    private int currentStamina;
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    public static stamina instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }
    public void UseStamina(int amount){
        if(currentStamina - amount >= 0){
            currentStamina -= amount;
            staminaBar.value = currentStamina;

            StartCoroutine(regenStamina());
        }
        else
        {
            Debug.Log("No stamina");
        }
    }
    private IEnumerator regenStamina(){
        yield return new WaitForSeconds(5);

        while(currentStamina < maxStamina){
            currentStamina += maxStamina / 100;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
    }
}
