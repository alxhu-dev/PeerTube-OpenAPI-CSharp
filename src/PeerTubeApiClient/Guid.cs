using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PeerTubeApiClient
{

    /// <summary>
    /// 
    /// </summary>
    public class Guid
    {
        /// <summary>
        /// Requirement for several build errors
        /// </summary>
        public readonly int Length = 36;
        private System.Guid _internalGuid;

        internal Guid() : this(System.Guid.Empty)
        {
        }

        internal Guid(System.Guid systemGuid)
        {
            _internalGuid = systemGuid;
        }

        public static implicit operator Guid(string s)
            => new Guid(System.Guid.TryParse(s, out System.Guid result) ? result : throw new Exception($"Can't parse Guid: {s}"));

        public static implicit operator Guid(System.Guid guid)
            => new Guid(guid);

        public static implicit operator System.Guid(Guid guid)
            => guid._internalGuid;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (ReferenceEquals(obj, null))
                return false;

            if (obj is Guid apiGuid)
                return _internalGuid.Equals(apiGuid._internalGuid);

            if (obj is System.Guid systemGuid)
                return _internalGuid.Equals(systemGuid);

            return false;
        }
    }
}
