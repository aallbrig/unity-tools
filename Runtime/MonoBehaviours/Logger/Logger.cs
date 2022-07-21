using UnityEngine;
using ILogger = Interfaces.ILogger;

namespace MonoBehaviours.Logger
{
    public class Logger : MonoBehaviour, ILogger
    {
        public void Log(string msg) => Debug.Log(msg);
        public void Warn(string msg) => Debug.LogWarning(msg);
        public void Error(string msg) => Debug.LogError(msg);
    }
}