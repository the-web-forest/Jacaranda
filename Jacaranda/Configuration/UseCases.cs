using System;
using Jacaranda.UseCase;
using Jacaranda.UseCase.AdministratorLogin;
using Jacaranda.UseCase.Certificate.GetCertificateByIdUseCase;
using Jacaranda.UseCase.CreatePartners;
using Jacaranda.UseCase.CreateTree;
using Jacaranda.UseCase.DeletePartner;
using Jacaranda.UseCase.DeleteTree;
using Jacaranda.UseCase.GetPartnerById;
using Jacaranda.UseCase.GetTreeById;
using Jacaranda.UseCase.ListPartners;
using Jacaranda.UseCase.ListTrees;
using Jacaranda.UseCase.ListUsers;
using Jacaranda.UseCase.UpdatePartner;
using Jacaranda.UseCase.UpdateTree;
using Jacaranda.UseCase.User.Detail;
using Jacaranda.UseCase.User;
using Jacaranda.UseCase.User.Register;
using Jacaranda.UseCase.Mail.ValidateEmail;
using Jacaranda.UseCase.Mail.SendVerificationEmail;
using Jacaranda.UseCase.Mail.CheckEmailUseCase;
using Jacaranda.UseCase.Mail.UserPasswordResetUseCase;
using Jacaranda.UseCase.User.PasswordChange;
using Jacaranda.UseCase.User.GetUserInfo;
using Jacaranda.UseCase.User.Login;
using Jacaranda.UseCase.Configuration.GetPublicConfigurationUseCase;
using Jacaranda.UseCase.States.GetStates;
using Jacaranda.UseCase.States.GetCitiesByState;

namespace Jacaranda.Configuration
{
    public static class UseCases
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUseCase<AdministratorLoginUseCaseInput, AdministratorLoginUseCaseOutput>, AdministratorLoginUseCase>();

            builder.Services.AddScoped<IUseCase<GetCertificateByIdUseCaseInput, GetCertificateByIdUseCaseOutput>, GetCertificateByIdUseCase>();

            #region User
            builder.Services.AddScoped<IUseCase<ListUsersUseCaseInput, ListUsersUseCaseOutput>, ListUsersUseCase>();
            builder.Services.AddScoped<IUseCase<UserDetailUseCaseInput, UserDetailUseCaseOutput>, UserDetailUseCase>();
            builder.Services.AddScoped<IUseCase<UserRegisterUseCaseInput, UserRegisterUseCaseOutput>, UserRegisterUseCase>();
            builder.Services.AddScoped<IUseCase<UserPasswordChangeUseCaseInput, UserPasswordChangeUseCaseOutput>, UserPasswordChangeUseCase>();
            builder.Services.AddScoped<IUseCase<GetUserInfoUseCaseInput, GetUserInfoUseCaseOutput>, GetUserInfoUseCase>();
            builder.Services.AddScoped<IUseCase<UserLoginUseCaseInput, UserLoginUseCaseOutput>, UserLoginUseCase>();
            #endregion

            #region Tree
            builder.Services.AddScoped<IUseCase<UpdateTreeUseCaseInput, UpdateTreeUseCaseOutput>, UpdateTreeUseCase>();
            builder.Services.AddScoped<IUseCase<CreateTreeUseCaseInput, CreateTreeUseCaseOutput>, CreateTreeUseCase>();
            builder.Services.AddScoped<IUseCase<ListTreesUseCaseInput, ListTreesUseCaseOutput>, ListTreesUseCase>();
            builder.Services.AddScoped<IUseCase<GetTreeByIdUseCaseInput, GetTreeByIdUseCaseOutput>, GetTreeByIdUseCase>();
            builder.Services.AddScoped<IUseCase<DeleteTreeUseCaseInput, DeleteTreeUseCaseOutput>, DeleteTreeUseCase>();
            #endregion

            #region Partner
            builder.Services.AddScoped<IUseCase<ListPartnersUseCaseInput, ListPartnersUseCaseOutput>, ListPartnersUseCase>();
            builder.Services.AddScoped<IUseCase<CreatePartnerUseCaseInput, CreatePartnerUseCaseOutput>, CreatePartnerUseCase>();
            builder.Services.AddScoped<IUseCase<DeletePartnerUseCaseInput, DeletePartnerUseCaseOutput>, DeletePartnerUseCase>();
            builder.Services.AddScoped<IUseCase<GetPartnerByIdUseCaseInput, GetPartnerByIdUseCaseOutput>, GetPartnerByIdUseCase>();
            builder.Services.AddScoped<IUseCase<UpdatePartnerUseCaseInput, UpdatePartnerUseCaseOutput>, UpdatePartnerUseCase>();
            #endregion

            #region Email
            builder.Services.AddScoped<IUseCase<ValidateEmailUseCaseInput, ValidateEmailUseCaseOutput>, ValidateEmailUseCase>();
            builder.Services.AddScoped<IUseCase<SendVerificationEmailUseCaseInput, SendVerificationEmailUseCaseOutput>, SendVerificationEmailUseCase>();
            builder.Services.AddScoped<IUseCase<CheckEmailUseCaseInput, CheckEmailUseCaseOutput>, CheckEmailUseCase>();
            builder.Services.AddScoped<IUseCase<UserPasswordResetUseCaseInput, UserPasswordResetUseCaseOutput>, UserPasswordResetUseCase>();
            #endregion

            #region Configuration
            builder.Services.AddScoped<IUseCase<GetPublicConfigurationUseCaseInput, GetPublicConfigurationUseCaseOutput>, GetPublicConfigurationUseCase>();
            #endregion

            #region State
            builder.Services.AddScoped<IUseCase<GetStatesUseCaseInput, GetStatesUseCaseOutput>, GetStatesUseCase>();
            builder.Services.AddScoped<IUseCase<GetCitiesByStateUseCaseInput, GetCitiesByStateUseCaseOutput>, GetCitiesByStateUseCase>();
            #endregion
        }
    }
}

