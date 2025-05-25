using Core;
using EventChanells;
using UnityEngine;
using UnityUtils.SceneManagement.Views;
using Zenject;

public class GameBooter : BaseBooter
{
    [SerializeField] private int _sceneGroupIndexToLoad;

    private SceneLoader _sceneLoader;
    private GameDataManager _gameDataManager;
    private SignalBus _signalBus;

    [Inject]
    private void InjectDependenceis(SceneLoader sceneLoader, GameDataManager gameDataManager, SignalBus signalBus)
    {
        _sceneLoader = sceneLoader;
        _gameDataManager = gameDataManager;
        _signalBus = signalBus;
    }

    protected async override void InitGame()
    {
        await _sceneLoader.LoadSceneGroup(_sceneGroupIndexToLoad, true,
            () => _signalBus.TryFire(new SceneLoadedStartedSignal()),
            () => _signalBus.TryFire(new SceneLoadedEndSignal())
            );

        await _gameDataManager.InitializeData();
    }
}
