using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizfy_LKS.Helpers
{
    /// <summary>
    /// Lightweight session & validation helper for the WinForms app.
    /// - Holds current user id/name (in-memory).
    /// - Provides email regex validation and simple form/input helpers.
    /// - Provides SignIn/SignOut and a SignedOut event.
    /// </summary>
    internal class Authentication
    {
        private static readonly object _lock = new object();
        private static int _userId;
        private static char? _role;
        private static string _userName;

        public static int UserId
        {
            get { lock (_lock) return _userId; }
        }

        public static char? UserRole
        {
            get { lock (_lock) return _role; }
        }

        public static string UserName
        {
            get { lock (_lock) return _userName; }
        }

        public static bool IsAuthenticated
        {
            get { lock (_lock) { return _userId != 0; } }
        }

        /// <summary>
        /// Sign the session in (store id and full name).
        /// </summary>
        public static void SignIn(int id, char role, string fullName)
        {
            if (id <= 0)
                throw new ArgumentException("id must be positive", nameof(id));

            lock (_lock)
            {
                _userId = id;
                _role = role;
                _userName = fullName ?? string.Empty;
            }
        }

        /// <summary>
        /// Sign the session out and raise the SignedOut event.
        /// </summary>
        public static void SignOut()
        {
            lock (_lock)
            {
                _userId = 0;
                _role = null;
                _userName = null;
            }

            SignedOut?.Invoke(null, EventArgs.Empty);
        }

        /// <summary>
        /// Raised after SignOut is called.
        /// Subscribe to this to react to logout (for example show login form).
        /// </summary>
        public static event EventHandler SignedOut;

        /// <summary>
        /// Simple email validation (safe, readable regex for typical addresses).
        /// Returns true for a basic valid email format.
        /// </summary>
        public static bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            const string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Validate the email and password TextBox controls and return trimmed credentials.
        /// Shows friendly MessageBoxes and focuses invalid control.
        /// Returns true when credentials are valid (not empty + valid email format).
        /// </summary>
        public static bool TryGetCredentials(TextBox emailBox, TextBox passwordBox, out string email, out string password)
        {
            email = emailBox?.Text?.Trim() ?? string.Empty;
            password = passwordBox?.Text ?? string.Empty;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Lengkapi Data Anda", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (string.IsNullOrEmpty(email)) emailBox?.Focus(); else passwordBox?.Focus();
                return false;
            }

            if (!ValidateEmail(email))
            {
                MessageBox.Show("Email tidak valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                emailBox?.Focus();
                return false;
            }

            return true;
        }
    }
}
