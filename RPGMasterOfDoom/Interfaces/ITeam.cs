using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMasterOfDoom
{
    interface ITeam<T>
    {
        /// <summary>
        /// Returns the list of members.
        /// </summary>
        /// <returns></returns>
        List<T> Members();
    }
}
