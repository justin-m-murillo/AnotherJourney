//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/InputActions/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayerControlsMap"",
            ""id"": ""09abf9a3-3348-4d24-a81c-ff7177d8750a"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""ff0aae09-6ff9-4bfb-ba75-0685f95a4032"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""dc49fead-78c1-470d-9f4b-e81fb52344b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""bab0b3ff-19f8-445e-9b0e-308bb6f8e8a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""f04074d0-f040-46bf-bc4d-6c3b173b1595"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""f1fd988e-ab9a-4e33-ab5c-4f47b427d643"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""bee8cdd2-0dd6-4a64-a5bd-0de44e17313d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""00d81f21-ca80-479f-b64f-f1698661ee72"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Hold(duration=0.2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe618db3-eeae-41a9-962a-8892d020cbb6"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControlsMap
        m_PlayerControlsMap = asset.FindActionMap("PlayerControlsMap", throwIfNotFound: true);
        m_PlayerControlsMap_Move = m_PlayerControlsMap.FindAction("Move", throwIfNotFound: true);
        m_PlayerControlsMap_Jump = m_PlayerControlsMap.FindAction("Jump", throwIfNotFound: true);
        m_PlayerControlsMap_Attack = m_PlayerControlsMap.FindAction("Attack", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerControlsMap
    private readonly InputActionMap m_PlayerControlsMap;
    private IPlayerControlsMapActions m_PlayerControlsMapActionsCallbackInterface;
    private readonly InputAction m_PlayerControlsMap_Move;
    private readonly InputAction m_PlayerControlsMap_Jump;
    private readonly InputAction m_PlayerControlsMap_Attack;
    public struct PlayerControlsMapActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerControlsMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerControlsMap_Move;
        public InputAction @Jump => m_Wrapper.m_PlayerControlsMap_Jump;
        public InputAction @Attack => m_Wrapper.m_PlayerControlsMap_Attack;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControlsMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsMapActions instance)
        {
            if (m_Wrapper.m_PlayerControlsMapActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_PlayerControlsMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public PlayerControlsMapActions @PlayerControlsMap => new PlayerControlsMapActions(this);
    public interface IPlayerControlsMapActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
}
