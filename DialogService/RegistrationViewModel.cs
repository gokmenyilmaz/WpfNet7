using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class RegistrationViewModel : ViewModelBase
    {
        IMessageBoxService MessageBoxService { get { return GetService<IMessageBoxService>(); } }
        public RegistrationViewModel()
        {

        }


        [Command]
        public void Sec()
        {

        }
        public string UserName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}
