using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Account.Common
{
    class Constant
    {
        public enum Mode
        {
            Insert = 1,
            View = 2,
            Modify = 3,
            Delete = 4,
            Copy = 5,
            QCInsert=6,
            QCUpdate = 7,
            SCInsert = 8,
            SCUpdate = 9,
            SECInsert = 10,
            SECUpdate = 11
        }

        public enum PRNPriority
        {
            Normal = 1,
            Urgent = 2,
            MostUrgent = 3
        }

        public enum DocumentStatus
        {
            
            Received = 0,
            Send = 1
        }

        public enum FollowUpMode
        {
            Phone  = 100,  
			Fax = 200,   
			Mail = 300, 
			Email = 400, 
			Other = 1000 
        }

    }
}
