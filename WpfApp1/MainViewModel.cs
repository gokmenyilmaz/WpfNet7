using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public  class MainViewModel: ViewModelBase
    {

        IDialogService DialogService { get { return GetService<IDialogService>(); } }


        RegistrationViewModel registrationViewModel;

        IMessageBoxService MessageBoxService { get { return GetService<IMessageBoxService>(); } }
  

        public MainViewModel()
        {
            registrationViewModel = new RegistrationViewModel();
        }


        [Command]
        public void ShowRegistrationForm()
        {

            UICommand registerCommand = new UICommand(
               id: null,
               caption: "Register",
               command: new DelegateCommand<CancelEventArgs>(
                   cancelArgs => {
                       try
                       {
                          
                       }
                       catch (Exception e)
                       {
                           MessageBoxService.ShowMessage(e.Message, "Error", MessageButton.OK);
                           cancelArgs.Cancel = true;
                       }
                   },
                   cancelArgs => !string.IsNullOrEmpty(registrationViewModel.UserName)
               ),
               isDefault: true,
               isCancel: false
           );

            UICommand cancelCommand = new UICommand(
                id: MessageBoxResult.Cancel,
                caption: "Cancel",
                command: null,
                isDefault: false,
                isCancel: true
            );




            //UICommand result = DialogService.ShowDialog(
            //    dialogCommands: new List<UICommand>() { registerCommand, cancelCommand },
            //    title: "Registration Dialog",
            //    viewModel: registrationViewModel
            //);




            var result = DialogService.ShowDialog(
                dialogCommands: new List<UICommand>() { registerCommand, cancelCommand },
                title: "Child View",
                documentType: "RegistrationView",
                viewModel: registrationViewModel

            );

            var x = result;


            //MessageBoxService.ShowMessage("denemem");


        }

    }
}
