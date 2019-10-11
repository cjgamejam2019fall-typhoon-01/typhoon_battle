using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Skuld.Utility.EditorControls
{
    public class Handles
    {
#if UNITY_EDITOR
        public static bool IsMovingByManipulator(GameObject target)
        {
            var isMoveTool = Tools.current == Tool.Move;
            var controlID = EditorGUIUtility.hotControl;
#if false
            // Move Toolハンドル（マニピュレータ）のControlIDを取得する手段がわからない
            var moveHandleID = ???;
            var isMoving = moveHandleID <= controlID && controlID <= moveHandleID+4;
#else
            var isMoving = controlID != 0;
#endif
            if (isMoveTool && isMoving)
            {
                var selected = Selection.gameObjects;
                foreach (var go in selected)
                {
                    if (go == target)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
#endif
    }
}
