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
        public event EventHandler<UpdatedEventArgs> Updated;

        public MemberService(RepositoryFactory rFactory) => memberRepository = rFactory.CreateMemberRepository();

        public IEnumerable<Member> All() => memberRepository.All();

        public IEnumerable<Member> SortIdAsc(List<Member> list) => list.OrderBy(o => o.Id);

        public IEnumerable<Member> SortIdDesc(List<Member> list) => list.OrderByDescending(o => o.Id);

        public IEnumerable<Member> SortTextAsc(List<Member> list) => list.OrderBy(o => o.Name);

        public IEnumerable<Member> SortTextDesc(List<Member> list) => list.OrderByDescending(o => o.Name);

        /// <summary>
        /// The Edit method makes sure that the given Member object is saved to the database and raises the Updated() event.
        /// </summary>
        /// <param name="b"></param>
        public void Edit(Member b)
        {
            memberRepository.Edit(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.EDIT, DateTime.Now));
        }

        /// <summary>
        /// The Add method saves a new Member object to the db and raises the Updated() event.
        /// </summary>
        /// <param name="b"></param>
        public void Add(Member b)
        {
            memberRepository.Add(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.ADD, DateTime.Now));
        }

        /// <summary>
        /// The Remove method removes a given book object in the db and raises the Updated() event.
        /// </summary>
        /// <param name="b"></param>
        public void Remove(Member b)
        {
            memberRepository.Remove(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.REMOVE, DateTime.Now));
        }

        public void Reset()
        {
            memberRepository.Reset();
        }

        private void OnUpdateEvent(UpdatedEventArgs uea) => Updated?.Invoke(this, uea);
    }
}
