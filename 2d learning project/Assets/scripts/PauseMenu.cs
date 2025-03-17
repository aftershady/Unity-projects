using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{


    void Awake()
    {
        Animator[] animators = FindObjectsOfType<Animator>();
    }
    public void Resume()
    {
        gameObject.SetActive(false);
		PlayerMovement.instance.rigidBody.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.instance.playerCollider.enabled = true;
		PlayerMovement.instance.enabled = true;
		PlayerMovement.instance.animator.speed = 1;
    }

	public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

        public void QuitGame()
    {
        Application.Quit();
    }
}
