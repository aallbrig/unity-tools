﻿using MonoBehaviours.EventListeners;
using NUnit.Framework;
using ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Tests.EditMode.MonoBehaviours.EventListeners
{
    public class SceneEventListenerTests
    {
        [Test]
        public void SceneEventListenerScriptExposesFunctionForWhenInUnityEditor()
        {
            // Setup
            var sceneEventListener = new GameObject().AddComponent<SceneEventListener>();

            var sceneEvent = ScriptableObject.CreateInstance<SceneEvent>();
            var unityEvent = new UnityEvent();

            sceneEventListener.soEvent = sceneEvent;
            sceneEventListener.unityEvent = unityEvent;

            // Assertion
            unityEvent.AddListener(() => Assert.Pass("Unity Event listener invoked"));

            // Action
            sceneEventListener.OnEnable();
            sceneEventListener.OnEventBroadcast();
            sceneEventListener.OnDisable();
        }

        [Test]
        public void SceneEventListenerRespondsToSceneEventBroadcast()
        {
            // Setup
            var sceneEventListener = new GameObject().AddComponent<SceneEventListener>();

            var sceneEvent = ScriptableObject.CreateInstance<SceneEvent>();
            var unityEvent = new UnityEvent();

            sceneEventListener.soEvent = sceneEvent;
            sceneEventListener.unityEvent = unityEvent;

            // Assertion
            unityEvent.AddListener(() => Assert.Pass("Unity Event listener invoked"));

            // Action
            sceneEvent.Broadcast();
        }
    }
}