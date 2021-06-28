// GENERATED AUTOMATICALLY FROM 'Assets/SCRIPTS/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""dbf23e2d-bed7-4401-b530-241daf20163c"",
            ""actions"": [
                {
                    ""name"": ""RedButton"",
                    ""type"": ""Button"",
                    ""id"": ""8e492b8a-95b9-4fca-8b2e-2943babb4b52"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BlueButton"",
                    ""type"": ""Button"",
                    ""id"": ""c2c6267e-b158-442a-ae70-2e7309b0d509"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GreenButton"",
                    ""type"": ""Button"",
                    ""id"": ""5690b2b9-9264-47fb-9cfa-15af81bfdba6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""YellowButton"",
                    ""type"": ""Button"",
                    ""id"": ""7828b828-3032-4123-a90f-6da1670f1447"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PurpleButton"",
                    ""type"": ""Button"",
                    ""id"": ""85bf1298-1a9f-4ec2-8dd3-fa193a4c6830"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3898e311-c5e2-4cd7-adbe-b9194ffc5a75"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RedButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6fba6c79-953e-4f32-9486-b4ef2229412c"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BlueButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71ef5881-aa99-4ec8-a7c0-cbca507de796"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GreenButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eeab18cd-e397-4eb0-bf27-2dc80aa83bcd"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YellowButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e57fc63f-380d-428e-9581-3bd3b8dc23f2"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PurpleButton"",
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
        m_Gameplay_RedButton = m_Gameplay.FindAction("RedButton", throwIfNotFound: true);
        m_Gameplay_BlueButton = m_Gameplay.FindAction("BlueButton", throwIfNotFound: true);
        m_Gameplay_GreenButton = m_Gameplay.FindAction("GreenButton", throwIfNotFound: true);
        m_Gameplay_YellowButton = m_Gameplay.FindAction("YellowButton", throwIfNotFound: true);
        m_Gameplay_PurpleButton = m_Gameplay.FindAction("PurpleButton", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_RedButton;
    private readonly InputAction m_Gameplay_BlueButton;
    private readonly InputAction m_Gameplay_GreenButton;
    private readonly InputAction m_Gameplay_YellowButton;
    private readonly InputAction m_Gameplay_PurpleButton;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @RedButton => m_Wrapper.m_Gameplay_RedButton;
        public InputAction @BlueButton => m_Wrapper.m_Gameplay_BlueButton;
        public InputAction @GreenButton => m_Wrapper.m_Gameplay_GreenButton;
        public InputAction @YellowButton => m_Wrapper.m_Gameplay_YellowButton;
        public InputAction @PurpleButton => m_Wrapper.m_Gameplay_PurpleButton;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @RedButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRedButton;
                @RedButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRedButton;
                @RedButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRedButton;
                @BlueButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBlueButton;
                @BlueButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBlueButton;
                @BlueButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBlueButton;
                @GreenButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGreenButton;
                @GreenButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGreenButton;
                @GreenButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGreenButton;
                @YellowButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnYellowButton;
                @YellowButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnYellowButton;
                @YellowButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnYellowButton;
                @PurpleButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPurpleButton;
                @PurpleButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPurpleButton;
                @PurpleButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPurpleButton;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RedButton.started += instance.OnRedButton;
                @RedButton.performed += instance.OnRedButton;
                @RedButton.canceled += instance.OnRedButton;
                @BlueButton.started += instance.OnBlueButton;
                @BlueButton.performed += instance.OnBlueButton;
                @BlueButton.canceled += instance.OnBlueButton;
                @GreenButton.started += instance.OnGreenButton;
                @GreenButton.performed += instance.OnGreenButton;
                @GreenButton.canceled += instance.OnGreenButton;
                @YellowButton.started += instance.OnYellowButton;
                @YellowButton.performed += instance.OnYellowButton;
                @YellowButton.canceled += instance.OnYellowButton;
                @PurpleButton.started += instance.OnPurpleButton;
                @PurpleButton.performed += instance.OnPurpleButton;
                @PurpleButton.canceled += instance.OnPurpleButton;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnRedButton(InputAction.CallbackContext context);
        void OnBlueButton(InputAction.CallbackContext context);
        void OnGreenButton(InputAction.CallbackContext context);
        void OnYellowButton(InputAction.CallbackContext context);
        void OnPurpleButton(InputAction.CallbackContext context);
    }
}
