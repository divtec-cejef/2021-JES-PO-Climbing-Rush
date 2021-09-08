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
                    ""name"": ""P1_RedButton"",
                    ""type"": ""Button"",
                    ""id"": ""8e492b8a-95b9-4fca-8b2e-2943babb4b52"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""P1_BlueButton"",
                    ""type"": ""Button"",
                    ""id"": ""c2c6267e-b158-442a-ae70-2e7309b0d509"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""P1_GreenButton"",
                    ""type"": ""Button"",
                    ""id"": ""5690b2b9-9264-47fb-9cfa-15af81bfdba6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""P1_YellowButton"",
                    ""type"": ""Button"",
                    ""id"": ""7828b828-3032-4123-a90f-6da1670f1447"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""P1_PurpleButton"",
                    ""type"": ""Button"",
                    ""id"": ""85bf1298-1a9f-4ec2-8dd3-fa193a4c6830"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""P2_RedButton"",
                    ""type"": ""Button"",
                    ""id"": ""12520a43-81ce-4db8-bd6a-6118e5cdc129"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""P2_BlueButton"",
                    ""type"": ""Button"",
                    ""id"": ""8cb8e474-18b4-42e4-9e7b-fcf75da01282"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""P2_GreenButton"",
                    ""type"": ""Button"",
                    ""id"": ""d66e243f-04d1-49da-89db-2c282be6b5a3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""P2_YellowButton"",
                    ""type"": ""Button"",
                    ""id"": ""31ec7e73-ce37-449e-86e6-96626b4049ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""P2_PurpleButton"",
                    ""type"": ""Button"",
                    ""id"": ""360df594-64f9-45ca-b0a1-2b746f18a32e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3898e311-c5e2-4cd7-adbe-b9194ffc5a75"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P1_RedButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6fba6c79-953e-4f32-9486-b4ef2229412c"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P1_BlueButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eeab18cd-e397-4eb0-bf27-2dc80aa83bcd"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P1_YellowButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e57fc63f-380d-428e-9581-3bd3b8dc23f2"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P1_PurpleButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71ef5881-aa99-4ec8-a7c0-cbca507de796"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P1_GreenButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a608c0f-8f0d-4fd8-b80f-bce3827220b3"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button10"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P2_PurpleButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77381470-9368-4508-9d2d-badee8e078e8"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P2_RedButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c35da0be-1edf-4136-9ede-e124e85064d1"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P2_BlueButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e23d2df-7c63-4aec-81f3-0ec7c0bb4550"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P2_GreenButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2bddf9ea-c2c1-4fc8-af61-f933603ed360"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""P2_YellowButton"",
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
        m_Gameplay_P1_RedButton = m_Gameplay.FindAction("P1_RedButton", throwIfNotFound: true);
        m_Gameplay_P1_BlueButton = m_Gameplay.FindAction("P1_BlueButton", throwIfNotFound: true);
        m_Gameplay_P1_GreenButton = m_Gameplay.FindAction("P1_GreenButton", throwIfNotFound: true);
        m_Gameplay_P1_YellowButton = m_Gameplay.FindAction("P1_YellowButton", throwIfNotFound: true);
        m_Gameplay_P1_PurpleButton = m_Gameplay.FindAction("P1_PurpleButton", throwIfNotFound: true);
        m_Gameplay_P2_RedButton = m_Gameplay.FindAction("P2_RedButton", throwIfNotFound: true);
        m_Gameplay_P2_BlueButton = m_Gameplay.FindAction("P2_BlueButton", throwIfNotFound: true);
        m_Gameplay_P2_GreenButton = m_Gameplay.FindAction("P2_GreenButton", throwIfNotFound: true);
        m_Gameplay_P2_YellowButton = m_Gameplay.FindAction("P2_YellowButton", throwIfNotFound: true);
        m_Gameplay_P2_PurpleButton = m_Gameplay.FindAction("P2_PurpleButton", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_P1_RedButton;
    private readonly InputAction m_Gameplay_P1_BlueButton;
    private readonly InputAction m_Gameplay_P1_GreenButton;
    private readonly InputAction m_Gameplay_P1_YellowButton;
    private readonly InputAction m_Gameplay_P1_PurpleButton;
    private readonly InputAction m_Gameplay_P2_RedButton;
    private readonly InputAction m_Gameplay_P2_BlueButton;
    private readonly InputAction m_Gameplay_P2_GreenButton;
    private readonly InputAction m_Gameplay_P2_YellowButton;
    private readonly InputAction m_Gameplay_P2_PurpleButton;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @P1_RedButton => m_Wrapper.m_Gameplay_P1_RedButton;
        public InputAction @P1_BlueButton => m_Wrapper.m_Gameplay_P1_BlueButton;
        public InputAction @P1_GreenButton => m_Wrapper.m_Gameplay_P1_GreenButton;
        public InputAction @P1_YellowButton => m_Wrapper.m_Gameplay_P1_YellowButton;
        public InputAction @P1_PurpleButton => m_Wrapper.m_Gameplay_P1_PurpleButton;
        public InputAction @P2_RedButton => m_Wrapper.m_Gameplay_P2_RedButton;
        public InputAction @P2_BlueButton => m_Wrapper.m_Gameplay_P2_BlueButton;
        public InputAction @P2_GreenButton => m_Wrapper.m_Gameplay_P2_GreenButton;
        public InputAction @P2_YellowButton => m_Wrapper.m_Gameplay_P2_YellowButton;
        public InputAction @P2_PurpleButton => m_Wrapper.m_Gameplay_P2_PurpleButton;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @P1_RedButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP1_RedButton;
                @P1_RedButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP1_RedButton;
                @P1_RedButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP1_RedButton;
                @P1_BlueButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP1_BlueButton;
                @P1_BlueButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP1_BlueButton;
                @P1_BlueButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP1_BlueButton;
                @P1_GreenButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP1_GreenButton;
                @P1_GreenButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP1_GreenButton;
                @P1_GreenButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP1_GreenButton;
                @P1_YellowButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP1_YellowButton;
                @P1_YellowButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP1_YellowButton;
                @P1_YellowButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP1_YellowButton;
                @P1_PurpleButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP1_PurpleButton;
                @P1_PurpleButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP1_PurpleButton;
                @P1_PurpleButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP1_PurpleButton;
                @P2_RedButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP2_RedButton;
                @P2_RedButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP2_RedButton;
                @P2_RedButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP2_RedButton;
                @P2_BlueButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP2_BlueButton;
                @P2_BlueButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP2_BlueButton;
                @P2_BlueButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP2_BlueButton;
                @P2_GreenButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP2_GreenButton;
                @P2_GreenButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP2_GreenButton;
                @P2_GreenButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP2_GreenButton;
                @P2_YellowButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP2_YellowButton;
                @P2_YellowButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP2_YellowButton;
                @P2_YellowButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP2_YellowButton;
                @P2_PurpleButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP2_PurpleButton;
                @P2_PurpleButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP2_PurpleButton;
                @P2_PurpleButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnP2_PurpleButton;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @P1_RedButton.started += instance.OnP1_RedButton;
                @P1_RedButton.performed += instance.OnP1_RedButton;
                @P1_RedButton.canceled += instance.OnP1_RedButton;
                @P1_BlueButton.started += instance.OnP1_BlueButton;
                @P1_BlueButton.performed += instance.OnP1_BlueButton;
                @P1_BlueButton.canceled += instance.OnP1_BlueButton;
                @P1_GreenButton.started += instance.OnP1_GreenButton;
                @P1_GreenButton.performed += instance.OnP1_GreenButton;
                @P1_GreenButton.canceled += instance.OnP1_GreenButton;
                @P1_YellowButton.started += instance.OnP1_YellowButton;
                @P1_YellowButton.performed += instance.OnP1_YellowButton;
                @P1_YellowButton.canceled += instance.OnP1_YellowButton;
                @P1_PurpleButton.started += instance.OnP1_PurpleButton;
                @P1_PurpleButton.performed += instance.OnP1_PurpleButton;
                @P1_PurpleButton.canceled += instance.OnP1_PurpleButton;
                @P2_RedButton.started += instance.OnP2_RedButton;
                @P2_RedButton.performed += instance.OnP2_RedButton;
                @P2_RedButton.canceled += instance.OnP2_RedButton;
                @P2_BlueButton.started += instance.OnP2_BlueButton;
                @P2_BlueButton.performed += instance.OnP2_BlueButton;
                @P2_BlueButton.canceled += instance.OnP2_BlueButton;
                @P2_GreenButton.started += instance.OnP2_GreenButton;
                @P2_GreenButton.performed += instance.OnP2_GreenButton;
                @P2_GreenButton.canceled += instance.OnP2_GreenButton;
                @P2_YellowButton.started += instance.OnP2_YellowButton;
                @P2_YellowButton.performed += instance.OnP2_YellowButton;
                @P2_YellowButton.canceled += instance.OnP2_YellowButton;
                @P2_PurpleButton.started += instance.OnP2_PurpleButton;
                @P2_PurpleButton.performed += instance.OnP2_PurpleButton;
                @P2_PurpleButton.canceled += instance.OnP2_PurpleButton;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnP1_RedButton(InputAction.CallbackContext context);
        void OnP1_BlueButton(InputAction.CallbackContext context);
        void OnP1_GreenButton(InputAction.CallbackContext context);
        void OnP1_YellowButton(InputAction.CallbackContext context);
        void OnP1_PurpleButton(InputAction.CallbackContext context);
        void OnP2_RedButton(InputAction.CallbackContext context);
        void OnP2_BlueButton(InputAction.CallbackContext context);
        void OnP2_GreenButton(InputAction.CallbackContext context);
        void OnP2_YellowButton(InputAction.CallbackContext context);
        void OnP2_PurpleButton(InputAction.CallbackContext context);
    }
}
