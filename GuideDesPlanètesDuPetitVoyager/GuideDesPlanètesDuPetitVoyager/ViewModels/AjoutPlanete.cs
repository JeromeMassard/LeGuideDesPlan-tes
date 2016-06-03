using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuideDesPlanètesDuPetitVoyager.Event;

namespace GuideDesPlanètesDuPetitVoyager.ViewModels
{
    public class AjoutPlanete : NotifyPropertyChangedBase
    {
        public DelegateCommande OnAddNew { get; set; }
        public DelegateCommande OnCancel { get; set; }
        public DelegateCommande OnModify { get; set; }

        public bool CLickOnAdd = false;

        public Planete Planete { get; set; }

        public AjoutPlanete(Planete _planete)
        {
            OnAddNew = new DelegateCommande(OnAddAction, CanAdd);
            OnCancel = new DelegateCommande(OnCancelCommand, CanCancel);
            OnModify = new DelegateCommande(OnModifyAction, CanModify);
            Planete = _planete;
        }

        #region Add

        private void OnAddAction(object obj)
        {
            CLickOnAdd = true;

            EventClick.GetClick().OnButtonPressedHandler(EventArgs.Empty);
        }
        private bool CanAdd(object obj)
        {
            return true;
        }
        #endregion

        #region Cancel
        private void OnCancelCommand(object obj)
        {
             EventClick.GetClick().OnButtonPressedHandler(EventArgs.Empty);
        }



        private bool CanCancel(object obj)
        {
            return true;
        }
        #endregion

        #region Modify

        private void OnModifyAction(object obj)
        {
            CLickOnAdd = true;

            EventClick.GetClick().OnButtonPressedHandler(EventArgs.Empty);
        }
        private bool CanModify(object obj)
        {

            return true;
        }
        #endregion

    }
}
