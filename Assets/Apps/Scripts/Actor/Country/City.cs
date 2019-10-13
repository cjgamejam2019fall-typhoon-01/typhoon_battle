using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apps.Actor.City
{
    public enum CityCode
    {
        Unknown,

        // 世界都市
        London,
        Newyork,
        Paris,
        Tokyo,
        HongKong,
        Singapore,

        // 東アジア
        Osaka,
        Nagoya,
        Beijing,
        Shanghai,
        Canton,
        Shenzhen,
        Chongqing,
        Taipei,
        Koahsiugn,
        Seoul,

        // 東南アジア
        Bangkok,
        KualaLumpur,
        Jakarta,
        Manila,
        HoChiMinh,

        // 南アジア
        Mumbai,
        Delhi,
        Calcutta,
        Chennai,
        Bangalore,
        Karachi,
        Lahore,

        // ヨーロッパ
        Berlin,
        Frankfurt,
        Munchen,
        Rome,
        Milan,
        Madrid,
        Barcelona,
        Zurich,
        Geneva,
        Amsterdam,
        Brussels,
        Dublin,
        Vienna,
        Stockholm,
        Copenhagen,
        Oslo,
        Lisbon,
        Praha,
        Moscow,
        Istanbul,

        // 北アメリカ
        LosAngeles,
        Chicago,
        Boston,
        Houston,
        Dallas,
        Miami,
        Atlanta,
        Seattle,
        Denver,
        Toronto,
        Montreal,
        Vancouver,
        Calgary,
        MexicoCity,

        // 南アメリカ
        SaoPaulo,
        RioDeJaneiro,
        BuenosAires,
        Bogota,
        Caracas,
        Lima,
        Santiago,
        Quito,
        Guayaquil,

        // 中東
        Dubai,
        AbuDhabi,
        TelAviv,
        Riyadh,
        Jiddah,
        Doha,

        // アフリカ
        Cairo,
        Johannesburg,
        CapeTown,
        Nairobi,
        Lagos,
        Casablanca,
        Tunis,
        AddisAbaba,
        Kinshasa,

        // オセアニア
        Sydney,
        Melbourne,
        Brisbane,
        Pers,
        Auckland,
        Wellington,
    }

    public class City : MonoBehaviour
    {
        public CityCode Code = CityCode.Unknown;
        public string Name = "";

        public bool IsTarget = false;
        private MeshRenderer _MeshRenderer = null;

        public float Health = 100f;
        public float MaxHealth = 100f;

        private void Awake()
        {
            MaxHealth = Health;
            _MeshRenderer = GetComponent<MeshRenderer>();
            SetTarget(false);
        }

        private void SetMeshRendererEnable(bool flag)
        {
            _MeshRenderer.enabled = false; // もう赤丸はいらんでしょ！
        }

        public void SetTarget(bool flag)
        {
            IsTarget = flag;
            SetMeshRendererEnable(flag);
        }

        public void EatDamage(float damage)
        {
            if (Health > 0)
            {
                Health = Mathf.Max(Health - damage, 0);
            }
        }


        void Start()
        {
        }

        void Update()
        {
            if (Health < 1)
            {
                GameSystem.GameManager.Level.BreakTarget(this);
                SetTarget(false);
            }
        }
    }
}
