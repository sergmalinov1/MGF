﻿using System;
using CodeBase.UI.Services.Factory;

namespace CodeBase.UI.Services.Windows
{
  public class WindowService : IWindowService
  {
    private readonly IUIFactory _uiFactory;

    public WindowService(IUIFactory uiFactory)
    {
      _uiFactory = uiFactory;
    }
    
    public void Open(WindowId windowId)
    {
      switch (windowId)
      {
        case WindowId.Unknow:
          break;
        case WindowId.Login: 
          _uiFactory.CreateLogin();
          break;
      }
    }
  }
}