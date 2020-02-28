using EPiServer;
using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using System.Configuration;
using System.Linq;
using System.Web.Security;

namespace AlloyTraining.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class RegisterAdminInitializationModule : IInitializableModule
    {
        private const string roleName = "WebAdmins";
        private const string userName = "Admin";
        private const string password = "Pa$$w0rd";
        private const string email = "admin@alloy.com";

        public void Initialize(InitializationEngine context)
        {
            string enabledString = ConfigurationManager.AppSettings["alloy:RegisterAdmin"];
            bool enabled;
            if (bool.TryParse(enabledString, out enabled))
            {
                if (enabled)
                {
                    #region Use ASP.NET Membership classes to create the role and user

                    // if the role does not exist, create it
                    if (!Roles.RoleExists(roleName))
                    {
                        Roles.CreateRole(roleName);
                    }

                    // if the user already exists, delete it
                    MembershipUser user = Membership.GetUser(userName);
                    if (user != null)
                    {
                        Membership.DeleteUser(userName);
                    }

                    // create the user with password and add it to role
                    Membership.CreateUser(userName, password, email);
                    Roles.AddUserToRole(userName, roleName);

                    #endregion

                    #region Use EPiServer classes to give full access to root of content tree

                    // get the root page
                    var loader = ServiceLocator.Current.GetInstance<IContentLoader>();
                    var root = loader.Get<PageData>(ContentReference.RootPage)
                        .CreateWritableClone() as PageData;

                    // try to get the access control entry for the role
                    var ace = root.ACL.Entries.Where(
                        e => e.Name == roleName).FirstOrDefault();

                    // if the entry exists, and it already has full access,
                    // then return, else remove it so it can be recreated
                    if ((ace != null) && (ace.Access == AccessLevel.FullAccess))
                    {
                        return;
                    }
                    if (ace != null)
                    {
                        root.ACL.RemoveEntry(ace);
                    }

                    // create, add, and save a new access control entry
                    ace = new AccessControlEntry(roleName, AccessLevel.FullAccess);
                    root.ACL.Add(ace);
                    root.ACL.Save();

                    #endregion
                }
            }
        }

        public void Uninitialize(InitializationEngine context) { }
    }
}
