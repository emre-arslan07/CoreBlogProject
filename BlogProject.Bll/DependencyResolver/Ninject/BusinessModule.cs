using BlogProject.Bll.Abstract;
using BlogProject.Bll.Concrete;
using BlogProject.Dal.Abstract;
using BlogProject.Dal.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Bll.DependencyResolver.Ninject
{
   public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EFCategoryDal>().InSingletonScope();

            Bind<IBlogService>().To<BlogManager>().InSingletonScope();
            Bind<IBlogDal>().To<EFBlogDal>().InSingletonScope();

            Bind<ICommentService>().To<CommentManager>().InSingletonScope();
            Bind<ICommentDal>().To<EFCommentDal>().InSingletonScope();

            Bind<IWriterService>().To<WriterManager>().InSingletonScope();
            Bind<IWriterDal>().To<EFWriterDal>().InSingletonScope();

            Bind<INewsLetterService>().To<NewsLetterManager>().InSingletonScope();
            Bind<INewsLetterDal>().To<EFNewsLetter>().InSingletonScope();

            Bind<IAboutService>().To<AboutManager>().InSingletonScope();
            Bind<IAboutDal>().To<EFAboutDal>().InSingletonScope();

            Bind<IContactService>().To<ContactManager>().InSingletonScope();
            Bind<IContactDal>().To<EFContactDal>().InSingletonScope();

            Bind<INotificationService>().To<NotificationManager>().InSingletonScope();
            Bind<INotificationDal>().To<EFNotificationDal>().InSingletonScope();

            Bind<IMessageService>().To<MessageManager>().InSingletonScope();
            Bind<IMessageDal>().To<EFMessageDal>().InSingletonScope();

            Bind<IMessage2Service>().To<Message2Manager>().InSingletonScope();
            Bind<IMessage2Dal>().To<EFMessage2Dal>().InSingletonScope();

            Bind<IAdminService>().To<AdminManager>().InSingletonScope();
            Bind<IAdminDal>().To<EFAdminDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EFAppUserDal>().InSingletonScope();
        }
    }
}
