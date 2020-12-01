using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace BlogCore.Aspects.Postsharp.AuthorizationAspects
{
    [Serializable]
    public class SecuredOperation : OnMethodBoundaryAspect
    {


        public string Yetki { get; set; }
        public override void OnEntry(MethodExecutionArgs args)
        {
            string[] roller = Yetki.Split(',');
            bool isAuthorized = false;

            for (int i = 0; i < roller.Length; i++)
            {
                if (System.Threading.Thread.CurrentPrincipal.IsInRole(roller[i]))
                {
                    isAuthorized = true;
                }
            }
            if (isAuthorized == false)
            {
                throw new SecurityException("Siz bu alana girmek için yetkili değilsiniz! lütfen 'SuperAdmin' ile İrtibata geçiniz..");
            }
        }

    }
}
