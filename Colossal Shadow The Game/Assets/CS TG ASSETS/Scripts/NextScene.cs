using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] private string sceneName; // option 1
    

    private void Start()
    {
        

    }
    private void Update()
    {
        string Death = SceneManager.GetActiveScene().name;
        if (Death == "DeathScene")
        {
            Destroy(PermanentUI.perm.gameObject);
        }
        else if (Death == "DeathScene2")
        {
            Destroy(PermanentUI.perm.gameObject);
        }
        if (Death == "DeathScene3")
        {
            Destroy(PermanentUI.perm.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneName);  // option 2
        }

    }

    public void load()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Checkname()
    {
        

        
        //SceneManager.LoadScene
    }

}
    

