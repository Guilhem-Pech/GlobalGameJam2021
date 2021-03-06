// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/GameInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputs"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""a47eea07-e99d-4591-91c2-3814d1c51f34"",
            ""actions"": [
                {
                    ""name"": ""FireGrapplingHook"",
                    ""type"": ""Button"",
                    ""id"": ""e536a44a-e2d6-4d84-a8d4-f0b5c5c1ad17"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""Button"",
                    ""id"": ""eb8eab7f-9c2c-43b9-8910-41afc4a08f2d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""4366f088-7649-4b3c-819f-2372264c1fba"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""c00bb64e-9b43-4a8c-b445-5ca745dcd8e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f358a2bc-facf-484e-8b93-8d9361697a9e"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""689da840-3197-49a4-9979-b89895b95651"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""622d27f8-8b5d-435b-9084-957cfaa90ce0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""931808a2-fc78-4b82-8d33-582ccaaf3fd9"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireGrapplingHook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_FireGrapplingHook = m_Gameplay.FindAction("FireGrapplingHook", throwIfNotFound: true);
        m_Gameplay_RightClick = m_Gameplay.FindAction("RightClick", throwIfNotFound: true);
        m_Gameplay_MousePosition = m_Gameplay.FindAction("MousePosition", throwIfNotFound: true);
        m_Gameplay_LeftClick = m_Gameplay.FindAction("LeftClick", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_FireGrapplingHook;
    private readonly InputAction m_Gameplay_RightClick;
    private readonly InputAction m_Gameplay_MousePosition;
    private readonly InputAction m_Gameplay_LeftClick;
    public struct GameplayActions
    {
        private @GameInputs m_Wrapper;
        public GameplayActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @FireGrapplingHook => m_Wrapper.m_Gameplay_FireGrapplingHook;
        public InputAction @RightClick => m_Wrapper.m_Gameplay_RightClick;
        public InputAction @MousePosition => m_Wrapper.m_Gameplay_MousePosition;
        public InputAction @LeftClick => m_Wrapper.m_Gameplay_LeftClick;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @FireGrapplingHook.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFireGrapplingHook;
                @FireGrapplingHook.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFireGrapplingHook;
                @FireGrapplingHook.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFireGrapplingHook;
                @RightClick.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightClick;
                @MousePosition.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMousePosition;
                @LeftClick.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftClick;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @FireGrapplingHook.started += instance.OnFireGrapplingHook;
                @FireGrapplingHook.performed += instance.OnFireGrapplingHook;
                @FireGrapplingHook.canceled += instance.OnFireGrapplingHook;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnFireGrapplingHook(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnLeftClick(InputAction.CallbackContext context);
    }
}
