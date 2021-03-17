using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_7_5_lab
{
    // 6) derive class ProductDBContext from DBContext
    class ProductDBContext
    {
        // 7) add constructor; use name of database as string parameter for base constructor invoking;
        // add to App.config file in <entityFramework>
                                        // <defaultConnectionFactory type=...
                                            // <parameters>
        // connection string: 
        //  <parameter value="data source=MyServer; Integrated Security=True;"/>
        // where "MyServer" - name of database server

        // 8) declare generic DBSets for all classes of database; they must be auto-properties

    }
}
