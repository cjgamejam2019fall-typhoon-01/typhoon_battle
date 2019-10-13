using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apps.Controller
{
    public class WindGenerator : TapGenerator
    {
        protected override bool CanGenerate(RaycastHit hit)
        {
            var infoList = UI.UIManager.WindSlotsUI.WindSlotInfoList;
            foreach(var info in infoList)
            {
                if (!info.UI.IsUse)
                {
                    return true;
                }
            }
            return false;
        }

        protected override void OnGenerated(GameObject result)
        {
            var infoList = UI.UIManager.WindSlotsUI.WindSlotInfoList;
            foreach(var info in infoList)
            {
                if (!info.UI.IsUse)
                {
                    info.UI.IsUse = true;
                    info.Image.fillAmount = 0f;
                    info.source = result.GetComponent<Actor.Wind.WindSource>();
                    break;
                }
            }
        }
    }
}
