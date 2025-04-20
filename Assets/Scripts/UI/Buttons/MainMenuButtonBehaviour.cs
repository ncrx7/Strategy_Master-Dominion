using UnityEngine;

namespace UI.Buttons
{
    public class MainMenuButtonBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject _buttonObject;

        private void SetScale()
        {
            _buttonObject.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        }
    }
}
