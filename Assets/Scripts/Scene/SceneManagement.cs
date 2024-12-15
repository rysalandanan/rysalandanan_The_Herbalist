using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private bool isAutoSceneChange;
    [SerializeField] private float delayChangeTime;
    [SerializeField] private string sceneName;

    private void Start()
    {
        if (isAutoSceneChange)
        {
            ChangeScene();
        }
    }

    public void ChangeScene()
    {
        StartCoroutine(SceneChange());
    }

    private IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(delayChangeTime);
        LoadSceneAsync(sceneName);
    }

    private async void LoadSceneAsync(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            //Debug.LogError("Scene name is empty or null. Please assign a valid scene name.");
            return;
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Optionally, track progress (optional UI updates could go here)
        while (!asyncLoad.isDone)
        {
            //Debug.Log($"Loading progress: {asyncLoad.progress * 100}%");
            await Task.Yield(); // Allow Unity to continue updating the main thread
        }

        //Debug.Log("Scene loaded successfully!");
    }
}
