using UnityEngine;
using UnityUtils.SceneManagement.Views;
using Zenject;

public class Test : MonoBehaviour
{
    [Inject] private SceneLoader sceneLoader;

    // Update is called once per frame
    async void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            await sceneLoader.LoadSceneGroup(1, true);
        }
    }
}
