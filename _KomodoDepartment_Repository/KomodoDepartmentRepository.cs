using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _KomodoDepartment_Repository
{
    public class KomodoDepartmentRepository
    {
        private Queue<KomodoDepartment> _listOfClaim = new Queue<KomodoDepartment>();

        //CREATE
        public void  AddClaimToList(KomodoDepartment claim)
        {
            if (claim != null)
            {

              _listOfClaim.Enqueue(claim);
            }
        }


        //READ
        public Queue<KomodoDepartment> GetClaimList()
        {
            return _listOfClaim;
        }


        //to pull the claim out of the queue
        public void pullTopClaim()
        {
            _listOfClaim.Dequeue();
        }

       
        //look at the top claim without taking it out 
        public KomodoDepartment ViewNextClaim()
        {
            return _listOfClaim.Peek();
        }
        
    }

}
