using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hw1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int score = 20;
        
        if(score > 18){
            Debug.Log("You win!");
        }else{
            Debug.Log("You lose");
        }

        while(score > 10){
            score--;
        }

        for(int i = 1; i <= 4; i++){
            score += i;
        }

        Debug.Log("Final Score: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
