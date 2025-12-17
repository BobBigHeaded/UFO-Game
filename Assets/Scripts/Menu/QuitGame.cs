using UnityEngine;

public class QuitGame : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Application.Quit();
    }
}
