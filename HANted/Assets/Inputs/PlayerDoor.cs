//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Inputs/PlayerDoor.inputactions
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

public partial class @PlayerDoorGenerated: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerDoorGenerated()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerDoor"",
    ""maps"": [
        {
            ""name"": ""PlayerDoor"",
            ""id"": ""6bec04b9-5c25-455d-a664-a7ecba32f91a"",
            ""actions"": [
                {
                    ""name"": ""PlayerDoor"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d344f3f2-7a58-4c71-8744-5e7df522eee7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""641aee24-eae6-4a3a-817a-1c126579edf7"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerDoor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerDoor
        m_PlayerDoor = asset.FindActionMap("PlayerDoor", throwIfNotFound: true);
        m_PlayerDoor_PlayerDoor = m_PlayerDoor.FindAction("PlayerDoor", throwIfNotFound: true);
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

    // PlayerDoor
    private readonly InputActionMap m_PlayerDoor;
    private List<IPlayerDoorActions> m_PlayerDoorActionsCallbackInterfaces = new List<IPlayerDoorActions>();
    private readonly InputAction m_PlayerDoor_PlayerDoor;
    public struct PlayerDoorActions
    {
        private @PlayerDoorGenerated m_Wrapper;
        public PlayerDoorActions(@PlayerDoorGenerated wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlayerDoor => m_Wrapper.m_PlayerDoor_PlayerDoor;
        public InputActionMap Get() { return m_Wrapper.m_PlayerDoor; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerDoorActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerDoorActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerDoorActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerDoorActionsCallbackInterfaces.Add(instance);
            @PlayerDoor.started += instance.OnPlayerDoor;
            @PlayerDoor.performed += instance.OnPlayerDoor;
            @PlayerDoor.canceled += instance.OnPlayerDoor;
        }

        private void UnregisterCallbacks(IPlayerDoorActions instance)
        {
            @PlayerDoor.started -= instance.OnPlayerDoor;
            @PlayerDoor.performed -= instance.OnPlayerDoor;
            @PlayerDoor.canceled -= instance.OnPlayerDoor;
        }

        public void RemoveCallbacks(IPlayerDoorActions instance)
        {
            if (m_Wrapper.m_PlayerDoorActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerDoorActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerDoorActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerDoorActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerDoorActions @PlayerDoor => new PlayerDoorActions(this);
    public interface IPlayerDoorActions
    {
        void OnPlayerDoor(InputAction.CallbackContext context);
    }
}
