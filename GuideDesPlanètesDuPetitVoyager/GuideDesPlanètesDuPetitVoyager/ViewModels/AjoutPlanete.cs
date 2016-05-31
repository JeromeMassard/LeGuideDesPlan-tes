using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideDesPlanètesDuPetitVoyager.ViewModels
{
    class AjoutPlanete
    {
        public DelegateCommande OnAddNew { get; set; }
        public DelegateCommande OnCancel { get; set; }

        
        private Planete _newplanete; // planete pour les test

        public AjoutPlanete(Planete _planete)
        {
            _newplanete = _planete;
            OnAddNew = new DelegateCommande(OnAddAction, CanExecuteAdd);
            OnCancel = new DelegateCommande(OnCancelCommand, CanCancelCommand);
        }

        private void OnAddAction(object obj)
        {
               _newplanete
        }

        private void OnCancelCommand(object obj)
        {
            //Close();
        }

        private bool CanExecuteAdd(object obj)
        {
            if ()
                return true;
            return false;
        }

        private bool CanCancelCommand(object obj)
        {
            return true; 
        }
    }
}
