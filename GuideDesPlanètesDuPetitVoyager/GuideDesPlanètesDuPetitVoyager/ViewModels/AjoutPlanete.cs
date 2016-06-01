using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuideDesPlanètesDuPetitVoyager.Event;

namespace GuideDesPlanètesDuPetitVoyager.ViewModels
{
    class AjoutPlanete
    {
        public DelegateCommande OnAddNew { get; set; }
        public DelegateCommande OnCancel { get; set; }

        public Planete Planete { get; set; }
        public AjoutPlanete(Planete _planete)
        {
            Planete = _planete;
            OnAddNew = new DelegateCommande(OnAddAction, CanExecuteAdd);
            OnCancel = new DelegateCommande(OnCancelCommand, CanCancelCommand);
        }

        private void OnAddAction(object obj)
        {

            EventClick.GetClick().OnButtonPressedHandler(EventArgs.Empty);
        }

        private void OnCancelCommand(object obj)
        {
            EventClick.GetClick().OnButtonPressedHandler(EventArgs.Empty);
        }

        private bool CanExecuteAdd(object obj)
        {
            
            return true;
        }

        private bool CanCancelCommand(object obj)
        {
            return true; 
        }
    }
}
