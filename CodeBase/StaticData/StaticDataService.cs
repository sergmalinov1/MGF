using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;
using UnityEngine;

namespace CodeBase.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private const string StaticDataWindowsPath = "StaticData/Windows/WindowStaticData";
    
    private Dictionary<WindowId, WindowConfig> _windows;

    public void Load()
    {
      _windows = Resources
        .Load<WindowsStaticData>(StaticDataWindowsPath)
        .Configs
        .ToDictionary(x => x.WindowId, x => x);
    }

    public WindowConfig ForWindow(WindowId windowId) =>
      _windows.TryGetValue(windowId, out WindowConfig config)
        ? config
        : null;
  }
}