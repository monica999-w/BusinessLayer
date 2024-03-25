using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Data
    {
        //var nt = new List<string> {"MVC4", "Node.js", "CouchDB", "KendoUI", "Dapper", "Angular"};
        private readonly List<string> _ot;

        //DEFECT #5274 DA 12/10/2012
        //We weren't filtering out the prodigy domain so I added it.
        private readonly List<string> _domains;

        //put list of employers in array
        private readonly List<string> _emps;
        public Data()
        {
            this._ot = new List<string>() { "Cobol", "Punch Cards", "Commodore", "VBScript" };
            this._domains = new List<string>() { "aol.com", "hotmail.com", "prodigy.com", "CompuServe.com" };
            this._emps = new List<string>() { "Microsoft", "Google", "Fog Creek Software", "37Signals" };
        }

        public List<string> Ot => this._ot;

        public List<string> Domains => this._domains;

        public List<string> Emps => this._emps;
    }
}

