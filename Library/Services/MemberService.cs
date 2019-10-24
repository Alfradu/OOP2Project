using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    class MemberService : IService
    {
        MemberRepository memberRepository;
        public event EventHandler<UpdatedEventArgs> Updated;

        public MemberService(RepositoryFactory rFactory)
        {
            this.memberRepository = rFactory.CreateMemberRepository();
        }

        public IEnumerable<Member> All()
        {
            return memberRepository.All();
        }

        internal List<Member> sortIdAsc(List<Member> list)
        {
            return list.OrderBy(o => o.Id).ToList();
        }

        internal List<Member> sortIdDesc(List<Member> list)
        {
            return list.OrderByDescending(o => o.Id).ToList();
        }

        internal List<Member> sortTextAsc(List<Member> list)
        {
            return list.OrderBy(o => o.Name).ToList();
        }

        internal List<Member> sortTextDesc(List<Member> list)
        {
            return list.OrderByDescending(o => o.Name).ToList();
        }

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

        private void OnUpdateEvent(UpdatedEventArgs uea) => Updated?.Invoke(this, uea);
    }
}
