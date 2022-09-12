using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Models
{
    public enum OrderStatus
    {
        New,
        CanceledBytheAdministrator,
        PaymentReceived,
        Sent,
        Received,
        Completed,
        CanceledByUser,
    }
}
