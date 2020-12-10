using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Security
{
    /// <summary>
    /// Implementacion de reglas de autorizacion
    /// </summary>
    public class GnericAccessAuthorizer : IAccessAuthorizer
    {
        private readonly List<IAccessRule> _accessRules = new List<IAccessRule>();

        
        public GnericAccessAuthorizer(List<IAccessRule> accessRules)
        {
            _accessRules = accessRules;
        }

        public void AppendAccessRule(IAccessRule rule)
        {
            Guard.AgainstArgumentNull(rule, "rule");
            if (!Contains(rule))
                _accessRules.Add(rule);
            else
                throw new ArgumentException(string.Format("Rule '{0}' is already added", rule.GetType()));
        }

        public void CheckRules(string username)
        {
            foreach (var rule in _accessRules)
                rule.CheckRule(username);
        }

        public int RuleAccessCount
        {
            get { return _accessRules.Count; }
        }

        private bool Contains(IAccessRule rule)
        {
            return _accessRules.SingleOrDefault(x => x.GetType() == rule.GetType()) != null;
        }

         
    }
}
