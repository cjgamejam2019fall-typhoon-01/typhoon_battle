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
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Button"",
                    ""id"": ""87ad12a5-ba84-4daa-bcaf-53ff2a6e2b0c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GenerateWind"",
                    ""type"": ""Button"",
                    ""id"": ""508cd66d-48f3-44b8-accf-ba462a73b0c2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePositionX"",
                    ""type"": ""Value"",
                    ""id"": ""9b9a6a4d-fd08-4d20-9767-6745db3ece75"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePositionY"",
                    ""type"": ""Value"",
                    ""id"": ""df6ddf33-f270-4e2a-9a8c-f3b66f3e16ea"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GenerateTyphoon"",
                    ""type"": ""Button"",
                    ""id"": ""05bc9b73-c07d-4bda-a128-bdc925099bdd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2c9d39da-ba0f-40d7-874b-51082e5db4a9"",
                    ""path"": ""<Mouse>/rightButton"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""44bc19bc-dcfa-4a1b-bf7a-72f9dfec8312"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5b8f61b-bf7e-47c8-968a-c10a2fca7a01"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GenerateWind"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc49f728-d0e4-419d-b407-4a6e914a402c"",
                    ""path"": ""<Mouse>/position/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePositionX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e190ed4a-a8be-408e-9e63-16fe68cb634a"",
                    ""path"": ""<Mouse>/position/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePositionY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8cd1683c-4631-448c-80fa-ca8df50c6b89"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GenerateTyphoon"",
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
            m_Game_Zoom = m_Game.FindAction("Zoom", throwIfNotFound: true);
            m_Game_GenerateWind = m_Game.FindAction("GenerateWind", throwIfNotFound: true);
            m_Game_MousePositionX = m_Game.FindAction("MousePositionX", throwIfNotFound: true);
            m_Game_MousePositionY = m_Game.FindAction("MousePositionY", throwIfNotFound: true);
            m_Game_GenerateTyphoon = m_Game.FindAction("GenerateTyphoon", throwIfNotFound: true);
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
        private readonly InputAction m_Game_Zoom;
        private readonly InputAction m_Game_GenerateWind;
        private readonly InputAction m_Game_MousePositionX;
        private readonly InputAction m_Game_MousePositionY;
        private readonly InputAction m_Game_GenerateTyphoon;
        public struct GameActions
        {
            private InputActions m_Wrapper;
            public GameActions(InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @RotationTrigger => m_Wrapper.m_Game_RotationTrigger;
            public InputAction @RotationX => m_Wrapper.m_Game_RotationX;
            public InputAction @RotationY => m_Wrapper.m_Game_RotationY;
            public InputAction @Zoom => m_Wrapper.m_Game_Zoom;
            public InputAction @GenerateWind => m_Wrapper.m_Game_GenerateWind;
            public InputAction @MousePositionX => m_Wrapper.m_Game_MousePositionX;
            public InputAction @MousePositionY => m_Wrapper.m_Game_MousePositionY;
            public InputAction @GenerateTyphoon => m_Wrapper.m_Game_GenerateTyphoon;
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
                    Zoom.started -= m_Wrapper.m_GameActionsCallbackInterface.OnZoom;
                    Zoom.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnZoom;
                    Zoom.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnZoom;
                    GenerateWind.started -= m_Wrapper.m_GameActionsCallbackInterface.OnGenerateWind;
                    GenerateWind.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnGenerateWind;
                    GenerateWind.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnGenerateWind;
                    MousePositionX.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMousePositionX;
                    MousePositionX.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMousePositionX;
                    MousePositionX.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMousePositionX;
                    MousePositionY.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMousePositionY;
                    MousePositionY.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMousePositionY;
                    MousePositionY.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMousePositionY;
                    GenerateTyphoon.started -= m_Wrapper.m_GameActionsCallbackInterface.OnGenerateTyphoon;
                    GenerateTyphoon.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnGenerateTyphoon;
                    GenerateTyphoon.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnGenerateTyphoon;
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
                    Zoom.started += instance.OnZoom;
                    Zoom.performed += instance.OnZoom;
                    Zoom.canceled += instance.OnZoom;
                    GenerateWind.started += instance.OnGenerateWind;
                    GenerateWind.performed += instance.OnGenerateWind;
                    GenerateWind.canceled += instance.OnGenerateWind;
                    MousePositionX.started += instance.OnMousePositionX;
                    MousePositionX.performed += instance.OnMousePositionX;
                    MousePositionX.canceled += instance.OnMousePositionX;
                    MousePositionY.started += instance.OnMousePositionY;
                    MousePositionY.performed += instance.OnMousePositionY;
                    MousePositionY.canceled += instance.OnMousePositionY;
                    GenerateTyphoon.started += instance.OnGenerateTyphoon;
                    GenerateTyphoon.performed += instance.OnGenerateTyphoon;
                    GenerateTyphoon.canceled += instance.OnGenerateTyphoon;
                }
            }
        }
        public GameActions @Game => new GameActions(this);
        public interface IGameActions
        {
            void OnRotationTrigger(InputAction.CallbackContext context);
            void OnRotationX(InputAction.CallbackContext context);
            void OnRotationY(InputAction.CallbackContext context);
            void OnZoom(InputAction.CallbackContext context);
            void OnGenerateWind(InputAction.CallbackContext context);
            void OnMousePositionX(InputAction.CallbackContext context);
            void OnMousePositionY(InputAction.CallbackContext context);
            void OnGenerateTyphoon(InputAction.CallbackContext context);
        }
    }
}
