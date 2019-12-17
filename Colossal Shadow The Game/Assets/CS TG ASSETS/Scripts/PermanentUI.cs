using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PermanentUI : MonoBehaviour
{
    public int score = 0; 
    public int health = 5;
    public int gem = 0;
    public TextMeshProUGUI healthAmount;
    public TextMeshProUGUI gemText;

    public static PermanentUI perm;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!perm)
            perm = this;

        else
            Destroy(gameObject);

    }

    public void Reset()
    {
        gem = 0;
        gemText.text = gem.ToString();
        health = 5;
        //healthAmount.text = health.ToString();
    }


}
