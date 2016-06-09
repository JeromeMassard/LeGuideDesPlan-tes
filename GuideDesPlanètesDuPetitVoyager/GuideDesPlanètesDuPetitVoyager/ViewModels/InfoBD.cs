using GuideDesPlanètesDuPetitVoyager.Event;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideDesPlanètesDuPetitVoyager.ViewModels
{
    public class InfoBD : NotifyPropertyChangedBase
    {

        public DelegateCommande ClickOk { get; set; }
        public DelegateCommande ClickYes { get; set; }
        public DelegateCommande ClickNo { get; set; }


        public bool _valid { get; set; }


        public InfoBD()
        {
               
            ClickYes = new DelegateCommande(OnYesAction, CanYes);
            ClickNo = new DelegateCommande(OnNoAction, CanNo);
        }


        #region Yes
        private void OnYesAction(object obj)
        {
            _valid = true;
            EventClick.GetClick().OnButtonPressedHandler(EventArgs.Empty);
        }



        private bool CanYes(object obj)
        {
            return true;
        }
    #endregion
    #region No

    private void OnNoAction(object obj)
    {
        EventClick.GetClick().OnButtonPressedHandler(EventArgs.Empty);
    }



    private bool CanNo(object obj)
    {
        return true;
    }
    #endregion
}
}
