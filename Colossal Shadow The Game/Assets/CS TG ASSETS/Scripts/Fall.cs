using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall : MonoBehaviour
{
    [SerializeField] private string sceneName; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PermanentUI.perm.Reset();
            SceneManager.LoadScene(sceneName);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
        }
    }
    
}
