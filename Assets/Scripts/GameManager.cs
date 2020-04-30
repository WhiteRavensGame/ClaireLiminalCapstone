using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score;
    public float timeLeft;

    public Target[] targets;
    public Target chosenTarget;

    void Start()
    {
        if(Instance == null)
        {
            Instance = this;

            ChooseNewTarget();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseNewTarget()
    {
        for(int i = 0; i < targets.Length; i++)
        {
            targets[i].isTarget = false;
        }

        chosenTarget = targets[Random.Range(0, targets.Length)];
        chosenTarget.gameObject.tag = "ColourTarget";
        chosenTarget.isTarget = true;


    }


}
