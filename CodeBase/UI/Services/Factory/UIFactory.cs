using System;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.StaticData;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;
using CodeBase.UI.Windows;
using CodeBase.UI.Windows.Login;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.UI.Services.Factory
{
  public class UIFactory : IUIFactory
  {
    private const string UIRootPath = "UI/UIRoot";
    
    private readonly IStaticDataService _staticData;
    private readonly IAssetProvider _assetsProvider;

    
    private Transform _uiRoot;
    
    public UIFactory(IStaticDataService staticData, IAssetProvider assetsProvider)
    {
      _staticData = staticData;
      _assetsProvider = assetsProvider;
    }
    
    public void CreateUIRoot() => 
      _uiRoot = _assetsProvider.Instantiate(UIRootPath).transform;

    public void CreateLogin(Action onLoaded = null)
    {
      WindowConfig config = _staticData.ForWindow(WindowId.Login);
      LoginWindow window = Object.Instantiate(config.Prefab, _uiRoot) as LoginWindow;
      window.Construct(onLoaded);
    }
  }
}