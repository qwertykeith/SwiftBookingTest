using SwiftBookingTest.Model.Client.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Model.Client
{
    public abstract class BaseViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        private byte[] _rowVersion;

        [HiddenInput]
        public byte[] RowVersion
        {
            get
            {
                return _rowVersion;
            }
            set
            {
                _rowVersion = value;
            }
        }

    }
}
