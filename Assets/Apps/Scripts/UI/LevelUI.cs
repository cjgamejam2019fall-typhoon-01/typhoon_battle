using UnityEngine;
using UnityEngine.UI;

namespace Apps.UI
{
    public class LevelUI : MonoBehaviour
    {
        public Text Text = null;

        void Start()
        {
            Text.text = "";
        }

        void Update()
        {
            Text.text = "";
            var cities = GameSystem.GameManager.Level.TargetCities;
            foreach (var city in cities)
            {
                string line = string.Format($"{city.Name} ({(int)city.Health}/{(int)city.MaxHealth})") + "\n";
                Text.text += line;
            }
        }
    }
}
