using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public AudioSource buttonClickSound;

   public void PlayGame()
   {
      buttonClickSound.Play();
      StartCoroutine(Load("Map1"));
   }

   public void Exit()
   {
      buttonClickSound.Play();
      StartCoroutine(_Exit());
   }

   public void Option()
   {
      buttonClickSound.Play();
      StartCoroutine(Load("Setting"));
   }

   public void Shop()
   {
      buttonClickSound.Play();
      StartCoroutine(Load("Shop"));
   }

   public void Menu()
   {
      buttonClickSound.Play();
      StartCoroutine(Load("Menu"));
   }

   public void DeleteData()
   {
      buttonClickSound.Play();
      PlayerPrefs.DeleteAll();
      StartCoroutine(Load("Menu"));
   }

   public void PlaySound()
   {
      buttonClickSound.Play();
   }

   private IEnumerator Load(string sceneString)
   {
      yield return new WaitForSeconds(0.3f);
      SceneManager.LoadScene(sceneString);
   }

   private IEnumerator _Exit()
   {
      yield return new WaitForSeconds(0.3f);
      Application.Quit();
   }
}
