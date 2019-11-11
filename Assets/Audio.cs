using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    // Start is called before the first frame update

    static GameObject musicGameObject;

    void Awake()

    {

        if (musicGameObject == null)

        {

            musicGameObject = gameObject;

            DontDestroyOnLoad(musicGameObject);

        }

        else

        {

            DestroyImmediate(gameObject);

        }
    }
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
