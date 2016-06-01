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

        
        private Planete _newplanete; // planete pour les test

        public AjoutPlanete(Planete _planete)
        {
            _newplanete = _planete;
            OnAddNew = new DelegateCommande(OnAddAction, CanExecuteAdd);
            OnCancel = new DelegateCommande(OnCancelCommand, CanCancelCommand);
        }

        public void CloseWindows()
        {
           // this.close();
        }

        private void OnAddAction(object obj)
        {

            EventClick.GetClick().OnButtonPressedHandler(EventArgs.Empty);
        }

        private void OnCancelCommand(object obj)
        {
            //this.Close();
        }

        private bool CanExecuteAdd(object obj)
        {
            if(_newplanete != null )
                return true;
            Info i = new Info("Vous devez remplir les champs pour creer une planète");
            i.ShowDialog();
            return false;
        }

        private bool CanCancelCommand(object obj)
        {
            return true; 
        }
    }
}
