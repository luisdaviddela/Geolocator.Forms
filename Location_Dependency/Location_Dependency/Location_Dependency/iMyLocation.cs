using System;
using System.Collections.Generic;
using System.Text;

namespace Location_Dependency
{
    public interface iMyLocation
    {
        void ObtainMyLocation();
        event EventHandler<ILocationEventArgs> locationObtained;
    }
    public interface ILocationEventArgs
    {
        double lat { get; set; }
        double lng { get; set; }
    }
}
