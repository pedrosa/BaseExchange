using Microsoft.Extensions.Logging;

namespace BaseExchange.OrderGenerator.Infrastructure.Fix
{
    public class FixApplication : QuickFix.MessageCracker, QuickFix.IApplication
    {
        private readonly ILogger<FixApplication> _logger;
        private QuickFix.Session _session;

        public FixApplication(ILogger<FixApplication> logger)
        {
            _logger = logger;
        }

        public void OnCreate(QuickFix.SessionID sessionID)
        {
            _logger.LogInformation($"Session created: {sessionID}");
        }

        public void OnLogon(QuickFix.SessionID sessionID)
        {
            _logger.LogInformation($"Logon - {sessionID}");
            _session = QuickFix.Session.LookupSession(sessionID);
        }

        public void OnLogout(QuickFix.SessionID sessionID)
        {
            _logger.LogInformation($"Logout - {sessionID}");
            _session = null;
        }

        public void FromAdmin(QuickFix.Message message, QuickFix.SessionID sessionID)
        {
            // Handle admin messages
        }

        public void FromApp(QuickFix.Message message, QuickFix.SessionID sessionID)
        {
            _logger.LogInformation($"FromApp - {message}");
            Crack(message, sessionID);
        }

        public void ToAdmin(QuickFix.Message message, QuickFix.SessionID sessionID)
        {
            // Handle admin messages
        }

        public void ToApp(QuickFix.Message message, QuickFix.SessionID sessionID)
        {
            _logger.LogInformation($"ToApp - {message}");
        }
    }
}