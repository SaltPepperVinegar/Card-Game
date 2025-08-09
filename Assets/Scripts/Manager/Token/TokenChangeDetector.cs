using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

    public class TokenChangeDetector : MonoBehaviour
    {
        public UnityEvent OnTokenChange;
        TokenManager tokenManager;

        void Start()
        {
            tokenManager = TokenManager.Instance;
            if (tokenManager != null)
            {
                tokenManager.OnTokenChange += HandleCurrencyChanged;
            }
        }

        void OnDestroy()
        {
            if (tokenManager != null)
            {
                tokenManager.OnTokenChange -= HandleCurrencyChanged;
            }
        }

        void HandleCurrencyChanged(int playerId)
        {
            OnTokenChange?.Invoke();
        }
    }