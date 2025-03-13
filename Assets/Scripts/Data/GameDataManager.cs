using System.Collections.Generic;
using UnityEngine;
using UnityUtils.BaseClasses;

namespace Data
{
    public class GameDataManager : SingletonBehavior<GameDataManager>
    {
        PlayerData _playerData;
        DataWriterAndReader<PlayerData> _dataWriterAndReader;

        private void Awake()
        {
            transform.parent = null;

            DontDestroyOnLoad(gameObject);

            _dataWriterAndReader = new DataWriterAndReader<PlayerData>(Application.persistentDataPath, "Player_Data");
        }

        private void Start()
        {
            InitializePlayerDataFile();
        }

        public void InitializePlayerDataFile()
        {
            _playerData = _dataWriterAndReader.InitializeDataFile();

            Debug.Log("Current Level Setted -> Level - " + _playerData.CurrentLevel);
            Debug.Log("Default Heroes Setted -> Hero ID - " + _playerData.HeroesIds[0]);
            Debug.Log("Default Gold Amount Setted -> Hero ID - " + _playerData.GoldAmount);
        }

        public void UpdatePlayerDataFile()
        {
            _dataWriterAndReader.UpdateDataFile(_playerData);
        }

        public PlayerData CreateNewPlayerDataObject()
        {
            PlayerData playerStats = new PlayerData(1, new List<int>() { 0 }, 0, 0);
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
