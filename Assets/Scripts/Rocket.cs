using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{

    //SerializeFields
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip winningSound;
    [SerializeField] AudioClip explosionSound;

    [SerializeField] float rotateSpeed = 5f;
    [SerializeField] float thrustSpeed = 5f;
    [SerializeField] GameObject winningFX;
    [SerializeField] GameObject explosionFX;
    [SerializeField] GameObject thrustFX;
    /*[SerializeField] GameObject life1;
    [SerializeField] GameObject life2;
    [SerializeField] GameObject life3;*/

    //components
    Rigidbody rocketRB;
    AudioSource rocketAudioSource;
    /*public class Global
    //{
    //public 
    //}*/
    public static int lives = 4;
    int loadingTime = 2;
    bool isActive = true;
    int NaN;

    // Start is called before the first frame update
    void Start()
    {
        rocketRB = GetComponent<Rigidbody>();
        rocketAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == true)
        {
            Thrust();
            Rotate();
        }
    }
    void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            rocketRB.AddRelativeForce(Vector3.up * thrustSpeed);
            thrustFX.SetActive(true);
            if (!rocketAudioSource.isPlaying)
            {
                rocketAudioSource.PlayOneShot(mainEngine);
            }
        }
        else
        {
            thrustFX.SetActive(false);
            rocketAudioSource.Stop();
        }
    }
    void Rotate()
    {
        var originalConstraints = rocketRB.constraints;
        rocketRB.freezeRotation = true; // take manual rotation of the object
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotateSpeed);
        }
        rocketRB.freezeRotation = false;
        rocketRB.constraints = originalConstraints;
    }
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                //print("No problem");
                break;
            case "Finish":
                print("Congrats, You won!");
                Invoke("LoadNextScene", loadingTime);
                winningFX.SetActive(true);
                isActive = false;
                if (!rocketAudioSource.isPlaying)
                {
                    rocketAudioSource.PlayOneShot(winningSound);
                }
                else
                {
                    rocketAudioSource.Stop();
                }
                break;
            default:
                
                /*print("you have " + lives);
                if (lives > 0)
                {
                    Invoke("RepeatCurrentScene", loadingTime);
                }
                else
                {
                    Invoke("firstLevelReset", loadingTime);
                }
                //print("sorry, you lose!");
                lives = lives - 1;
                Invoke("decreaseLives", loadingTime);*/
                Invoke("firstLevelReset", loadingTime);
                explosionFX.SetActive(true);
                isActive = false;
                if (!rocketAudioSource.isPlaying)
                {
                    rocketAudioSource.PlayOneShot(explosionSound);
                }
                else
                {
                    rocketAudioSource.Stop();
                }
                break;
        }
    }
    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
            SceneManager.LoadScene(nextSceneIndex);
    }
    void RepeatCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void firstLevelReset()
    {
        SceneManager.LoadScene(0);
    }
    /*void decreaseLives()
    {
        lives = lives - 1;
    }
    void heartDisappear()
    {
        if (lives ==  3)
        {
            life1.SetActive(false);
        }
        else if (lives == 2)
        {
            life2.SetActive(false);
        }
        else if (lives == 1)
        {
            life1.SetActive(false);
        }*/
    }
//}
