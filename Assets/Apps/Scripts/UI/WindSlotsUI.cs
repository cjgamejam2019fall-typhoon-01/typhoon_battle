using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Apps.UI
{
    public class WindSlotsUI : MonoBehaviour
    {
        public List<WindSlotImageUI> ImageList = new List<WindSlotImageUI>();

        public class WindSlotInfo
        {
            public WindSlotImageUI UI = null;
            public Image Image = null;
            public Actor.Wind.WindSource source = null;
            public WindSlotRingUI ring = null;

            public WindSlotInfo(WindSlotImageUI ui, Image image)
            {
                UI = ui;
                Image = image;
                ring = ui.GetComponentInChildren<WindSlotRingUI>();
            }
        }

        public List<WindSlotInfo> WindSlotInfoList = new List<WindSlotInfo>();

        private void Awake()
        {
            UIManager.WindSlotsUI = this;
        }

        void Start()
        {
            // 一旦消す
            foreach (var image in ImageList)
            {
                image.gameObject.SetActive(false);
                image.enabled = false;
            }

            // 集める
            var num = GameSystem.GameManager.Level.MaxWindSlotNum;
            for (uint i = 0; i < num; ++i)
            {
                var wsimage = ImageList[(int)i];
                wsimage.gameObject.SetActive(true);
                var info = new WindSlotInfo(wsimage, wsimage.GetComponent<Image>());
                WindSlotInfoList.Add(info);
            }
            WindSlotInfoList.Reverse();
        }

        void Update()
        {
            foreach (var info in WindSlotInfoList)
            {
                if (info.UI.IsUse)
                {
                    var rate = 1.0f - (info.source.CurrentLife/info.source.Life);
                    info.Image.fillAmount = rate;
                    if (rate >= 1)
                    {
                        info.Image.fillAmount = 1;
                        info.UI.IsUse = false;
                        info.source = null;
                        info.ring.StartAnimation();
                    }
                }
            }
        }
    }
}
