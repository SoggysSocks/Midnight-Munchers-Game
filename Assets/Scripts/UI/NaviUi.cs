using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NaviUi : MonoBehaviour
{
    public RoundSystem roundSystem;

    [SerializeField]
    private TextMeshProUGUI _text;

    // Start is called before the first frame update
    // help from https://stackoverflow.com/questions/67411554/how-to-change-text-by-script-in-unity
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!roundSystem.startNight)
        {
            _text.text = "GO TO BED TO START THE NIGHT";
        }
        else
        {
            if (roundSystem.fridgeDrinkTask)
            {
                _text.text = "GRAB A DRINK";
                Debug.Log("YOUR THIRSTY, GRAB A DRINK FROM THE FRIDGE");
            }
            if (roundSystem.snackTask)
            {
                _text.text = "GRAB A SNACK";
                Debug.Log("YOUR HUNGRY, GRAB A SNACK FROM THE KITCHEN");
            }
            if (roundSystem.homeworkTask)
            {
                _text.text = "SUBMIT YOUR HOMEWORK";
            }
            if (roundSystem.peeTask)
            {
                _text.text = "GO TOILET";
            }
        }


    }
}
