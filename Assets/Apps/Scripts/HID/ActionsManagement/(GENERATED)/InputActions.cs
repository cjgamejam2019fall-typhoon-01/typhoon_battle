// GENERATED AUTOMATICALLY FROM 'Assets/Apps/Scripts/HID/ActionsManagement/InputActions.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Apps.HID.ActionsManagement
{
    public class InputActions : IInputActionCollection
    {
        private InputActionAsset asset;
        public InputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""429b4856-8d96-4c55-9e89-4d6f0a2e8736"",
            ""actions"": [
                {
                    ""name"": ""RotationTrigger"",
                    ""type"": ""Button"",
                    ""id"": ""ab1a6028-fef1-432e-abe2-d89ce08973dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotationX"",
                    ""type"": ""Value"",
                    ""id"": ""7db8e3d7-bed5-4985-9c36-5e67fc386994"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotationY"",
                    ""type"": ""Button"",
                    ""id"": ""353d8949-eb66-4f20-b765-fa0fe7572cd2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2c9d39da-ba0f-40d7-874b-51082e5db4a9"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotationTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c735293-464e-4345-a65c-d53faadd10a0"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotationX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""736df051-12bc-4ca7-a1b1-b80f01ee2e63"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotationY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Game
            m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
            m_Game_RotationTrigger = m_Game.FindAction("RotationTrigger", throwIfNotFound: true);
            m_Game_RotationX = m_Game.FindAction("RotationX", throwIfNotFound: true);
            m_Game_RotationY = m_Game.FindAction("RotationY", throwIfNotFound: true);
        }

        ~InputActions()
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

        // Game
        private readonly InputActionMap m_Game;
        private IGameActions m_GameActionsCallbackInterface;
        private readonly InputAction m_Game_RotationTrigger;
        private readonly InputAction m_Game_RotationX;
        private readonly InputAction m_Game_RotationY;
        public struct GameActions
        {
            private InputActions m_Wrapper;
            public GameActions(InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @RotationTrigger => m_Wrapper.m_Game_RotationTrigger;
            public InputAction @RotationX => m_Wrapper.m_Game_RotationX;
            public InputAction @RotationY => m_Wrapper.m_Game_RotationY;
            public InputActionMap Get() { return m_Wrapper.m_Game; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
            public void SetCallbacks(IGameActions instance)
            {
                if (m_Wrapper.m_GameActionsCallbackInterface != null)
                {
                    RotationTrigger.started -= m_Wrapper.m_GameActionsCallbackInterface.OnRotationTrigger;
                    RotationTrigger.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnRotationTrigger;
                    RotationTrigger.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnRotationTrigger;
                    RotationX.started -= m_Wrapper.m_GameActionsCallbackInterface.OnRotationX;
                    RotationX.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnRotationX;
                    RotationX.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnRotationX;
                    RotationY.started -= m_Wrapper.m_GameActionsCallbackInterface.OnRotationY;
                    RotationY.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnRotationY;
                    RotationY.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnRotationY;
                }
                m_Wrapper.m_GameActionsCallbackInterface = instance;
                if (instance != null)
                {
                    RotationTrigger.started += instance.OnRotationTrigger;
                    RotationTrigger.performed += instance.OnRotationTrigger;
                    RotationTrigger.canceled += instance.OnRotationTrigger;
                    RotationX.started += instance.OnRotationX;
                    RotationX.performed += instance.OnRotationX;
                    RotationX.canceled += instance.OnRotationX;
                    RotationY.started += instance.OnRotationY;
                    RotationY.performed += instance.OnRotationY;
                    RotationY.canceled += instance.OnRotationY;
                }
            }
        }
        public GameActions @Game => new GameActions(this);
        public interface IGameActions
        {
            void OnRotationTrigger(InputAction.CallbackContext context);
            void OnRotationX(InputAction.CallbackContext context);
            void OnRotationY(InputAction.CallbackContext context);
        }
    }
}
