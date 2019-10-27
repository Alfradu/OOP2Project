using System;

namespace Library
{
    /// <summary>
    /// Defines what database action an event fires.
    /// </summary>
    public enum Action { ADD, EDIT, REMOVE }

    /// <summary>
    /// Event arguments for database actions.
    /// </summary>
    class UpdatedEventArgs : EventArgs
    {
        public Action Action { get; set; }
        public DateTime UpdateTime { get; set; }
        public UpdatedEventArgs(Action action, DateTime updateTime)
        {
            Action = action;
            UpdateTime = updateTime;
        }
    }
}
