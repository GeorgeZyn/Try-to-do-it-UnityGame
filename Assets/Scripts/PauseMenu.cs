using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   public AudioSource buttonClickSound;


   public static bool gameIsPaused = false;
   public GameObject pauseMenuUI;

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
         if (gameIsPaused)
            Resume();
         else
            Pause();
      }

   }

   public void Resume()
   {
      buttonClickSound.Play();
      pauseMenuUI.SetActive(false);
      Time.timeScale = 1f;
      gameIsPaused = false;
   }

   public void Pause()
   {
      buttonClickSound.Play();
      pauseMenuUI.SetActive(true);
      Time.timeScale = 0f;
      gameIsPaused = true;
   }

   public void LoadMenu()
   {
      buttonClickSound.Play();
      Time.timeScale = 1f;
      StartCoroutine(Load("Menu"));
   }

   public void LoadShop()
   {
      buttonClickSound.Play();
      Time.timeScale = 1f;
      StartCoroutine(Load("Shop"));
   }

   private IEnumerator Load(string sceneString)
   {
      yield return new WaitForSeconds(0.3f);
      SceneManager.LoadScene(sceneString);
   }
}
