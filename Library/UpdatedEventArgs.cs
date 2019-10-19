using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public enum Action { ADD, EDIT, REMOVE }
    class UpdatedEventArgs : EventArgs
    {
        private Action Action { get; set; }
        private DateTime UpdateTime { get; set; }
        public UpdatedEventArgs(Action action, DateTime updateTime)
        {
            Action = action;
            UpdateTime = updateTime;
        }
    }
}
