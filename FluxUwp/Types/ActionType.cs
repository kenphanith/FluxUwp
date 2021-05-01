using System;

namespace FluxUwp.Types
{
    public struct ActionType<Action> where Action: Enum
    {
        #region Members
        public Action _action { get; set; }
        public dynamic param { get; set; }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="action"></param>
        /// <param name="param"></param>
        public ActionType(Action action, dynamic param = null)
        {
            this._action = action;
            this.param = param;
        }
    }
}
