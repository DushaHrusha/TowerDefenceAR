using DilmerGames.Core.Singletons;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class GameManagerCar : Singleton<GameManagerCar>
{
    [SerializeField]
    private GlobalGameSettings globalGameSettings;

    public GlobalGameSettings GlobalGameSettings
    {
        get
        {
            return globalGameSettings;
        }
    }
    
    void Awake() 
    {
        EnhancedTouchSupport.Enable();
    }
}
