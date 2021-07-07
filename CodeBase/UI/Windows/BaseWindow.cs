﻿using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
  public abstract class BaseWindow : MonoBehaviour
  {
    public void Construct() { }
    
    private void Awake() => 
      OnAwake();

    private void Start()
    {
      Initialize();
      SubscribeUpdate();
    }

    private void OnDestroy() => 
      Cleanup();

    protected virtual void OnAwake() { }
    protected virtual void Initialize() {}

    protected virtual void SubscribeUpdate() {}
    protected virtual void Cleanup() {}
  }
}