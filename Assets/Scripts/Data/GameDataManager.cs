using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Data.Scriptable.Heroes;
using UnityEngine;
using UnityUtils.BaseClasses;
using UnityUtils.Core.DataManagment;

namespace Data
{
    public class GameDataManager : SingletonBehavior<GameDataManager>
    {
        [SerializeField] private List<FixedHeroData> _fixedHeroDataList;
        [SerializeField] PlayerData _playerData;
        DataWriterAndReader<PlayerData> _dataWriterAndReader;
        public bool IsDataLoadFinished = false;

        protected void Awake()
        {
            base.Awake();

            transform.parent = null;

            DontDestroyOnLoad(gameObject);

            _dataWriterAndReader = new DataWriterAndReader<PlayerData>(Application.persistentDataPath, "Player_Data");
        }

        private void Start()
        {
            InitializeData();
        }

        private async void InitializeData()
        {
            await LoadPlayerDataFile();
            await LoadHeroFixedData();

            IsDataLoadFinished = true;
            GameEventHandler.OnCompleteGameDataLoad?.Invoke(_playerData);
        }

        private async UniTask LoadPlayerDataFile()
        {
            _playerData = await _dataWriterAndReader.InitializeDataFile(CreateNewPlayerDataObject);

/*             Debug.Log("Current Level Setted -> Level - " + _playerData.CurrentLevel);
            Debug.Log("Default Heroes Setted -> Hero 0 HP - " + _playerData.Heroes[0].HpStat);
            Debug.Log("Default Gold Amount Setted -> Gold Amount - " + _playerData.GoldAmount); */
        }

        private async UniTask LoadHeroFixedData()
        {
            foreach (var hero in _playerData.Heroes)
            {
                hero.FixedHeroData = _fixedHeroDataList.FirstOrDefault(fixedHeroData => fixedHeroData.HeroId == hero.HeroId);
            }

            await UniTask.Delay(1000);
        }

        public void UpdatePlayerDataFile()
        {
            _dataWriterAndReader.UpdateDataFile(_playerData);
        }

        public PlayerData CreateNewPlayerDataObject()
        {
            DynamicHeroData _starterHero = new DynamicHeroData(1, 100, 20, 5, 10);
            PlayerData playerStats = new PlayerData(1, new List<DynamicHeroData>() { _starterHero }, 0, 0, true, 0);
            return playerStats;
        }

        public PlayerData GetPlayerDataObjectReference()
        {
            return _playerData;
        }

        public void SetPlayerDataObjectReference(PlayerData playerStats)
        {
            _playerData = playerStats;
        }
    }
}
