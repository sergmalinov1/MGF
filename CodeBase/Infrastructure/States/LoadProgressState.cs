using UnityEngine;

namespace CodeBase.Infrastructure.States
{
  public class LoadProgressState : IPayloadedState<string>
  {
    private SceneLoader _sceneLoader;

    public LoadProgressState(GameStateMachine stateMachine, SceneLoader sceneLoader)
    {
      _sceneLoader = sceneLoader;
    }
      

    public void Enter(string sceneName)
    {
      _sceneLoader.Load(sceneName, OnLoaded);
    }

    private void OnLoaded()
    {
      Debug.Log("LoadProgressState");
    }

    public void Exit()
    {
    }
  }
}