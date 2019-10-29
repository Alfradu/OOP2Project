using System;

namespace Library.Services
{
    /// <summary>
    /// Allows services to notify when their underlying data model changes.
    /// </summary>
    interface IService {
        event EventHandler<UpdatedEventArgs> Updated;
    }
}
