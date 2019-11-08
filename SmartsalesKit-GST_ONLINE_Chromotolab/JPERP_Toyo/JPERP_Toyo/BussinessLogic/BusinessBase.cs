using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Account.BusinessLogic
{
    class BusinessBase
    {
        #region "Private Fields"
        private string mErrorMessage = "";
        private Exception mException = null;

        #endregion

        #region "Public Properties ..."

        public string ErrorMessage
        {
            get
            { return mErrorMessage; }
            set
            { mErrorMessage = value; }
        }

        public Exception Exception
        {
            get
            { return mException; }
            set
            { mException = value; }
        }

        #endregion 
    }
}
