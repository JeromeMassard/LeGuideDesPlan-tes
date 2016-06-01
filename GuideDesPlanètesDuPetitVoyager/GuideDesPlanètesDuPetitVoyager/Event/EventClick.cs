using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideDesPlanètesDuPetitVoyager.Event
{
    public class EventClick
    {
        #region singleton
        private static EventClick _click { get; set; }
        private EventClick() { }
        public static EventClick GetClick()
        {
            if(_click == null)
            {
                _click = new EventClick();
            }
            return _click;
        }
        #endregion  

        public event EventHandler Handler;

        public void OnButtonPressedHandler(EventArgs e)
        {
            if (Handler != null)
            {
                Handler(this, e);
            }
        }
    }
}
