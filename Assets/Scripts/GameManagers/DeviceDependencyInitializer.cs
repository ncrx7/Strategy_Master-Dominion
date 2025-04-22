using UnityEngine;
using VillageSceneUI;

namespace GameManagers.Device
{
    public class DeviceDependencyInitializer : MonoBehaviour
    {
        public Enums.DeviceType deviceType;

        private void OnEnable()
        {
            GameEventHandler.OnVillageSceneStart += Initialize;
        }

        private void OnDisable()
        {
            GameEventHandler.OnVillageSceneStart -= Initialize;
        }

        private void Initialize()
        {
            switch (deviceType)
            {
                case Enums.DeviceType.PC:
                    VillageSceneUIManager.Instance.SetPanel(Enums.GamePanelType.JoyStickPanel, false);
                    break;
                case Enums.DeviceType.Mobile:
                    VillageSceneUIManager.Instance.SetPanel(Enums.GamePanelType.JoyStickPanel, true);
                    break;
                default:
                    Debug.LogWarning("Undefined Device Type!!");
                    break;
            }
        }
    }
}
