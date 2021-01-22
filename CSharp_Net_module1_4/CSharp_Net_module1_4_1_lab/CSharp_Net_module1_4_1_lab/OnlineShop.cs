using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_4_1_lab
{
    class OnlineShop
    {
        // 4) declare event of type EventHandler<GoodsInfoEventArgs>
        public event EventsHandler Startle;

        public delegate void EventsHandler(object sender, GoodsInfoEventArgs e);

        // 5) declare method NewGoods for event initiation
        // use parameter string to get GoodsName
        protected virtual void NewGoods(GoodsInfoEventArgs e)
        {
            EventsHandler handler = Startle;
            if (handler != null)
            {
                handler(this, new GoodsInfoEventArgs(e));
            }
        }
        // don't forget to check if event is not null
        // in true case intiate the event
        // use next line

        // your_event_name(this, new GoodsInfoEventArgs(GoodsName));

    }
}
