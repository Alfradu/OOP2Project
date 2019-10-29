using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Services
{
    /// <summary>
    /// Service for handling member-related queries.
    /// </summary>
    class MemberService : IService
    {
        MemberRepository memberRepository;

        /// <summary>
        /// Allows services to notify when their underlying data model changes.
        /// </summary>
        public event EventHandler<UpdatedEventArgs> Updated;

        /// <param name="rFactory">A repository factory, so the service can create its own repository.</param>
        public MemberService(RepositoryFactory rFactory) => memberRepository = rFactory.CreateMemberRepository();
        
        /// <returns>Returns all members.</returns>
        public IEnumerable<Member> All() => memberRepository.All();

        /// <summary>
        /// Sorts given list by id ascending.
        /// </summary>
        /// <param name="list">List of items to be sorted.</param>
        /// <returns>Returns a sorted IEnumerable.</returns>
        public IEnumerable<Member> SortIdAsc(List<Member> list) => list.OrderBy(o => o.Id);

        /// <summary>
        /// Sorts given list by id descending.
        /// </summary>
        /// <param name="list">List of items to be sorted.</param>
        /// <returns>Returns a sorted IEnumerable.</returns>
        public IEnumerable<Member> SortIdDesc(List<Member> list) => list.OrderByDescending(o => o.Id);

        /// <summary>
        /// Sorts given list by text ascending.
        /// </summary>
        /// <param name="list">List of items to be sorted.</param>
        /// <returns>Returns a sorted IEnumerable.</returns>
        public IEnumerable<Member> SortTextAsc(List<Member> list) => list.OrderBy(o => o.Name);

        /// <summary>
        /// Sorts given list by text descending.
        /// </summary>
        /// <param name="list">List of items to be sorted.</param>
        /// <returns>Returns a sorted IEnumerable.</returns>
        public IEnumerable<Member> SortTextDesc(List<Member> list) => list.OrderByDescending(o => o.Name);

        /// <summary>
        /// The Edit method makes sure that the given Member object is saved to the database and raises the Updated() event.
        /// </summary>
        /// <param name="b">Member item to be edited (Saved).</param>
        public void Edit(Member b)
        {
            memberRepository.Edit(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.EDIT, DateTime.Now));
        }

        /// <summary>
        /// The Add method saves a new Member object to the db and raises the Updated() event.
        /// </summary>
        /// <param name="b">Member item to be added.</param>
        public void Add(Member b)
        {
            memberRepository.Add(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.ADD, DateTime.Now));
        }

        /// <summary>
        /// The Remove method removes a given book object in the db and raises the Updated() event.
        /// </summary>
        /// <param name="b">Member item to be removed.</param>
        public void Remove(Member b)
        {
            memberRepository.Remove(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.REMOVE, DateTime.Now));
        }

        /// <summary>
        /// Rollback db to ignore uncommitted changes.
        /// </summary>
        public void Reset()
        {
            memberRepository.Reset();
        }

        /// <summary>
        /// Invoke Updated event to listeners with arguments.
        /// </summary>
        /// <param name="uea">UpdatedEventArgs describing db action and time.</param>
        private void OnUpdateEvent(UpdatedEventArgs uea) => Updated?.Invoke(this, uea);
    }
}
