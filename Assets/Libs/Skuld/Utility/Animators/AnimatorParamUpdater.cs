using System;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;

namespace Skuld.Utility.Animators
{
    public sealed class AnimatorParamUpdater<T> where T : struct
    {
        public sealed class InvalidGetTypeException : System.Exception
        {
            public T Value { get; set; }

            public InvalidGetTypeException(T value)
            {
                Value = value;
            }
        }

        public sealed class InvalidEnumDefinitionException : System.Exception
        {
            public InvalidEnumDefinitionException(string message) : base(message) { }
        }

        public sealed class InvalidParamAccesException : System.Exception
        {
            public InvalidParamAccesException(string message) : base(message) { }
        }

        struct ID
        {
            public int Value;
            public AnimatorControllerParameterType Type;
        }

        private Animator _animator;
        private ID[] _idList;

        public void Initialize(Animator animator)
        {
            _animator = animator;

            CheckEnumDefinition();

            var enumType = typeof(T);
            var parameters = _animator.parameters;
            _idList = new ID[Enum.GetNames(enumType).Length];
            foreach (var index in Enum.GetValues(enumType))
            {
                var parameter = parameters[(int)index];
                _idList[(int)index].Value = Animator.StringToHash(Enum.GetName(enumType, index));
                _idList[(int)index].Type = parameter.type;
            }
        }

        [Conditional("UNITY_EDITOR")]
        private void CheckEnumDefinition()
        {
            var enumType = typeof(T);
            var enumNames = Enum.GetNames(enumType);

            // Counter check
            if (enumNames.Length != _animator.parameterCount)
            {
                throw new InvalidEnumDefinitionException($"[Counter check failed] Enum:{enumNames.Length} vs Animator:{_animator.parameterCount}");
            }

            // Duplicate check
            var list = new List<int>(enumNames.Length);
            foreach (var index in Enum.GetValues(enumType))
            {
                var item = Convert.ToInt32(index);
                if (list.Contains(item))
                {
                    throw new InvalidEnumDefinitionException($"[Duplicate check failed] value:{item}");
                }
                else
                {
                    list.Add(item);
                }
            }

            // Divergence check
            for(int i = 0; i < enumNames.Length; ++i)
            {
                if (enumNames[i] != _animator.parameters[i].name)
                {
                    throw new InvalidEnumDefinitionException($"[Divergence check failed] Enum:{enumNames[i]} vs Animator:{_animator.parameters[i].name}");
                }
            }
        }

        public void Set(T index, bool value)
        {
            _animator.SetBool(ToID(index, AnimatorControllerParameterType.Bool), value);
        }

        public void Set(T index, int value)
        {
            _animator.SetInteger(ToID(index, AnimatorControllerParameterType.Int), value);
        }

        public void Set(T index, float value)
        {
            _animator.SetFloat(ToID(index, AnimatorControllerParameterType.Float), value);
        }

        public void Trigger(T index)
        {
            _animator.SetTrigger(ToID(index, AnimatorControllerParameterType.Trigger));
        }

        public void Reset(T index)
        {
            _animator.ResetTrigger(ToID(index, AnimatorControllerParameterType.Trigger));
        }

        public U Get<U>(T index)
        {
            if (typeof(U) == typeof(bool))
            {
                return (U)(object)(_animator.GetBool(ToID(index, AnimatorControllerParameterType.Bool, AnimatorControllerParameterType.Trigger)));
            }
            if (typeof(U) == typeof(int))
            {
                return (U)(object)(_animator.GetInteger(ToID(index, AnimatorControllerParameterType.Int)));
            }
            if (typeof(U) == typeof(float))
            {
                return (U)(object)(_animator.GetFloat(ToID(index, AnimatorControllerParameterType.Float)));
            }

            throw new InvalidGetTypeException(index);
        }

        private int ToID(T index, AnimatorControllerParameterType requiredType)
        {
            var id = _idList[Convert.ToInt32(index)];
            if (id.Type != requiredType)
            {
                throw new InvalidEnumDefinitionException($"Invalid required type:{requiredType.ToString()}, because \"{Enum.GetNames(typeof(T))[Convert.ToInt32(index)]}\" is {id.Type.ToString()}.");
            }
            return id.Value;
        }

        private int ToID(T index, AnimatorControllerParameterType requiredType, AnimatorControllerParameterType requiredType2)
        {
            var id = _idList[Convert.ToInt32(index)];
            if (id.Type != requiredType && id.Type != requiredType2)
            {
                throw new InvalidEnumDefinitionException($"Invalid required type:{requiredType.ToString()} or {requiredType2.ToString()}, because \"{Enum.GetNames(typeof(T))[Convert.ToInt32(index)]}\" is {id.Type.ToString()}.");
            }
            return id.Value;
        }
    }
}
