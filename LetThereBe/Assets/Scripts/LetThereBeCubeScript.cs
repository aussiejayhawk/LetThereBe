using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetThereBeCubeScript : Interactable
{
    public CubeManagerScript cubeManager;

    private bool areLightsOn = true;
    public override int DecideOutcome()
    {
        float endChance = Random.Range(0, 100);
        if (endChance >= 100)
        {
            cubeManager.LetThereBeAnEnd();
            return 6;
        }
        int oneInFourChance = Random.Range(1,4);
        switch (oneInFourChance)
        {
            case 1:
                cubeManager.LetThereBeChaos();
                return 1;
                break;
            case 2:
                //light or darkness
                if (areLightsOn == true)
                {
                    cubeManager.LetThereBeDarkness();
                    return 2;
                }
                else
                {
                    cubeManager.LetThereBeLight();
                    return 3;
                }
                break;
            case 3:
            cubeManager.LetThereBeHope();
            return 4;
                break;   
            case 4:
            cubeManager.LetThereBeOrder();
            return 5;
                break;        

        }
        
        int outcome = Random.Range(1, 6);


        return outcome;
    }
}
