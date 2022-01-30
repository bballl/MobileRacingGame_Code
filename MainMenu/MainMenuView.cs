using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] 
        private Button _buttonStart;

        [SerializeField]
        private Button _buttonDailyReward;

        [SerializeField]
        private Button _buttonExit;

        public void Init(UnityAction startGame, UnityAction watchDailyReward)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonDailyReward.onClick.AddListener(watchDailyReward);
            _buttonExit.onClick.AddListener(Exit);
        }

        protected void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonExit.onClick.RemoveAllListeners();
            _buttonDailyReward.onClick.RemoveAllListeners();
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}

