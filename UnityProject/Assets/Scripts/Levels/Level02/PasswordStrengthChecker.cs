using UnityEngine;
using System.Text.RegularExpressions;

namespace CyberSec
{
    public class PasswordStrengthChecker : MonoBehaviour
    {
        public PasswordResult EvaluatePassword(string password)
        {
            var result = new PasswordResult();
            int score = 0;

            // Length
            if (password.Length >= 8) score += 15;
            if (password.Length >= 12) score += 15;
            if (password.Length >= 16) score += 10;

            // Character variety
            if (Regex.IsMatch(password, "[a-z]")) score += 10;
            if (Regex.IsMatch(password, "[A-Z]")) score += 10;
            if (Regex.IsMatch(password, "[0-9]")) score += 10;
            if (Regex.IsMatch(password, @"[!@#$%^&*(),.?""{}|<>]")) score += 15;

            // Penalties
            if (Regex.IsMatch(password.ToLower(), @"(password|123456|qwerty|abc123|admin)")) score -= 30;
            if (Regex.IsMatch(password, @"(.)\1{2,}")) score -= 10; // repeated chars
            if (password.Length < 6) score -= 20;

            score = Mathf.Clamp(score, 0, 100);
            result.score = score;

            if (score >= 80) { result.label = "STRONG"; result.color = Color.green; result.tip = "Excellent!"; }
            else if (score >= 60) { result.label = "MODERATE"; result.color = Color.yellow; result.tip = "Add special characters or make it longer."; }
            else if (score >= 30) { result.label = "WEAK"; result.color = new Color(1f, 0.5f, 0f); result.tip = "Use a mix of uppercase, lowercase, numbers, and symbols."; }
            else { result.label = "VERY WEAK"; result.color = Color.red; result.tip = "Avoid common words and short passwords."; }

            return result;
        }
    }

    [System.Serializable]
    public class PasswordResult
    {
        public int score;
        public string label;
        public Color color;
        public string tip;
    }
}
