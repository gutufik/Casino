using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public partial class CasinoEntities
    {
        private CasinoEntities _context;
        public CasinoEntities GetContext()
        {
            if (_context == null)
                _context = new CasinoEntities();
            return _context;
        }
    }
}
