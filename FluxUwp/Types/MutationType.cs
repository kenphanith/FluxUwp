using System;

namespace FluxUwp.Types
{
    public struct MutationType<Mutation> where Mutation: Enum
    {
        #region Members
        public Mutation _mutation { get; set; }
        public dynamic param { get; set; }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mutation"></param>
        /// <param name="param"></param>
        public MutationType(Mutation mutation, dynamic param = null)
        {
            this._mutation = mutation;
            this.param = param;
        }
    }
}
