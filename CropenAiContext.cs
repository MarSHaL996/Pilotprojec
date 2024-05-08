﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CR_CoreBot_DataAccess.CR_OpenAI;

public partial class CropenAiContext : DbContext
{
    public CropenAiContext()
    {
    }

    public CropenAiContext(DbContextOptions<CropenAiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BlobConnection> BlobConnections { get; set; }

    public virtual DbSet<BlobFileDatum> BlobFileData { get; set; }

    public virtual DbSet<ChatBotKeyConfiguration> ChatBotKeyConfigurations { get; set; }

    public virtual DbSet<CustomerConfiguration> CustomerConfigurations { get; set; }

    public virtual DbSet<CustomerInformation> CustomerInformations { get; set; }

    public virtual DbSet<CustomerModel> CustomerModels { get; set; }

    public virtual DbSet<CustomerOffer> CustomerOffers { get; set; }

    public virtual DbSet<EntityExtractrion> EntityExtractrions { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<PerformanceMatrixChecker> PerformanceMatrixCheckers { get; set; }

    public virtual DbSet<PersonalDetail> PersonalDetails { get; set; }

    public virtual DbSet<RoleMaster> RoleMasters { get; set; }

    public virtual DbSet<TblCustomerFileDetail> TblCustomerFileDetails { get; set; }

    public virtual DbSet<TblModelConfiguration> TblModelConfigurations { get; set; }

    public virtual DbSet<TblSummaryExtractrion> TblSummaryExtractrions { get; set; }

    public virtual DbSet<TblUserInformationMapping> TblUserInformationMappings { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<UserSessionTracker> UserSessionTrackers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ucoracle.eastus2.cloudapp.azure.com\\SQLEXPRESS,1434;Database=CropenAiDev_3;User id=test;password=Unifyclud@123#789;TrustServerCertificate=True");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BlobConnection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BlobConn__3214EC0796B96F50");

            entity.ToTable("BlobConnection");

            entity.Property(e => e.DateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<BlobFileDatum>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<ChatBotKeyConfiguration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChatBot___3214EC073B6BD0C4");

            entity.ToTable("ChatBot_KeyConfiguration");

            entity.Property(e => e.DateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<CustomerConfiguration>(entity =>
        {
            entity.HasKey(e => e.ConfigurationId).HasName("PK__Customer__95AA53BB416ADED6");

            entity.ToTable("CustomerConfiguration");

            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.FileFormat).HasMaxLength(500);
            entity.Property(e => e.LoginType).HasMaxLength(200);
            entity.Property(e => e.Username).HasMaxLength(200);
        });

        modelBuilder.Entity<CustomerInformation>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8A2707F0E");

            entity.ToTable("CustomerInformation");

            entity.Property(e => e.DateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LoginWith)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CustomerModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07BC7FF536");

            entity.ToTable("CustomerModel");

            entity.Property(e => e.ServiceName).HasMaxLength(100);
        });

        modelBuilder.Entity<CustomerOffer>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Customer Offer");

            entity.Property(e => e.CustId)
                .HasMaxLength(255)
                .HasColumnName("Cust_Id");
            entity.Property(e => e.OfferId).HasColumnName("Offer_Id");
            entity.Property(e => e.OffersName).HasMaxLength(255);
            entity.Property(e => e.RateOfIntrest).HasColumnName("Rate Of Intrest");
        });

        modelBuilder.Entity<EntityExtractrion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EntityEx__3214EC0787956471");

            entity.ToTable("EntityExtractrion");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Entity)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FileId).HasColumnName("FileID");
            entity.Property(e => e.FileName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Icdcode)
                .HasMaxLength(20)
                .HasColumnName("ICDCode");
            entity.Property(e => e.ImportantNotes)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDD69B4144A1");

            entity.ToTable("Feedback");

            entity.Property(e => e.EmailFeedback)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FeedbackDate).HasColumnType("datetime");
            entity.Property(e => e.Satisfactionwithbot)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PerformanceMatrixChecker>(entity =>
        {
            entity.HasKey(e => e.PeformanceId).HasName("PK__Performa__C642C42C3F06E184");

            entity.ToTable("PerformanceMatrixChecker");

            entity.Property(e => e.Cost).HasColumnType("decimal(18, 9)");
            entity.Property(e => e.CurrentDateTime).HasColumnType("datetime");
            entity.Property(e => e.IsValid).HasMaxLength(50);
            entity.Property(e => e.LoginType).HasMaxLength(200);
            entity.Property(e => e.ResponseTime).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Role).HasMaxLength(200);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        modelBuilder.Entity<PersonalDetail>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BankCode).HasColumnName("Bank Code");
            entity.Property(e => e.BranchCode).HasColumnName("Branch Code");
            entity.Property(e => e.BranchName)
                .HasMaxLength(255)
                .HasColumnName("Branch Name");
            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.CommunicationAddress)
                .HasMaxLength(255)
                .HasColumnName("Communication Address");
            entity.Property(e => e.Country).HasMaxLength(255);
            entity.Property(e => e.CustId)
                .HasMaxLength(255)
                .HasColumnName("Cust_Id");
            entity.Property(e => e.CustomerName).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Isfccode)
                .HasMaxLength(255)
                .HasColumnName("ISFCCode");
            entity.Property(e => e.Mobile).HasMaxLength(255);
            entity.Property(e => e.PermanentAddress)
                .HasMaxLength(255)
                .HasColumnName("Permanent Address");
            entity.Property(e => e.State).HasMaxLength(255);
        });

        modelBuilder.Entity<RoleMaster>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__RoleMast__8AFACE1A70C2BBC1");

            entity.ToTable("RoleMaster");

            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblCustomerFileDetail>(entity =>
        {
            entity.ToTable("Tbl_CustomerFileDetails");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FileName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FilePath).IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<TblModelConfiguration>(entity =>
        {
            entity.ToTable("tbl_ModelConfiguration");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ConfigurationText).IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Industry).IsUnicode(false);
        });

        modelBuilder.Entity<TblSummaryExtractrion>(entity =>
        {
            entity.ToTable("tbl_SummaryExtractrion");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FileId).HasColumnName("FileID");
            entity.Property(e => e.FileName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SummaryDescription).IsUnicode(false);
        });

        modelBuilder.Entity<TblUserInformationMapping>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__TBL_User__1788CC4C0EEA37BA");

            entity.ToTable("TBL_UserInformationMapping");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LoginType).HasMaxLength(200);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Transaction");

            entity.Property(e => e.ClosingBalance).HasColumnName("Closing Balance");
            entity.Property(e => e.CustId)
                .HasMaxLength(255)
                .HasColumnName("Cust_Id");
            entity.Property(e => e.Date).HasMaxLength(255);
            entity.Property(e => e.DepositAmt).HasColumnName(" Deposit Amt");
            entity.Property(e => e.TransectionId).HasColumnName("Transection_Id");
            entity.Property(e => e.TransectionType).HasMaxLength(255);
            entity.Property(e => e.WithdrawalAmt).HasColumnName("Withdrawal Amt");
        });

        modelBuilder.Entity<UserSessionTracker>(entity =>
        {
            entity.HasKey(e => e.SessionTrackerId).HasName("PK__UserSess__46414E0D2C21C38A");

            entity.ToTable("UserSessionTracker");

            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e.LoginTime).HasColumnType("datetime");
            entity.Property(e => e.LoginWith).HasMaxLength(200);
            entity.Property(e => e.RoleName).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
